
namespace Ristorante_Davide
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.Proprietario = new System.Windows.Forms.Button();
            this.Ordina = new System.Windows.Forms.Button();
            this.Uscita = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.lettura = new System.Windows.Forms.TextBox();
            this.Login = new System.Windows.Forms.Button();
            this.risposta = new System.Windows.Forms.TextBox();
            this.indietro = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Aquamarine;
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBox1.Location = new System.Drawing.Point(286, 86);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(333, 63);
            this.textBox1.TabIndex = 8;
            this.textBox1.Text = "Benvenuto!";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Proprietario
            // 
            this.Proprietario.BackColor = System.Drawing.Color.Cornsilk;
            this.Proprietario.Location = new System.Drawing.Point(791, 449);
            this.Proprietario.Name = "Proprietario";
            this.Proprietario.Size = new System.Drawing.Size(138, 48);
            this.Proprietario.TabIndex = 7;
            this.Proprietario.Text = "Proprietario";
            this.Proprietario.UseVisualStyleBackColor = false;
            this.Proprietario.Click += new System.EventHandler(this.Proprietario_Click);
            // 
            // Ordina
            // 
            this.Ordina.BackColor = System.Drawing.Color.LightGray;
            this.Ordina.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Ordina.Location = new System.Drawing.Point(327, 216);
            this.Ordina.Name = "Ordina";
            this.Ordina.Size = new System.Drawing.Size(244, 94);
            this.Ordina.TabIndex = 6;
            this.Ordina.Text = "Ordinazione";
            this.Ordina.UseVisualStyleBackColor = false;
            this.Ordina.Click += new System.EventHandler(this.Ordina_Click);
            // 
            // Uscita
            // 
            this.Uscita.BackColor = System.Drawing.Color.Red;
            this.Uscita.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Uscita.Location = new System.Drawing.Point(820, 12);
            this.Uscita.Name = "Uscita";
            this.Uscita.Size = new System.Drawing.Size(109, 59);
            this.Uscita.TabIndex = 5;
            this.Uscita.Text = "Uscita";
            this.Uscita.UseVisualStyleBackColor = false;
            this.Uscita.Click += new System.EventHandler(this.Uscita_Click);
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(303, 155);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(153, 27);
            this.textBox2.TabIndex = 9;
            this.textBox2.Text = "Inserisci password";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // lettura
            // 
            this.lettura.Location = new System.Drawing.Point(303, 241);
            this.lettura.Name = "lettura";
            this.lettura.Size = new System.Drawing.Size(243, 27);
            this.lettura.TabIndex = 10;
            this.lettura.Visible = false;
            // 
            // Login
            // 
            this.Login.BackColor = System.Drawing.Color.Chartreuse;
            this.Login.Location = new System.Drawing.Point(303, 314);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(109, 48);
            this.Login.TabIndex = 11;
            this.Login.Text = "Check";
            this.Login.UseVisualStyleBackColor = false;
            this.Login.Visible = false;
            this.Login.Click += new System.EventHandler(this.Login_Click);
            // 
            // risposta
            // 
            this.risposta.BackColor = System.Drawing.Color.White;
            this.risposta.Enabled = false;
            this.risposta.Location = new System.Drawing.Point(441, 316);
            this.risposta.Name = "risposta";
            this.risposta.ReadOnly = true;
            this.risposta.Size = new System.Drawing.Size(153, 27);
            this.risposta.TabIndex = 12;
            this.risposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.risposta.Visible = false;
            // 
            // indietro
            // 
            this.indietro.BackColor = System.Drawing.Color.Red;
            this.indietro.Location = new System.Drawing.Point(303, 363);
            this.indietro.Name = "indietro";
            this.indietro.Size = new System.Drawing.Size(109, 48);
            this.indietro.TabIndex = 13;
            this.indietro.Text = "Indietro";
            this.indietro.UseVisualStyleBackColor = false;
            this.indietro.Visible = false;
            this.indietro.Click += new System.EventHandler(this.indietro_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Ristorante_Davide.Properties.Resources.pizza;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(941, 509);
            this.Controls.Add(this.indietro);
            this.Controls.Add(this.risposta);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Proprietario);
            this.Controls.Add(this.Ordina);
            this.Controls.Add(this.Uscita);
            this.Controls.Add(this.lettura);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button Proprietario;
        private System.Windows.Forms.Button Ordina;
        private System.Windows.Forms.Button Uscita;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox lettura;
        private System.Windows.Forms.Button Login;
        private System.Windows.Forms.TextBox risposta;
        private System.Windows.Forms.Button indietro;
    }
}

