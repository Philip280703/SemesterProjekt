using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class EjendomsMaegler
    {
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
                if (value.Length < 2 || value.Length < 25)
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
                    throw new ArgumentException("Phonenumber is not valid");
                }
            }
        }
        public int Afdeling {  get; set; }
    }
}
