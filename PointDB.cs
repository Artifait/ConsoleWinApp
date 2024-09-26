using QuizTop.UI;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;

public class PointDB
{
    SqlConnection conn;
    public PointDB()
    {
        string conStr = @"Server=(localdb)\MSSQLLocalDB;
                Database=Fruits;
                Trusted_Connection=True;";
        conn = new SqlConnection(conStr);
    }

    public bool OpenDB()
    {
        try
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
                return true;
        }
        catch (Exception ex)
        {
            WindowsHandler.AddErroreWindow(new string[] { ex.Message });
        }
        CLoseBD();
        return false;
    }

    public void CLoseBD()
    {
        if (conn.State == ConnectionState.Open)
            conn.Close();
    }

    public bool IsWork() => conn.State == ConnectionState.Open;

    // Получить всю информацию
    public List<(int Id, string Name, string Type, string Color, int Calories)> GetAllInfo()
    {
        string query = "SELECT Id, Name, Type, Color, Calories FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        var result = new List<(int, string, string, string, int)>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add((reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetInt32(4)));
            }
        }

        return result;
    }

    // Получить все названия
    public List<string> GetAllNames()
    {
        string query = "SELECT Name FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        var result = new List<string>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }
        }

        return result;
    }

    // Получить все цвета
    public List<string> GetAllColors()
    {
        string query = "SELECT DISTINCT Color FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        var result = new List<string>();

        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                result.Add(reader.GetString(0));
            }
        }

        return result;
    }

    // Максимальная калорийность
    public int GetMaxCalories()
    {
        string query = "SELECT MAX(Calories) FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        return (int)command.ExecuteScalar();
    }

    // Минимальная калорийность
    public int GetMinCalories()
    {
        string query = "SELECT MIN(Calories) FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        return (int)command.ExecuteScalar();
    }

    // Средняя калорийность
    public double GetAvgCalories()
    {
        string query = "SELECT AVG(Calories) FROM FruitsAndVegetables";
        SqlCommand command = new SqlCommand(query, conn);
        return (double)command.ExecuteScalar();
    }
}
