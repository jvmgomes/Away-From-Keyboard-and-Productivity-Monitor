using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using System.Media;

namespace time_tracker
{
    public partial class Form1 : Form
    {
        // Importa a função para obter o "handle" (ponteiro) da janela que está ativa/focada
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();
        // Importa a função para ler o texto da barra de título dessa janela
        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        // Importa a função para descobrir qual PROCESSO é dono daquela janela
        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);
        // Importa a funcao para detectar teclas pressionadas
        [DllImport("user32.dll")]
        private static extern short GetAsyncKeyState(int vKey);
        // Importa funcao para pegar a posicao do mouse x e y
        [DllImport("user32.dll")]
        private static extern bool GetCursorPos(out Point lpPoint);

        // Variáveis privadas
        private Point ultimaPosicaoMouse;
        private Config configuracoes;
        private Logs gerenciadorLogs;
        private Mail gerenciadorEmail;
        private AppMonitor monitorApps;
        
        private Thread threadMonitoramento;
        private bool monitoramentoAtivo = false;
        private int segundosInativo = 0;
        private bool alertaEnviado = false;
        private bool emailEnviado = false;
        private SessaoAtividade sessaoAtual;
        private List<SessaoAtividade> historicoSessoes = new List<SessaoAtividade>();

        public Form1()
        {
            InitializeComponent();
            
            // Inicializa os gerenciadores
            configuracoes = new Config();
            gerenciadorLogs = new Logs();
            monitorApps = new AppMonitor();
            
            // Só inicializa o email se estiver configurado
            if (!string.IsNullOrEmpty(configuracoes.EmailRemetente) && 
                !string.IsNullOrEmpty(configuracoes.SenhaEmail))
            {
                gerenciadorEmail = new Mail(configuracoes.EmailRemetente, configuracoes.SenhaEmail);
            }
        }

        private string GetActiveWindowTitle()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();
            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        public bool isUsingKeyboard()
        {
            // 0x08 até 0xFE são os códigos das teclas
            for (int i = 8; i <= 254; i++)
            {
                short estado = GetAsyncKeyState(i);

                if (estado < 0)
                {
                    return true; // Tecla pressionada
                }
            }
            return false;
        }

        private bool isUsingMouse()
        {
            Point posicaoAtualMouse;
            GetCursorPos(out posicaoAtualMouse);

            if(posicaoAtualMouse != ultimaPosicaoMouse)
            {
                ultimaPosicaoMouse = posicaoAtualMouse;
                return true;
            }

            if (GetAsyncKeyState(0x01) < 0) return true; // Click esquerdo
            if (GetAsyncKeyState(0x02) < 0) return true; // Click direito
            if (GetAsyncKeyState(0x04) < 0) return true; // Click do meio

            return false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetCursorPos(out ultimaPosicaoMouse);
            AtualizarInterface();
            AdicionarLogInterface("Sistema iniciado. Pressione 'Iniciar Monitoramento' para começar.");
        }

        private void btnIniciarParar_Click(object sender, EventArgs e)
        {
            if (!monitoramentoAtivo)
            {
                IniciarMonitoramento();
            }
            else
            {
                PararMonitoramento();
            }
        }

        private void IniciarMonitoramento()
        {
            monitoramentoAtivo = true;
            btnIniciarParar.Text = "Parar Monitoramento";
            btnIniciarParar.BackColor = Color.LightCoral;
            
            gerenciadorLogs.Registrar("=== MONITORAMENTO INICIADO ===");
            AdicionarLogInterface("Monitoramento iniciado!");

            threadMonitoramento = new Thread(MonitoramentoLoop);
            threadMonitoramento.IsBackground = true;
            threadMonitoramento.Start();
        }

        private void PararMonitoramento()
        {
            monitoramentoAtivo = false;
            btnIniciarParar.Text = "Iniciar Monitoramento";
            btnIniciarParar.BackColor = SystemColors.Control;
            
            gerenciadorLogs.Registrar("=== MONITORAMENTO PARADO ===");
            AdicionarLogInterface("Monitoramento parado.");
            
            if (sessaoAtual != null)
            {
                sessaoAtual.Encerrar();
                historicoSessoes.Add(sessaoAtual);
                gerenciadorLogs.Registrar($"Sessão encerrada: {sessaoAtual}");
            }
        }

