using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class EjendomsMaegler
    {
        public int MId { get; set; }
        public string MFname { get; set; }
        public string MLname { get; set; }
        public bool MAktiv { get; set; }
        public string MEmail { get; set; }
        public int MTlfNr { get; set; }
        public int Afdeling {  get; set; }
    }
}
