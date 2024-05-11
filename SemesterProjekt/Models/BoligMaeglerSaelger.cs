using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class BoligMaeglerSaelger
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
                if (value < 1000 || value > 10000)
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
        public int Kvadratmeter { get; set; }
        public int KvmPris { get; set; }
        public string BoligType { get; set; }
        public bool Aktiv { get; set; }

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
        public DateTime SalgsDato { get; set; }
        public int MaeglerId { get; set; }

        public int MId { get; set; }
        public string MFname { get; set; }
        public string MLname { get; set; }
        public bool MAktiv { get; set; }
        public string MEmail { get; set; }
        public int MTlfNr { get; set; }

        public int SId { get; set; }
        public string SFname { get; set; }
        public string SLname { get; set; }
        public int SBoligId { get; set; }
        public string SEmail { get; set; }
        public int STlfNr { get; set; }
    }
}