        private void MonitoramentoLoop()
        {
            int[] capturasDeMovimento = new int[configuracoes.TamanhoBufferDeteccao];
            for (int i = 0; i < capturasDeMovimento.Length; i++)
                capturasDeMovimento[i] = 1; // Inicia como ativo
            
            int idx = 0;
            bool estavoInativo = false;

            while (monitoramentoAtivo)
            {
                Thread.Sleep(configuracoes.IntervaloMonitoramentoMs);

                // Atualiza o monitoramento de aplicações
                monitorApps.Atualizar();

                // Detecta atividade
                bool temAtividade = isUsingKeyboard() || isUsingMouse();
                capturasDeMovimento[idx] = temAtividade ? 1 : 0;

                // Verifica se está inativo (todas as capturas são 0)
                bool estaInativo = capturasDeMovimento.Sum() == 0;
                
                if (estaInativo)
                {
                    segundosInativo++;
                    
                    // Se acabou de ficar inativo
                    if (!estavoInativo)
                    {
                        if (sessaoAtual != null)
                        {
                            sessaoAtual.Encerrar();
                            historicoSessoes.Add(sessaoAtual);
                            gerenciadorLogs.Registrar($"Sessão ATIVA encerrada: {sessaoAtual}");
                        }
                        
                        string appAtual = monitorApps.AppAtual?.ProcessName ?? "Desconhecido";
                        sessaoAtual = new SessaoAtividade(false, appAtual);
                        
                        AtualizarInterfaceAsync("INATIVO", Color.Orange);
                        gerenciadorLogs.Registrar($"Usuário ficou INATIVO na janela: {GetActiveWindowTitle()}");
                        AdicionarLogInterfaceAsync($" Inatividade detectada!");
                    }

                    // Alerta de inatividade curta
                    if (segundosInativo >= configuracoes.TempoInactividadeSegundos && !alertaEnviado)
                    {
                        alertaEnviado = true;
                        string msg = $"Usuário inativo há {segundosInativo} segundos na janela: {GetActiveWindowTitle()}";
                        gerenciadorLogs.Registrar(msg);
                        AdicionarLogInterfaceAsync($" ALERTA: Inativo há {segundosInativo}s!");
                        
                        if (configuracoes.TocarSomAlerta)
                        {
                            SystemSounds.Exclamation.Play();
                        }
                    }

                    // Alerta de inatividade longa (email)
                    if (segundosInativo >= configuracoes.TempoInactividadeLongaSegundos && 
                        !emailEnviado && 
                        configuracoes.EnviarEmailInatividade)
                    {
                        emailEnviado = true;
                        EnviarEmailInatividade();
                    }
                }
                else // Está ativo
                {
                    if (estavoInativo)
                    {
                        // Acabou de voltar a ficar ativo
                        if (sessaoAtual != null)
                        {
                            sessaoAtual.Encerrar();
                            historicoSessoes.Add(sessaoAtual);
                            gerenciadorLogs.Registrar($"Sessão INATIVA encerrada após {segundosInativo}s: {sessaoAtual}");
                        }
                        
                        string appAtual = monitorApps.AppAtual?.ProcessName ?? "Desconhecido";
                        sessaoAtual = new SessaoAtividade(true, appAtual);
                        
                        AtualizarInterfaceAsync("ATIVO", Color.LightGreen);
                        gerenciadorLogs.Registrar($"Usuário voltou a ficar ATIVO. Estava inativo por {segundosInativo}s");
                        AdicionarLogInterfaceAsync($"✓ Usuário ativo novamente (esteve inativo {segundosInativo}s)");
                        
                        // Reseta contadores
                        segundosInativo = 0;
                        alertaEnviado = false;
                        emailEnviado = false;
                    }
                }

                estavoInativo = estaInativo;

                // Atualiza interface
                AtualizarInterfaceAsync();

                // Move o índice circular
                idx = (idx + 1) % capturasDeMovimento.Length;
            }
        }

        private void EnviarEmailInatividade()
        {
            if (gerenciadorEmail == null || string.IsNullOrEmpty(configuracoes.EmailDestino))
            {
                AdicionarLogInterfaceAsync("Email não configurado. Configure em Configurações.");
                return;
            }

            Task.Run(async () =>
            {
                try
                {
                    string assunto = $"[AFK Notifier] Inatividade Prolongada Detectada - {DateTime.Now:dd/MM/yyyy HH:mm}";
                    
                    StringBuilder corpo = new StringBuilder();
                    corpo.AppendLine($"Olá,")
                         .AppendLine()
                         .AppendLine($"Foi detectada inatividade prolongada no seu computador.")
                         .AppendLine()
                         .AppendLine($"Detalhes:")
                         .AppendLine($"- Horário: {DateTime.Now:dd/MM/yyyy HH:mm:ss}")
                         .AppendLine($"- Tempo inativo: {segundosInativo} segundos ({segundosInativo / 60} minutos)")
                         .AppendLine($"- Janela ativa: {GetActiveWindowTitle()}")
                         .AppendLine($"- Aplicação: {monitorApps.AppAtual?.ProcessName ?? "Desconhecido"}")
                         .AppendLine()
                         .AppendLine("Histórico de sessões:")
                         .AppendLine("====================");
                    
                    var sessoesRecentes = historicoSessoes.Skip(Math.Max(0, historicoSessoes.Count - 10)).ToList();
                    foreach (var sessao in sessoesRecentes)
                    {
                        corpo.AppendLine(sessao.ToString());
                    }
                    
                    corpo.AppendLine()
                         .AppendLine("Este é um email automático do AFK Notifier.");
                    
                    string caminhoLog = gerenciadorLogs.ObterCaminhoLogAtual();
                    
                    await gerenciadorEmail.EnviarRelatorioAsync(
                        configuracoes.EmailDestino,
                        assunto,
                        corpo.ToString(),
                        caminhoLog
                    );
                    
                    gerenciadorLogs.Registrar($"Email de inatividade enviado para {configuracoes.EmailDestino}");
                    AdicionarLogInterfaceAsync($"📧 Email de alerta enviado!");
                }
                catch (Exception ex)
                {
                    gerenciadorLogs.Registrar($"Erro ao enviar email: {ex.Message}");
                    AdicionarLogInterfaceAsync($" Erro ao enviar email: {ex.Message}");
                }
            });
        }

