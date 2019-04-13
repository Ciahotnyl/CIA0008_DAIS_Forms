using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database
{
    class SmenaTymu
    {
        public int ID_smenyTymu { get; set; }
        public int ID_smeny { get; set; }
        public int ID_tym { get; set; }

        public override string ToString()
        {
            return ID_smenyTymu + " " + ID_smeny + " " + ID_tym;
        }
    }
}
