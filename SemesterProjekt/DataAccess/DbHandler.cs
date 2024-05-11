using SemesterProjekt.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.IO;
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


        // -------------------------------- Bolig -------------------------------------------------------------

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
        internal bool MarkBoligAsSold(Bolig bolig, int BoligId)
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



        // -------------------- Sælgere ---------------------------------------------------

        // Create new Sælger
        internal bool CreateSaelger(Saelger Saelger)
        {
            int NextSId = FindMaxSId();
            string NextSIdString = NextSId.ToString();

            string Command = "Insert Saelger (SId, SFname, SLname, SBoligId, SEmail, STlfNr)" +
                " values (@SId, @SFname, @SLname, @SBoligId, @SEmail, @STlfNr)";

            using SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Command, conn);

            cmd.Parameters.AddWithValue("@SId", NextSIdString);
            cmd.Parameters.AddWithValue("@SFname", "SFname");
            cmd.Parameters.AddWithValue("@SLname", "SLname");
            cmd.Parameters.AddWithValue("@SBoligId", "SBoligId");
            cmd.Parameters.AddWithValue("@SEmail", "SEmail");
            cmd.Parameters.AddWithValue("@STlfNr", "STlfNr");

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



        // Get list of Sælgere
        internal List<Saelger> GetAllSaelger()
        {
            // create list, ready for input
            List<Saelger> SaelgerList = new List<Saelger>();

            // sql selection of the given table
            string command = "Select * from Saelger";
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

                    int SId = (int)reader["SId"];
                    string SFname = (string)reader["SFname"];
                    string SLname = (string)reader["SLname"];
                    int SBoligId = (int)reader["SBoligId"];
                    string SEmail = (string)reader["SEmail"];
                    int STlfNr = (int)reader["STlfNr"];

                    Saelger saelger = new Saelger
                    {
                        SId = SId,
                        SFname = SFname,
                        SLname = SLname,
                        SBoligId = SBoligId,
                        SEmail = SEmail,
                        STlfNr = STlfNr
                    };
                    SaelgerList.Add(saelger);
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

            return SaelgerList;
        }



        // Read/Get one Sælger
        internal Saelger GetSingleSaelger(int SId)
        {
            Saelger SingleSaelger = new Saelger();
            // sql selection of the given table
            string command = "Select * from Saelger where SId = @SId";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Sid", SId);
            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SingleSaelger = new Saelger
                        {
                        SId = (int)reader["SId"],
                        SFname = (string)reader["SFname"],
                        SLname = (string)reader["SLname"],
                        SBoligId = (int)reader["SBoligId"],
                        SEmail = (string)reader["SEmail"],
                        STlfNr = (int)reader["STlfNr"] };
                
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


            return SingleSaelger;
        }



        // Update Sælger 
        internal bool UpdateSaelger(Saelger saelger, int SId)
        {

            // sql selection of the given table
            string command = "UPDATE saelger SET STlfNr = (@STlfNr) WHERE SId = (@SId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@SId", SId);
            cmd.Parameters.AddWithValue("@STlfNr", saelger.STlfNr);



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



        // delete Sælger
        internal bool HardDeleteSaelgerFromDB(int SId)
        {

            // sql selection of the given table
            string command = "Delete from Saelger where SId = (@SId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@SId", SId);
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



        // ------------------------- CSV Files ----------------------------------------------------------------------------

        // Boliger til salg, export to CSV
        internal List<Bolig> GetCSVAllBoligActive()
        {
            // create list, ready for input
            List<Bolig> BoligList = new List<Bolig>();
            string path = "C:\\csv\\EDC-BoligerTilSalg.csv";

            // sql selection of the given table
            string command = "Select * from Bolig where aktiv = 1";
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
                    int MaeglerId = (int)reader["MaeglerId"];

                    Bolig bolig = new Bolig
                    {
                        BoligId = BoligId,
                        Adresse = Adresse,
                        PostNr = PostNr,
                        UdbudsPris = UdbudsPris,
                        Kvadratmeter = Kvadratmeter,
                        KvmPris = KvmPris,
                        BoligType = BoligType,
                        Aktiv = Aktiv,
                        MaeglerId = MaeglerId
                    };
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
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("BoligID;Adresse;PostNr;UdbudsPris;Kavdratmeter;KvmPris;BoligType;Aktiv;MaeglerId");

                foreach (Bolig bolig in BoligList)
                {
                    writer.WriteLine($"{bolig.BoligId};{bolig.Adresse};{bolig.PostNr};{bolig.UdbudsPris};{bolig.Kvadratmeter};{bolig.KvmPris};{bolig.BoligType};{bolig.Aktiv};{bolig.MaeglerId}");
                }
            }

            return BoligList;
           
        }



        // Boliger fra bestemt Postnummer, med mægler og sælger info til CSV
        internal List<BoligMaeglerSaelger> GetCSVEverything(int PostNr)
        {
            // create list, ready for input
            List<BoligMaeglerSaelger> List = new List<BoligMaeglerSaelger>();
            string path = "C:\\csv\\EDC-OverviewList.csv";

            // sql selection of the given table
            string command = "Select * from Bolig, Ejendomsmaegler, Saelger where MaeglerId = MId and BoligId = SBoligId and PostNr = (@PostNr)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);

            

            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                // save connection in variable - to handle commands
                SqlCommand cmd = new SqlCommand(command, conn);

                cmd.Parameters.AddWithValue("@PostNr", PostNr);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {

                    int BoligId = (int)reader["BoligId"];
                    string Adresse = (string)reader["Adresse"];
                    int postNr = PostNr;
                    int UdbudsPris = (int)reader["Udbudspris"];
                    int Kvadratmeter = (int)reader["Kvadratmeter"];
                    int KvmPris = (int)reader["KvmPris"];
                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];

                    int MId = (int)reader["MId"];
                    string MFname = (string)reader["MFname"];
                    string MLname = (string)reader["MLname"];
                    bool MAktiv = (bool)reader["MAktiv"];
                    string MEmail = (string)reader["MEmail"];
                    int MTlfNr = (int)reader["MTlfNr"];

                    int SId = (int)reader["SId"];
                    string SFname = (string)reader["SFname"];
                    string SLname = (string)reader["SLname"];
                    int SBoligId = (int)reader["SBoligId"];
                    string SEmail = (string)reader["SEmail"];
                    int STlfNr = (int)reader["STlfNr"];

                    BoligMaeglerSaelger boligMm = new BoligMaeglerSaelger
                    {
                        BoligId = BoligId,
                        Adresse = Adresse,
                        PostNr = postNr,
                        UdbudsPris = UdbudsPris,
                        Kvadratmeter = Kvadratmeter,
                        KvmPris = KvmPris,
                        BoligType = BoligType,
                        Aktiv = Aktiv,
                        SalgsPris = SalgsPris,
                        SalgsDato = SalgsDato,
                        MaeglerId = MaeglerId,

                        MId = MId,
                        MFname = MFname,
                        MLname = MLname,
                        MAktiv = MAktiv,
                        MEmail = MEmail,
                        MTlfNr = MTlfNr,

                        SId = SId,
                        SFname = SFname,
                        SLname = SLname,
                        SBoligId = SBoligId,
                        SEmail = SEmail,
                        STlfNr = STlfNr
                    };
                    List.Add(boligMm);
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
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Bolig;-;-;-;-;-;-;-;-;-;-;EjendomsMægler;-;-;-;-;-;Sælger;-;-;-;-;-;");
                writer.WriteLine("BoligID;Adresse;PostNr;UdbudsPris;Kavdratmeter;KvmPris;BoligType;Aktiv;SalgsPris;SalgsDato;MaeglerId;Mægler ID;Fornavn;Efternavn;Aktiv;Email;Tlf;ID;Fornavn;Efternavn;BoligId;Email;Tlf");

                foreach (BoligMaeglerSaelger Item in List)
                {
                    writer.WriteLine($"{Item.BoligId};{Item.Adresse};{Item.PostNr};{Item.UdbudsPris};{Item.Kvadratmeter};{Item.KvmPris};{Item.BoligType};{Item.Aktiv};{Item.SalgsPris};{Item.SalgsDato};{Item.MaeglerId};" +
                        $"{Item.MId};{Item.MFname};{Item.MLname};{Item.MAktiv};{Item.MEmail};{Item.MTlfNr};{Item.SId};{Item.SFname};{Item.SLname};{Item.SBoligId};{Item.SEmail};{Item.STlfNr};");
                }
            }

            return List;

        }






        // --------------------------- Ekstra Features -------------------------------------

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

        internal int FindMaxSId()
        {
            Saelger saelger = new Saelger();
            string command = "Select max(SId) as id from Saelger";
            using SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(command, connection);

            try
            {
                connection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    saelger = new Saelger { SId = reader.GetInt32("id") };
                    saelger.SId = reader.GetInt32("id") + 1;
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
            int MaxSId = saelger.SId;

            return MaxSId;
        }
    }
}
