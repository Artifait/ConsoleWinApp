using QuizTop.UI;
using System.Data;
using System.Data.SqlClient;

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
        if (IsWork()) return true;
        try
        {
            conn.Open();
            if (conn.State == ConnectionState.Open)
                return true;
        }
        catch (Exception ex)
        {
            WindowsHandler.AddErroreWindow(new string[] { ex.Message }, true);
        }
        return false;
    }

    public void CloseDB()
    {
        if (conn.State == ConnectionState.Open)
            conn.Close();
    }

    public bool IsWork() => conn.State == ConnectionState.Open;

    // Получить всю информацию
    public DataTable GetAllInfo()
    {
        string query = "SELECT Id, Name, Type, Color, Calories FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    // Получить все названия
    public DataTable GetAllNames()
    {
        string query = "SELECT Name FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    // Получить все цвета
    public DataTable GetAllColors()
    {
        string query = "SELECT DISTINCT Color FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    // Максимальная калорийность
    public DataTable GetMaxCalories()
    {
        string query = "SELECT MAX(Calories) AS MaxCalories FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    // Минимальная калорийность
    public DataTable GetMinCalories()
    {
        string query = "SELECT MIN(Calories) AS MinCalories FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    // Средняя калорийность
    public DataTable GetAvgCalories()
    {
        string query = "SELECT AVG(Calories) AS AvgCalories FROM FruitsAndVegetables";
        return ExecuteQuery(query);
    }

    private DataTable ExecuteQuery(string query)
    {
        DataTable dt = new DataTable();
        try
        {
            if (OpenDB())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            CloseDB();
            WindowsHandler.AddErroreWindow(new string[] { "Сломалась бд :(", ex.Message }, true);
        }
        return dt;
    }

    // Получение количества овощей
    public int GetVegetableCount()
    {
        string query = "SELECT COUNT(*) FROM FruitsAndVegetables WHERE Type = 'Vegetable'";
        SqlCommand command = new SqlCommand(query, conn);
        return (int)command.ExecuteScalar();
    }

    // Получение количества фруктов
    public int GetFruitCount()
    {
        string query = "SELECT COUNT(*) FROM FruitsAndVegetables WHERE Type = 'Fruit'";
        SqlCommand command = new SqlCommand(query, conn);
        return (int)command.ExecuteScalar();
    }

    // Получение количества овощей и фруктов заданного цвета
    public int GetCountByColor(string color)
    {
        string query = @"SELECT COUNT(*) FROM FruitsAndVegetables WHERE Color = @color";
        OpenDB();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@color", color);

            int result = (int)cmd.ExecuteScalar();
            return result;
        }
    }


    // Получение количества овощей и фруктов каждого цвета
    public DataTable GetCountForEachColor()
    {
        string query = @"SELECT Color, COUNT(*) AS Count FROM FruitsAndVegetables GROUP BY Color";
        return ExecuteQuery(query);
    }

    // Овощи и фрукты с калорийностью ниже указанной
    public DataTable GetByCaloriesBelow(int maxCalories)
    {
        string query = @"SELECT * FROM FruitsAndVegetables WHERE Calories < @maxCalories";
        DataTable dt = new DataTable();
        OpenDB();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@maxCalories", maxCalories);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }


    // Овощи и фрукты с калорийностью выше указанной
    public DataTable GetByCaloriesAbove(int minCalories)
    {
        string query = @"SELECT * FROM FruitsAndVegetables WHERE Calories > @minCalories";
        DataTable dt = new DataTable();
        OpenDB();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@minCalories", minCalories);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }


    // Овощи и фрукты с калорийностью в диапазоне
    public DataTable GetByCaloriesInRange(int minCalories, int maxCalories)
    {
        string query = @"SELECT * FROM FruitsAndVegetables WHERE Calories BETWEEN @minCalories AND @maxCalories";
        DataTable dt = new DataTable();
        OpenDB();
        using (SqlCommand cmd = new SqlCommand(query, conn))
        {
            cmd.Parameters.AddWithValue("@minCalories", minCalories);
            cmd.Parameters.AddWithValue("@maxCalories", maxCalories);

            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                adapter.Fill(dt);
            }
        }
        return dt;
    }


    // Овощи и фрукты с цветом "красный" или "желтый"
    public DataTable GetByColorRedOrYellow()
    {
        string query = "SELECT * FROM FruitsAndVegetables WHERE Color IN ('Red', 'Yellow')";
        return ExecuteQuery(query);
    }
}
