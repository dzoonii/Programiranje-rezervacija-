using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Projekat
{
    internal class Klasa
    {

        private string ime, adresa, jmbg;
        private DateTime datum_ulaska, datum_izlaska;
        public Klasa()
        {
            ime = "";
            adresa = "";
            jmbg = "";
        }

        public Klasa(string ime, string adresa, string jmbg, DateTime datum_ulaska, DateTime datum_izlaska)
        {
            this.ime = ime;
            this.adresa = adresa;
            this.jmbg = jmbg;
            this.datum_ulaska = datum_ulaska;
            this.datum_izlaska = datum_izlaska;

        }
        public string Ime
        {
            get { return ime; }
            set { ime = value; }
        }
        public string Adresa
        {
            get { return adresa; }
            set { adresa = value; }
        }
        public String Jmbg
        {
            get { return jmbg; }
            set
            {if (jmbg.Length == 13)
                {
                    jmbg = value;
                }
                else
                    throw new Exception("Pogresan unos jmbg");
            }
        }

        public DateTime Datum_ulaska
        {
            get { return datum_ulaska; }
            set { datum_ulaska = value; }
        }
        public DateTime Datum_Izlaska
        {
            get { return datum_izlaska; }
            set
            {   
                if ((datum_ulaska - datum_izlaska).Days < 0)
                {
                    datum_izlaska = value;
                }
                else
                {
                    throw new Exception("Datum izlaska mora biti veci od datuma ulaska");
                }

            }
        }
        public int Dani_ostanka()
        {
            return (datum_izlaska-datum_ulaska).Days;
        }
        public string Datumi()
        {
            return "Datum prijave: " + datum_ulaska.ToShortDateString() + "\r\n" + "Datum odjave: " + datum_izlaska.ToShortDateString();
        }
        public void Pisi(StreamWriter sw)
        {
            sw.WriteLine("Osoba: " + ime + " je iznajmila stan na adresi " + adresa);
            sw.WriteLine("Datum ulaska: " + datum_ulaska.ToShortDateString());
            sw.WriteLine("Datum izlaska: " + datum_izlaska.ToShortDateString());
            sw.WriteLine("Dani ostanka : " + Dani_ostanka() + " dana");
            sw.WriteLine("----------------------------------");
        }
        
    }
}
