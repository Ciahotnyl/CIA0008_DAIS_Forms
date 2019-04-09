using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class TymZamestnance
    {
        public int ID_tymZamestnance { get; set; }
        public int ID_zamestnance { get; set; }
        public int ID_tym { get; set; }

        public override string ToString()
        {
            return ID_tymZamestnance + " " + ID_zamestnance + " " + ID_tym; 
        }
    }
}
