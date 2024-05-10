using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class Kunde
    {
        public int KId { get; set; }
        public string KFname { get; set; }
        public string KLname { get; set; }
        public int KBoligId { get; set; }
        public string KEmail { get; set; }
        public int KTlfNr { get; set; }
    }
}
