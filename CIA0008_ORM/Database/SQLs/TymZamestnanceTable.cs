using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class TymZamestnanceTable
    {
        public static String SQL_SELECT = "SELECT * FROM TymZamestnance";

        public static String SQL_SELECT_ID = "SELECT * FROM TymZamestnance WHERE ID_tymZamestnance=@ID_tymZamestnance";
        public static String SQL_SELECT_ID_ZAMESTNANCE = "SELECT ID_zamestnance FROM TymZamestnance WHERE ID_tym=@ID_tym";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_tymZamestnance) FROM TymZamestnance";
        public static String SQL_INSERT = "INSERT INTO TymZamestnance VALUES (@ID_zamestnance, @ID_tym)";
        public static String SQL_DELETE_ID = "DELETE FROM TymZamestnance WHERE ID_tymZamestnance=@ID_tymZamestnance";
        public static String SQL_UPDATE = "UPDATE TymZamestnance SET ID_zamestnance=@ID_zamestnance, ID_tym=@ID_tym WHERE ID_poziceZamestnance=@ID_poziceZamestnance";
        public static String SQL_POCET_TYMU_ZAMESTNANCE = "SELECT COUNT(*) FROM TymZamestnance WHERE ID_tymZamestnance=@ID_tymZamestnance ";
        public static String SQL_POCET_TYMU_ZAMESTNANCE2 = "SELECT COUNT(*) FROM TymZamestnance WHERE ID_zamestnance=@ID_zamestnance AND ID_tym=@ID_tym";
        public static String SQL_ODEBRAT_ZAMESTNANCE_Z_TYMU = "DELETE FROM TymZamestnance WHERE ID_zamestnance=@ID_zamestnance AND ID_tym=@ID_tym";

        public static Collection<TymZamestnance> SeznamZamestnancuVTymu(int id, MyDatabase pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_ZAMESTNANCE);
            command.Parameters.AddWithValue("@ID_tym", id);
            SqlDataReader reader = db.Select(command);

            Collection<TymZamestnance> tymZamestnancu = ReadZamestnance(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return tymZamestnancu;
        }

        public static int Insert(TymZamestnance tz, MyDatabase pDB = null)
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
            PrepareCommand(command, tz);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(TymZamestnance tz, MyDatabase pDb = null)
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
            PrepareCommand(command, tz);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static TymZamestnance Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_tymZamestnance", id);
            SqlDataReader reader = db.Select(command);

            Collection<TymZamestnance> tzC = Read(reader);
            TymZamestnance tz = null;
            if (tzC.Count == 1)
            {
                tz = tzC[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (tz == null)
                Console.WriteLine("Tym zamestnance neexistuje");

            return tz;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_TYMU_ZAMESTNANCE);

            command.Parameters.AddWithValue("@ID_tymZamestnance", id);

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
        public static int SelectPocet2(int id, int id2, MyDatabase pDb = null)
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
            SqlCommand command = db.CreateCommand(SQL_POCET_TYMU_ZAMESTNANCE2);

            command.Parameters.AddWithValue("@ID_tymZamestnance", id);
            command.Parameters.AddWithValue("@ID_tym", id2);

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
            Collection<TymZamestnance> tzC = Select(pDb);

            int max = 0;

            foreach (TymZamestnance tz in tzC)
            {
                if (tz.ID_tymZamestnance > max)
                    max = tz.ID_tymZamestnance;
            }

            return max;
        }

        public static int DeleteJednohoZamestnance(int id_zamestnance, int id_tym, MyDatabase pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_ODEBRAT_ZAMESTNANCE_Z_TYMU);

            command.Parameters.AddWithValue("@ID_zamestnance", id_zamestnance);
            command.Parameters.AddWithValue("@id_tym", id_tym);
            ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

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

                command.Parameters.AddWithValue("@ID_tymZamestnance", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<TymZamestnance> Select(MyDatabase pDb = null)
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

            Collection<TymZamestnance> tzC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return tzC;
        }

        private static void PrepareCommand(SqlCommand command, TymZamestnance tz)
        {
            command.Parameters.AddWithValue("@ID_tymZamestnance", tz.ID_tymZamestnance);
            command.Parameters.AddWithValue("@ID_zamestnance", tz.ID_zamestnance);
            command.Parameters.AddWithValue("@ID_tym", tz.ID_tym);
        }

        private static Collection<TymZamestnance> Read(SqlDataReader reader)
        {
            Collection<TymZamestnance> tzC = new Collection<TymZamestnance>();

            while (reader.Read())
            {
                int i = -1;
                TymZamestnance tz = new TymZamestnance();
                tz.ID_tymZamestnance = reader.GetInt32(++i);
                tz.ID_zamestnance = reader.GetInt32(++i);
                tz.ID_tym = reader.GetInt32(++i);
                tzC.Add(tz);
            }
            return tzC;
        }

        private static Collection<TymZamestnance> ReadZamestnance(SqlDataReader reader)
        {
            Collection<TymZamestnance> tzC = new Collection<TymZamestnance>();

            while (reader.Read())
            {
                int i = -1;
                TymZamestnance tz = new TymZamestnance();
                tz.ID_zamestnance = reader.GetInt32(++i);
                tzC.Add(tz);
            }
            return tzC;
        }
    }
}
