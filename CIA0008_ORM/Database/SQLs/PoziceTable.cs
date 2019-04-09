using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class PoziceTable
    {
        public static String SQL_SELECT = "SELECT * FROM Pozice";

        public static String SQL_SELECT_ID = "SELECT * FROM Pozice WHERE ID_pozice=@ID_pozice";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_pozice) FROM Pozice";
        public static String SQL_INSERT = "INSERT INTO Pozice VALUES (@Nazev)";
        public static String SQL_DELETE_ID = "DELETE FROM Pozice WHERE ID_pozice=@ID_pozice";
        public static String SQL_UPDATE = "UPDATE Pozice SET Nazev=@Nazev WHERE ID_pozice=@ID_pozice";
        public static String SQL_POCET_POZIC = "SELECT COUNT(*) FROM PoziceZamestnance WHERE ID_pozice = @ID_pozice";

        public static int Insert(Pozice pozice, MyDatabase pDB = null)
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


        public static int Update(Pozice pozice, MyDatabase pDb = null)
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
            PrepareCommand(command, pozice);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Pozice Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_pozice", id);
            SqlDataReader reader = db.Select(command);

            Collection<Pozice> poziceC = Read(reader);
            Pozice pozice = null;
            if (poziceC.Count == 1)
            {
                pozice = poziceC[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (pozice == null)
                Console.WriteLine("Pozice neexistuje");

            return pozice;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_POZIC);

            command.Parameters.AddWithValue("@ID_pozice", id);

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
            Collection<Pozice> poziceC = Select(pDb);

            int max = 0;

            foreach (Pozice pozice in poziceC)
            {
                if (pozice.ID_pozice > max)
                    max = pozice.ID_pozice;
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

            if (SelectPocet(kID, pDb) == 0)
            {
                SqlCommand command = db.CreateCommand(SQL_DELETE_ID);

                command.Parameters.AddWithValue("@ID_pozice", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Pozice> Select(MyDatabase pDb = null)
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

            Collection<Pozice> poziceC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return poziceC;
        }



        private static void PrepareCommand(SqlCommand command, Pozice pozice)
        {
            command.Parameters.AddWithValue("@ID_pozice", pozice.ID_pozice);
            command.Parameters.AddWithValue("@Nazev", pozice.Nazev);
        }

        private static Collection<Pozice> Read(SqlDataReader reader)
        {
            Collection<Pozice> poziceC = new Collection<Pozice>();

            while (reader.Read())
            {
                int i = -1;
                Pozice pozice = new Pozice();
                pozice.ID_pozice = reader.GetInt32(++i);
                pozice.Nazev = reader.GetString(++i);

                poziceC.Add(pozice);
            }
            return poziceC;
        }
    }
}
