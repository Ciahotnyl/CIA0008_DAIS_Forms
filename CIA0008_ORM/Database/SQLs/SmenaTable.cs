using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA0008_ORM.Database.SQLs
{
    class SmenaTable
    {
        public static String SQL_SELECT = "SELECT * FROM Smena";

        public static String SQL_SELECT_ID = "SELECT * FROM Smena WHERE ID_smeny=@ID_smeny";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_smeny) FROM Smena";
        public static String SQL_INSERT = "INSERT INTO Smena VALUES (@Popis)";
        public static String SQL_DELETE_ID = "DELETE FROM Smena WHERE ID_smeny=@ID_smeny";
        public static String SQL_UPDATE = "UPDATE Smena SET Popis=@Popis WHERE ID_smeny=@ID_smeny";
        public static String SQL_POCET_SMENY = "SELECT COUNT(*) FROM SmenaTymu WHERE ID_smeny = @ID_smeny";

        public static int Insert(Smena smena, MyDatabase pDB = null)
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
            PrepareCommand(command, smena);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(Smena smena, MyDatabase pDb = null)
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
            PrepareCommand(command, smena);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Smena Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_smeny", id);
            SqlDataReader reader = db.Select(command);

            Collection<Smena> smeny = Read(reader);
            Smena smena = null;
            if (smeny.Count == 1)
            {
                smena = smeny[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (smena == null)
                Console.WriteLine("Smena neexistuje");

            return smena;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_SMENY);

            command.Parameters.AddWithValue("@ID_smeny", id);

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
            Collection<Smena> smeny = Select(pDb);

            int max = 0;

            foreach (Smena smena in smeny)
            {
                if (smena.ID_smeny > max)
                    max = smena.ID_smeny;
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

                command.Parameters.AddWithValue("@ID_smeny", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Smena> Select(MyDatabase pDb = null)
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

            Collection<Smena> smeny = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return smeny;
        }



        private static void PrepareCommand(SqlCommand command, Smena smena)
        {
            command.Parameters.AddWithValue("@ID_smeny", smena.ID_smeny);
            command.Parameters.AddWithValue("@Popis", smena.Popis);
        }

        private static Collection<Smena> Read(SqlDataReader reader)
        {
            Collection<Smena> smeny = new Collection<Smena>();

            while (reader.Read())
            {
                int i = -1;
                Smena smena = new Smena();
                smena.ID_smeny = reader.GetInt32(++i);
                smena.Popis = reader.GetString(++i);

                smeny.Add(smena);
            }
            return smeny;
        }
    }
}
