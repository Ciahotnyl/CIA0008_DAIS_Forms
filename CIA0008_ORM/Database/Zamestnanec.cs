using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class Zamestnanec
    {
        public int ID_zamestnance { get; set; }
        public string Jmeno { get; set; }
        public string Prijmeni { get; set; }
        public DateTime Narozeniny { get; set; }
        public DateTime Nastupni_den { get; set; }
        public Boolean Mistr { get; set; }
        public string Login { get; set; }
        public string Heslo { get; set; }
        public int Zbyva_dovolenych { get; set; }
        public object info { get; set; }
        
        public override string ToString()
        {
            //return ID_zamestnance + " " + Jmeno + " " + Prijmeni + " " + Narozeniny + " " + Nastupni_den + " " + Mistr + " " + Login + " " + Heslo + " " + Zbyva_dovolenych + (info == null? "":info.ToString());
            return ID_zamestnance + " " + Jmeno + " " + Prijmeni + " " + (info == null ? "" : info.ToString());
        }
        
    }
}
