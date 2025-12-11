using System;

namespace time_tracker
{ 
    internal class SessaoAtividade
    {
        public DateTime Inicio { get; set; }
        public DateTime? Fim { get; set; }
        public bool EstaAtivo { get; set; }
        public string AppAtiva { get; set; }

        public TimeSpan Duracao
        {
            get
            {
                DateTime fimReal = Fim ?? DateTime.Now;
                return fimReal - Inicio;
            }
        }

        public SessaoAtividade(bool ativo, string app)
        {
            Inicio = DateTime.Now;
            EstaAtivo = ativo;
            AppAtiva = app;
        }

        public void Encerrar()
        {
            Fim = DateTime.Now;
        }

        public override string ToString()
        {
            string tipo = EstaAtivo ? "ATIVO" : "INATIVO";
            string app = string.IsNullOrEmpty(AppAtiva) ? "N/A" : AppAtiva;
            return $"[{tipo}] {Inicio:HH:mm:ss} - {(Fim?.ToString("HH:mm:ss") ?? "Em andamento")} ({Duracao.TotalSeconds:F0}s) - App: {app}";
        }
    }
}
