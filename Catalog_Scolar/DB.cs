using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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

    public bool Connect()
    {
        try
        {
            string connectionString = "Server=localhost;Database=Online_School_Catalog;Trusted_Connection=True;";
            sqlConnHandle = new SqlConnection(connectionString);
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

    
    public string GetParola(string email)
    {
        try
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Parola FROM Utilizatori WHERE Email = @Email", sqlConnHandle))
            {
                cmd.Parameters.AddWithValue("@Email", email);
                return (string)cmd.ExecuteScalar();
            }
        }
        catch (SqlException e)
        {
            Console.WriteLine(e.Message);
            return null;
        }
    }

    
}

