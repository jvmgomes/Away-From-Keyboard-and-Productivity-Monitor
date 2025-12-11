namespace time_tracker
{
    partial class Form1
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titulo = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAppAtual = new System.Windows.Forms.Label();
            this.lblTempoInativo = new System.Windows.Forms.Label();
            this.btnIniciarParar = new System.Windows.Forms.Button();
            this.btnEnviarRelatorio = new System.Windows.Forms.Button();
            this.btnConfiguracoes = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.lblLogTitulo = new System.Windows.Forms.Label();
            this.btnLimparLog = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titulo
            // 
            this.titulo.AutoSize = true;
            this.titulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titulo.Location = new System.Drawing.Point(300, 20);
            this.titulo.Name = "titulo";
            this.titulo.Size = new System.Drawing.Size(200, 24);
            this.titulo.TabIndex = 0;
            this.titulo.Text = "AFK Notifier System";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(30, 60);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(150, 17);
            this.lblStatus.TabIndex = 1;
            this.lblStatus.Text = "Status: Aguardando...";
            // 
            // lblAppAtual
            // 
            this.lblAppAtual.AutoSize = true;
            this.lblAppAtual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppAtual.Location = new System.Drawing.Point(30, 90);
            this.lblAppAtual.Name = "lblAppAtual";
            this.lblAppAtual.Size = new System.Drawing.Size(120, 15);
            this.lblAppAtual.TabIndex = 2;
            this.lblAppAtual.Text = "App Atual: Nenhuma";
            // 
            // lblTempoInativo
            // 
            this.lblTempoInativo.AutoSize = true;
            this.lblTempoInativo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoInativo.Location = new System.Drawing.Point(30, 115);
            this.lblTempoInativo.Name = "lblTempoInativo";
            this.lblTempoInativo.Size = new System.Drawing.Size(120, 15);
            this.lblTempoInativo.TabIndex = 3;
            this.lblTempoInativo.Text = "Tempo Inativo: 0s";
            // 
            // btnIniciarParar
            // 
            this.btnIniciarParar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciarParar.Location = new System.Drawing.Point(30, 150);
            this.btnIniciarParar.Name = "btnIniciarParar";
            this.btnIniciarParar.Size = new System.Drawing.Size(150, 40);
            this.btnIniciarParar.TabIndex = 4;
            this.btnIniciarParar.Text = "Iniciar Monitoramento";
            this.btnIniciarParar.UseVisualStyleBackColor = true;
            this.btnIniciarParar.Click += new System.EventHandler(this.btnIniciarParar_Click);
            // 
            // btnEnviarRelatorio
            // 
            this.btnEnviarRelatorio.Location = new System.Drawing.Point(200, 150);
            this.btnEnviarRelatorio.Name = "btnEnviarRelatorio";
            this.btnEnviarRelatorio.Size = new System.Drawing.Size(150, 40);
            this.btnEnviarRelatorio.TabIndex = 5;
            this.btnEnviarRelatorio.Text = "Enviar Relatório por Email";
            this.btnEnviarRelatorio.UseVisualStyleBackColor = true;
            this.btnEnviarRelatorio.Click += new System.EventHandler(this.btnEnviarRelatorio_Click);
            // 
            // btnConfiguracoes
            // 
            this.btnConfiguracoes.Location = new System.Drawing.Point(370, 150);
            this.btnConfiguracoes.Name = "btnConfiguracoes";
            this.btnConfiguracoes.Size = new System.Drawing.Size(150, 40);
            this.btnConfiguracoes.TabIndex = 6;
            this.btnConfiguracoes.Text = "Configurações";
            this.btnConfiguracoes.UseVisualStyleBackColor = true;
            this.btnConfiguracoes.Click += new System.EventHandler(this.btnConfiguracoes_Click);
            // 
            // txtLog
            // 
            this.txtLog.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(30, 230);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(740, 190);
            this.txtLog.TabIndex = 7;
            // 
            // lblLogTitulo
            // 
            this.lblLogTitulo.AutoSize = true;
            this.lblLogTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogTitulo.Location = new System.Drawing.Point(30, 210);
            this.lblLogTitulo.Name = "lblLogTitulo";
            this.lblLogTitulo.Size = new System.Drawing.Size(107, 15);
            this.lblLogTitulo.TabIndex = 8;
            this.lblLogTitulo.Text = "Log de Eventos";
            // 
            // btnLimparLog
            // 
            this.btnLimparLog.Location = new System.Drawing.Point(670, 205);
            this.btnLimparLog.Name = "btnLimparLog";
            this.btnLimparLog.Size = new System.Drawing.Size(100, 23);
            this.btnLimparLog.TabIndex = 9;
            this.btnLimparLog.Text = "Limpar Log";
            this.btnLimparLog.UseVisualStyleBackColor = true;
            this.btnLimparLog.Click += new System.EventHandler(this.btnLimparLog_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLimparLog);
            this.Controls.Add(this.lblLogTitulo);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnConfiguracoes);
            this.Controls.Add(this.btnEnviarRelatorio);
            this.Controls.Add(this.btnIniciarParar);
            this.Controls.Add(this.lblTempoInativo);
            this.Controls.Add(this.lblAppAtual);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.titulo);
            this.Name = "Form1";
            this.Text = "AFK Notifier - Time Tracker";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titulo;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblAppAtual;
        private System.Windows.Forms.Label lblTempoInativo;
        private System.Windows.Forms.Button btnIniciarParar;
        private System.Windows.Forms.Button btnEnviarRelatorio;
        private System.Windows.Forms.Button btnConfiguracoes;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Label lblLogTitulo;
        private System.Windows.Forms.Button btnLimparLog;
    }
}

