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
            ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["defaultM"].ToString();
        }


        // -------------------------------- Bolig -------------------------------------------------------------

        // Create new Bolig
        internal bool CreateBolig(Bolig bolig)
        {
            int NextBoligId = FindMaxBoligId();
            string NextBoligIdString = NextBoligId.ToString();

            string Command = "Insert Bolig (BoligId, Adresse, PostNr, UdbudsPris, Kvadratmeter, BoligType, Aktiv, SalgsPris, SalgsDato, MaeglerId)" +
                " values (@BoligId, @Adresse, @PostNr, @UdbudsPris, @Kvadratmeter, @BoligType, @Aktiv, @SalgsPris, @SalgsDato, @MaeglerId)";

            using SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Command, conn);


            cmd.Parameters.AddWithValue("@BoligId", NextBoligIdString);
            cmd.Parameters.AddWithValue("@Adresse", "Adresse");
            cmd.Parameters.AddWithValue("@PostNr", "PostNr");
            cmd.Parameters.AddWithValue("@UdbudsPris", "UdbudsPris");
            cmd.Parameters.AddWithValue("@Kvadratmeter", "Kvadratmeter");
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
                   
                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];

                    // Calculate squaremeterprice. If the listing is active then calc by UdbudsPris, else calc by Salgspris
                    int KvmPris;
                    if (Aktiv == true) 
                    {
                        int activeCalc = UdbudsPris / Kvadratmeter;
                        KvmPris = activeCalc;
                    }
                    else
                    {
                        int soldCalc = SalgsPris / Kvadratmeter;
                        KvmPris = soldCalc;
                    }

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

        internal List<Bolig> Searchbar(string txt)
        {
            // create list, ready for input
            List<Bolig> BoligList = new List<Bolig>();

            // sql selection of the given table
            string command = $"Select * from Bolig where Adresse Like '%{txt}%'";
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

                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];

                    // Calculate squaremeterprice. If the listing is active then calc by UdbudsPris, else calc by Salgspris
                    int KvmPris;
                    if (Aktiv == true)
                    {
                        int activeCalc = UdbudsPris / Kvadratmeter;
                        KvmPris = activeCalc;
                    }
                    else
                    {
                        int soldCalc = SalgsPris / Kvadratmeter;
                        KvmPris = soldCalc;
                    }

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
                        SalgsPris = SalgsPris,
                        SalgsDato = SalgsDato,
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
                    int boligId = BoligId;
                    string Adresse = (string)reader["Adresse"];
                    int PostNr = (int)reader["PostNr"];
                    int UdbudsPris = (int)reader["Udbudspris"];
                    int Kvadratmeter = (int)reader["Kvadratmeter"];

                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];

                    // Calculate squaremeterprice. If the listing is active then calc by UdbudsPris, else calc by Salgspris
                    int KvmPris;
                    if (Aktiv == true)
                    {
                        int activeCalc = UdbudsPris / Kvadratmeter;
                        KvmPris = activeCalc;
                    }
                    else
                    {
                        int soldCalc = SalgsPris / Kvadratmeter;
                        KvmPris = soldCalc;
                    }
                    SingleBolig = new Bolig {
                        BoligId = boligId,
                        Adresse = Adresse,
                        PostNr = PostNr,
                        UdbudsPris = UdbudsPris,
                        Kvadratmeter = Kvadratmeter,
                        KvmPris = KvmPris,
                        BoligType = BoligType,
                        Aktiv = Aktiv,
                        SalgsPris = SalgsPris,
                        SalgsDato = SalgsDato,
                        MaeglerId = MaeglerId
                    };
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

            // Method sets bool of active status aswell as a salesprice, salesdate and updates on the boligid that is given


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





        // -------------------- Ejendomsmæglere ---------------------------------------------------

        // Create new ejendomsmægler
        internal bool CreateMaegler(Saelger Saelger)
        {
            int NextMId = FindMaxMId();
            string NextMIdString = NextMId.ToString();

            string Command = "Insert Saelger (MId, MFname, MLname, MAktiv, MEmail, MTlfNr, Afdeling)" +
                " values (@MId, @MFname, @MLname, @MAktiv, @MEmail, @MTlfNr, @Afdeling)";

            using SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Command, conn);

            cmd.Parameters.AddWithValue("@MId", NextMIdString);
            cmd.Parameters.AddWithValue("@MFname", "MFname");
            cmd.Parameters.AddWithValue("@MLname", "MLname");
            cmd.Parameters.AddWithValue("@MAktiv", "MAktiv");
            cmd.Parameters.AddWithValue("@MEmail", "MEmail");
            cmd.Parameters.AddWithValue("@MTlfNr", "MTlfNr");
            cmd.Parameters.AddWithValue("@Afdeling", "Afdeling");

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


        // Get list of Ejendomsmæglere
        internal List<EjendomsMaegler> GetAllEjendomsMaegler()
        {
            // create list, ready for input
            List<EjendomsMaegler> EjendomsMaeglerList = new List<EjendomsMaegler>();

            // sql selection of the given table
            string command = "Select * from EjendomsMaegler";
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

                    int MId = (int)reader["MId"];
                    string MFname = (string)reader["MFname"];
                    string MLname = (string)reader["MLname"];
                    bool MAktiv = (bool)reader["MAktiv"];
                    string MEmail = (string)reader["MEmail"];
                    int MTlfNr = (int)reader["MTlfNr"];
                    int Afdeling = (int)reader["Afdeling"];

                    EjendomsMaegler maegler = new EjendomsMaegler
                    {
                        MId = MId,
                        MFname = MFname,
                        MLname = MLname,
                        MAktiv = MAktiv,
                        MEmail = MEmail,
                        MTlfNr = MTlfNr,
                        Afdeling = Afdeling,
                    };
                    EjendomsMaeglerList.Add(maegler);
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

            return EjendomsMaeglerList;
        }


        // Read/Get one Ejedomsmægler
        internal EjendomsMaegler GetSingleEjendomsMaegler(int MId)
        {
            EjendomsMaegler SingleEjendomsMaegler = new EjendomsMaegler();
            // sql selection of the given table
            string command = "Select * from EjendomsMaegler where MId = @MId";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Mid", MId);
            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SingleEjendomsMaegler = new EjendomsMaegler()
                    {
                        MId = (int)reader["MId"],
                        MFname = (string)reader["MFname"],
                        MLname = (string)reader["MLname"],
                        MAktiv = (bool)reader["MAktiv"],
                        MEmail = (string)reader["MEmail"],
                        MTlfNr = (int)reader["MTlfNr"],
                        Afdeling = (int)reader["Afdeling"]
                    };

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


            return SingleEjendomsMaegler;
        }


        // Update Ejendomsmægler 
        internal bool UpdateEjendomsMaegler(EjendomsMaegler ejendomsMaegler, int MId)
        {

            // sql selection of the given table
            string command = "UPDATE EjendomsMaegler SET Afdeling = (@Afdeling) WHERE MId = (@MId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@MId", MId);
            cmd.Parameters.AddWithValue("@Afdeling", ejendomsMaegler.Afdeling);



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


        // delete Ejendomsmægler
        internal bool HardDeleteEjendomsMaeglerFromDB(int MId)
        {

            // sql selection of the given table
            string command = "Delete from EjendomsMaegler where MId = (@MId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@MId", MId);
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



        // -------------------- Kunder ---------------------------------------------------

        // Create new Kunde
        internal bool CreateKunde(Kunde kunde)
        {
            int NextKId = FindMaxKId();
            string NextKIdString = NextKId.ToString();

            string Command = "Insert Saelger (KId, KFname, KLname, KBoligId, KEmail, KTlfNr)" +
                " values (@KId, @KFname, @KLname, @KBoligId, @KEmail, @KTlfNr)";

            using SqlConnection conn = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(Command, conn);

            cmd.Parameters.AddWithValue("@KId", NextKIdString);
            cmd.Parameters.AddWithValue("@KFname", "KFname");
            cmd.Parameters.AddWithValue("@KLname", "KLname");
            cmd.Parameters.AddWithValue("@KBoligId", "KBoligId");
            cmd.Parameters.AddWithValue("@KEmail", "KEmail");
            cmd.Parameters.AddWithValue("@KTlfNr", "KTlfNr");

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



        // Get list of kunder
        internal List<Kunde> GetAllKunder()
        {
            // create list, ready for input
            List<Kunde> kundeList = new List<Kunde>();

            // sql selection of the given table
            string command = "Select * from Kunde";
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

                    int KId = (int)reader["KId"];
                    string KFname = (string)reader["KFname"];
                    string KLname = (string)reader["KLname"];
                    int KBoligId = (int)reader["KBoligId"];
                    string KEmail = (string)reader["KEmail"];
                    int KTlfNr = (int)reader["KTlfNr"];

                    Kunde kunde = new Kunde()
                    {
                        KId = KId,
                        KFname = KFname,
                        KLname = KLname,
                        KBoligId = KBoligId,
                        KEmail = KEmail,
                        KTlfNr = KTlfNr
                    };
                    kundeList.Add(kunde);
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

            return kundeList;
        }



        // Read/Get one Kunde
        internal Kunde GetSingleKunde(int KId)
        {
            Kunde SingleKunde = new Kunde();
            // sql selection of the given table
            string command = "Select * from Kunde where KId = @KId";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Kid", KId);
            try
            {
                // opening the connection to the sql table in mssql
                conn.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    SingleKunde = new Kunde
                    {
                        KId = (int)reader["KId"],
                        KFname = (string)reader["KFname"],
                        KLname = (string)reader["KLname"],
                        KBoligId = (int)reader["KBoligId"],
                        KEmail = (string)reader["KEmail"],
                        KTlfNr = (int)reader["KTlfNr"]
                    };

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


            return SingleKunde;
        }



        // Update Kunde ved salg 
        internal bool UpdateKunde(Kunde kunde, int KId)
        {

            // sql selection of the given table
            string command = "UPDATE Kunde SET KBoligId = (@KBoligId) WHERE KId = (@KId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@Kd", KId);
            cmd.Parameters.AddWithValue("@KBoligId", kunde.KBoligId);



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



        // delete Kunde
        internal bool HardDeleteKundeFromDB(int KId)
        {

            // sql selection of the given table
            string command = "Delete from Kunde where KId = (@KId)";
            // using sqlconnection
            using SqlConnection conn = new SqlConnection(ConnectionString);
            // save connection in variable - to handle commands
            SqlCommand cmd = new SqlCommand(command, conn);

            cmd.Parameters.AddWithValue("@KId", KId);
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

            // The file is saved to this path. that means that you have to have a folder on your C: disk that is called "csv"
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
                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int MaeglerId = (int)reader["MaeglerId"];
                    int KvmPris = UdbudsPris / Kvadratmeter;
                   

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
            // streamwriter takes the list and exports it to all kinds of files.
            // this is a list that is printed in a file that is seperated by ; and exported to csv, so that the ouput has its own field in an file in excel
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

            // The path for where the file is stored, it overides each time you run it. Need to have a foulder called "csv" on your C: drive
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
                    
                    string BoligType = (string)reader["BoligType"];
                    bool Aktiv = (bool)reader["Aktiv"];
                    int SalgsPris = (int)reader["SalgsPris"];
                    DateTime SalgsDato = (DateTime)reader["SalgsDato"];
                    int MaeglerId = (int)reader["MaeglerId"];
                    int KvmPris;
                    if (Aktiv == true)
                    {
                        int activeCalc = UdbudsPris / Kvadratmeter;
                        KvmPris = activeCalc;
                    }
                    else
                    {
                        int soldCalc = SalgsPris / Kvadratmeter;
                        KvmPris = soldCalc;
                    }

                    int MId = (int)reader["MId"];
                    string MFname = (string)reader["MFname"];
                    string MLname = (string)reader["MLname"];
                    bool MAktiv = (bool)reader["MAktiv"];
                    string MEmail = (string)reader["MEmail"];
                    int MTlfNr = (int)reader["MTlfNr"];
                    int Afdeling = (int)reader["Afdeling"];

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
                        Afdeling = Afdeling,

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

            // streamwriter takes the list and exports it to all kinds of files.
            // this is a list that is printed in a file that is seperated by ; and exported to csv, so that the ouput has its own field in an file in excel
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Bolig;-;-;-;-;-;-;-;-;-;-;EjendomsMægler;-;-;-;-;-;-;Sælger;-;-;-;-;-;");
                writer.WriteLine("BoligID;Adresse;PostNr;UdbudsPris;Kavdratmeter;KvmPris;BoligType;Aktiv;SalgsPris;SalgsDato;MaeglerId;Mægler ID;Fornavn;Efternavn;Aktiv;Email;Tlf;Afdeling;ID;Fornavn;Efternavn;BoligId;Email;Tlf");

                foreach (BoligMaeglerSaelger Item in List)
                {
                    writer.WriteLine($"{Item.BoligId};{Item.Adresse};{Item.PostNr};{Item.UdbudsPris};{Item.Kvadratmeter};{Item.KvmPris};{Item.BoligType};{Item.Aktiv};{Item.SalgsPris};{Item.SalgsDato};{Item.MaeglerId};" +
                        $"{Item.MId};{Item.MFname};{Item.MLname};{Item.MAktiv};{Item.MEmail};{Item.MTlfNr};{Item.Afdeling};{Item.SId};{Item.SFname};{Item.SLname};{Item.SBoligId};{Item.SEmail};{Item.STlfNr};");
                }
            }

            return List;

        }






        // --------------------------- MaxId -------------------------------------

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

        internal int FindMaxMId()
        {
            EjendomsMaegler ejendomsmaegler = new EjendomsMaegler();
            string command = "Select max(MId) as id from EjendomsMaegler";
            using SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(command, connection);

            try
            {
                connection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ejendomsmaegler = new EjendomsMaegler { MId = reader.GetInt32("id") };
                    ejendomsmaegler.MId = reader.GetInt32("id") + 1;
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
            int MaxMId = ejendomsmaegler.MId;

            return MaxMId;
        }

        internal int FindMaxKId()
        {
            Kunde kunde = new Kunde();
            string command = "Select max(KId) as id from Kunde";
            using SqlConnection connection = new SqlConnection(ConnectionString);

            SqlCommand cmd = new SqlCommand(command, connection);

            try
            {
                connection.Open();
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    kunde = new Kunde { KId = reader.GetInt32("id") };
                    kunde.KId = reader.GetInt32("id") + 1;
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
            int MaxKId = kunde.KId;

            return MaxKId;
        }



    }
}
