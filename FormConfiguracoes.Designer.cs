namespace time_tracker
{
    partial class FormConfiguracoes
    { 
        private System.ComponentModel.IContainer components = null;
         
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblTempoInativo = new System.Windows.Forms.Label();
            this.numTempoInativo = new System.Windows.Forms.NumericUpDown();
            this.lblSegundos1 = new System.Windows.Forms.Label();
            this.lblTempoLongo = new System.Windows.Forms.Label();
            this.numTempoLongo = new System.Windows.Forms.NumericUpDown();
            this.lblSegundos2 = new System.Windows.Forms.Label();
            this.chkEnviarEmail = new System.Windows.Forms.CheckBox();
            this.lblEmailDestino = new System.Windows.Forms.Label();
            this.txtEmailDestino = new System.Windows.Forms.TextBox();
            this.lblEmailRemetente = new System.Windows.Forms.Label();
            this.txtEmailRemetente = new System.Windows.Forms.TextBox();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.chkTocarSom = new System.Windows.Forms.CheckBox();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoInativo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoLongo)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(150, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(124, 20);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Configurações";
            // 
            // lblTempoInativo
            // 
            this.lblTempoInativo.AutoSize = true;
            this.lblTempoInativo.Location = new System.Drawing.Point(30, 60);
            this.lblTempoInativo.Name = "lblTempoInativo";
            this.lblTempoInativo.Size = new System.Drawing.Size(165, 13);
            this.lblTempoInativo.TabIndex = 1;
            this.lblTempoInativo.Text = "Tempo para alerta de inatividade:";
            // 
            // numTempoInativo
            // 
            this.numTempoInativo.Location = new System.Drawing.Point(250, 58);
            this.numTempoInativo.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numTempoInativo.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numTempoInativo.Name = "numTempoInativo";
            this.numTempoInativo.Size = new System.Drawing.Size(80, 20);
            this.numTempoInativo.TabIndex = 2;
            this.numTempoInativo.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // lblSegundos1
            // 
            this.lblSegundos1.AutoSize = true;
            this.lblSegundos1.Location = new System.Drawing.Point(336, 60);
            this.lblSegundos1.Name = "lblSegundos1";
            this.lblSegundos1.Size = new System.Drawing.Size(54, 13);
            this.lblSegundos1.TabIndex = 3;
            this.lblSegundos1.Text = "segundos";
            // 
            // lblTempoLongo
            // 
            this.lblTempoLongo.AutoSize = true;
            this.lblTempoLongo.Location = new System.Drawing.Point(30, 90);
            this.lblTempoLongo.Name = "lblTempoLongo";
            this.lblTempoLongo.Size = new System.Drawing.Size(214, 13);
            this.lblTempoLongo.TabIndex = 4;
            this.lblTempoLongo.Text = "Tempo para inatividade longa (enviar email):";
            // 
            // numTempoLongo
            // 
            this.numTempoLongo.Location = new System.Drawing.Point(250, 88);
            this.numTempoLongo.Maximum = new decimal(new int[] {
            7200,
            0,
            0,
            0});
            this.numTempoLongo.Minimum = new decimal(new int[] {
            60,
            0,
            0,
            0});
            this.numTempoLongo.Name = "numTempoLongo";
            this.numTempoLongo.Size = new System.Drawing.Size(80, 20);
            this.numTempoLongo.TabIndex = 5;
            this.numTempoLongo.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // lblSegundos2
            // 
            this.lblSegundos2.AutoSize = true;
            this.lblSegundos2.Location = new System.Drawing.Point(336, 90);
            this.lblSegundos2.Name = "lblSegundos2";
            this.lblSegundos2.Size = new System.Drawing.Size(54, 13);
            this.lblSegundos2.TabIndex = 6;
            this.lblSegundos2.Text = "segundos";
            // 
            // chkEnviarEmail
            // 
            this.chkEnviarEmail.AutoSize = true;
            this.chkEnviarEmail.Location = new System.Drawing.Point(33, 130);
            this.chkEnviarEmail.Name = "chkEnviarEmail";
            this.chkEnviarEmail.Size = new System.Drawing.Size(192, 17);
            this.chkEnviarEmail.TabIndex = 7;
            this.chkEnviarEmail.Text = "Enviar email em inatividade longa";
            this.chkEnviarEmail.UseVisualStyleBackColor = true;
            // 
            // lblEmailDestino
            // 
            this.lblEmailDestino.AutoSize = true;
            this.lblEmailDestino.Location = new System.Drawing.Point(30, 160);
            this.lblEmailDestino.Name = "lblEmailDestino";
            this.lblEmailDestino.Size = new System.Drawing.Size(76, 13);
            this.lblEmailDestino.TabIndex = 8;
            this.lblEmailDestino.Text = "Email Destino:";
            // 
            // txtEmailDestino
            // 
            this.txtEmailDestino.Location = new System.Drawing.Point(150, 157);
            this.txtEmailDestino.Name = "txtEmailDestino";
            this.txtEmailDestino.Size = new System.Drawing.Size(250, 20);
            this.txtEmailDestino.TabIndex = 9;
            // 
            // lblEmailRemetente
            // 
            this.lblEmailRemetente.AutoSize = true;
            this.lblEmailRemetente.Location = new System.Drawing.Point(30, 190);
            this.lblEmailRemetente.Name = "lblEmailRemetente";
            this.lblEmailRemetente.Size = new System.Drawing.Size(117, 13);
            this.lblEmailRemetente.TabIndex = 10;
            this.lblEmailRemetente.Text = "Email Remetente (you):";
            // 
            // txtEmailRemetente
            // 
            this.txtEmailRemetente.Location = new System.Drawing.Point(150, 187);
            this.txtEmailRemetente.Name = "txtEmailRemetente";
            this.txtEmailRemetente.Size = new System.Drawing.Size(250, 20);
            this.txtEmailRemetente.TabIndex = 11;
            // 
            // lblSenha
            // 
            this.lblSenha.AutoSize = true;
            this.lblSenha.Location = new System.Drawing.Point(30, 220);
            this.lblSenha.Name = "lblSenha";
            this.lblSenha.Size = new System.Drawing.Size(114, 13);
            this.lblSenha.TabIndex = 12;
            this.lblSenha.Text = "Senha de App (Gmail):";
            // 
            // txtSenha
            // 
            this.txtSenha.Location = new System.Drawing.Point(150, 217);
            this.txtSenha.Name = "txtSenha";
            this.txtSenha.PasswordChar = '*';
            this.txtSenha.Size = new System.Drawing.Size(250, 20);
            this.txtSenha.TabIndex = 13;
            // 
            // chkTocarSom
            // 
            this.chkTocarSom.AutoSize = true;
            this.chkTocarSom.Checked = true;
            this.chkTocarSom.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTocarSom.Location = new System.Drawing.Point(33, 250);
            this.chkTocarSom.Name = "chkTocarSom";
            this.chkTocarSom.Size = new System.Drawing.Size(152, 17);
            this.chkTocarSom.TabIndex = 14;
            this.chkTocarSom.Text = "Tocar som ao detectar AFK";
            this.chkTocarSom.UseVisualStyleBackColor = true;
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(150, 330);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(100, 30);
            this.btnSalvar.TabIndex = 15;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(270, 330);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 30);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // FormConfiguracoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 381);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.chkTocarSom);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtEmailRemetente);
            this.Controls.Add(this.lblEmailRemetente);
            this.Controls.Add(this.txtEmailDestino);
            this.Controls.Add(this.lblEmailDestino);
            this.Controls.Add(this.chkEnviarEmail);
            this.Controls.Add(this.lblSegundos2);
            this.Controls.Add(this.numTempoLongo);
            this.Controls.Add(this.lblTempoLongo);
            this.Controls.Add(this.lblSegundos1);
            this.Controls.Add(this.numTempoInativo);
            this.Controls.Add(this.lblTempoInativo);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfiguracoes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configurações - AFK Notifier";
            ((System.ComponentModel.ISupportInitialize)(this.numTempoInativo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTempoLongo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblTempoInativo;
        private System.Windows.Forms.NumericUpDown numTempoInativo;
        private System.Windows.Forms.Label lblSegundos1;
        private System.Windows.Forms.Label lblTempoLongo;
        private System.Windows.Forms.NumericUpDown numTempoLongo;
        private System.Windows.Forms.Label lblSegundos2;
        private System.Windows.Forms.CheckBox chkEnviarEmail;
        private System.Windows.Forms.Label lblEmailDestino;
        private System.Windows.Forms.TextBox txtEmailDestino;
        private System.Windows.Forms.Label lblEmailRemetente;
        private System.Windows.Forms.TextBox txtEmailRemetente;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.CheckBox chkTocarSom;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblInfo;
    }
}
