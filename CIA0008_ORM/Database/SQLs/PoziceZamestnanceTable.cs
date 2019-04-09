using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class PoziceZamestnanceTable
    {
        public static String SQL_SELECT = "SELECT * FROM poziceZamestnance";

        public static String SQL_SELECT_ID = "SELECT * FROM PoziceZamestnance WHERE ID_poziceZamestnance=@ID_poziceZamestnance";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_poziceZamestnance) FROM PoziceZamestnance";
        public static String SQL_INSERT = "INSERT INTO PoziceZamestnance VALUES (@ID_zamestnance, @ID_pozice)";
        public static String SQL_DELETE_ID = "DELETE FROM PoziceZamestnance WHERE ID_poziceZamestnance=@ID_poziceZamestnance";
        public static String SQL_UPDATE = "UPDATE PoziceZamestnance SET ID_zamestnance=@ID_zamestnance, ID_pozice=@ID_pozice WHERE ID_poziceZamestnance=@ID_poziceZamestnance";
        public static String SQL_POCET_POZICE_ZAMESTNANCE = "SELECT COUNT(*) FROM PoziceZamestnance WHERE ID_poziceZamestnance=@ID_poziceZamestnance";

        public static int Insert(PoziceZamestnance pz, MyDatabase pDB = null)
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
            PrepareCommand(command, pz);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(PoziceZamestnance pz, MyDatabase pDb = null)
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
            PrepareCommand(command, pz);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static PoziceZamestnance Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_poziceZamestnance", id);
            SqlDataReader reader = db.Select(command);

            Collection<PoziceZamestnance> pzC = Read(reader);
            PoziceZamestnance pz = null;
            if (pzC.Count == 1)
            {
                pz = pzC[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (pz == null)
                Console.WriteLine("Pozice zamestnance neexistuje");

            return pz;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_POZICE_ZAMESTNANCE);

            command.Parameters.AddWithValue("@ID_poziceZamestnance", id);

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
            Collection<PoziceZamestnance> pzC = Select(pDb);

            int max = 0;

            foreach (PoziceZamestnance pz in pzC)
            {
                if (pz.ID_poziceZamestnance > max)
                    max = pz.ID_poziceZamestnance;
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

                command.Parameters.AddWithValue("@ID_poziceZamestnance", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<PoziceZamestnance> Select(MyDatabase pDb = null)
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

            Collection<PoziceZamestnance> pzC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pzC;
        }



        private static void PrepareCommand(SqlCommand command, PoziceZamestnance pz)
        {
            command.Parameters.AddWithValue("@ID_poziceZamestnance", pz.ID_poziceZamestnance);
            command.Parameters.AddWithValue("@ID_zamestnance", pz.ID_zamestnance);
            command.Parameters.AddWithValue("@ID_pozice", pz.ID_pozice);
        }

        private static Collection<PoziceZamestnance> Read(SqlDataReader reader)
        {
            Collection<PoziceZamestnance> pzC = new Collection<PoziceZamestnance>();

            while (reader.Read())
            {
                int i = -1;
                PoziceZamestnance pz = new PoziceZamestnance();
                pz.ID_poziceZamestnance = reader.GetInt32(++i);
                pz.ID_zamestnance = reader.GetInt32(++i);
                pz.ID_pozice = reader.GetInt32(++i);
                pzC.Add(pz);
            }
            return pzC;
        }
    }
}
