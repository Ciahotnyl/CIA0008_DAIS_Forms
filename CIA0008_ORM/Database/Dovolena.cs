using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class Dovolena
    {
        public int ID_dovolene { get; set; }
        public int ID_zamestnance { get; set; }
        public int ID_duvodu { get; set; }
        public DateTime Od { get; set; }
        public DateTime Do { get; set; }

        public override string ToString()
        {
            return ID_dovolene + " " + ID_zamestnance + " " + ID_duvodu + " " + Od + " " + Do;
        }
    }
}
