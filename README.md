🖥️ Away From Keyboard and Productivity Monitor

Um monitor de produtividade em Windows Forms (C#) que detecta inatividade do usuário em uma janela — seja por falta de interação com o teclado ou mouse — e envia um alerta por e-mail caso o tempo limite seja atingido.

Este projeto é útil para:

Monitoramento de produtividade

Controle de pausas em ambientes corporativos

Sistemas de segurança que exigem atividade contínua

Aplicações que precisam detectar ausência do operador

🚀 Funcionalidades
✔️ Detecção de Inatividade

O sistema monitora:

Movimentação do mouse

Cliques

Pressionamento de teclas

Atividade dentro da janela monitorada

Se nenhum desses eventos ocorrer dentro de um intervalo configurado, o usuário é considerado AFK (Away From Keyboard).

✔️ Envio Automático de Alerta por E-mail

Quando a inatividade ultrapassa o limite definido, o sistema envia automaticamente uma notificação usando SMTP.

O e-mail contém:

Tempo detectado de inatividade

Data e hora

Informações da sessão

✔️ Configurações Ajustáveis

O usuário pode definir:

Tempo máximo permitido sem atividade

Endereço(s) de e-mail para alerta

Configurações de servidor SMTP

Comportamentos adicionais quando AFK

✔️ Interface Simples e Direta

Desenvolvido em Windows Forms, o sistema oferece:

Formulário de configuração

Logs de atividade

Visualização clara de status

🛠️ Tecnologias Utilizadas

C#

.NET Framework / Windows Forms

Funções DLL

Monitoramento de eventos do sistema (mouse e teclado)

Envio de e-mails via System.Net.Mail

📂 Estrutura do Projeto

src/
├── AppMonitor.cs            # Lógica principal de detecção
├── Logs.cs                  # Registro de atividades
├── Mail.cs                  # Envio de alertas por e-mail
├── Program.cs               # Ponto de entrada
├── SessaoAtividade.cs       # Controle da sessão e temporizador
├── Form1.cs / Designer      # Interface principal
├── FormConfiguracoes.cs     # Interface de configuração
├── *.resx                   # Recursos visuais

🔧 Como Executar

Clone o repositório:

git clone https://github.com/seu-usuario/Away-From-Keyboard-and-Productivity-Monitor.git


Abra o projeto no Visual Studio.

Configure os parâmetros (tempo e e-mail) no formulário.

Execute.

📧 Configuração de E-mail (SMTP)

No formulário de configurações, preencha:

Servidor SMTP

Porta

E-mail remetente

Senha / App Password

E-mail(s) destino

Suporta servidores como:

Gmail

Outlook

Hotmail

Provedores corporativos

🧪 Funcionamento Interno

O aplicativo registra eventos de input do usuário.

Um cronômetro reinicia sempre que ocorre uma interação.

Caso o tempo exceda o limite configurado:

Uma entrada é registrada no log

Um e-mail é disparado

O monitoramento segue ativo até o encerramento da aplicação.
