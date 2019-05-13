using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace bilgiguvenligi
{
   
    public partial class Form1 : Form
    {
        public Form1()
        { 
            InitializeComponent();  
        }
    private void Form1_Load(object sender, EventArgs e)
        {           
            comboBox1.Items.Add("Ceasar");
            comboBox1.Items.Add("Sütun");
            comboBox1.Items.Add("Çit");
            comboBox1.Items.Add("Polybius");
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Ceasar")
            {
                int anahtar = Convert.ToInt32(textBox3.Text);

                string sifrelimetin = textBox2.Text;

                string acikmetin = Ceasar_Decode(sifrelimetin, anahtar);
                
                textBox5.Text = acikmetin;
            }
            if (comboBox1.Text == "Çit")
            {
                string sifrelimetin = textBox2.Text;
                string acikmetin = Cit_Decode(sifrelimetin);
                textBox5.Text = acikmetin;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text=="Ceasar")
            {
                int anahtar = Convert.ToInt32(textBox3.Text);

                string acikmetin = textBox1.Text;
                                
                string sifrelimetin = Ceasar(acikmetin, anahtar);
                
                textBox2.Text = sifrelimetin;
            }
            if (comboBox1.Text == "Sütun")
            {
                string acikmetin1 = textBox1.Text;
                string acikmetin = acikmetin1.Replace(" ", "");
                int sutunsayi = Convert.ToInt32(textBox4.Text);

                string sifrelimetin = Sutun(acikmetin, sutunsayi);

                textBox2.Text = sifrelimetin;

                
            }
            if (comboBox1.Text == "Çit")
            {
                string acikmetin = textBox1.Text;
                String sifrelimetin = Cit(acikmetin);
                textBox2.Text = sifrelimetin; 
            }
            if (comboBox1.Text == "Polybius")
            {
                string acikmetin = textBox1.Text;

                String sifrelimetin = Polybius(acikmetin);

                textBox2.Text = sifrelimetin;
            }
        }
        //Fonksiyonlar

        public String Ceasar(String acikmetin, int anahtar)
        {
            String sifrelimetin = "";
            char[] chrText = acikmetin.ToCharArray();
            for (int i = 0; i < chrText.Length; i++)
            {
                sifrelimetin = sifrelimetin + (char)(chrText[i] + anahtar);
            }

            return sifrelimetin;
        }
        public String Ceasar_Decode(String sifrelimetin, int anahtar)
        {
            String acikmetin = "";
            char[] chrText = sifrelimetin.ToCharArray();
            for (int i = 0; i < chrText.Length; i++)
            {
                acikmetin = acikmetin + (char)(chrText[i] - anahtar);
            }
            return acikmetin;
        }

        public String Cit(String acikmetin)
        {
            char[] chrText = acikmetin.ToCharArray();
            string tek = "";
            string cift = "";
            for (int i = 0; i < chrText.Length; i += 2)
            {
                tek += chrText[i].ToString();
            }
            for (int i = 1; i < chrText.Length; i = i + 2)
            {
                cift += chrText[i].ToString();
            }
            String sifrelimetin = tek.ToString() + cift.ToString();

            return sifrelimetin;
        }
        public String Cit_Decode(String sifrelimetin)
        {
            string ilk = "", son = "", acikmetin = "", xx = "";
            if (sifrelimetin.Length % 2 == 0)
            {
                ilk = sifrelimetin.Substring(0, sifrelimetin.Length / 2);
                son = sifrelimetin.Substring(sifrelimetin.Length / 2);
                for (int i = 0; i < sifrelimetin.Length / 2; i++)
                {
                    acikmetin += ilk[i].ToString() + son[i].ToString();
                }
                return acikmetin;
            }
            else
            {
                ilk = sifrelimetin.Substring(0, (sifrelimetin.Length / 2) + 1);
                son = sifrelimetin.Substring((sifrelimetin.Length / 2) + 1);
                for (int i = 0; i < (sifrelimetin.Length / 2); i++)
                {
                    acikmetin += ilk[i].ToString() + son[i].ToString();
                }
                for (int i = 0; i < ilk.Length; i++)
                {
                    xx = ilk[i].ToString();
                }
                return acikmetin + xx;
            }
        }
        public String Sutun(String acikmetin, int sutunsayi)
        {

            string sifrelimetin = "";
            int sayac = 0;
            Random rnd = new Random();

            if(sutunsayi <= 0)
            {
                sifrelimetin = "Sütun Sayısı 0'dan büyük olmalıdır.";
                return sifrelimetin;
            }
            int matrisboy = 0;
            if (acikmetin.Length % sutunsayi != 0)
            {
                matrisboy = ((acikmetin.Length / sutunsayi) + 1) * sutunsayi;
            }
            int s1 = matrisboy - acikmetin.Length;
            if (matrisboy > acikmetin.Length)
            {
                for (int i = 0; i < s1; i++)
                {
                    int kod = rnd.Next(97, 122);
                    acikmetin += Convert.ToChar(kod);
                }
            }

            char[] chrText = acikmetin.ToCharArray();
            char[,] matris = new char[chrText.Length / sutunsayi, sutunsayi];


            for (int i = 0; i < chrText.Length / sutunsayi; i++)
            {
                for (int j = 0; j < sutunsayi; j++)
                {
                    matris[i, j] = chrText[sayac];
                    sayac++;
                }
            }
            for (int i = 0; i < sutunsayi; i++)
            {
                for (int j = 0; j < chrText.Length / sutunsayi; j++)
                {
                    sifrelimetin += matris[j, i];
                }
            }
            return sifrelimetin;
        }
        public String Polybius(String acikmetin)
        {
            string acikmetin1 = acikmetin.Replace("ç", "c").Replace("ö", "o").Replace("ü", "u").Replace("ı", "i");

            char[] chrText = acikmetin1.ToCharArray();

            string[] sifrelimetin = new string[2 * (chrText.Length)];

            string sonuc = "";

            int sayac = 0;

            char[,] matrisalfabe = new char[5, 5] { { 'a', 'b', 'c', 'd', 'e' },{'f','g','h','i','j' },
                                                {'k','l','m','n','o'},{'p','r','s','ş','t' },
                                                { 'u','ü','v','y','z' } };
            for (int k = 0; k < chrText.Length; k++)
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matrisalfabe[i, j] == chrText[k])
                        {
                            sifrelimetin[sayac] = Convert.ToString(i) + Convert.ToString(j);
                            sayac++;
                        }
                    }
                }
            }
            for (int i = 0; i < 2 * (chrText.Length); i++)
            {
                sonuc = sonuc + sifrelimetin[i] + " ";
            }
            sonuc = sonuc.Trim();
            return sonuc;    
        }
        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            textBox1.Focus();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
