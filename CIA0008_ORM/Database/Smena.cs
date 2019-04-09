using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class Smena
    {
        public int ID_smeny { get; set; }
        public string Nazev { get; set; }

        public override string ToString()
        {
            return ID_smeny + " " + Nazev;
        }
    }
}
