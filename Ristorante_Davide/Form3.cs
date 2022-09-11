using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Linq;

namespace Ristorante_Davide
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        public struct piatto
        {
            public string nome;
            public string prezzo;
            public string[] ingredienti;
            public string tipologia;
        }
        //dati
        public piatto[] menu = new piatto[300];   //grandezza menu       
        int contatore = 0;                  //numero di piatti
        int contaordini = 0;
        public int grandezzapiatto = 7;     //elementi in un piatto
        int numeroingredienti = 4;          //numero ingredienti
        int cont = 0;                       //numero di elementi
        int puntatore = 0;
        


        //button menu
        int buttonsize_x = 90;
        int buttonsize_y = 35;

        int generationordinepri_x = 1;
        int generationordinepri_y = 40;
        int generationordinesec_x = 1;
        int generationordinesec_y = 40;
        int generationordinedes_x = 1;
        int generationordinedes_y = 40;
        int generationordineant_x = 1;
        int generationordineant_y = 40;
        Button[] butt = new Button[100];


        //button ordine
        int buttonsizeordine_x = 90;
        int buttonsizeordine_y = 35;
        int generationbuttons_x = 1;
        int generationbuttons_y = 40;
        Button[] buttordine = new Button[100];
        int[] listatracciatore = new int[100];
        int puntatore2 = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            lettura(ref contatore, menu);
        }


        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  

        public void lettura(ref int contatore, piatto[] menu)
        {
            StreamReader sr;
            int a = 0;
            puntatore = 0;
            try
            {
                sr = new StreamReader(@"./menu.txt");
            }
            catch
            {
                MessageBox.Show("manutenzione in corso");
                exit();
                return;
            }
            //caricamento in memoria del menu
            bool prova = false;

            for (cont = 0; !sr.EndOfStream; contatore++)
            {
                string copia = sr.ReadLine();
                if (prova = string.IsNullOrEmpty(copia) == true)
                { }
                else
                {
                    string[] menutemp = copia.Split(';');
                    a = 0;
                    menu[contatore].nome = menutemp[a];
                    //MessageBox.Show(menu[contatore].nome);
                    a++;
                    cont++;
                    menu[contatore].prezzo = menutemp[a];
                    //MessageBox.Show(menu[contatore].prezzo);
                    a++;
                    cont++;
                    caricaingredienti(menu, contatore, ref a, menutemp, ref cont);
                    menu[contatore].tipologia = menutemp[a];                    
                    //MessageBox.Show(menu[contatore].tipologia);
                    a++;
                    cont++;
                    
                    //MessageBox.Show(puntatore.ToString());
                    generabutton(menu[contatore], contatore);
                }
            }
            puntatore = -1;
            sr.Close();
            //controllo del menu
            if (cont / grandezzapiatto * grandezzapiatto != cont)
            {
                MessageBox.Show("menu danneggiato, ripristinare i file prima di continuare");
                exit();
            }
        }
        public void caricaingredienti(piatto[] menu, int contator, ref int a, string[] menutemp, ref int cont)
        {
            menu[contator].ingredienti = new string[numeroingredienti];
            for (int b = 0; b < numeroingredienti; b++, a++, cont++)
            {
                //MessageBox.Show(a.ToString());
                menu[contator].ingredienti[b] = menutemp[a];
                //MessageBox.Show(menu[contator].ingredienti[b]);
            }
        }
        public void exit()
        {
            this.Close();
        }
        public void generabutton(piatto mentmp, int contatore)
        {
            butt[contatore] = new Button();

            butt[contatore].Name = contatore.ToString();
            //MessageBox.Show(butt[contatore].Name);
            butt[contatore].Text = mentmp.nome;           
            butt[contatore].Size = new Size(buttonsize_x, buttonsize_y);
            butt[contatore].Padding = new Padding(0);
            butt[contatore].Visible = true;
            butt[contatore].Font = new Font("Segoe UI", 10);
            butt[contatore].Click += new EventHandler(this.button_click);
            string str = menu[puntatore].tipologia;
            //MessageBox.Show(str);
            switch (str)
            {
                case "antipasto":
                    //MessageBox.Show(str);
                    butt[contatore].BackColor = Color.Pink;
                    butt[contatore].Location = new Point(generationordineant_x, generationordineant_y);
                    generationordineant_y += buttonsizeordine_y + 10;
                    panelantipasti.Controls.Add(butt[contatore]);
                    break;
                case "primo":
                    //MessageBox.Show(str);
                    butt[contatore].BackColor = Color.LightGoldenrodYellow;
                    butt[contatore].Location = new Point(generationordinepri_x, generationordinepri_y);
                    generationordinepri_y += buttonsizeordine_y + 10;
                    panelprimi.Controls.Add(butt[contatore]);
                    break;
                case "secondo":
                    //MessageBox.Show(str);
                    butt[contatore].BackColor = Color.LightGreen;
                    butt[contatore].Location = new Point(generationordinesec_x, generationordinesec_y);
                    generationordinesec_y += buttonsizeordine_y + 10;
                    panelsecondi.Controls.Add(butt[contatore]);
                    break;
                case "dessert":
                    //MessageBox.Show(str);
                    butt[contatore].BackColor = Color.LightCyan;
                    butt[contatore].Location = new Point(generationordinedes_x, generationordinedes_y);
                    generationordinedes_y += buttonsizeordine_y + 10;
                    paneldessert.Controls.Add(butt[contatore]);
                    break;
            }
            puntatore++;
        }
        public void generabuttonordine(piatto mentmp, ref int puntatore2)
        {
            listatracciatore[puntatore2] = puntatore;
            buttordine[puntatore2] = new Button();

            buttordine[puntatore2].Name = contaordini+"ordine";
            buttordine[puntatore2].Text = mentmp.nome;
            buttordine[puntatore2].BackColor = Color.Orange;
            buttordine[puntatore2].Size = new Size(buttonsizeordine_x, buttonsizeordine_y);
            buttordine[puntatore2].Location = new Point(generationbuttons_x, generationbuttons_y);
            generationbuttons_y += buttonsize_y + 10;
            buttordine[puntatore2].Padding = new Padding(0);
            buttordine[puntatore2].Visible = true;
            buttordine[puntatore2].Font = new Font("Segoe UI", 11);

            buttordine[puntatore2].Click += new EventHandler(this.buttonordine_click);

            
            panellista.Controls.Add(buttordine[puntatore2]);
            puntatore2++;
            contaordini++;
        }
        public void stampaintextbox(int pos)
        {
            innome.Text = menu[pos].nome;
            inprezzo.Text = menu[pos].prezzo;
            iningredienti.Text = menu[pos].ingredienti[0] + "; " + menu[pos].ingredienti[1] + "; " + menu[pos].ingredienti[2] + "; " + menu[pos].ingredienti[3];
            switch (menu[pos].tipologia)
            {
                default:
                    MessageBox.Show(menu[pos].tipologia);
                    break;
                case "primo":
                    primo.Checked = true;
                    break;
                case "secondo":
                    secondo.Checked = true;
                    break;
                case "antipasto":
                    antipasto.Checked = true;
                    break;
                case "dessert":
                    dessert.Checked = true;
                    break;
            }
        }
        private void button_click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int v = Convert.ToInt32(btn.Name);
            
            stampaintextbox(v);
            puntatore = v;
        }
        private void buttonordine_click(object sender, EventArgs e)
        {          
            Button btn = sender as Button;
            string str = btn.Name;
            char[] cr = str.ToCharArray();
            int v = Convert.ToInt32(cr[0]);
            v -= 48;
            //MessageBox.Show(cr[0].ToString());
            stampaintextbox(listatracciatore[v]);
            puntatore = v;
        }

        public void cancellalist()
        {
            for (int j = 0; j < contaordini; j++)
            {
                panellista.Controls.Remove(buttordine[j]);
                buttordine[j].Dispose();
            }

            buttordine = new Button[100];
            listatracciatore = new int[100];
            puntatore2 = 0;
            contaordini = 0;

            generationbuttons_x = 1;
            generationbuttons_y = 40;
        }








        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  //  
        /*
        private void buttonup_Click(object sender, EventArgs e)
        {
            int change = panelmain.VerticalScroll.Value - panelmain.VerticalScroll.SmallChange * 10;
            panelmain.AutoScrollPosition = new Point(0, change);
        }
        private void buttondown_Click(object sender, EventArgs e)
        {
            int change = panelmain.VerticalScroll.Value + panelmain.VerticalScroll.SmallChange * 10;
            panelmain.AutoScrollPosition = new Point(0, change);
        }
        */
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBoxMenù_TextChanged(object sender, EventArgs e)
        {

        }
        private void panel3_Click(object sender, EventArgs e)
        {

        }
        private void buttonaggiungi_Click(object sender, EventArgs e)
        {
            if (puntatore == -1)
            {
                MessageBox.Show("Scegli prima un piatto!");
            }
            else
            {
                generabuttonordine(menu[puntatore], ref puntatore2);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ordinabutton_Click(object sender, EventArgs e)
        {
            if (contaordini > 0)
            {
                buttonconferma.Visible = true;
                buttonannulla.Visible = true;
            }
            else
                MessageBox.Show("Aggiungi prima qualcosa!");

        }

        private void buttonconferma_Click(object sender, EventArgs e)
        {
            double somma = 0.00;           
            for (int i = 0; i < contaordini; i++)
            {
                somma += Convert.ToDouble(menu[listatracciatore[i]].prezzo);                              
            }
            MessageBox.Show("Totale: " + somma/100 + "€");
            buttonconferma.Visible = false;
            buttonannulla.Visible = false;
            cancellalist();
        }

        private void buttonannulla_Click(object sender, EventArgs e)
        {
            buttonconferma.Visible = false;
            buttonannulla.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            annullacancellalista.Visible = false;
            confermacancellalista.Visible = false;
            cancellalist();
        }

        private void Cancellalista_Click(object sender, EventArgs e)
        {
            if (contaordini > 0)
            {
                annullacancellalista.Visible = true;
                confermacancellalista.Visible = true;
            }
            else
                MessageBox.Show("Aggiungi prima qualcosa!");         
        }

        private void button1_Click(object sender, EventArgs e)
        {
            annullacancellalista.Visible = false;
            confermacancellalista.Visible = false;
        }

        private void uscita_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
