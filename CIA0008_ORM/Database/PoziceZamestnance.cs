using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class PoziceZamestnance
    {
        public int ID_poziceZamestnance { get; set; }
        public int ID_zamestnance { get; set; }
        public int ID_pozice { get; set; }

        public override string ToString()
        {
            return ID_poziceZamestnance + " " + ID_zamestnance + " " + ID_pozice;
        }
    }
}
