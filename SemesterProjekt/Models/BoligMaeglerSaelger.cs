using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
                    throw new ArgumentException("BoligId is out of range");
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
                    throw new ArgumentException("Postalcode is out of range");
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
                if (value < 0 || value > 100000000)
                {
                    throw new ArgumentException("Price is out of range");
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
                    throw new ArgumentException("Square meter is out of range");
                }
            }
        }

        int kvmpris;
        public int KvmPris
        {
            get { return kvmpris; }
            set
            {
                if (value < 1000 || value > 250000)
                {
                    throw new ArgumentException();
                }
                kvmpris = value;
            }
        }

       
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
                if (value < 0 || value > 100000000)
                {
                    throw new ArgumentException("Price is out of range");
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
                if (value < new DateTime(1850, 01, 01) || value > new DateTime(2050, 01, 01))
                {
                    throw new ArgumentException("Date is out of range");
                }
                date = value;
            }
        }
  
        int maeglerid;
        public int MaeglerId
        {
            get
            {
                return maeglerid;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("ID is out of range");
                }
                maeglerid = value;
            }
        }

        int mid;
        public int MId
        {
            get
            {
                return mid;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("ID is out of range");
                }
                mid = value;
            }
        }

        string mfname;
        public string MFname 
        {
            get
            {
                return mfname;
            }
            set
            {
                if (value.Length < 2 || value.Length > 25)
                {
                    throw new ArgumentException("Firstname is out of range");
                }
                mfname = value;
            }
        }

        string mlname;
        public string MLname
        {
            get 
            { 
                return mlname;
            }
            set 
            { 
                if(value.Length < 2 || value.Length < 25)
                {
                    throw new ArgumentException("Lastname is out of range");
                }
                mlname = value;
            }
        }
        public bool MAktiv { get; set; }


        string memail;
        public string MEmail
        {
            get { return memail; }
            set
            {
                if (value.Length < 5 || !value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Email is not valid");
                }
                memail = value;
            }
        }


        int mtlfnr;
        public int MTlfNr
        {
            get { return mtlfnr; }
            set
            {
                if (value < 7 || value >= 10)
                {
                    throw new ArgumentException("Phonenumber is out of range");
                }
                mtlfnr = value;
            }
        }
        int afdeling;
        public int Afdeling 
        {
            get { return afdeling; }
            set
            {
                if (value < 0 || value >= 20)
                {
                    throw new ArgumentException("Afdeling number is not between 0 and 20");
                }
                afdeling = value;
            }
        }

        
        int sid;
        public int SId
        {
            get
            {
                return sid;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("ID is out of range");
                }
                sid = value;
            }
        }

        string sfname;
        public string SFname
        {
            get
            {
                return sfname;
            }
            set
            {
                if (value.Length < 2 || value.Length > 25)
                {
                    throw new ArgumentException("Firstname is out of range");
                }
                sfname = value;
            }
        }

        string slname;
        public string SLname
        {
            get
            {
                return slname;
            }
            set
            {
                if (value.Length < 2 || value.Length < 25)
                {
                    throw new ArgumentException("Lastname is out of range");
                }
                slname = value;
            }
        }
        
        int sboligid;
        public int SBoligId
        {
            get
            {
                return sboligid;
            }
            set
            {
                if (value < 0 || value > 10000)
                {
                    throw new ArgumentException("ID is out of range");
                }
                sboligid = value;
            }
        }
        
        string semail;
        public string SEmail
        {
            get { return semail; }
            set
            {
                if (value.Length < 5 || !value.Contains("@") || !value.Contains("."))
                {
                    throw new ArgumentException("Email is not valid");
                }
                semail = value;
            }
        }

        int stlfnr;
        public int STlfNr
        {
            get { return stlfnr; }
            set
            {
                if (value < 7 || value >= 10)
                {
                    throw new ArgumentException("Phonenumber is out of range");
                }
                stlfnr = value;
            }
        }
    }
}
