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
    class TymTable
    {
        public static String SQL_SELECT = "SELECT * FROM Tym";

        public static String SQL_SELECT_ID = "SELECT * FROM Tym WHERE ID_tym=@ID_tym";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_tym) FROM Tym";
        public static String SQL_INSERT = "INSERT INTO Tym VALUES (@ID_pracoviste, @Nazev, @Min_zamestnancu, @Datum)";
        public static String SQL_DELETE_ID = "DELETE FROM Tym WHERE ID_tym=@ID_tym";
        public static String SQL_UPDATE = "UPDATE Tym SET ID_pracoviste=@ID_pracoviste, Nazev=@Nazev, Min_zamestnancu=@Min_zamestnancu, Datum=@Datum WHERE ID_tym=@ID_tym";
        public static String SQL_POCET_TYMU = "SELECT COUNT(*) FROM Tym WHERE ID_tym = @ID_tym";

        public static int VytvoreniKopieTymu(int ID_starehoTymu, DateTime Datum, string nazev, int ID_smeny, MyDatabase pDb = null)
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
            SqlCommand command = db.CreateCommand("VytvoreniKopieTymu");
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@ID_starehoTymu";
            input.DbType = DbType.Int32;
            input.Value = ID_starehoTymu;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@Datum";
            input2.DbType = DbType.DateTime;
            input2.Value = Datum;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@nazev";
            input3.DbType = DbType.String;
            input3.Value = nazev;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@ID_smeny";
            input4.DbType = DbType.Int32;
            input4.Value = ID_smeny;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }

        public static Collection<Tym> VypisTymuZaUrciteObdobi(DateTime Od, DateTime Do, MyDatabase pDb = null)
        {
            String SQL_DOVOLENE_ZA_CAS = "SELECT * FROM Tym " +
                "WHERE Datum BETWEEN '" + Convert.ToDateTime(Od).ToString("yyyy-MM-dd") + "' and '" + Convert.ToDateTime(Do).ToString("yyyy-MM-dd") + "'";
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

            SqlCommand command = db.CreateCommand(SQL_DOVOLENE_ZA_CAS);
            SqlDataReader reader = db.Select(command);

            Collection<Tym> tymy = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return tymy;
        }


        public static int Insert(Tym tym, MyDatabase pDB = null)
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
            PrepareCommand(command, tym);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(Tym tym, MyDatabase pDb = null)
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
            PrepareCommand(command, tym);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Tym Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_tym", id);
            SqlDataReader reader = db.Select(command);

            Collection<Tym> tymy = Read(reader);
            Tym tym = null;
            if (tymy.Count == 1)
            {
                tym = tymy[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (tym == null)
                Console.WriteLine("Tym neexistuje");

            return tym;
        }

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
            SqlCommand command = db.CreateCommand(SQL_POCET_TYMU);

            command.Parameters.AddWithValue("@ID_tym", id);

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
            Collection<Tym> tymy = Select(pDb);

            int max = 0;

            foreach (Tym tym in tymy)
            {
                if (tym.ID_tym > max)
                    max = tym.ID_tym;
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

                command.Parameters.AddWithValue("@ID_tym", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Tym> Select(MyDatabase pDb = null)
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

            Collection<Tym> tymy = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return tymy;
        }



        private static void PrepareCommand(SqlCommand command, Tym tym)
        {
            command.Parameters.AddWithValue("@ID_tym", tym.ID_tym);
            command.Parameters.AddWithValue("@ID_pracoviste", tym.ID_pracoviste);
            command.Parameters.AddWithValue("@Nazev", tym.Nazev);
            command.Parameters.AddWithValue("@Min_zamestnancu", tym.Min_zamestnancu);
            command.Parameters.AddWithValue("@Datum", Convert.ToDateTime(tym.Datum).ToString("yyyy-MM-dd"));
        }

        private static Collection<Tym> Read(SqlDataReader reader)
        {
            Collection<Tym> tymy = new Collection<Tym>();

            while (reader.Read())
            {
                int i = -1;
                Tym tym = new Tym();
                tym.ID_tym = reader.GetInt32(++i);
                tym.ID_pracoviste = reader.GetInt32(++i);
                tym.Nazev = reader.GetString(++i);
                tym.Min_zamestnancu = reader.GetInt32(++i);
                tym.Datum = reader.GetDateTime(++i);

                tymy.Add(tym);
            }
            return tymy;
        }
    }
}
