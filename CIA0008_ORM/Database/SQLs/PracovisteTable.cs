using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class PracovisteTable
    {
        public static String SQL_SELECT = "SELECT * FROM Pracoviste";

        public static String SQL_SELECT_ID = "SELECT * FROM Pracoviste WHERE ID_pracoviste=@ID_pracoviste";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_pracoviste) FROM Pracoviste";
        public static String SQL_INSERT = "INSERT INTO Pracoviste VALUES (@ID_nadrizenehoPracoviste, @Nazev)";
        public static String SQL_DELETE_ID = "DELETE FROM Pracoviste WHERE ID_pracoviste=@ID_pracoviste";
        public static String SQL_UPDATE = "UPDATE Pracoviste SET ID_nadrizenehoPracoviste=@ID_nadrizenehoPracoviste, Nazev=@Nazev WHERE ID_pracoviste=@ID_pracoviste";
        public static String SQL_POCET_PRACOVISTE = "SELECT COUNT(*) FROM Pracoviste WHERE ID_pracoviste = @ID_pracoviste";

        public static int Insert(Pracoviste pracoviste, MyDatabase pDB = null)
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
            PrepareCommand(command, pracoviste);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(Pracoviste pracoviste, MyDatabase pDb = null)
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
            PrepareCommand(command, pracoviste);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Pracoviste Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_pracoviste", id);
            SqlDataReader reader = db.Select(command);

            Collection<Pracoviste> pracovisteC = Read(reader);
            Pracoviste pracoviste = null;
            if (pracovisteC.Count == 1)
            {
                pracoviste = pracovisteC[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (pracoviste == null)
                Console.WriteLine("Pracoviste neexistuje");

            return pracoviste;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_PRACOVISTE);

            command.Parameters.AddWithValue("@ID_pracoviste", id);

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
            Collection<Pracoviste> pracovisteC = Select(pDb);

            int max = 0;

            foreach (Pracoviste pracoviste in pracovisteC)
            {
                if (pracoviste.ID_pracoviste > max)
                    max = pracoviste.ID_pracoviste;
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

                command.Parameters.AddWithValue("@ID_pracoviste", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Pracoviste> Select(MyDatabase pDb = null)
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

            Collection<Pracoviste> pracovisteC = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return pracovisteC;
        }



        private static void PrepareCommand(SqlCommand command, Pracoviste pracoviste)
        {
            command.Parameters.AddWithValue("@ID_pracoviste", pracoviste.ID_pracoviste);
            command.Parameters.AddWithValue("@ID_nadrizenehoPracoviste",  (object)pracoviste.ID_nadrizenehoPracoviste ?? DBNull.Value);
            command.Parameters.AddWithValue("@Nazev", pracoviste.Nazev);
        }

        private static Collection<Pracoviste> Read(SqlDataReader reader)
        {
            Collection<Pracoviste> pracovisteC = new Collection<Pracoviste>();

            while (reader.Read())
            {
                int i = -1;
                Pracoviste pracoviste = new Pracoviste();
                pracoviste.ID_pracoviste = reader.GetInt32(++i);
                int ix = i++;
                pracoviste.ID_nadrizenehoPracoviste = reader.IsDBNull(ix) ? (int?)reader.GetInt32(ix) : null;
                pracoviste.Nazev = reader.GetString(++i);

                pracovisteC.Add(pracoviste);
            }
            return pracovisteC;
        }
    }
}
