using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Ristorante_Davide
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            this.ControlBox = false;
        }
        //sistemare aggiunta, fisicoelimina
        private void Form2_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void radioButtonNome_CheckedChanged(object sender, EventArgs e)
        {

        }

        public struct piatto
        {
            public string nome;
            public string prezzo;
            public string[] ingredienti;
            public string tipologia;
        }

        public piatto[] menu = new piatto[300];   //grandezza menu       
        public int contatore = 0;                  //numero di piatti
        public int grandezzapiatto = 7;     //elementi in un piatto
        int numeroingredienti = 4;          //numero ingredienti
        int cont = 0;                       //numero di elementi
        int cosacercare = 0;                //cosa cercare 
        int ricercaomodifica = -1;           //ricerca(0) o modifica(1)
        piatto[] temporaneo = new piatto[300]; //array di piatti usati temporaneamente
        int w = 0;                             //puntatore di temporaneo
        int contemp = 0;                     //contatore di temporaneo
        int[] tracciatore = new int[300];  //tabella per la copiatura
        bool elimina = false;
        int[] eliminati = new int[300];    //tracciatore piatti eliminati
        int contaeliminati = 0;            //contatore piatti eliminati
        int puntatoreattuale = 0;           //punta al primo elemento trovato nel menu
        int contapagine = 0;
        int piattiaggiunti = 0;

        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   
        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        public void exit()
        { 
           this.Close();
        }
        public void ripristinacaselle()
        {
            innome.Text = "";
            inprezzo.Text = "";
            iningredienti.Text = "";
            radioButtonIngrediente.Checked = false;
            radioButtonNome.Checked = false;
            radioButtonPortata.Checked = false;
            radioButtonPrezzo.Checked = false;
            dessert.Checked = false;
            primo.Checked = false;
            secondo.Checked = false;
            antipasto.Checked = false;
        }
        public void ripristinavalori()
        {
            cosacercare = 0;
            ricercaomodifica = -1;
            temporaneo = new piatto[300];
            contemp = 0;
            tracciatore = new int[300];
            w = -1;
            puntatoreattuale = 0;
            elimina = false;
            selectionsort(tracciatore, contaeliminati);
        }
        public void veditextbox()
        {
            nome.Visible = true;
            prezzo.Visible = true;
            ingredienti.Visible = true;
            portata.Visible = true;
            innome.Visible = true;
            inprezzo.Visible = true;
            iningredienti.Visible = true;
            esempioingredienti.Visible = true;
            esempioprezzo.Visible = true;
            esempionome.Visible = true;
            indicazione2.Visible = true;
            indicazione1.Visible = true;
            antipasto.Visible = true;
            primo.Visible = true;
            secondo.Visible = true;
            dessert.Visible = true;
            home.Visible = true;
        }
        public void nasconditextbox()
        {
            nome.Visible = false;
            prezzo.Visible = false;
            ingredienti.Visible = false;
            portata.Visible = false;
            innome.Visible = false;
            inprezzo.Visible = false;
            iningredienti.Visible = false;
            esempioingredienti.Visible = false;
            esempioprezzo.Visible = false;
            esempionome.Visible = false;
            indicazione2.Visible = false;
            indicazione1.Visible = false;
            antipasto.Visible = false;
            primo.Visible = false;
            secondo.Visible = false;
            dessert.Visible = false;
            fatto.Visible = false;
            home.Visible = false;
        }
        public void enableintextbox()
        {
            innome.Enabled = true;
            inprezzo.Enabled = true;
            iningredienti.Enabled = true;
            antipasto.Enabled = true;
            primo.Enabled = true;
            secondo.Enabled = true;
            dessert.Enabled = true;
        }
        public void disableintextbox()
        {
            innome.Enabled = false;
            inprezzo.Enabled = false;
            iningredienti.Enabled = false;
            antipasto.Enabled = false;
            primo.Enabled = false;
            secondo.Enabled = false;
            dessert.Enabled = false;
        }
        public void vedipulsanti()
        {
            logout.Visible = true;
            Aggiunta.Visible = true;
            Modifica.Visible = true;
            Ricerca.Visible = true;
            Eliminazione.Visible = true;
            Fisicoelimina.Visible = true;
            Ripristino.Visible = true;

        }
        public void nascondipulsanti()
        {
            logout.Visible = false;
            Aggiunta.Visible = false;
            Modifica.Visible = false;
            Ricerca.Visible = false;
            Eliminazione.Visible = false;
            Fisicoelimina.Visible = false;
            Ripristino.Visible = false;
            precedente.Visible = false;
            successivo.Visible = false;
        }
        public void enablepulsanti()
        {
            logout.Enabled = true;
            Aggiunta.Enabled = true;
            Modifica.Enabled = true;
            Ricerca.Enabled = true;
            Eliminazione.Enabled = true;
            Fisicoelimina.Enabled = true;
            Ripristino.Enabled = true;
            fatto.Enabled = true;
        }
        public void disablepulsanti()
        {
            logout.Enabled = false;
            Aggiunta.Enabled = false;
            Modifica.Enabled = false;
            Ricerca.Enabled = false;
            Eliminazione.Enabled = false;
            Fisicoelimina.Enabled = false;
            Ripristino.Enabled = false;
            fatto.Enabled = false;
        }
        public void vedipulsantiricerca()
        {
            groupBox1.Visible = true;
            radioButtonNome.Visible = true;
            radioButtonPrezzo.Visible = true;
            radioButtonIngrediente.Visible = true;
            radioButtonPortata.Visible = true;
            sceltaricerca.Visible = true;
        }
        public void nascondipulsantiricerca()
        {
            groupBox1.Visible = false;
            radioButtonNome.Visible = false;
            radioButtonPrezzo.Visible = false;
            radioButtonIngrediente.Visible = false;
            radioButtonPortata.Visible = false;
            sceltaricerca.Visible = false;
            modificabutton.Visible = false;
            fattoricerca.Visible = false;
            eliminabutton.Visible = false;
            ripristinabutton.Visible = false;
        }
        public void vedifisicoelimina()
        {
            fisicoeliminano.Visible = true;
            fisicoeliminasi.Visible = true;
            fisicoeliminatextbox.Visible = true;
        }
        public void nascondifisicoelimina()
        {
            fisicoeliminano.Visible = false;
            fisicoeliminasi.Visible = false;
            fisicoeliminatextbox.Visible = false;
        }
        public void schermatahome()
        {
            enablepulsanti();
            vedipulsanti();
            nasconditextbox();
            nascondipulsantiricerca();
            ripristinacaselle();
            ripristinavalori();
            enableintextbox();
            nascondifisicoelimina();
        }

        public void leggitextbox(ref piatto temp, ref int control)
        {
            int controllo = 0;
            temp.nome = innome.Text;
            check(temp.nome, ref controllo);
            checkparola(temp.nome, ref controllo);
            temp.prezzo = inprezzo.Text;
            check(temp.prezzo, ref controllo);
            checkprezzo(temp.prezzo, ref controllo);
            if (controllo > 0)
            {

            }
            else { prezzoadeguato(ref temp.prezzo); }
            string tmpingredienti = iningredienti.Text + ";;;;";
            string[] temping = tmpingredienti.Split(';');
            if (temping.Length > 8 || temping.Length < 8)
            { controllo++; }
            else
            {
                for (int d = 0; d < numeroingredienti; d++)
                {
                    check(temping[d], ref controllo);
                    checkparola(temping[d], ref controllo);
                }
            }
            if (controllo > 0)
            { }
            else
            {
                ingredientiqualcosa(ref temp, temping);
            }
            string tempportata = "";
            assegnaportata(ref tempportata);
            check(tempportata, ref controllo);
            if (controllo > 0)
            { }
            else
            {
                temp.tipologia = tempportata;
            }
            if (controllo > 0)
            {
                control = 1;
            }
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

        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        public void check(string tmp, ref int controllo)
        {
            bool prova = string.IsNullOrWhiteSpace(tmp);
            if (prova == true && controllo == 0)
            {
                MessageBox.Show("Inserisci i dati richiesti!");
                controllo++;
            }
        }
        public void checkparola(string tmp, ref int controllo)
        {
            char[] ar = tmp.ToCharArray();
            int val = 0;
            for (int c = 0; c < ar.Length; c++)
            {
                val = (int)ar[c];
                if (val >= 65 && val <= 90 || val >= 97 && val <= 122 || val == 32)
                { }
                else
                { controllo++; }
            }
        }
        public void checkprezzo(string tmp, ref int controllo)
        {
            char[] ar = tmp.ToCharArray();
            int unpunto = 0;
            int val = 0;
            for (int c = 0; c < ar.Length; c++)
            {
                val = (int)ar[c];
                if (val >= 48 && val <= 57)
                { }
                else
                {
                    if (val == 46 && unpunto < 1)
                    { unpunto++; }
                    else
                    { controllo++; }
                }
            }
        }
        public void checkeliminato(int num, ref bool controlloeliminato)
        {
            for (int j = 0; j < contatore; j++)
            {
                if (eliminati[j] == num)
                { controlloeliminato = true; }
            }
        }
        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //

        public void lettura(ref int contatore, piatto[] menu)
        {
            StreamReader sr;
            int a = 0;
            try
            {
                sr = new StreamReader(@"./menu.txt");
            }
            catch
            {
                MessageBox.Show("file menu non trovato");
                Inizio.Visible = true;
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
                    //MessageBox.Show(menutemp[a]);
                    menu[contatore].tipologia = menutemp[a];
                    //MessageBox.Show(menu[contatore].tipologia);
                    a++;
                    cont++;
                }
            }
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
            }
        }
        public void ingredientiqualcosa(ref piatto nuovo, string[] menutemp)
        {
            nuovo.ingredienti = new string[numeroingredienti];
            for (int b = 0; b < numeroingredienti; b++)
            {
                nuovo.ingredienti[b] = menutemp[b];
            }
        }
        private void valoreradiobutton(RadioButton rdb, ref string valore)
        {
            if (rdb.Checked)
            {
                valore = rdb.Text;
            }
        }
        public void assegnaportata(ref string temp)
        {
            valoreradiobutton(antipasto, ref temp);
            valoreradiobutton(primo, ref temp);
            valoreradiobutton(secondo, ref temp);
            valoreradiobutton(dessert, ref temp);
        }
        private void ricerca(int zona, string str)
        {
            int a = 0;
            int controllo = 0;
            int posizione = 0;
            bool controlloeliminato = false;
            // MessageBox.Show(str);
            // MessageBox.Show(menu[0].prezzo);
            switch (zona)
            {
                default:
                    break;
                case 1:

                    for (a = 0; a < contatore; a++)
                    {
                        if (menu[a].nome == str)
                        {
                            /*MessageBox.Show(menu[a].nome);
                            MessageBox.Show(str);*/

                            checkeliminato(a, ref controlloeliminato);
                            if (controlloeliminato == true)
                            { controlloeliminato = false; }
                            else
                            {
                                temporaneo[controllo] = menu[a];
                                /*MessageBox.Show(menu[a].nome);
                                MessageBox.Show(menu[a].prezzo);
                                MessageBox.Show(menu[a].tipologia);
                                MessageBox.Show(temporaneo[controllo].nome);*/
                                tracciatore[controllo] = a;
                                contemp++;
                                if (controllo == 0)
                                { posizione = a; }
                                controllo++;
                            }
                        }
                    }
                    if (controllo == 0)
                    {
                        MessageBox.Show("Nessun piatto si chiama in questo modo");
                    }
                    else
                    {
                        if (ricercaomodifica == 0 || elimina == true)
                        {
                            disableintextbox();
                        }
                        if (ricercaomodifica == 1)
                            
                        { modificabutton.Visible = true; }
                        if (elimina == true)
                        { eliminabutton.Visible = true; }
                        veditextbox();

                        stampaintextbox(posizione);
                    }
                    break;
                case 2:
                    prezzoadeguato(ref str);
                    for (a = 0; a < contatore; a++)
                    {
                        if (menu[a].prezzo == str)
                        {
                            checkeliminato(a, ref controlloeliminato);
                            if (controlloeliminato == true)
                            { controlloeliminato = false; }
                            else
                            {
                                temporaneo[contemp] = menu[a];
                                tracciatore[contemp] = a;
                                contemp++;
                                if (controllo == 0)
                                { posizione = a; }
                                controllo++;
                            }
                        }
                    }
                    if (controllo == 0)
                    {
                        MessageBox.Show("Nessun piatto costa questo prezzo");
                    }
                    else
                    {
                        if (ricercaomodifica == 0 || elimina == true)
                        {
                            disableintextbox();
                        }
                        if (ricercaomodifica == 1)
                        { modificabutton.Visible = true; }
                        if (elimina == true)
                        { eliminabutton.Visible = true; }
                        veditextbox();
                        stampaintextbox(posizione);
                        successivo.Visible = true;
                        precedente.Visible = true;
                    }
                    break;
                case 3:
                    for (a = 0; a < contatore; a++)
                    {
                        for (int b = 0; b < numeroingredienti; b++)
                        {
                            if (menu[a].ingredienti[b] == str)
                            {
                                checkeliminato(a, ref controlloeliminato);
                                if (controlloeliminato == true)
                                { controlloeliminato = false; }
                                else
                                {
                                    temporaneo[contemp] = menu[a];
                                    tracciatore[contemp] = a;
                                    contemp++;
                                    if (controllo == 0)
                                    { posizione = a; }
                                    controllo++;
                                }
                            }
                        }
                    }
                    if (controllo == 0)
                    {
                        MessageBox.Show("Nessun piatto contiene questo ingrediente");
                    }
                    else
                    {
                        if (ricercaomodifica == 0 || elimina == true)
                        {
                            disableintextbox();
                        }
                        if (ricercaomodifica == 1)
                        { modificabutton.Visible = true; }
                        if (elimina == true)
                        { eliminabutton.Visible = true; }
                        veditextbox();

                        stampaintextbox(posizione);
                        successivo.Visible = true;
                        precedente.Visible = true;
                    }
                    break;
                case 4:
                    for (a = 0; a < contatore; a++)
                    {
                        if (menu[a].tipologia == str)
                        {
                            checkeliminato(a, ref controlloeliminato);
                            if (controlloeliminato == true)
                            { controlloeliminato = false; }
                            else
                            {
                                temporaneo[contemp] = menu[a];
                                tracciatore[contemp] = a;
                                contemp++;
                                if (controllo == 0)
                                { posizione = a; }
                                controllo++;
                            }
                        }
                    }
                    if (controllo == 0)
                    {
                        MessageBox.Show("Nessun piatto è di questa portata");
                    }
                    else
                    {
                        if (ricercaomodifica == 0 || elimina == true)
                        {
                            disableintextbox();
                        }
                        if (ricercaomodifica == 1)
                        { modificabutton.Visible = true; }
                        if (elimina == true)
                        { eliminabutton.Visible = true; }
                        veditextbox();
                        stampaintextbox(posizione);
                        successivo.Visible = true;
                        precedente.Visible = true;
                    }
                    break;
            }
            if (controllo > 0 && ricercaomodifica == 1)
            {
                modificabutton.Visible = true;
            }
            else
            {
                if (controllo > 0 && ricercaomodifica == 0)
                {
                    home.Visible = true;
                }
            }
            
        }
        public void ricompattazione()
        {
            if (contaeliminati > 0 || piattiaggiunti > 0)
            {
                string path = @"./menu.txt";
                string path2 = @"./tmp.txt";
                FileStream filename = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
                FileStream filename2 = new FileStream(path2, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None);
              
                StreamReader sr1 = new StreamReader(filename);
                StreamReader sr2 = new StreamReader(filename2);
                
                StreamWriter sw1 = new StreamWriter(filename);
                sw1.AutoFlush = true;
                StreamWriter sw2 = new StreamWriter(filename2);
                sw2.AutoFlush = true;

                string copy = "";
                int contsr = 0;
                int cnt = 0;
                while (!sr1.EndOfStream)
                {
                    copy = sr1.ReadLine();
                    if (eliminati[cnt] == contsr)
                    {
                        cnt++;
                    }
                    else
                    {
                        //MessageBox.Show(copy);
                        sw2.WriteLine(copy);
                    }
                    contsr++;
                }

                sr1.Close();
                sw2.Close();

                File.Delete(path);
                File.Move(path2, path);
                File.Create(path2);
            }
            else
            {

            }
        } //sistemare
        public void prezzoadeguato(ref string str)
        {
            string strcopy = str + "   ";
            bool controllo = false;
            char[] cr = strcopy.ToCharArray();
            char[] copy = new char[cr.Length + 3];
            if (cr[0] == '.')
            {
                copy[0] = '0';
                copy[1] = '.';
                int z = 2;
                string ss = cr[z].ToString();
                //MessageBox.Show(ss);
                controllo = string.IsNullOrEmpty(ss);
                if (controllo == true)
                {
                    cr[z] = '0';
                    cr[z + 1] = '0';
                    str = cr.ToString();
                    return;
                }
                else
                {
                    z++;
                    ss = cr[z].ToString();
                    controllo = string.IsNullOrEmpty(ss);
                    if (controllo == true)
                    {
                        cr[z] = '0';
                        str = cr.ToString();
                        return;
                    }
                }
            }
            for (int z = cr.Length; z < cr.Length; z++)
            {
                if (cr[z] == '.')
                {
                    z++;
                    string ss = cr[z].ToString();
                    controllo = string.IsNullOrEmpty(ss);
                    if (controllo == true)
                    {
                        cr[z] = '0';
                        cr[z + 1] = '0';
                        str = cr.ToString();
                        return;
                    }
                    else
                    {
                        z += 2;
                        ss = cr[z].ToString();
                        controllo = string.IsNullOrEmpty(ss);
                        if (controllo == true)
                        {
                            cr[z] = '0';
                            str = cr.ToString();
                            return;
                        }
                    }
                }
            }
        }
        public void selectionsort(int[] arr, int n)
        {
            int temp, smallest;
            for (int i = 0; i < n - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (arr[j] < arr[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }
        }


        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //   //
        private void home_Click(object sender, EventArgs e)
        {
            schermatahome();
        }
        private void logout_Click_1(object sender, EventArgs e)
        {
            selectionsort(eliminati, contaeliminati);
            ricompattazione();
            exit();
        }
        private void Inizio_Click_1(object sender, EventArgs e)
        {
            for (int q = 0; q < eliminati.Length; q++)
            {
                eliminati[q] = -1;
            }
            Inizio.Visible = false;           
            //caricamento menù nell'array
            lettura(ref contatore, menu);
            vedipulsanti();
        }
        private void Aggiunta_Click(object sender, EventArgs e)
        {
            veditextbox();
            nascondipulsanti();
            fatto.Visible = true;
            Aggiunta.Visible = true;
            Aggiunta.Enabled = false;
        }
        private void Modifica_Click(object sender, EventArgs e)
        {
            if (contatore == 0)
            { MessageBox.Show("Il menu è vuoto"); }
            else
            {
                nascondipulsanti();
                vedipulsantiricerca();
                home.Visible = true;
                ricercaomodifica = 1;
                Modifica.Enabled = false;
                Modifica.Visible = true;
            }
        }
        private void Ricerca_Click(object sender, EventArgs e)
        {
            if (contatore == 0)
            { MessageBox.Show("Il menu è vuoto"); }
            else
            {
                nascondipulsanti();
                vedipulsantiricerca();
                home.Visible = true;
                ricercaomodifica = 0;
                Ricerca.Enabled = false;
                Ricerca.Visible = true;
            }
        }
        private void sceltaricerca_Click(object sender, EventArgs e)
        {
            string str = "";
            int controllo = 0;
            valoreradiobutton(radioButtonNome, ref str);
            valoreradiobutton(radioButtonPrezzo, ref str);
            valoreradiobutton(radioButtonIngrediente, ref str);
            valoreradiobutton(radioButtonPortata, ref str);
            check(str, ref controllo);
            if (controllo == 0)
            {
                nascondipulsantiricerca();
                fattoricerca.Visible = true;
                cosacercare = 0;
                switch (str)
                {
                    default:
                        break;
                    case "Nome":
                        cosacercare = 1;
                        nome.Visible = true;
                        innome.Visible = true;
                        break;

                    case "Prezzo":
                        cosacercare = 2;
                        prezzo.Visible = true;
                        inprezzo.Visible = true;
                        break;

                    case "Ingrediente":
                        cosacercare = 3;
                        ingredienti.Visible = true;
                        iningredienti.Visible = true;
                        break;

                    case "Portata":
                        cosacercare = 4;
                        portata.Visible = true;
                        antipasto.Visible = true;
                        primo.Visible = true;
                        secondo.Visible = true;
                        dessert.Visible = true;
                        break;
                }
            }
            else
            {
                cosacercare = 0;
            }
        }
        private void fattoricerca_Click(object sender, EventArgs e)
        {
            string str = "";
            int controllo = 0;
            int zona = 0;

            switch (cosacercare)
            {
                default:
                    break;
                case 1:     //nome
                    str = innome.Text;
                    checkparola(str, ref controllo);
                    check(str, ref controllo);
                    if (controllo == 0)
                    {
                        zona = 1;
                        fattoricerca.Visible = false;
                        ricerca(zona, str);

                    }

                    break;
                case 2:     //prezzo
                    str = inprezzo.Text;
                    prezzoadeguato(ref str);
                    check(str, ref controllo);
                    if (controllo == 0)
                    {
                        zona = 2;
                        fattoricerca.Visible = false;
                        ricerca(zona, str);

                    }

                    break;
                case 3:     //ingrediente
                    str = iningredienti.Text;
                    check(str, ref controllo);
                    if (controllo == 0)
                    {
                        zona = 3;
                        fattoricerca.Visible = false;
                        ricerca(zona, str);

                    }

                    break;
                case 4:     //portata
                    assegnaportata(ref str);
                    check(str, ref controllo);
                    if (controllo == 0)
                    {
                        zona = 4;
                        fattoricerca.Visible = false;
                        ricerca(zona, str);

                    }

                    break;
            }
        }
        private void fatto_Click(object sender, EventArgs e)
        {
            piatto nuovo = new piatto();
            nuovo.ingredienti = new string[numeroingredienti];
            int control = 0;
            leggitextbox(ref nuovo, ref control);
            if (control == 0)
            {
                menu[contatore] = nuovo;
                contatore++;
                piattiaggiunti++;
                fatto.Visible = false;
                schermatahome();
            }
            else
            { }
        }
        private void successivo_Click(object sender, EventArgs e)
        {
            if (w < (contemp - 1))
            {
                stampaintextbox(tracciatore[contapagine]);
                contapagine++;
                w++;
            }
            else
            {
                MessageBox.Show("Fine della lista");
            }
        }
        private void precedente_Click(object sender, EventArgs e)
        {
            if (w > 0)
            {
                w--;
                stampaintextbox(tracciatore[contapagine]);
                contapagine--;
            }
            else
            {
                MessageBox.Show("Fine della lista");
            }
        }
        private void modificabutton_Click(object sender, EventArgs e)
        {
            int controllo = 0;
            piatto nuovo = new piatto();
            leggitextbox(ref nuovo, ref controllo);
            if (controllo == 0)
            {
                menu[tracciatore[contemp]] = nuovo;
            }
            else { }
        }
        private void Eliminazione_Click(object sender, EventArgs e)
        {
            if (contatore == 0)
            { MessageBox.Show("Il menu è vuoto"); }
            else
            {
                nascondipulsanti();
                vedipulsantiricerca();
                elimina = true;
                home.Visible = true;
                Eliminazione.Enabled = false;
                Eliminazione.Visible = true;
            }
        }
        private void eliminabutton_Click(object sender, EventArgs e)
        {
            for (int r = 0; r <= contaeliminati; r++)
            {
                //MessageBox.Show(eliminati[r].ToString());
                //MessageBox.Show(tracciatore[contapagine].ToString());
                if (eliminati[r] == tracciatore[contapagine])
                {
                    MessageBox.Show("Piatto già eliminato");
                }
                else
                {
                    eliminati[contaeliminati] = tracciatore[contapagine];                 
                    contatore--;
                    contaeliminati++;
                    return;
                }
            }
            
        }
        private void Ripristino_Click(object sender, EventArgs e)
        {
            if (contaeliminati < 1)
            { MessageBox.Show("Non ci sono piatti da ripristinare"); }
            else
            {
                veditextbox();
                nascondipulsanti();
                stampaintextbox(eliminati[0]);
                puntatoreattuale = 0;
                ripristinabutton.Visible = true;
                Ripristino.Visible = true;
                Ripristino.Enabled = false;
                successivo.Visible = true;
                precedente.Visible = true;
            }
        }
        private void ripristinabutton_Click(object sender, EventArgs e)
        {
            bool ripristinato = false;
            for (int r = 0; r < contaeliminati; r++)
            {
                if (eliminati[r] == tracciatore[puntatoreattuale])
                {
                    MessageBox.Show("Piatto ripristinato con successo");
                    int[] neweliminati = new int[300];
                    neweliminati = eliminati;
                    eliminati = new int[300];
                    for (int q = 0; q < contaeliminati; q++)
                    {
                        if (neweliminati[q] == tracciatore[puntatoreattuale])
                        {

                        }
                        else
                        {
                            eliminati[q] = neweliminati[q];
                        }
                    }
                    ripristinato = true;
                    contaeliminati--;
                    contatore++;
                    return;
                }
                else
                {

                }
            }
            if (ripristinato == false)
            {
                MessageBox.Show("Piatto già ripristinato");
            }
        }
        private void Fisicoelimina_Click(object sender, EventArgs e)
        {
            nascondipulsanti();
            if (contaeliminati > 1)
            {
                Fisicoelimina.Enabled = false;
                Fisicoelimina.Visible = true;
                vedifisicoelimina();
            }
            else
            {
                MessageBox.Show("Il cestino è già vuoto");
                schermatahome();
            }
        }
        private void fisicoeliminano_Click(object sender, EventArgs e)
        {
            schermatahome();
        }
        private void fisicoeliminasi_Click(object sender, EventArgs e)
        {
            ricompattazione();
            schermatahome();
        }

        private void primo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}