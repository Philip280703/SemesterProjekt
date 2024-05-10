using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemesterProjekt.DataAccess
{
    internal class DbHandler
    {
        string ConnectionString;
        public DbHandler() 
        { 
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultP"].ToString();
        }


        // Create new Bolig
        internal bool CreateBolig(Bolig bolig)
        {
            int NextBoligId = FindMaxBoligId();
            string NextBoligIdString = NextBoligId.ToString();

            int CalcKvmPris = bolig.UdbudsPris / bolig.Kvadratmeter;

            string Command = "Insert Bolig (BoligId, Adresse, PostNr, UdbudsPris, Kvadratmeter, KvmPris, BoligType, Aktiv, SalgsPris, SalgsDato, MaeglerId)" +
                " values (@BoligId, @Adresse, @PostNr, @UdbudsPris, @Kvadratmeter, @KvmPris, @BoligType, @Aktiv, @SalgsPris, @SalgsDato, @MaeglerId)";

            using SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Command, conn);

            cmd.Parameters.AddWithValue("@BoligId", NextBoligIdString);
            cmd.Parameters.AddWithValue("@Adresse", "Adresse");
            cmd.Parameters.AddWithValue("@PostNr", "PostNr");
            cmd.Parameters.AddWithValue("@UdbudsPris", "UdbudsPris");
            cmd.Parameters.AddWithValue("@Kvadratmeter", "Kvadratmeter");
            cmd.Parameters.AddWithValue("@KvmPris", CalcKvmPris);
            cmd.Parameters.AddWithValue("@BoligType", "BoligType");
            cmd.Parameters.AddWithValue("@Aktiv", "Aktiv");
            cmd.Parameters.AddWithValue("@SalgsPris", "SalgsPris");
            cmd.Parameters.AddWithValue("@SalgsDato", "SalgsDato");
            cmd.Parameters.AddWithValue("@MaeglerId", "MaeglerId");

            int Rows = 0;
            try
            {
                conn.Open();
                Rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.Message);
            }
            finally 
            { 
                conn.Close(); 
            }
            if (Rows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }



        // Get list of Bolig
        internal List<Bolig> GetAllBolig()
        {
            // create list, ready for input
            List<Bolig> BoligList = new List<Bolig>();

            // sql selection of the given table
            string command = "Select * from Bolig";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);

            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                // save connection in variable - to handle commands
                SqlCommand cmd = new SqlCommand(command, conn);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    int BoligId = (int)reader["BoligId"];
                    string Adresse = (string)reader["Adresse"];
                    int PostNr = (int)reader["PostNr"];
                    int UdbudsPris = (int)reader["Udbudspris"];
                    int Kvadratmeter = (int)reader["Kvadratmeter"];
                    int KvmPris = (int)reader["KvmPris"];
                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];

                    Bolig bolig = new Bolig { BoligId = BoligId, Adresse = Adresse, PostNr = PostNr, UdbudsPris = UdbudsPris, Kvadratmeter = Kvadratmeter, 
                        KvmPris = KvmPris, BoligType = BoligType, Aktiv = Aktiv, SalgsPris = SalgsPris, SalgsDato = SalgsDato, MaeglerId = MaeglerId };
                    BoligList.Add(bolig);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn.Close();
            }

            return BoligList;
        }



        // Read/Get one Bolig
        internal Bolig GetSingleBolig(int BoligId)
        {
            Bolig SingleBolig = new Bolig();
            // sql selection of the given table
            string command = "Select * from Bolig where BoligId = @BoligId";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Boligid", BoligId);
            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SingleBolig = new Bolig { BoligId = (int)reader["BoligId"], Adresse = (string)reader["Title"], PostNr = (int)reader["PostNr"], UdbudsPris = (int)reader["Udbudspris"], 
                        Kvadratmeter = (int)reader["Kvadratmeter"], KvmPris = (int)reader["KvmPris"], BoligType = (string)reader["BoligType"], Aktiv = (bool)reader["Aktiv"], 
                        SalgsPris = (int)reader["SalgsPris"], SalgsDato = (DateTime)reader["SalgsDato"], MaeglerId = (int)reader["MaeglerId"] };
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                conn.Close();
            }


            return SingleBolig;
        }



        // Update Bolig
        internal bool UpdateBolig(Bolig bolig, int BoligId)
        {

            // sql selection of the given table
            string command = "UPDATE Bolig SET UdbudsPris = (@UdbudsPris) WHERE BoligId = (@BoligId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@BoligId", BoligId);
            cmd.Parameters.AddWithValue("@UdbudsPris", bolig.UdbudsPris);



            int rows = 0;
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }

            catch (Exception lm)
            {
                Console.WriteLine(lm.Message);
            }
            finally
            {
                conn.Close();
            }

            if (rows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        // Sold Bolig, mark as not avaliable
        internal bool SoldBoligMethod(Bolig bolig, int BoligId)
        {

            // sql selection of the given table
            string command = "UPDATE Bolig SET Aktiv = (@Aktiv), Salgspris = (@Salgspris), SalgsDato = (@SalgsDato) WHERE BoligId = (@BoligId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@BoligId", BoligId);
            cmd.Parameters.AddWithValue("@UdbudsPris", bolig.UdbudsPris);
            cmd.Parameters.AddWithValue("@Salgspris", bolig.SalgsPris);
            cmd.Parameters.AddWithValue("@SalgsDato", bolig.SalgsDato);



            int rows = 0;
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }

            catch (Exception ll)
            {
                Console.WriteLine(ll.Message);
            }
            finally
            {
                conn.Close();
            }

            if (rows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        // Hard Delete Bolig - Never Use!
        internal bool HardDeleteBoligFromDB(int BoligId)
        {

            // sql selection of the given table
            string command = "Delete from bolig where BoligId = (@BoligId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@BoligId", BoligId);
            int rows = 0;
            try
            {
                conn.Open();
                rows = cmd.ExecuteNonQuery();
            }

            catch (Exception lm)
            {
                Console.WriteLine(lm.Message);
            }
            finally
            {
                conn.Close();
            }

            if (rows == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }






        // find max id, function for Create method
        internal int FindMaxBoligId()
        {
            Bolig bolig = new Bolig();
            string command = "Select max(BoligId) as id from Bolig";
            using SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(command, connection);

            try
            {
                connection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bolig = new Bolig { BoligId = reader.GetInt32("id") };
                    bolig.BoligId = reader.GetInt32("id") + 1;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            int MaxBoligId = bolig.BoligId;

            return MaxBoligId;
        }
    }
}
