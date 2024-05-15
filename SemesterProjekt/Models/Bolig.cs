using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class Bolig
    {
        private int boligId;
        public int BoligId
        {
            get
            {
                return boligId;
            }
            set
            {
                if (value <= 0 || value > 100001)
                {
                    throw new Exception("BoligId is out of range");
                }
                boligId = value;
            }
        }
        public string Adresse { get; set; }

        int postnr;
        public int PostNr
        {
            get
            {
                return postnr;
            }
            set
            {
                if (value < 1000 || value > 10000 )
                {
                    throw new Exception("Postalcode is out of range");
                }
                postnr = value;
            }
        }

        int udbudspris;
        public int UdbudsPris
        {
            get
            {
                return udbudspris;
            }
            set
            {
                if (value < 0 || value > 1000000001)
                {
                    throw new Exception("Price is out of range");
                }
                udbudspris = value;
            }
        }
        int kvadratmeter;
        public int Kvadratmeter
        {
            get
            {
                return kvadratmeter;
            }
            set
            {
                if (value < 30 || value > 1000)
                {
                    throw new Exception("Square meter is out of range");
                }
                kvadratmeter = value;
            }
        }

        public int KvmPris { get; set; }
        public string BoligType { get; set; }
        public bool Aktiv {  get; set; }

        int salgspris;
        public int SalgsPris
        {
            get
            {
                return salgspris;
            }
            set
            {
                if (value < 0 || value > 1000000001)
                {
                    throw new Exception("Price is out of range");
                }
                salgspris = value;
            }
        }
  

        DateTime date;
        public DateTime SalgsDato
        {
            get { return date; }
            set
            {
                if (value < new DateTime (01 - 01 - 1850) || value > new DateTime ( 01 - 01 - 2050))
                {
                    throw new Exception("Date is out of range");
                }
                date = value;
            }
        }
        public int MaeglerId { get; set; }
    }
}
