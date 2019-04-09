using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class Pracoviste
    {
        public int ID_pracoviste { get; set; }
        public int? ID_nadrizenehoPracoviste { get; set; }
        public string Nazev { get; set; }

        public override string ToString()
        {
            return ID_pracoviste + " " + ID_nadrizenehoPracoviste + " " + Nazev;
        }
    }
}
