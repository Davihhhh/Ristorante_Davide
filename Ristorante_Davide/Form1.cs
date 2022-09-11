using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;



namespace Ristorante_Davide
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        string password = "";
        private void Proprietario_Click(object sender, EventArgs e)
        {
            nascondilogin();
            vediproprietariologin();
            try
            {
                StreamReader sr = new StreamReader(@"./password.txt");
                while (!sr.EndOfStream)
                {
                    password = sr.ReadLine();
                }
                sr.Close();
            }
            catch
            {
                MessageBox.Show("impossibile accedere, password corrotta");               
                vedilogin();
                nascondiproprietariologin();
            }
        }

        private void Login_Click(object sender, EventArgs e)
        {
            if (lettura.Text != password)
            {
                risposta.Text = "password errata";
            }
            else
            {
                vedilogin();
                nascondiproprietariologin();

                Form2 fr2 = new Form2();
                fr2.ShowDialog();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        public void vedilogin ()
        {
            textBox1.Visible = true;
            Proprietario.Visible = true;
            Ordina.Visible = true;
            Uscita.Visible = true;
            
        }
        public void nascondilogin ()
        {
            textBox1.Visible = false;
            Proprietario.Visible = false;
            Ordina.Visible = false;
            Uscita.Visible = false;
            risposta.Visible = false;
        }
        public void vediproprietariologin()
        {
            textBox2.Visible = true;
            lettura.Visible = true;
            Login.Visible = true;
            indietro.Visible = true;
            risposta.Visible = true;
            risposta.Text = "";
            lettura.Text = "";
        }
        public void nascondiproprietariologin()
        {
            textBox2.Visible = false;
            lettura.Visible = false;
            Login.Visible = false;
            indietro.Visible = false;
            risposta.Visible = false;
        }

        private void indietro_Click(object sender, EventArgs e)
        {
            vedilogin();
            nascondiproprietariologin();
        }

        private void Ordina_Click(object sender, EventArgs e)
        {
            nascondiproprietariologin();
            vedilogin();
            Form3 fr3 = new Form3();
            fr3.ShowDialog();
        }

        private void Uscita_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
