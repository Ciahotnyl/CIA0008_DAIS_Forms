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
    public partial class TymyForm : Form
    {
        public TymyForm()
        {
            InitializeComponent();
            if(SmenyCB.SelectedIndex == -1)
            {
                FillSmeny();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            String Od = datum_od.Value.ToString("yyyy-MM-dd");
            String Do = datum_do.Value.ToString("yyyy-MM-dd");
            DateTime Datum_od = DateTime.Parse(Od);
            DateTime Datum_do = DateTime.Parse(Do);

            int vysledek = DateTime.Compare(Datum_od, Datum_do);
            if (vysledek > 0)
            {
                MessageBox.Show("Špatně zadaný rozsah: Od > Do");
                return;
            }

            MyDatabase db = new MyDatabase();
            db.Connect();

            LoadTymy(Datum_od, Datum_do);

            db.Close();
            
        }

        private void NovyTymButton_Click(object sender, EventArgs e)
        {
            NovyTym nt = new NovyTym();
            nt.ShowDialog(this);
        }
        public bool LoadTymy(DateTime Od, DateTime Do)
        {
            Collection<Tym> tymy = TymTable.VypisTymuZaUrciteObdobi(Od, Do);

            foreach (Tym tym in tymy)
            {
                listBox1.Items.Add(tym.ID_tym + " - " +tym.Nazev);
            }
            return true;
        }

        public void FillSmeny()
        {
            MyDatabase db = new MyDatabase();
            db.Connect();

            Collection<Smena> smeny = SmenaTable.Select(db);
            foreach(Smena s in smeny)
            {
                SmenyCB.Items.Add(s.ID_smeny +" - "+s.Popis);
            }
            db.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zaznam;
            string[] casti;
            int ID_tymu;
            string NovyNazev;
            string zaznamZComboBoxu;
            string[] cast;
            int ID_smeny;
            String Datum_kopie;
            DateTime NovyDatum;

            MyDatabase db = new MyDatabase();
            db.Connect();

            if (listBox1.Items.Count > 0 && listBox1.SelectedIndex != -1)
            {
                zaznam = listBox1.GetItemText(listBox1.SelectedItem);
                casti = zaznam.Split(' ');
                ID_tymu = int.Parse(casti[0]);
                if(NazevTB.Text != "" && !NazevTB.Text.Contains(" "))
                {
                    NovyNazev = NazevTB.Text;
                    if(SmenyCB.SelectedIndex  != -1)
                    {
                        zaznamZComboBoxu = SmenyCB.SelectedItem.ToString();
                        cast = zaznamZComboBoxu.Split(' ');
                        ID_smeny = int.Parse(casti[0]);

                        Datum_kopie = DatumKopie.Value.ToString("yyyy-MM-dd");
                        NovyDatum = DateTime.Parse(Datum_kopie);
                        TymTable.VytvoreniKopieTymu(ID_tymu, NovyDatum, NovyNazev, ID_smeny);
                        MessageBox.Show("Byl vytvořen nový tým s názvem: " + NovyNazev + " a pro datum: " + NovyDatum);
                        db.Close();
                    }
                    else
                    {
                        MessageBox.Show("Nebyla vybrána žádná směna, na kterou se má přiřadit okopírovaný tým");
                        db.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Nebylo vyplněno pole pro název okopírovaného týmu nebo název obsahuje mezery");
                    db.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nebyl vybrán tým, na který chcete vytvořit kopii týmu");
                db.Close();
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrirazeniZamestnanceDoTymu pzdt = new PrirazeniZamestnanceDoTymu();
            pzdt.ShowDialog(this);
        }
    }
}
