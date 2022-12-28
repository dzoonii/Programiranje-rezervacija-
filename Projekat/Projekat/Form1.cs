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
using System.IO;

namespace Projekat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public static string SetValueForText1 = "";

        private void kljucToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 forma2 = new Form2();
            forma2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           kljucToolStripMenuItem.Enabled = false;
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form3 forma3 = new Form3();
            forma3.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            StreamWriter sw = new StreamWriter("stanovi.txt", true);
            try
            {
                if (textBox1.Text=="" || textBox2.Text =="" || comboBox1.Text=="")
                {
                    throw new Exception("Sva polja moraju biti popunjena");
                }
                else
                {
                    ArrayList lista = new ArrayList();
                    //List<Klasa> lista = new List<Klasa>();
                    Klasa k = new Klasa();

                    string ime = textBox1.Text;
                    string jmbg = textBox2.Text;
                    string adresa = comboBox1.SelectedItem.ToString();
                    DateTime datum_ulaska = monthCalendar1.SelectionStart;
                    DateTime datum_izlaska = monthCalendar2.SelectionStart;
                    lista.Add(k);
                    k = new Klasa(ime, adresa, jmbg, datum_ulaska, datum_izlaska);
                    k.Pisi(sw);

                    textBox1.Text = textBox2.Text = comboBox1.Text = "";
                    
                    textBox1.Focus();
                    sw.Close();
                    SetValueForText1 = jmbg.ToString();
                    kljucToolStripMenuItem.Enabled = true;
                }
            }
            catch
            {
                MessageBox.Show("Pogresan unos", "Error");
            }

        }
    }
}
