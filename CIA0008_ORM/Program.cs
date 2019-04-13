using System;
using CIA0008_ORM.Database;
using CIA0008_ORM.Database.SQLs;
using System.Windows.Forms;


namespace CIA0008_ORM
{
    class Program
    {
        static void Main(string[] args)
        {
            MyDatabase db = new MyDatabase();
            db.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TymyForm());
            /*        
                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                        //Testy pro tabulku 1. Zamestnanec
                        Console.WriteLine("\nTest tabulky Zamestnanec:");
                        Smena sm = new Smena();
                        sm.ID_smeny = SmenaTable.SelectMaxID(db);

                        Zamestnanec zamestnanec = new Zamestnanec();
                        zamestnanec.Jmeno = "Lukas";
                        zamestnanec.Prijmeni = "Ciahotny";
                        zamestnanec.Narozeniny = new DateTime(2000, 1, 1);
                        zamestnanec.Nastupni_den = DateTime.Now;
                        zamestnanec.Mistr = true;
                        zamestnanec.Login = "CIA01";
                        zamestnanec.Heslo = "abc";
                        zamestnanec.Zbyva_dovolenych = 50;

                        //Netriviální funkce
                        //1.1
                        ZamestnanecTable.VlozeniNovehoZamestnance(zamestnanec.Jmeno, zamestnanec.Prijmeni, zamestnanec.Nastupni_den, zamestnanec.Mistr, zamestnanec.Heslo, "Pozice_A");                                

                        Console.WriteLine("\nTest select, update, delete:");
                        zamestnanec.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);                   
                        Console.WriteLine("Select:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));  
                        zamestnanec.Jmeno = "Petr";
                        zamestnanec.Prijmeni = "Novak";
                        zamestnanec.Narozeniny = new DateTime(2001, 1, 1);
                        zamestnanec.Nastupni_den = DateTime.Now;
                        zamestnanec.Mistr = false;
                        zamestnanec.Login = "NOV01";
                        zamestnanec.Heslo = "cba";
                        zamestnanec.Zbyva_dovolenych = 25;

                        //1.b - Výpis zaměstnance a všech jeho dovolených s počtem dnů za poslední rok
                        Console.WriteLine("\nVypis zaměstnance a všech jeho dovolených s počtem dnů za poslední rok:");
                        foreach (Zamestnanec z in ZamestnanecTable.VypisDovolenycZamestnceZaPosledniRok(db))
                            Console.WriteLine(z);

                        //1.c - Výpis zaměstnanců, kteří jsou vhodní k přidání do týmu
                        Console.WriteLine("\nVypis vsech vhodnych zamestnancu:");
                        foreach (Zamestnanec z in ZamestnanecTable.VypisVhodnychZamestnancu(2, new DateTime(2002, 1, 2), db))
                            Console.WriteLine(z.Jmeno.ToString(), z.Prijmeni, z.info);

                        //1.d - Aktualizace zaměstnance
                        ZamestnanecTable.Update(zamestnanec, db);                                 
                        Console.WriteLine("Update:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));
                        //1.e - Detail zaměstnance podle ID
                        Console.WriteLine("DetailZamestnance:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));

                        ZamestnanecTable.Insert(zamestnanec, db);
                        zamestnanec.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
                        //1.f - Smazání zaměstnance
                        ZamestnanecTable.Delete(zamestnanec.ID_zamestnance);                                   
                        Console.WriteLine("Delete:\t" + ZamestnanecTable.Select(zamestnanec.ID_zamestnance));  

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        //Testy pro tabulku 2. Dovolena
                        Console.WriteLine("\nTest tabulky Dovolena:");

                        Zamestnanec z2 = new Zamestnanec();
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

                        z2.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
                        d2.ID_duvodu = DuvodTable.SelectMaxID(db);


                        Dovolena dov2 = new Dovolena();
                        dov2.ID_zamestnance = z2.ID_zamestnance;
                        dov2.ID_duvodu = d2.ID_duvodu;
                        dov2.Od = DateTime.Now;
                        dov2.Do = new DateTime(2020, 1, 1);

                        //Netriviální funkce
                        //2.a - Vložení nové dovolené
                        DovolenaTable.VlozeniNoveDovolene(1, new DateTime(2020, 1, 1), new DateTime(2020, 1, 5), 2); 
                        //DovolenaTable.Insert(dov2, db);                                  

                        Console.WriteLine("\nTest select, update, delete:");

                        //2.c - Detail dovolené
                        dov2.ID_dovolene = DovolenaTable.SelectMaxID(db);
                        Console.WriteLine("DetailDovolene:\t" + DovolenaTable.Select(dov2.ID_dovolene));

                        //2.d - Seznam dovolených podle časového období
                        foreach (Dovolena d in DovolenaTable.VypisDovolenychZaUrciteObdobi(new DateTime(2000, 1, 1), new DateTime(2020, 1, 1), db))
                            Console.WriteLine(d);

                        //2.e - Aktualizace dovolené
                        dov2.ID_zamestnance = z2.ID_zamestnance;
                        dov2.ID_duvodu = d2.ID_duvodu;
                        dov2.Od = new DateTime(2021, 1, 1);
                        dov2.Do = new DateTime(2022, 1, 1);
                        DovolenaTable.Update(dov2, db);                                   
                        Console.WriteLine("Update:\t" + DovolenaTable.Select(dov2.ID_dovolene));  

                        //2.b - Smazání dovolené
                        DovolenaTable.Delete(dov2.ID_dovolene);                                  
                        Console.WriteLine("Delete:\t" + DovolenaTable.Select(dov2.ID_dovolene));  

                        DuvodTable.Delete(d2.ID_duvodu);
                        ZamestnanecTable.Delete(z2.ID_zamestnance);


                        Console.WriteLine("--------------------------------------------------------------------------------------------");

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

                        Smena s3 = new Smena();
                        s3.Popis = "Smena pro Tym";
                        SmenaTable.Insert(s3, db);
                        s3.ID_smeny = SmenaTable.SelectMaxID(db);

                        //3.b - Vytvoření nového týmu
                        TymTable.Insert(t3, db);
                        t3.ID_tym = TymTable.SelectMaxID(db);                         

                        Console.WriteLine("\nTest select, update, delete:");

                        //3.d - Detail tymu
                        t3.ID_tym = TymTable.SelectMaxID(db);                   
                        Console.WriteLine("Select:\t" + TymTable.Select(t3.ID_tym));  

                        //3.e - Seznam týmů podle časového úseku
                        Console.WriteLine("\nVypis vsech tymu podle casoveho obdobi:");
                        foreach (Tym t in TymTable.VypisTymuZaUrciteObdobi(new DateTime(2000, 1, 1), new DateTime(2020, 1, 1), db))
                            Console.WriteLine(t);

                        //3.f - Aktualizace týmu
                        t3.ID_pracoviste = p3.ID_pracoviste;
                        t3.Nazev = "Zmenene pracoviste";
                        t3.Min_zamestnancu = 2;
                        t3.Datum = new DateTime(2020, 1, 1);
                        TymTable.Update(t3, db);                                  
                        Console.WriteLine("Update:\t" + TymTable.Select(t3.ID_tym));

                        //Netriviální funkce
                        //3.a - Vytvoření kopie týmu
                        TymTable.VytvoreniKopieTymu(t3.ID_tym, new DateTime(2010, 1, 1), "Nove", s3.ID_smeny);

                        //3.c - Smazání týmu
                        TymTable.Delete(t3.ID_tym);
                        Console.WriteLine("Delete:\t" + TymTable.Select(t3.ID_tym));

                        SmenaTable.Delete(s3.ID_smeny);
                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                       //Testy pro tabulku 4. Smena
                       Console.WriteLine("\nTest tabulky Smena:");
                       Smena smena = new Smena();
                       smena.Popis = "Testik";

                       //4.a - Vložení nové směny
                       SmenaTable.Insert(smena, db);                                   

                       Console.WriteLine("\nTest select, update, delete:");
                       // 4.c - Detail směny
                       smena.ID_smeny = SmenaTable.SelectMaxID(db);                   
                       Console.WriteLine("Select:\t" + SmenaTable.Select(smena.ID_smeny));  
                       smena.Popis = "Zmeneny nazev";

                        //4.d - Seznam směn (Pouze číselník, max 4 záznamy)
                        Console.WriteLine("\nVypis vsech smen:");
                       foreach (Smena s in SmenaTable.Select(db))
                           Console.WriteLine(s);

                        //4.b - Smazání směny
                        SmenaTable.Delete(smena.ID_smeny, db);                                   
                        Console.WriteLine("Delete:\t" + SmenaTable.Select(smena.ID_smeny)); 

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                       //Testy pro tabulku 5. Duvod
                       Console.WriteLine("\nTest tabulky Duvod:");
                       Duvod duvod = new Duvod();
                       duvod.Nazev = "Testik";

                        //5.a - Vložení nového důvodu
                        DuvodTable.Insert(duvod, db);                                 

                       Console.WriteLine("\nTest select, update, delete:");

                        //5.c - Detail důvodu
                       duvod.ID_duvodu = DuvodTable.SelectMaxID(db);                  
                       Console.WriteLine("Select:\t" + DuvodTable.Select(duvod.ID_duvodu));  

                        //4.d - Seznam důvodů (Pouze číselník, max 6 záznamů)
                        Console.WriteLine("\nVypis vsech duvodu:");
                       foreach (Duvod d in DuvodTable.Select(db))
                           Console.WriteLine(d);

                        //4.b - Smazání důvodu
                        DuvodTable.Delete(duvod.ID_duvodu);
                        Console.WriteLine("Delete:\t" + DuvodTable.Select(duvod.ID_duvodu));

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        //Testy pro tabulku 6. PoziceZamestnance

                        Console.WriteLine("\nTest tabulky poziceZamestnance:");

                        Pozice p6 = new Pozice();
                        p6.Nazev = "Pozice pro PoziceZamestnance";
                        PoziceTable.Insert(p6, db);

                        Zamestnanec z6 = new Zamestnanec();
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

                        //6.a - Vložení nové pozice zaměstnanci
                        PoziceZamestnanceTable.Insert(pz, db);                                   

                        Console.WriteLine("\nTest select, update, delete:");

                        //6.c - Detail pozice zaměstnance
                        pz.ID_poziceZamestnance = PoziceZamestnanceTable.SelectMaxID(db);                   
                        Console.WriteLine("Select:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));

                        //6.e - Aktualizace pozice zaměstnance
                        PoziceZamestnanceTable.Update(pz, db);                                   
                        Console.WriteLine("Update:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));

                        //6.d Seznam pozic zaměstnance podle jeho ID
                        Console.WriteLine("\nVypis vsech pozic zamestnancu:");
                        foreach (PoziceZamestnance p in PoziceZamestnanceTable.SeznamPozicZamestnance(pz.ID_zamestnance, db))
                            Console.WriteLine(p);

                        //6.b - Smazání pozice zaměstnance
                        PoziceZamestnanceTable.Delete(pz.ID_poziceZamestnance);
                        Console.WriteLine("Delete:\t" + PoziceZamestnanceTable.Select(pz.ID_poziceZamestnance));
                        ZamestnanecTable.Delete(z6.ID_zamestnance);
                        PoziceTable.Delete(p6.ID_pozice);

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                       //Testy pro tabulku 7. Pozice

                       Console.WriteLine("\nTest tabulky Pozice:");
                       Pozice pozice = new Pozice();
                       pozice.Nazev = "Testik_pozice";

                        //7.a - Vložení nové pozice
                        PoziceTable.Insert(pozice, db);                                   

                       Console.WriteLine("\nTest select, update, delete:");

                       //7.c - Detail pozice 
                       pozice.ID_pozice = PoziceTable.SelectMaxID(db);                   
                       Console.WriteLine("Select:\t" + PoziceTable.Select(pozice.ID_pozice));

                       //7.d
                       Console.WriteLine("\nVypis vsech Pozic:");
                       foreach (Pozice p in PoziceTable.Select(db))
                           Console.WriteLine(p);

                        //7.e - Aktualizace pozice
                        pozice.Nazev = "Zmeneny nazev";
                        PoziceTable.Update(pozice, db);
                        Console.WriteLine("Update:\t" + PoziceTable.Select(pozice.ID_pozice));

                        //7.b - Smazání pozice
                        PoziceTable.Delete(pozice.ID_pozice);
                        Console.WriteLine("Delete:\t" + PoziceTable.Select(pozice.ID_pozice));

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        //Testy pro tabulku 8. TymZamestnance

                        Console.WriteLine("\nTest tabulky TymZamestnance:");

                        Pracoviste prac8 = new Pracoviste();
                        prac8.ID_nadrizenehoPracoviste = null;
                        prac8.Nazev = "Pracoviste pro TymZamestnance";
                        PracovisteTable.Insert(prac8, db);
                        prac8.ID_pracoviste = PracovisteTable.SelectMaxID(db);

                        Tym t8 = new Tym();
                        t8.ID_pracoviste = prac8.ID_pracoviste;
                        t8.Nazev = "Pracoviste pro TymZamestnance";
                        t8.Min_zamestnancu = 3;
                        t8.Datum = new DateTime(2000, 1, 1);
                        TymTable.Insert(t8, db);
                        t8.ID_tym = TymTable.SelectMaxID(db);

                        Pozice p8 = new Pozice();
                        p8.Nazev = "Pozice pro TymZamestnance";
                        PoziceTable.Insert(p8, db);
                        p8.ID_pozice = PoziceTable.SelectMaxID(db);

                        Zamestnanec z8 = new Zamestnanec();
                        z8.Jmeno = "Lukas";
                        z8.Prijmeni = "Ciahotny";
                        z8.Narozeniny = new DateTime(2000, 1, 1);
                        z8.Nastupni_den = DateTime.Now;
                        z8.Mistr = true;
                        z8.Login = "CIA01";
                        z8.Heslo = "abc";
                        z8.Zbyva_dovolenych = 50;
                        z8.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);
                        ZamestnanecTable.Insert(z8, db);
                        z8.ID_zamestnance = ZamestnanecTable.SelectMaxID(db);

                        TymZamestnance tz8 = new TymZamestnance();
                        tz8.ID_zamestnance = z8.ID_zamestnance;
                        tz8.ID_tym = t8.ID_tym;

                        //8.a - Vložení zaměstnance do nového týmu zaměstnance
                        TymZamestnanceTable.Insert(tz8, db);

                        Console.WriteLine("\nTest select, update, delete:");

                        //8.c - Detail týmu zaměstnance
                        tz8.ID_tymZamestnance = TymZamestnanceTable.SelectMaxID(db);
                        Console.WriteLine("Select:\t" + TymZamestnanceTable.Select(tz8.ID_tymZamestnance));

                        //8.d Seznam zaměstnanců v týmu podle ID týmu
                        Console.WriteLine("\nVypis vsech zamestnancu v tymu:");
                        foreach (TymZamestnance tz in TymZamestnanceTable.SeznamZamestnancuVTymu(tz8.ID_tym, db))
                            Console.WriteLine(tz);

                        //8.b - Smazání týmu zaměstnanci
                        TymZamestnanceTable.Delete(tz8.ID_tymZamestnance);
                        Console.WriteLine("Delete:\t" + TymZamestnanceTable.Select(tz8.ID_tymZamestnance));

                        ZamestnanecTable.Delete(z8.ID_zamestnance);
                        PoziceTable.Delete(p8.ID_pozice);
                        TymTable.Delete(t8.ID_tym);
                        PracovisteTable.Delete(prac8.ID_pracoviste);

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        //Testy pro tabulku 9. Pracoviste

                        Console.WriteLine("\nTest tabulky Pracoviste:");
                        Pracoviste pracoviste = new Pracoviste();
                        pracoviste.ID_nadrizenehoPracoviste = null;
                        pracoviste.Nazev = "Testik_pracoviste";

                        //9.a - Vložení nového pracoviště
                        PracovisteTable.Insert(pracoviste, db);                                   

                        Console.WriteLine("\nTest select, update, delete:");

                        //9.c - Detail pracoviště
                        pracoviste.ID_pracoviste = PracovisteTable.SelectMaxID(db);                  
                        Console.WriteLine("Select:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));

                        //9.e - Aktualizace pracoviště
                        pracoviste.ID_nadrizenehoPracoviste = null;
                        pracoviste.Nazev = "Zmeneny nazev";
                        PracovisteTable.Update(pracoviste, db);                                   
                        Console.WriteLine("Update:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));

                        //9.d - Seznam pracovišť podle ID nadřízeného pracoviště
                        Console.WriteLine("\nSeznam pracovist podle nadrizeneho pracoviste:");
                        foreach (Pracoviste p in PracovisteTable.SeznamPracovistPodleNadrizeneho(1,db))
                            Console.WriteLine(p);

                        //9.b - Smazání pracoviště
                        PracovisteTable.Delete(pracoviste.ID_pracoviste);
                        Console.WriteLine("Delete:\t" + PracovisteTable.Select(pracoviste.ID_pracoviste));

                        Console.WriteLine("--------------------------------------------------------------------------------------------");

                        //Testy pro tabulku 10. SmenaTymu

                        Console.WriteLine("\nTest tabulky SmenaTymu:");

                        Pracoviste prac10 = new Pracoviste();
                        prac10.ID_nadrizenehoPracoviste = null;
                        prac10.Nazev = "Pracoviste pro SmenaTymu";
                        PracovisteTable.Insert(prac10, db);
                        prac10.ID_pracoviste = PracovisteTable.SelectMaxID(db);

                        Tym t10 = new Tym();
                        t10.ID_pracoviste = prac10.ID_pracoviste;
                        t10.Nazev = "Tym pro SmenaTymu";
                        t10.Min_zamestnancu = 3;
                        t10.Datum = new DateTime(2000, 1, 1);
                        TymTable.Insert(t10, db);
                        t10.ID_tym = TymTable.SelectMaxID(db);

                        Smena s10 = new Smena();
                        s10.Popis = "Smena pro SmenaTymu";
                        SmenaTable.Insert(s10, db);
                        s10.ID_smeny = SmenaTable.SelectMaxID(db);

                        SmenaTymu st10 = new SmenaTymu();
                        st10.ID_smeny = s10.ID_smeny;
                        st10.ID_tym = t10.ID_tym;

                        //10.a - Vložení týmu na směnu
                        SmenaTymuTable.Insert(st10, db);

                        Console.WriteLine("\nTest select, update, delete:");

                        //10.c - Detail směny týmu
                        st10.ID_smenyTymu = SmenaTymuTable.SelectMaxID(db);
                        Console.WriteLine("Select:\t" + SmenaTymuTable.Select(st10.ID_smenyTymu));

                        //10.d - Seznam směn týmu podle ID směny
                        Console.WriteLine("\nVypis vsech zamestnancu v tymu:");
                        foreach (SmenaTymu st in SmenaTymuTable.SeznamSmenTymu(st10.ID_smeny, db))
                            Console.WriteLine(st);

                        //10.e - Aktualizace směny týmu
                        SmenaTymuTable.Update(st10, db);
                        Console.WriteLine("Update:\t" + SmenaTymuTable.Select(st10.ID_smenyTymu));

                        //10.b - Smazání týmu ze směny
                        SmenaTymuTable.Delete(st10.ID_smenyTymu);
                        Console.WriteLine("Delete:\t" + SmenaTymuTable.Select(st10.ID_smenyTymu));

                        SmenaTable.Delete(s10.ID_smeny);
                        //TymTable.Delete(t10.ID_tym);
                        //PracovisteTable.Delete(prac10.ID_pracoviste);

                        Console.WriteLine("--------------------------------------------------------------------------------------------");
                    */
            db.Close();

            Console.ReadKey();
        }
    }
}
