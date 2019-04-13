using CIA0008_ORM.Database;
using CIA0008_ORM.Database.SQLs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CIA0008_ORM
{
    public partial class NovyTym : Form
    {
        public NovyTym()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MyDatabase db = new MyDatabase();
            db.Connect();

            String DatumTymu;
            DateTime datum;
            String NazevTymu;
            int Minimalne_zamestnancu;
            int ID_pracoviste;
            if (ID_prac.Text != "")
            {
                if(Int32.TryParse(ID_prac.Text, out ID_pracoviste))
                {
                    if (ID_pracoviste > 0)
                    {
                        if (Min_zamestnancu.Text != "")
                        {
                            if (Int32.TryParse(Min_zamestnancu.Text, out Minimalne_zamestnancu))
                            {
                                if (int.Parse(Min_zamestnancu.Text) >= 1)
                                {
                                    NazevTymu = Nazev_tymu.Text;
                                    if (NazevTymu != "" && !NazevTymu.Contains(" "))
                                    {
                                        DatumTymu = Datum.Value.ToString("yyyy-MM-dd");
                                        datum = DateTime.Parse(DatumTymu);
                                        Tym t = new Tym();

                                        t.ID_pracoviste = ID_pracoviste;
                                        t.Min_zamestnancu = Minimalne_zamestnancu;
                                        t.Nazev = NazevTymu;
                                        t.Datum = datum;

                                        TymTable.Insert(t, db);
                                        MessageBox.Show("Nový tým byl vytvořen");

                                        db.Close();
                                        this.Close();
                                    }
                                    else
                                    {
                                        MessageBox.Show("Nebylo vyplněno pole pro název týmu nebo název obsahuje mezery");
                                        db.Close();
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Nejméně může být v týmu jeden zaměstnanec");
                                    db.Close();
                                    return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Minimální počet zaměstnanců musí být číslo");
                                db.Close();
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("Nebylo vyplněno pole minimální počet zaměstnanců na týmu");
                            db.Close();
                            return;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ID pracoviště nesmí být menší nebo rovné 0");
                        db.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("ID pracoviště musí být číslo");
                    db.Close();
                    return;
                }
            }
            else
            {
                MessageBox.Show("Nebylo vyplněno pole pro ID pracoviště");
                db.Close();
                return;
            }             
        }

        private void ZpetBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
