using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;


public class DB
{
    private static DB instance = null;
    private SqlConnection sqlConnHandle = null;

    private DB() { }

    public static DB GetInstance()
    {
        if (instance == null)
        {

            instance = new DB();
            if (!instance.Connect())
            {
                MessageBox.Show("Failed to connect to the database.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
        }
        return instance;
    }

    public static void DestroyInstance()
    {
        if (instance != null)
        {
            instance.Disconnect();
            instance = null;
        }
    }

    public SqlConnection GetSqlConnection()
    {
        return sqlConnHandle;   
    }
        
    public bool Connect()
    {
        try
        {
            var connectionString = ConfigurationManager.ConnectionStrings["Online_School_Catalog"];

            sqlConnHandle = new SqlConnection(connectionString.ConnectionString);
            sqlConnHandle.Open();
            return true;
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
    }

    public void Disconnect()
    {
        if (sqlConnHandle != null && sqlConnHandle.State == System.Data.ConnectionState.Open)
        {
            sqlConnHandle.Close();
        }
    }

    //public static bool SaveData(string email,string lastname,string firstname,string password,string rol)
    //{
    //    DB db = DB.GetInstance();

    //    if (!db.Connect())
    //    {
    //        MessageBox.Show("Failed to connect to the database.", "Connection Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //        return false;
    //    }

    //    try
    //    {
    //        using (SqlCommand checkEmailCommand = new SqlCommand("SELECT COUNT(*) FROM Utilizator WHERE Email = @Email", db.sqlConnHandle))
    //        {
    //            checkEmailCommand.Parameters.AddWithValue("@Email",email);

    //            int count = (int)checkEmailCommand.ExecuteScalar();
    //            if (count > 0)
    //            {
    //                MessageBox.Show("Email already in use.", "Duplicate Email", MessageBoxButton.OK, MessageBoxImage.Warning);
    //                return false;
    //            }
    //        }

    //        using (SqlCommand insertCommand = new SqlCommand(
    //            "INSERT INTO Utilizator (Email, Parola, Rol) VALUES (@Email, @Password, @Rol)",
    //            db.sqlConnHandle))
    //        {
    //            insertCommand.Parameters.AddWithValue("@Email", email);
    //            insertCommand.Parameters.AddWithValue("@Password", password);
    //            insertCommand.Parameters.AddWithValue("@Rol", Convert.ToInt32(rol));

    //            int rowsAffected = insertCommand.ExecuteNonQuery();

    //            if (rol == "Profesor") rol = "1";
    //            else if (rol == "Elev") rol = "0";
    //            else if (rol == "Parinte") rol = "2";

    //            //elev
    //            if(Convert.ToInt32(rol) == 0)
    //            {
    //                using (SqlCommand insertCommandElevi = new SqlCommand(
    //                        "INSERT INTO Elevi (Nume,Prenume) VALUES (@LastName, @FirstName)",
    //                        db.sqlConnHandle))
    //                {
    //                    insertCommandElevi.Parameters.AddWithValue("@LastName", lastname);
    //                    insertCommandElevi.Parameters.AddWithValue("@FirstName", firstname);
    //                }
    //            }

    //            //profesor
    //            if (Convert.ToInt32(rol) == 1)
    //            {
    //                using (SqlCommand insertCommandprof = new SqlCommand(
    //                        "INSERT INTO Profesor (Nume,Prenume) VALUES (@LastName, @FirstName)",
    //                        db.sqlConnHandle))
    //                {
    //                    insertCommandprof.Parameters.AddWithValue("@LastName", lastname);
    //                    insertCommandprof.Parameters.AddWithValue("@FirstName", firstname);
    //                }
    //            }

    //            //parinti
    //            if (Convert.ToInt32(rol) == 2)
    //            {
    //                using (SqlCommand insertCommandparinte = new SqlCommand(
    //                        "INSERT INTO Parinti (Nume,Prenume) VALUES (@LastName, @FirstName)",
    //                        db.sqlConnHandle))
    //                {
    //                    insertCommandparinte.Parameters.AddWithValue("@LastName", lastname);
    //                    insertCommandparinte.Parameters.AddWithValue("@FirstName", firstname);
    //                }
    //            }

    //            return rowsAffected > 0;
    //        }
    //    }
    //    catch (SqlException ex)
    //    {
    //        MessageBox.Show(ex.Message, "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
    //        return false;
    //    }
    //    finally
    //    {
    //        db.Disconnect();
    //    }
    //}

}
