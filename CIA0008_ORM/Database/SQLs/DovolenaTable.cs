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
    class DovolenaTable
    {
        public static String SQL_SELECT = "SELECT * FROM Dovolena";

        public static String SQL_SELECT_ID = "SELECT * FROM Dovolena WHERE ID_dovolene=@ID_dovolene";
        public static String SQL_SELECT_MAX_ID = "SELECT MAX(ID_dovolene) FROM Dovolenena";
        public static String SQL_INSERT = "INSERT INTO Dovolena VALUES (@ID_zamestnance, @ID_duvodu, @Od, @Do)";
        public static String SQL_DELETE_ID = "DELETE FROM Dovolena WHERE ID_dovolene=@ID_dovolene";
        public static String SQL_UPDATE = "UPDATE Dovolena SET ID_zamestnance=@ID_zamestnance, ID_duvodu=@ID_duvodu, Od=@Od, Do=@Do WHERE ID_dovolene=@ID_dovolene";
        public static String SQL_POCET_DOVOLENYCH = "SELECT COUNT(*) FROM Dovolena WHERE ID_dovolene=@ID_dovolene";

        public static int VlozeniNoveDovolene(int ID_zamestnance, DateTime Od, DateTime Do, int ID_duvod, MyDatabase pDb = null)
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
            SqlCommand command = db.CreateCommand("VlozeniNoveDovolene");
            command.CommandType = CommandType.StoredProcedure;

            SqlParameter input = new SqlParameter();
            input.ParameterName = "@ID_zamestnance";
            input.DbType = DbType.Int32;
            input.Value = ID_zamestnance;
            input.Direction = ParameterDirection.Input;
            command.Parameters.Add(input);

            SqlParameter input2 = new SqlParameter();
            input2.ParameterName = "@Od";
            input2.DbType = DbType.DateTime;
            input2.Value = Od;
            input2.Direction = ParameterDirection.Input;
            command.Parameters.Add(input2);

            SqlParameter input3 = new SqlParameter();
            input3.ParameterName = "@Do";
            input3.DbType = DbType.DateTime;
            input3.Value = Do;
            input3.Direction = ParameterDirection.Input;
            command.Parameters.Add(input3);

            SqlParameter input4 = new SqlParameter();
            input4.ParameterName = "@ID_duvod";
            input4.DbType = DbType.Int32;
            input4.Value = ID_duvod;
            input4.Direction = ParameterDirection.Input;
            command.Parameters.Add(input4);

            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }
            return ret;
        }


        public static Collection<Dovolena> VypisDovolenychZaUrciteObdobi(DateTime Od, DateTime Do, MyDatabase pDb = null)
        {
            String SQL_DOVOLENE_ZA_CAS = "SELECT * FROM Dovolena " +
                "WHERE Od BETWEEN '" + Convert.ToDateTime(Od).ToString("yyyy-MM-dd") + "' and '"+ Convert.ToDateTime(Do).ToString("yyyy-MM-dd") + "'";
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

            Collection<Dovolena> dovolene = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return dovolene;
        }

        public static int Insert(Dovolena dovolena, MyDatabase pDB = null)
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
            PrepareCommand(command, dovolena);
            int ret = db.ExecuteNonQuery(command);

            if (pDB == null)
            {
                db.Close();
            }

            return ret;
        }


        public static int Update(Dovolena dovolena, MyDatabase pDb = null)
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
            PrepareCommand(command, dovolena);
            int ret = db.ExecuteNonQuery(command);

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        public static Dovolena Select(int id, MyDatabase pDb = null)
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

            command.Parameters.AddWithValue("@ID_dovolene", id);
            SqlDataReader reader = db.Select(command);

            Collection<Dovolena> dovolene = Read(reader);
            Dovolena dovolena = null;
            if (dovolene.Count == 1)
            {
                dovolena = dovolene[0];
            }
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            if (dovolena == null)
                Console.WriteLine("Dovolena neexistuje");

            return dovolena;
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
            SqlCommand command = db.CreateCommand(SQL_POCET_DOVOLENYCH);

            command.Parameters.AddWithValue("@ID_dovolene", id);

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
            Collection<Dovolena> dovolene = Select(pDb);

            int max = 0;

            foreach (Dovolena dovolena in dovolene)
            {
                if (dovolena.ID_dovolene > max)
                    max = dovolena.ID_dovolene;
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

                command.Parameters.AddWithValue("@ID_dovolene", kID);
                ret = db.ExecuteNonQuery(command);
            }

            if (pDb == null)
            {
                db.Close();
            }

            return ret;
        }


        //3.4
        public static Collection<Dovolena> Select(MyDatabase pDb = null)
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

            Collection<Dovolena> dovolene = Read(reader);
            reader.Close();

            if (pDb == null)
            {
                db.Close();
            }

            return dovolene;
        }



        private static void PrepareCommand(SqlCommand command, Dovolena dovolena)
        {
            command.Parameters.AddWithValue("@ID_dovolene", dovolena.ID_dovolene);
            command.Parameters.AddWithValue("@ID_zamestnance", dovolena.ID_zamestnance);
            command.Parameters.AddWithValue("@ID_duvodu", dovolena.ID_duvodu);
            command.Parameters.AddWithValue("@Od", Convert.ToDateTime(dovolena.Od).ToString("yyyy-MM-dd"));
            command.Parameters.AddWithValue("@Do", Convert.ToDateTime(dovolena.Do).ToString("yyyy-MM-dd"));
        }

        private static Collection<Dovolena> Read(SqlDataReader reader)
        {
            Collection<Dovolena> dovolene = new Collection<Dovolena>();

            while (reader.Read())
            {
                int i = -1;
                Dovolena dovolena = new Dovolena();
                dovolena.ID_dovolene = reader.GetInt32(++i);
                dovolena.ID_zamestnance = reader.GetInt32(++i);
                dovolena.ID_duvodu = reader.GetInt32(++i);
                dovolena.Od = reader.GetDateTime(++i);
                dovolena.Do = reader.GetDateTime(++i);


                dovolene.Add(dovolena);
            }
            return dovolene;
        }
    }
}
