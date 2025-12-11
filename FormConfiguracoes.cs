using System;
using System.Windows.Forms;

namespace time_tracker
{
    public partial class FormConfiguracoes : Form
    {
        public Config ConfigAtualizada { get; private set; }

        public FormConfiguracoes(Config configAtual)
        {
            InitializeComponent();
            
            ConfigAtualizada = configAtual;
            CarregarConfiguracoes();
        }

        private void CarregarConfiguracoes()
        {
            numTempoInativo.Value = ConfigAtualizada.TempoInactividadeSegundos;
            numTempoLongo.Value = ConfigAtualizada.TempoInactividadeLongaSegundos;
            chkEnviarEmail.Checked = ConfigAtualizada.EnviarEmailInatividade;
            txtEmailDestino.Text = ConfigAtualizada.EmailDestino;
            txtEmailRemetente.Text = ConfigAtualizada.EmailRemetente;
            txtSenha.Text = ConfigAtualizada.SenhaEmail;
            chkTocarSom.Checked = ConfigAtualizada.TocarSomAlerta;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            // Validações
            if (chkEnviarEmail.Checked)
            {
                if (string.IsNullOrWhiteSpace(txtEmailDestino.Text) ||
                    string.IsNullOrWhiteSpace(txtEmailRemetente.Text) ||
                    string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show(
                        "Para enviar emails, preencha todos os campos de email!",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }

                if (!txtEmailDestino.Text.Contains("@") || !txtEmailRemetente.Text.Contains("@"))
                {
                    MessageBox.Show(
                        "Digite emails válidos!",
                        "Validação",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning
                    );
                    return;
                }
            }

            if (numTempoLongo.Value <= numTempoInativo.Value)
            {
                MessageBox.Show(
                    "O tempo de inatividade longa deve ser maior que o tempo de alerta simples!",
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
                return;
            }

            // Salva as configurações
            ConfigAtualizada.TempoInactividadeSegundos = (int)numTempoInativo.Value;
            ConfigAtualizada.TempoInactividadeLongaSegundos = (int)numTempoLongo.Value;
            ConfigAtualizada.EnviarEmailInatividade = chkEnviarEmail.Checked;
            ConfigAtualizada.EmailDestino = txtEmailDestino.Text.Trim();
            ConfigAtualizada.EmailRemetente = txtEmailRemetente.Text.Trim();
            ConfigAtualizada.SenhaEmail = txtSenha.Text.Trim();
            ConfigAtualizada.TocarSomAlerta = chkTocarSom.Checked;

            ConfigAtualizada.Salvar();

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
