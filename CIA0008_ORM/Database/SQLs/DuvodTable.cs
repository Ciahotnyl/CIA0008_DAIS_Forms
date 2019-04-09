using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class DuvodTable
    {
        public static String SQL_SELECT = "SELECT * FROM Duvod";

        public static String SQL_SELECT_ID = "SELECT * FROM Duvod WHERE ID_duvodu=@ID_duvodu";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_duvodu) FROM Duvod";
        public static String SQL_INSERT = "INSERT INTO Duvod VALUES (@Nazev)";
        public static String SQL_DELETE_ID = "DELETE FROM Duvod WHERE ID_duvodu=@ID_duvodu";
        public static String SQL_UPDATE = "UPDATE Duvod SET Nazev=@Nazev WHERE ID_duvodu=@ID_duvodu";
        public static String SQL_POCET_DUVODY = "SELECT COUNT(*) FROM Dovolena WHERE ID_duvodu = @ID_duvodu";

        public static int Insert(Duvod duvod, MyDatabase pDB = null)
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
            PrepareCommand(command, duvod);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(Duvod duvod, MyDatabase pDb = null)
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
            PrepareCommand(command, duvod);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Duvod Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_duvodu", id);
            SqlDataReader reader = db.Select(command);

            Collection<Duvod> duvody = Read(reader);
            Duvod duvod = null;
            if (duvody.Count == 1)
            {
                duvod = duvody[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (duvod == null)
                Console.WriteLine("Duvod neexistuje");

            return duvod;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_DUVODY);

            command.Parameters.AddWithValue("@ID_duvodu", id);

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
            Collection<Duvod> duvody = Select(pDb);

            int max = 0;

            foreach (Duvod duvod in duvody)
            {
                if (duvod.ID_duvodu > max)
                    max = duvod.ID_duvodu;
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

                command.Parameters.AddWithValue("@ID_duvodu", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Duvod> Select(MyDatabase pDb = null)
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

            Collection<Duvod> duvody = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return duvody;
        }



        private static void PrepareCommand(SqlCommand command, Duvod duvod)
        {
            command.Parameters.AddWithValue("@ID_duvodu", duvod.ID_duvodu);
            command.Parameters.AddWithValue("@Nazev", duvod.Nazev);
        }

        private static Collection<Duvod> Read(SqlDataReader reader)
        {
            Collection<Duvod> duvody = new Collection<Duvod>();

            while (reader.Read())
            {
                int i = -1;
                Duvod duvod = new Duvod();
                duvod.ID_duvodu = reader.GetInt32(++i);
                duvod.Nazev = reader.GetString(++i);

                duvody.Add(duvod);
            }
            return duvody;
        }
    }
}
