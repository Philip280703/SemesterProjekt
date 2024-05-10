using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.Models
{
    internal class Bolig
    {
        public int BoligId { get; set; }
        public string Adresse { get; set; }
        public int PostNr { get; set; }
        public int UdbudsPris { get; set; }
        public int Kvadratmeter { get; set; }
        public int KvmPris { get; set; }
        public int BoligType { get; set; }
        public bool Aktiv {  get; set; }
        public int SalgsPris { get; set; }
        public DateTime SalgsDato { get; set; }
        public int MaeglerId { get; set; }
    }
}
