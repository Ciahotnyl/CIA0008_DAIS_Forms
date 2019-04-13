using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class SmenaTymuTable
    {
        public static String SQL_SELECT = "SELECT * FROM SmenaTymu";

        public static String SQL_SELECT_ID = "SELECT * FROM SmenaTymu WHERE ID_smenyTymu=@ID_smenyTymu";
        public static String SQL_SELECT_ID_SMENY = "SELECT ID_smenyTymu, ID_smeny, ID_tym FROM SmenaTymu WHERE ID_smeny=@ID_smeny";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_smenyTymu) FROM SmenaTymu";
        public static String SQL_INSERT = "INSERT INTO SmenaTymu VALUES (@ID_smeny, @ID_tym)";
        public static String SQL_DELETE_ID = "DELETE FROM SmenaTymu WHERE ID_smenyTymu=@ID_smenyTymu";
        public static String SQL_UPDATE = "UPDATE SmenaTymu SET ID_smeny=@ID_smeny, ID_tym=@ID_tym WHERE ID_smenyTymu=@ID_smenyTymu";
        public static String SQL_POCET_SMENY_TYMU = "SELECT COUNT(*) FROM SmenaTymu WHERE ID_smenyTymu=@ID_smenyTymu";

        public static Collection<SmenaTymu> SeznamSmenTymu(int id, MyDatabase pDb = null)
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

            SqlCommand command = db.CreateCommand(SQL_SELECT_ID_SMENY);
            command.Parameters.AddWithValue("@ID_smeny", id);
            SqlDataReader reader = db.Select(command);

            Collection<SmenaTymu> stC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return stC;
        }

        public static int Insert(SmenaTymu st, MyDatabase pDB = null)
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
            PrepareCommand(command, st);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }

        public static int Update(SmenaTymu st, MyDatabase pDb = null)
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
            PrepareCommand(command, st);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static SmenaTymu Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_smenyTymu", id);
            SqlDataReader reader = db.Select(command);

            Collection<SmenaTymu> stC = Read(reader);
            SmenaTymu st = null;
            if (stC.Count == 1)
            {
                st = stC[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (st == null)
                Console.WriteLine("Smena tymu neexistuje");

            return st;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_SMENY_TYMU);

            command.Parameters.AddWithValue("@ID_smenyTymu", id);

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
            Collection<SmenaTymu> stC = Select(pDb);

            int max = 0;

            foreach (SmenaTymu st in stC)
            {
                if (st.ID_smenyTymu > max)
                    max = st.ID_smenyTymu;
            }

            return max;
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

                command.Parameters.AddWithValue("@ID_smenyTymu", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }

        public static Collection<SmenaTymu> Select(MyDatabase pDb = null)
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

            Collection<SmenaTymu> stC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return stC;
        }

        private static void PrepareCommand(SqlCommand command, SmenaTymu st)
        {
            command.Parameters.AddWithValue("@ID_smenyTymu", st.ID_smenyTymu);
            command.Parameters.AddWithValue("@ID_smeny", st.ID_smeny);
            command.Parameters.AddWithValue("@ID_tym", st.ID_tym);
        }

        private static Collection<SmenaTymu> Read(SqlDataReader reader)
        {
            Collection<SmenaTymu> stC = new Collection<SmenaTymu>();

            while (reader.Read())
            {
                int i = -1;
                SmenaTymu st = new SmenaTymu();
                st.ID_smeny = reader.GetInt32(++i);
                st.ID_tym = reader.GetInt32(++i);
                stC.Add(st);
            }
            return stC;
        }
    }
}
