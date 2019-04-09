using System;
using CIA0008_ORM.Database;
using CIA0008_ORM.Database.SQLs;


namespace CIA0008_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();
            db.Connect();
            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");
            //Testy pro tabulku 1. Zamestnanec
            Console.WriteLine("\nTest tabulky Zamestnanec:");
            Smena sm = new Smena();
            sm.ID_smeny = SmenaTable.SelectMaxID(db);

            Zamestnanec zamestnanec = new Zamestnanec();
            zamestnanec.ID_smeny = sm.ID_smeny;
            zamestnanec.Jmeno = "Lukas";
            zamestnanec.Prijmeni = "Ciahotny";
            zamestnanec.Narozeniny = new DateTime(2000, 1, 1);
            zamestnanec.Nastupni_den = DateTime.Now;
            zamestnanec.Mistr = true;
            zamestnanec.Login = "CIA01";
            zamestnanec.Heslo = "abc";
            zamestnanec.Zbyva_dovolenych = 50;


            //1.1
            ZamestnanecTable.Insert(zamestnanec, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            zamestnanec.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));  //Select nad vybranym zaznamem
            zamestnanec.Jmeno = "Petr";
            zamestnanec.Prijmeni = "Novak";
            zamestnanec.Narozeniny = new DateTime(2001, 1, 1);
            zamestnanec.Nastupni_den = DateTime.Now;
            zamestnanec.Mistr = false;
            zamestnanec.Login = "NOV01";
            zamestnanec.Heslo = "cba";
            zamestnanec.Zbyva_dovolenych = 25;

            //1.2
            ZamestnanecTable.Update(zamestnanec, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));  //Overeni funkcnosti Update

            //1.3
            ZamestnanecTable.Delete(zamestnanec.ID_zamestnance);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));  //Overeni smazani

            //1.4
            Console.WriteLine("\nVypis vsech zamestnancu:");
            foreach (Zamestnanec z in ZamestnanecTable.Select(db))
                Console.WriteLine(z);


            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 2. Dovolena
            Console.WriteLine("\nTest tabulky Dovolena:");

            Smena s2 = new Smena();
            s2.Nazev = "Smena pro dovolenou";
            SmenaTable.Insert(s2, db);

            Zamestnanec z2 = new Zamestnanec();
            z2.ID_smeny = sm.ID_smeny;
            z2.Jmeno = "Lukas";
            z2.Prijmeni = "Ciahotny";
            z2.Narozeniny = new DateTime(2000, 1, 1);
            z2.Nastupni_den = DateTime.Now;
            z2.Mistr = true;
            z2.Login = "CIA01";
            z2.Heslo = "abc";
            z2.Zbyva_dovolenych = 50;
            z2.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
            ZamestnanecTable.Insert(z2, db);

            Duvod d2 = new Duvod();
            d2.Nazev = "Dovolena";
            DuvodTable.Insert(d2, db);

            s2.ID_smeny = SmenaTable.SelectMaxID(db);
            z2.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
            d2.ID_duvodu = DuvodTable.SelectMaxID(db);


            Dovolena dov2 = new Dovolena();
            dov2.ID_zamestnance = z2.ID_zamestnance;
            dov2.ID_duvodu = d2.ID_duvodu;
            dov2.Od = DateTime.Now;
            dov2.Do = new DateTime(2020, 1, 1);

            //2.1
            DovolenaTable.Insert(dov2, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            dov2.ID_dovolene = DovolenaTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + DovolenaTable.Select(dov2.ID_dovolene));  //Select nad vybranym zaznamem

            dov2.ID_zamestnance = z2.ID_zamestnance;
            dov2.ID_duvodu = d2.ID_duvodu;
            dov2.Od = new DateTime(2021, 1, 1);
            dov2.Do = new DateTime(2022, 1, 1);
            //2.2
            DovolenaTable.Update(dov2, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + DovolenaTable.Select(dov2.ID_dovolene));  //Overeni funkcnosti Update

            //2.3
            DovolenaTable.Delete(dov2.ID_dovolene);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + DovolenaTable.Select(dov2.ID_dovolene));  //Overeni smazani

            //2.4
            Console.WriteLine("\nVypis vsech dovolenych:");
            foreach (Dovolena d in DovolenaTable.Select(db))
                Console.WriteLine(d);

            SmenaTable.Delete(s2.ID_smeny);
            DuvodTable.Delete(d2.ID_duvodu);
            ZamestnanecTable.Delete(z2.ID_zamestnance);


            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 3. Tym
            Console.WriteLine("\nTest tabulky Tym:");

            Pracoviste p3 = new Pracoviste();
            p3.ID_nadrizenehoPracoviste = null;
            p3.Nazev = "Pracoviste pro Tym";
            PracovisteTable.Insert(p3, db);

            p3.ID_pracoviste = PracovisteTable.SelectMaxID(db);


            Tym t3 = new Tym();
            t3.ID_pracoviste = p3.ID_pracoviste;
            t3.Nazev = "Pracoviste";
            t3.Min_zamestnancu = 3;
            t3.Datum = DateTime.Now;

            //2.1
            TymTable.Insert(t3, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            t3.ID_tym = TymTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + TymTable.Select(t3.ID_tym));  //Select nad vybranym zaznamem

            t3.ID_pracoviste = p3.ID_pracoviste;
            t3.Nazev = "Zmenene pracoviste";
            t3.Min_zamestnancu = 2;
            t3.Datum = new DateTime(2020, 1, 1);
            //2.2
            TymTable.Update(t3, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + TymTable.Select(t3.ID_tym));  //Overeni funkcnosti Update

            //2.3
            TymTable.Delete(t3.ID_tym);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + TymTable.Select(t3.ID_tym));  //Overeni smazani

            //2.4
            Console.WriteLine("\nVypis vsech dovolenych:");
            foreach (Tym t in TymTable.Select(db))
                Console.WriteLine(t);

            TymTable.Delete(p3.ID_pracoviste);


            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 4. Smena
            Console.WriteLine("\nTest tabulky Smena:");
            Smena smena = new Smena();
            smena.Nazev = "Testik";

            //4.1
            SmenaTable.Insert(smena, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            smena.ID_smeny = SmenaTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + SmenaTable.Select(smena.ID_smeny));  //Select nad vybranym zaznamem
            smena.Nazev = "Zmeneny nazev";

            //4.2
            SmenaTable.Update(smena, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + SmenaTable.Select(smena.ID_smeny));  //Overeni funkcnosti Update

            //4.3
            SmenaTable.Delete(smena.ID_smeny);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + SmenaTable.Select(smena.ID_smeny));  //Overeni smazani

            //4.4
            Console.WriteLine("\nVypis vsech smen:");
            foreach (Smena s in SmenaTable.Select(db))
                Console.WriteLine(s);

            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 4. Duvod
            Console.WriteLine("\nTest tabulky Duvod:");
            Duvod duvod = new Duvod();
            duvod.Nazev = "Testik";

            //4.1
            DuvodTable.Insert(duvod, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            duvod.ID_duvodu = DuvodTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + DuvodTable.Select(duvod.ID_duvodu));  //Select nad vybranym zaznamem
            duvod.Nazev = "Zmeneny nazev";

            //4.2
            DuvodTable.Update(duvod, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + DuvodTable.Select(duvod.ID_duvodu));  //Overeni funkcnosti Update

            //4.3
            DuvodTable.Delete(duvod.ID_duvodu);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + DuvodTable.Select(duvod.ID_duvodu));  //Overeni smazani

            //4.4
            Console.WriteLine("\nVypis vsech duvodu:");
            foreach (Duvod d in DuvodTable.Select(db))
                Console.WriteLine(d);

            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 7. Pozice

            Console.WriteLine("\nTest tabulky Pozice:");
            Pozice pozice = new Pozice();
            pozice.Nazev = "Testik_pozice";

            //7.1
            PoziceTable.Insert(pozice, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");
            pozice.ID_pozice = PoziceTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + PoziceTable.Select(pozice.ID_pozice));  //Select nad vybranym zaznamem
            pozice.Nazev = "Zmeneny nazev";

            //7.2
            PoziceTable.Update(pozice, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + PoziceTable.Select(pozice.ID_pozice));  //Overeni funkcnosti Update

            //7.3
            PoziceTable.Delete(pozice.ID_pozice);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + PoziceTable.Select(pozice.ID_pozice));  //Overeni smazani

            //7.4
            Console.WriteLine("\nVypis vsech Pozic:");
            foreach (Pozice p in PoziceTable.Select(db))
                Console.WriteLine(p);

            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 9. Pracoviste

            Console.WriteLine("\nTest tabulky Pracoviste:");
            Pracoviste pracoviste = new Pracoviste();
            pracoviste.ID_nadrizenehoPracoviste = null;
            pracoviste.Nazev = "Testik_pracoviste";

            //9.1
            PracovisteTable.Insert(pracoviste, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");

            pracoviste.ID_pracoviste = PracovisteTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));  //Select nad vybranym zaznamem
            pracoviste.ID_nadrizenehoPracoviste = null;
            pracoviste.Nazev = "Zmeneny nazev";

            //9.2
            PracovisteTable.Update(pracoviste, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));  //Overeni funkcnosti Update

            //9.3
            PracovisteTable.Delete(pracoviste.ID_pracoviste);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));  //Overeni smazani

            //9.4
            Console.WriteLine("\nVypis vsech pracovist:");
            foreach (Pracoviste p in PracovisteTable.Select(db))
                Console.WriteLine(p);

            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            //Testy pro tabulku 6. PoziceZamestnance

            Console.WriteLine("\nTest tabulky poziceZamestnance:");

            Pozice p6 = new Pozice();
            p6.Nazev = "Pozice pro PoziceZamestnance";
            PoziceTable.Insert(p6, db);

            Zamestnanec z6 = new Zamestnanec();
            z6.ID_smeny = sm.ID_smeny;
            z6.Jmeno = "Lukas";
            z6.Prijmeni = "Ciahotny";
            z6.Narozeniny = new DateTime(2000, 1, 1);
            z6.Nastupni_den = DateTime.Now;
            z6.Mistr = true;
            z6.Login = "CIA01";
            z6.Heslo = "abc";
            z6.Zbyva_dovolenych = 50;
            z6.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
            ZamestnanecTable.Insert(z2, db);

            p6.ID_pozice = PoziceTable.SelectMaxID(db);
            z6.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);

            PoziceZamestnance pz = new PoziceZamestnance();
            pz.ID_zamestnance = z6.ID_zamestnance;
            pz.ID_pozice = p6.ID_pozice;

            //6.1
            PoziceZamestnanceTable.Insert(pz, db);                                   //Insert noveho zaznamu

            Console.WriteLine("\nTest select, update, delete:");

            pz.ID_poziceZamestnance = PoziceZamestnanceTable.SelectMaxID(db);                   //Nalezeni ID nove pridaneho zaznamu
            Console.WriteLine("Select:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));
                                                                                                 //Select nad vybranym zaznamem
            //6.2
            PoziceZamestnanceTable.Update(pz, db);                                   //Update vybraneho zaznamu
            Console.WriteLine("Update:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));  //Overeni funkcnosti Update

            //6.3
            PoziceZamestnanceTable.Delete(pz.ID_poziceZamestnance);                                   //Smazani zaznamu z databaze
            Console.WriteLine("Delete:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));  //Overeni smazani

            //6.4
            Console.WriteLine("\nVypis vsech pozic zamestnancu:");
            foreach (PoziceZamestnance p in PoziceZamestnanceTable.Select(db))
                Console.WriteLine(p);

            Console.WriteLine("\n--------------------------------------------------------------------------------------------\n");

            db.Close();

            Console.ReadKey();
        }
    }
}