        private void btnEnviarRelatorio_Click(object sender, EventArgs e)
        {
            if (gerenciadorEmail == null || string.IsNullOrEmpty(configuracoes.EmailDestino))
            {
                MessageBox.Show("Configure o email nas Configurações primeiro!", "Aviso", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Task.Run(async () =>
            {
                try
                {
                    string assunto = $"[AFK Notifier] Relatório de Atividades - {DateTime.Now:dd/MM/yyyy}";
                    
                    StringBuilder corpo = new StringBuilder();
                    corpo.AppendLine("Segue em anexo o relatório detalhado de atividades.")
                         .AppendLine()
                         .AppendLine("Resumo de Aplicações:")
                         .AppendLine(monitorApps.ObterRelatorio())
                         .AppendLine()
                         .AppendLine("Histórico de Sessões:")
                         .AppendLine("====================");
                    
                    foreach (var sessao in historicoSessoes)
                    {
                        corpo.AppendLine(sessao.ToString());
                    }
                    
                    string caminhoLog = gerenciadorLogs.ObterCaminhoLogAtual();
                    
                    await gerenciadorEmail.EnviarRelatorioAsync(
                        configuracoes.EmailDestino,
                        assunto,
                        corpo.ToString(),
                        caminhoLog
                    );
                    
                    AdicionarLogInterfaceAsync("📧 Relatório enviado com sucesso!");
                }
                catch (Exception ex)
                {
                    AdicionarLogInterfaceAsync($"❌ Erro ao enviar relatório: {ex.Message}");
                }
            });
        }

        private void btnConfiguracoes_Click(object sender, EventArgs e)
        {
            FormConfiguracoes formConfig = new FormConfiguracoes(configuracoes);
            if (formConfig.ShowDialog() == DialogResult.OK)
            {
                configuracoes = formConfig.ConfigAtualizada;
                
                 
                if (!string.IsNullOrEmpty(configuracoes.EmailRemetente) && 
                    !string.IsNullOrEmpty(configuracoes.SenhaEmail))
                {
                    gerenciadorEmail = new Mail(configuracoes.EmailRemetente, configuracoes.SenhaEmail);
                }
                
                gerenciadorLogs.Registrar("Configurações atualizadas");
                AdicionarLogInterface("⚙ Configurações atualizadas");
            }
        }

        private void btnLimparLog_Click(object sender, EventArgs e)
        {
            txtLog.Clear();
        }
         
        private void AtualizarInterfaceAsync(string status = null, Color? cor = null)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AtualizarInterface(status, cor)));
            }
            else
            {
                AtualizarInterface(status, cor);
            }
        }

        private void AtualizarInterface(string status = null, Color? cor = null)
        {
            if (status != null)
            {
                lblStatus.Text = $"Status: {status}";
                if (cor.HasValue)
                    lblStatus.BackColor = cor.Value;
            }

            if (monitorApps.AppAtual != null)
            {
                lblAppAtual.Text = $"App Atual: {monitorApps.AppAtual.ProcessName}";
            }

            lblTempoInativo.Text = $"Tempo Inativo: {segundosInativo}s";
        }

        private void AdicionarLogInterfaceAsync(string mensagem)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => AdicionarLogInterface(mensagem)));
            }
            else
            {
                AdicionarLogInterface(mensagem);
            }
        }

        private void AdicionarLogInterface(string mensagem)
        {
            string linha = $"[{DateTime.Now:HH:mm:ss}] {mensagem}{Environment.NewLine}";
            txtLog.AppendText(linha);
            
            // Auto-scroll para o final
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }
    }
}
