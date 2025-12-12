# Away From Keyboard and Productivity Monitor

Um sistema de monitoramento de atividade em C# que detecta inatividade do usuário através do teclado e mouse, enviando alertas por email quando o tempo de inatividade ultrapassa um limite configurável.

## 📋 Descrição

Este projeto monitora continuamente a atividade do usuário no Windows, rastreando movimentos do mouse e pressionamentos de tecla. Quando detecta inatividade por um período determinado, envia automaticamente um alerta por email para notificar sobre a ausência do usuário.

> ⚠️ **Projeto Educacional**: Este projeto foi desenvolvido para fins didáticos e de aprendizado em programação C#, Win32 API e desenvolvimento de aplicações Windows Forms.

## ✨ Funcionalidades

- 🖱️ **Monitoramento de Mouse**: Detecta movimento e cliques do mouse
- ⌨️ **Monitoramento de Teclado**: Rastreia pressionamentos de tecla
- ⏱️ **Detecção de Inatividade**: Configura tempo limite personalizado
- 📧 **Alertas por Email**: Envia notificações automáticas via SMTP
- 🎯 **Interface Gráfica**: Configuração fácil através de formulários Windows Forms
- 💾 **Persistência de Configurações**: Salva preferências do usuário
- 📊 **Registro de Atividades**: Mantém logs de eventos de inatividade

## 🚀 Tecnologias Utilizadas

- C# / .NET Framework
- Windows Forms
- Win32 API (Hooks de Sistema)
- SMTP para envio de emails
- System.Configuration para gerenciamento de configurações

## 📦 Pré-requisitos

- Windows 7 ou superior
- .NET Framework 4.7.2 ou superior
- Conta de email com SMTP habilitado (Gmail, Outlook, etc.)

## 🔧 Instalação

1. Clone o repositório:
```bash
git clone https://github.com/jvmgomes/Away-From-Keyboard-and-Productivity-Monitor.git
```

2. Abra o projeto no Visual Studio:
```bash
cd Away-From-Keyboard-and-Productivity-Monitor
```

3. Restaure os pacotes NuGet (se necessário)

4. Compile e execute o projeto

## ⚙️ Configuração

### Configuração de Tempo de Inatividade

- Acesse a interface do programa
- Configure o tempo limite em minutos através do formulário de configurações
- Salve as preferências

### Configuração para Gmail

Para usar o Gmail, você precisa:
1. Ativar a verificação em duas etapas
2. Gerar uma senha de aplicativo
3. Usar a senha de aplicativo no campo `EmailPassword`

## 📖 Como Usar

1. **Inicie o aplicativo**
2. **Configure suas preferências**:
   - Tempo de inatividade (em minutos)
   - Configurações de email
3. **Inicie o monitoramento**
4. O sistema começará a rastrear sua atividade
5. Ao detectar inatividade, um email será enviado automaticamente

## 🏗️ Estrutura do Projeto

```
src/
├── App.config              # Configurações da aplicação
├── AppMonitor.cs          # Lógica principal de monitoramento
├── Config.cs              # Gerenciamento de configurações
├── Form1.cs               # Interface principal
├── Form1.Designer.cs      # Designer do formulário
├── Form1.resx            # Recursos do formulário
├── FormConfiguracoes.cs   # Formulário de configurações
├── Logs.cs               # Sistema de logs
├── Mail.cs               # Gerenciamento de email
├── Program.cs            # Ponto de entrada
└── SessaoAtividade.cs    # Controle de sessões
```

## 🔐 Segurança

⚠️ **Importante**: 
- Nunca compartilhe seu arquivo `App.config` com senhas reais
- Use senhas de aplicativo ao invés de senhas principais
- Considere usar variáveis de ambiente para dados sensíveis
- Adicione `App.config` ao `.gitignore` em produção

## 🤝 Contribuindo

Contribuições são bem-vindas! Para contribuir:

1. Faça um Fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas mudanças (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abra um Pull Request

## 📄 Licença

Este projeto está sob a licença MIT. Veja o arquivo `LICENSE` para mais detalhes.

**Nota**: Este é um projeto educacional desenvolvido para fins de aprendizado e demonstração de conceitos de programação.

## 👤 Autores

- GitHub: [@jvmgomes](https://github.com/jvmgomes)
- Github: [@Thiago-Heleno](https://github.com/Thiago-Heleno)
- Github: [@EnzoBaldinotti](https://github.com/EnzoBaldinotti)
