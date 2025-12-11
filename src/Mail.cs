using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace time_tracker
{
    internal class Mail
    {

        private string _emailRemetente;
        private string _senhaApp;
        private string _smtpHost;
        private int _smtpPort;
        private bool _usarSSL;

        public Mail(string email, string senha, string provedor = "gmail")
        {
            _emailRemetente = email;
            _senhaApp = senha;
            
             
            ConfigurarProvedor(provedor.ToLower());
        }

        private void ConfigurarProvedor(string provedor)
        {
            switch (provedor)
            {
                case "gmail":
                    _smtpHost = "smtp.gmail.com";
                    _smtpPort = 587;
                    _usarSSL = true;
                    break;
                    
                case "outlook":
                case "hotmail":
                    _smtpHost = "smtp-mail.outlook.com";
                    _smtpPort = 587;
                    _usarSSL = true;
                    break;
                    
                case "yahoo":
                    _smtpHost = "smtp.mail.yahoo.com";
                    _smtpPort = 587;
                    _usarSSL = true;
                    break;
                    
                case "office365":
                    _smtpHost = "smtp.office365.com";
                    _smtpPort = 587;
                    _usarSSL = true;
                    break;
                    
                default:
                     
                    _smtpHost = "smtp.gmail.com";
                    _smtpPort = 587;
                    _usarSSL = true;
                    break;
            }
        }

        public async Task EnviarRelatorioAsync(string emailDestino, string assunto, string corpoMensagem, string caminhoAnexo = null)
        {
            try
            {
                using (SmtpClient smtp = new SmtpClient(_smtpHost, _smtpPort))
                {
                     
                    smtp.EnableSsl = _usarSSL;
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(_emailRemetente, _senhaApp);

                     
                    using (MailMessage mensagem = new MailMessage())
                    {
                        mensagem.From = new MailAddress(_emailRemetente);
                        mensagem.To.Add(emailDestino);
                        mensagem.Subject = assunto;
                        mensagem.Body = corpoMensagem;
                        mensagem.IsBodyHtml = false; 

                        // Adiciona anexo 
                        if (!string.IsNullOrEmpty(caminhoAnexo) && System.IO.File.Exists(caminhoAnexo))
                        {
                            Attachment anexo = new Attachment(caminhoAnexo);
                            mensagem.Attachments.Add(anexo);
                        }
 
                        await smtp.SendMailAsync(mensagem);
                    }
                }

                MessageBox.Show("Relatório enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao enviar e-mail: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
