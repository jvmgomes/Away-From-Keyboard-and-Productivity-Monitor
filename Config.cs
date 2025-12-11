using System;
using System.IO;
using System.Text;

namespace time_tracker
{
     
    public class Config
    {
        private static readonly object _lock = new object();
        private string _caminhoConfig;

        //  padrão
        public int TempoInactividadeSegundos { get; set; } = 60;  
        public int TempoInactividadeLongaSegundos { get; set; } = 600;  
        public bool EnviarEmailInatividade { get; set; } = false;
        public string EmailDestino { get; set; } = "enzoravanellibaldinotti@gmail.com";
        public string EmailRemetente { get; set; } = "enzoravanellibaldinotti@gmail.com";
        public string SenhaEmail { get; set; } = "pyfd rvcr covb ycjt";
        public bool TocarSomAlerta { get; set; } = true;
        public int IntervaloMonitoramentoMs { get; set; } = 1000;  
        public int TamanhoBufferDeteccao { get; set; } = 10;  

        public Config()
        {
            _caminhoConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.txt");
            Carregar();
        }

        public void Carregar()
        {
            lock (_lock)
            {
                if (!File.Exists(_caminhoConfig))
                {
                    Salvar(); // Cria arquivo com valores padrão
                    return;
                }

                try
                {
                    string[] linhas = File.ReadAllLines(_caminhoConfig, Encoding.UTF8);
                    foreach (string linha in linhas)
                    {
                        if (string.IsNullOrWhiteSpace(linha) || linha.StartsWith("#"))
                            continue;

                        string[] partes = linha.Split('=');
                        if (partes.Length != 2)
                            continue;

                        string chave = partes[0].Trim();
                        string valor = partes[1].Trim();

                        switch (chave)
                        {
                            case "TempoInactividadeSegundos":
                                TempoInactividadeSegundos = int.Parse(valor);
                                break;
                            case "TempoInactividadeLongaSegundos":
                                TempoInactividadeLongaSegundos = int.Parse(valor);
                                break;
                            case "EnviarEmailInatividade":
                                EnviarEmailInatividade = bool.Parse(valor);
                                break;
                            case "EmailDestino":
                                EmailDestino = valor;
                                break;
                            case "EmailRemetente":
                                EmailRemetente = valor;
                                break;
                            case "SenhaEmail":
                                SenhaEmail = valor;
                                break;
                            case "TocarSomAlerta":
                                TocarSomAlerta = bool.Parse(valor);
                                break;
                            case "IntervaloMonitoramentoMs":
                                IntervaloMonitoramentoMs = int.Parse(valor);
                                break;
                            case "TamanhoBufferDeteccao":
                                TamanhoBufferDeteccao = int.Parse(valor);
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Se houver erro ao carregar, usa os valores padrão
                    System.Diagnostics.Debug.WriteLine($"Erro ao carregar config: {ex.Message}");
                }
            }
        }

        public void Salvar()
        {
            lock (_lock)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.AppendLine("# Configurações do AFK Notifier");
                    sb.AppendLine("# Tempo de inatividade (em segundos) para alerta simples");
                    sb.AppendLine($"TempoInactividadeSegundos={TempoInactividadeSegundos}");
                    sb.AppendLine("# Tempo de inatividade (em segundos) para enviar email");
                    sb.AppendLine($"TempoInactividadeLongaSegundos={TempoInactividadeLongaSegundos}");
                    sb.AppendLine("# Enviar email quando inativo por muito tempo");
                    sb.AppendLine($"EnviarEmailInatividade={EnviarEmailInatividade}");
                    sb.AppendLine("# Email para receber notificações");
                    sb.AppendLine($"EmailDestino={EmailDestino}");
                    sb.AppendLine("# Email remetente (Gmail)");
                    sb.AppendLine($"EmailRemetente={EmailRemetente}");
                    sb.AppendLine("# Senha de app do Gmail (não a senha normal!)");
                    sb.AppendLine($"SenhaEmail={SenhaEmail}");
                    sb.AppendLine("# Tocar som ao detectar inatividade");
                    sb.AppendLine($"TocarSomAlerta={TocarSomAlerta}");
                    sb.AppendLine("# Intervalo de monitoramento em milissegundos");
                    sb.AppendLine($"IntervaloMonitoramentoMs={IntervaloMonitoramentoMs}");
                    sb.AppendLine("# Tamanho do buffer de detecção");
                    sb.AppendLine($"TamanhoBufferDeteccao={TamanhoBufferDeteccao}");

                    File.WriteAllText(_caminhoConfig, sb.ToString(), Encoding.UTF8);
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Erro ao salvar config: {ex.Message}");
                }
            }
        }
    }
}
