using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class Tym
    {
        public int ID_tym { get; set; }
        public int ID_pracoviste { get; set; }
        public string Nazev { get; set; }
        public int Min_zamestnancu { get; set; }
        public DateTime Datum { get; set; }

        public override string ToString()
        {
            return ID_tym + " " + ID_pracoviste + " " + Nazev + " " + Min_zamestnancu + " " + Datum;
        }
    }
}
