using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace time_tracker
{
    internal class Logs
    {
        private string _diretorioLogs;

        // Objeto usado para garantir que apenas uma thread escreva por vez
        private static readonly object _lock = new object();

        public Logs() {

            _diretorioLogs = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs");

            // Se a pasta não existir, cria agora
            if (!Directory.Exists(_diretorioLogs))
            {
                Directory.CreateDirectory(_diretorioLogs);
            }
        }

        public void Registrar(string mensagem)
        {
            // Define o nome do arquivo com a data de hoje 
            string nomeArquivo = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";
            string caminhoCompleto = Path.Combine(_diretorioLogs, nomeArquivo);
 
            string linhaLog = $"[{DateTime.Now:HH:mm:ss}] {mensagem}{Environment.NewLine}";

            // O 'lock' garante que se a Thread e o Botão tentarem salvar ao mesmo tempo,
            // um espera o outro terminar, evitando erro de "Arquivo em uso".
            lock (_lock)
            {
                File.AppendAllText(caminhoCompleto, linhaLog, Encoding.UTF8);
            }
        }

        public string ObterCaminhoLogAtual()
        {
            string nomeArquivo = $"Log_{DateTime.Now:yyyy-MM-dd}.txt";
            return Path.Combine(_diretorioLogs, nomeArquivo);
        }

        public string LerLogAtual()
        {
            string caminho = ObterCaminhoLogAtual();
            lock (_lock)
            {
                if (File.Exists(caminho))
                {
                    return File.ReadAllText(caminho, Encoding.UTF8);
                }
                return "Nenhum log gravado hoje.";
            }
        }

    }
}
