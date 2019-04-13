using CIA0008_ORM.Database;
using CIA0008_ORM.Database.SQLs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIA0008_ORM
{
    public partial class PrirazeniZamestnanceDoTymu : Form
    {
        public PrirazeniZamestnanceDoTymu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDatabase db = new MyDatabase();
            db.Connect();
            String Od = datum_od.Value.ToString("yyyy-MM-dd");
            String Do = datum_do.Value.ToString("yyyy-MM-dd");
            DateTime Datum_od = DateTime.Parse(Od);
            DateTime Datum_do = DateTime.Parse(Do);
            int vysledek = DateTime.Compare(Datum_od, Datum_do);
            if (vysledek > 0)
            {
                MessageBox.Show("Špatně zadaný rozsah: Od > Do");
                db.Close();
                return;
            }

            LoadTymy(Datum_od, Datum_do);

            db.Close();
        }
        public bool LoadTymy(DateTime Od, DateTime Do)
        {
            Collection<Tym> tymy = TymTable.VypisTymuZaUrciteObdobi(Od, Do);
            TymyLB.Items.Clear();
            foreach (Tym tym in tymy)
            {
                TymyLB.Items.Add(tym.ID_tym + " " + tym.Nazev + " " +tym.Datum);
            }
            return true;
        }
        public bool NacistVhodneZamestnance(int ID, DateTime Datum)
        {
            Collection<Zamestnanec> zamestnanci = ZamestnanecTable.VypisVhodnychZamestnancu(ID, Datum);
            ZamestnanciLB.Items.Clear();
            foreach (Zamestnanec zamestnanec in zamestnanci)
            {
                ZamestnanciLB.Items.Add(zamestnanec.ID_zamestnance + " " + zamestnanec.Jmeno + " " + zamestnanec.Prijmeni);
            }
            return true;
        }

        public bool NacistZamestnanceZTymu(int ID)
        {
            Collection<TymZamestnance> zamestnanci = TymZamestnanceTable.SeznamZamestnancuVTymu(ID);
            TymZamestnanceLB.Items.Clear();
            foreach (TymZamestnance zamestnanec in zamestnanci)
            {
                Zamestnanec z = ZamestnanecTable.Select(zamestnanec.ID_zamestnance);
                TymZamestnanceLB.Items.Add(z.ID_zamestnance + " " + z.Jmeno + " " + z.Prijmeni);
            }
            return true;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zaznam = TymyLB.GetItemText(TymyLB.SelectedItem);
            string[] casti = zaznam.Split(' ');
            int ID_tymu = int.Parse(casti[0]);
            DateTime DatumTymu = DateTime.Parse(casti[2]);
            NacistVhodneZamestnance(ID_tymu, DatumTymu);
            NacistZamestnanceZTymu(ID_tymu);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            string zaznam;
            string[] casti;
            int ID_zamestnance;

            string zaznam2;
            string[] casti2;
            int ID_tymu;

            MyDatabase db = new MyDatabase();
            db.Connect();

            if (TymyLB.Items.Count > 0 && TymyLB.SelectedIndex != -1)
            {
                zaznam2 = TymyLB.GetItemText(TymyLB.SelectedItem);
                casti2 = zaznam2.Split(' ');
                ID_tymu = int.Parse(casti2[0]);
                if (ZamestnanciLB.Items.Count > 0 && ZamestnanciLB.SelectedIndex != -1)
                {
                    zaznam = ZamestnanciLB.GetItemText(ZamestnanciLB.SelectedItem);
                    casti = zaznam.Split(' ');
                    ID_zamestnance = int.Parse(casti[0]);


                    TymZamestnance tz = new TymZamestnance();
                    tz.ID_zamestnance = ID_zamestnance;
                    tz.ID_tym = ID_tymu;
                    TymZamestnanceTable.Insert(tz, db);
                    DateTime DatumTymu = DateTime.Parse(casti2[2]);

                    NacistVhodneZamestnance(ID_tymu, DatumTymu);
                    NacistZamestnanceZTymu(ID_tymu);

                    db.Close();
                }
                else
                {
                    MessageBox.Show("Nebyl vybrán zaměstnanec, kterého chcete přidat do týmu");
                    db.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nebyl vybrán tým, na který chcete přidat zaměstnance");
                db.Close();
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string zaznam = TymZamestnanceLB.GetItemText(TymZamestnanceLB.SelectedItem);
            string[] casti = zaznam.Split(' ');
            int ID_zamestnance = int.Parse(casti[0]);

            string zaznam2 = TymyLB.GetItemText(TymyLB.SelectedItem);
            string[] casti2 = zaznam2.Split(' ');
            int ID_tymu = int.Parse(casti2[0]);

            MyDatabase db = new MyDatabase();
            db.Connect();

            if (TymyLB.Items.Count > 0 && TymyLB.SelectedIndex != -1)
            {
                zaznam2 = TymyLB.GetItemText(TymyLB.SelectedItem);
                casti2 = zaznam2.Split(' ');
                ID_tymu = int.Parse(casti2[0]);

                if (TymZamestnanceLB.Items.Count > 0 && TymZamestnanceLB.SelectedIndex != -1)
                {
                    zaznam = TymyLB.GetItemText(TymyLB.SelectedItem);
                    casti = zaznam2.Split(' ');
                    ID_zamestnance = int.Parse(casti2[0]);

                    TymZamestnance tz = new TymZamestnance();
                    tz.ID_zamestnance = ID_zamestnance;
                    tz.ID_tym = ID_tymu;

                    TymZamestnanceTable.DeleteJednohoZamestnance(ID_zamestnance, ID_tymu, db);
                    DateTime DatumTymu = DateTime.Parse(casti2[2]);

                    NacistVhodneZamestnance(ID_tymu, DatumTymu);
                    NacistZamestnanceZTymu(ID_tymu);

                    db.Close();
                }
                else
                {
                    MessageBox.Show("Nebyl vybrán zaměstnanec, kterého chcete odstranit z týmu");
                    db.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nebyl vybrán tým, na kterém chcete odebrat zaměstnance");
                db.Close();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
