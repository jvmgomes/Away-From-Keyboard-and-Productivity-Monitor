using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace time_tracker
{ 
    internal class AppInfo
    {
        public string ProcessName { get; set; }
        public string WindowTitle { get; set; }
        public DateTime PrimeiroFoco { get; set; }
        public DateTime UltimoFoco { get; set; }
        public TimeSpan TempoTotalEmFoco { get; set; }

        public AppInfo(string processName, string windowTitle)
        {
            ProcessName = processName;
            WindowTitle = windowTitle;
            PrimeiroFoco = DateTime.Now;
            UltimoFoco = DateTime.Now;
            TempoTotalEmFoco = TimeSpan.Zero;
        }

        public void AtualizarFoco(DateTime agora)
        {
            UltimoFoco = agora;
        }

        public void AdicionarTempoEmFoco(TimeSpan tempo)
        {
            TempoTotalEmFoco += tempo;
        }

        public override string ToString()
        {
            return $"{ProcessName} - {WindowTitle} (Desde: {PrimeiroFoco:HH:mm:ss}, Total: {TempoTotalEmFoco.TotalMinutes:F1}min)";
        }
    }

    internal class AppMonitor
    {
        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        private Dictionary<string, AppInfo> _aplicacoes = new Dictionary<string, AppInfo>();
        private string _appAtualChave = "";
        private DateTime _ultimaChecagem = DateTime.Now;

        public AppInfo AppAtual { get; private set; }
        public Dictionary<string, AppInfo> TodasAplicacoes => _aplicacoes;

        public void Atualizar()
        {
            DateTime agora = DateTime.Now;
            TimeSpan tempoDesdeUltimaChecagem = agora - _ultimaChecagem;

            IntPtr hWnd = GetForegroundWindow();
            if (hWnd == IntPtr.Zero)
            {
                _ultimaChecagem = agora;
                return;
            }

            const int nChars = 256;
            StringBuilder buff = new StringBuilder(nChars);
            string windowTitle = GetWindowText(hWnd, buff, nChars) > 0 ? buff.ToString() : "Sem Título";

            uint processId;
            GetWindowThreadProcessId(hWnd, out processId);
            string processName = "Desconhecido";

            try
            {
                Process proc = Process.GetProcessById((int)processId);
                processName = proc.ProcessName;
            }
            catch
            {
                
            }

            string chave = $"{processName}|{windowTitle}";

            if (!string.IsNullOrEmpty(_appAtualChave) && _appAtualChave != chave)
            {
                if (_aplicacoes.ContainsKey(_appAtualChave))
                {
                    _aplicacoes[_appAtualChave].AdicionarTempoEmFoco(tempoDesdeUltimaChecagem);
                }
            }

            if (!_aplicacoes.ContainsKey(chave))
            {
                _aplicacoes[chave] = new AppInfo(processName, windowTitle);
            }

            _aplicacoes[chave].AtualizarFoco(agora);
            
            if (_appAtualChave == chave)
            {
                _aplicacoes[chave].AdicionarTempoEmFoco(tempoDesdeUltimaChecagem);
            }

            AppAtual = _aplicacoes[chave];
            _appAtualChave = chave;
            _ultimaChecagem = agora;
        }

        public string ObterRelatorio()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("=== RELATÓRIO DE APLICAÇÕES ===");
            sb.AppendLine($"Gerado em: {DateTime.Now:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine();

            if (_aplicacoes.Count == 0)
            {
                sb.AppendLine("Nenhuma aplicação rastreada ainda.");
                return sb.ToString();
            }

            var appsOrdenadas = _aplicacoes.Values
                .OrderByDescending(app => app.TempoTotalEmFoco.TotalSeconds)
                .ToList();

            sb.AppendLine($"Total de aplicações diferentes: {appsOrdenadas.Count}");
            sb.AppendLine();

            foreach (var app in appsOrdenadas)
            {
                sb.AppendLine($"Processo: {app.ProcessName}");
                sb.AppendLine($"  Janela: {app.WindowTitle}");
                sb.AppendLine($"  Primeiro foco: {app.PrimeiroFoco:dd/MM/yyyy HH:mm:ss}");
                sb.AppendLine($"  Último foco: {app.UltimoFoco:HH:mm:ss}");
                sb.AppendLine($"  Tempo total em foco: {app.TempoTotalEmFoco.Hours:D2}:{app.TempoTotalEmFoco.Minutes:D2}:{app.TempoTotalEmFoco.Seconds:D2}");
                sb.AppendLine();
            }

            return sb.ToString();
        }

        public void LimparHistorico()
        {
            _aplicacoes.Clear();
            _appAtualChave = "";
            AppAtual = null;
        }
    }
}
