using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class ZamestnanecTable
    {
        public static String SQL_SELECT = "SELECT * FROM Zamestnanec";

        public static String SQL_SELECT_ID = "SELECT * FROM Zamestnanec WHERE ID_zamestnance=@ID_zamestnance";
        public static String SQL_INSERT = "INSERT INTO Zamestnanec VALUES (@Jmeno, @Prijmeni, @Narozeniny, @Nastupni_den, @Mistr, @Login, @Heslo, @Zbyva_dovolenych)";
        public static String SQL_DELETE_ID = "DELETE FROM Zamestnanec WHERE ID_zamestnance=@ID_zamestnance";
        public static String SQL_UPDATE = "UPDATE Zamestnanec SET Jmeno=@Jmeno, Prijmeni=@Prijmeni, Narozeniny=@Narozeniny, Nastupni_den=@Nastupni_den, Mistr=@Mistr, Login=@Login, Heslo=@Heslo, Zbyva_dovolenych=@Zbyva_dovolenych WHERE ID_zamestnance=@ID_zamestnance";
        public static String SQL_POCET_ZAMESTNANCU = "SELECT COUNT(*) FROM Zamestnanec WHERE ID_zamestnance = @ID_zamestnance";
        public static String SQL_DOVOLENE_ZAMESTNANCE_ZA_POSLEDNI_ROK = "SELECT z.ID_zamestnance, z.Jmeno, z.Prijmeni, DATEDIFF(DAY, d.Od, d.Do) AS PocetDnu FROM Zamestnanec z " +
    "JOIN Dovolena d ON z.ID_zamestnance = d.ID_zamestnance " +
    "WHERE YEAR(d.Od) = YEAR(GETDATE()) ORDER BY PocetDnu DESC";



        public static int VlozeniNovehoZamestnance(String jmeno, String prijmeni, DateTime datum_narozeni, Boolean jeMistr, String heslo, String pozice, MyDatabase pDb = null)
        {

            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }
            SqlCommand command = db.CreateCommand("VlozeniNovehoZamestnance");
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@jmeno";
            input.DbType = DbType.String;
            input.Value = jmeno;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@prijmeni";
            input2.DbType = DbType.String;
            input2.Value = prijmeni;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@datum_narozeni";
            input3.DbType = DbType.DateTime;
            input3.Value = datum_narozeni;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@jeMistr";
            input4.DbType = DbType.Boolean;
            input4.Value = jeMistr;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            SqlParameter input5 = new SqlParameter();
            input5.ParameterName = "@heslo";
            input5.DbType = DbType.String;
            input5.Value = heslo;
            input5.Direction = ParameterDirection.Input;
            command.Parameters.Add(input5);

            SqlParameter input6 = new SqlParameter();
            input6.ParameterName = "@pozice";
            input6.DbType = DbType.String;
            input6.Value = pozice;
            input6.Direction = ParameterDirection.Input;
            command.Parameters.Add(input6);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }


        public static int Insert(Zamestnanec pozice, MyDatabase pDB = null)
        {
            MyDatabase db;
            if (pDB == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDB;
            }
            SqlCommand command = db.CreateCommand(SQL_INSERT);
            PrepareCommand(command, pozice);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(Zamestnanec zamestnanec, MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_UPDATE);
            PrepareCommand(command, zamestnanec);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Zamestnanec Select(int id, MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID);

            command.Parameters.AddWithValue("@ID_zamestnance", id);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            Zamestnanec zamestnanec = null;
            if (zamestnanci.Count == 1)
            {
                zamestnanec = zamestnanci[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (zamestnanec == null)
                Console.WriteLine("Zamestnanec neexistuje");

            return zamestnanec;
        }

        //--------------------------------------------

        public static Collection<Zamestnanec> VypisVhodnychZamestnancu(int ID_tym, DateTime datum, MyDatabase pDb = null)
        {
            String SQL_VHODNI_ZAMESTNANCI = "SELECT z.ID_zamestnance, z.Jmeno, z.Prijmeni FROM Zamestnanec z "
            + "LEFT OUTER JOIN Dovolena d ON d.ID_zamestnance = z.ID_zamestnance AND " + "'" + Convert.ToDateTime(datum).ToString("yyyy-MM-dd")+"'" + " BETWEEN d.Od AND d.Do "
            + "LEFT OUTER JOIN TymZamestnance tz ON tz.ID_zamestnance = z.ID_zamestnance AND tz.ID_tym = "+ ID_tym+ " "
            + "WHERE d.ID_zamestnance IS NULL AND tz.ID_tym IS NULL";
        MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_VHODNI_ZAMESTNANCI);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = ReadGeneral(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanci;
        }
        public static Collection<Zamestnanec> VypisDovolenycZamestnceZaPosledniRok(MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_DOVOLENE_ZAMESTNANCE_ZA_POSLEDNI_ROK);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = ReadDovolene(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanci;
        }

        //--------------------------------------------

        public static int SelectPocet(int id, MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }
            SqlCommand command = db.CreateCommand(SQL_POCET_ZAMESTNANCU);

            command.Parameters.AddWithValue("@ID_zamestnance", id);

            int pocet = 0;
            SqlDataReader reader = db.Select(command);
            reader.Read();
            pocet = reader.GetInt32(0);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pocet;
        }


        public static int SelectMaxID(MyDatabase pDb = null)
        {
            Collection<Zamestnanec> zamestnanci = Select(pDb);

            int max = 0;

            foreach (Zamestnanec zamestnanec in zamestnanci)
            {
                if (zamestnanec.ID_zamestnance > max)
                    max = zamestnanec.ID_zamestnance;
            }

            return max;
        }


        //3.3
        public static int Delete(int kID, MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            int ret = 0;

            if (SelectPocet(kID, pDb) == 1)
            {
                SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

                command.Parameters.AddWithValue("@ID_zamestnance", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Zamestnanec> Select(MyDatabase pDb = null)
        {
            MyDatabase db;
            if (pDb == null)
            {
                db = new MyDatabase();
                db.Connect();
            }
            else
            {
                db = (MyDatabase)pDb;
            }

            SqlCommand command = db.CreateCommand(SQL_SELECT);
            SqlDataReader reader = db.Select(command);

            Collection<Zamestnanec> zamestnanci = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return zamestnanci;
        }



        private static void PrepareCommand(SqlCommand command, Zamestnanec zamestnanec)
        {
            command.Parameters.AddWithValue("@ID_zamestnance", zamestnanec.ID_zamestnance);
            command.Parameters.AddWithValue("@Jmeno", zamestnanec.Jmeno);
            command.Parameters.AddWithValue("@Prijmeni", zamestnanec.Prijmeni);
            command.Parameters.AddWithValue("@Narozeniny", Convert.ToDateTime(zamestnanec.Narozeniny).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Nastupni_den", Convert.ToDateTime(zamestnanec.Nastupni_den).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Mistr", zamestnanec.Mistr);
            command.Parameters.AddWithValue("@Login", zamestnanec.Login);
            command.Parameters.AddWithValue("@Heslo", zamestnanec.Heslo);
            command.Parameters.AddWithValue("@Zbyva_dovolenych", zamestnanec.Zbyva_dovolenych);
        }

        private static Collection<Zamestnanec> Read(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.ID_zamestnance = reader.GetInt32(++i);
                zamestnanec.Jmeno = reader.GetString(++i);
                zamestnanec.Prijmeni = reader.GetString(++i);
                zamestnanec.Narozeniny = reader.GetDateTime(++i);
                zamestnanec.Nastupni_den = reader.GetDateTime(++i);
                zamestnanec.Mistr = reader.GetBoolean(++i);
                zamestnanec.Login = reader.GetString(++i);
                zamestnanec.Heslo = reader.GetString(++i);
                zamestnanec.Zbyva_dovolenych = reader.GetInt32(++i);

                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }
        private static Collection<Zamestnanec> ReadGeneral(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.ID_zamestnance = reader.GetInt32(++i);
                zamestnanec.Jmeno = reader.GetString(++i);
                zamestnanec.Prijmeni = reader.GetString(++i);

                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }
        private static Collection<Zamestnanec> ReadDovolene(SqlDataReader reader)
        {
            Collection<Zamestnanec> zamestnanci = new Collection<Zamestnanec>();

            while (reader.Read())
            {
                int i = -1;
                Zamestnanec zamestnanec = new Zamestnanec();
                zamestnanec.ID_zamestnance = reader.GetInt32(++i);
                zamestnanec.Jmeno = reader.GetString(++i);
                zamestnanec.Prijmeni = reader.GetString(++i);
                zamestnanec.info = reader.GetInt32(++i);
                zamestnanci.Add(zamestnanec);
            }
            return zamestnanci;
        }
    }
}
