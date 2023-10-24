using Microsoft.Data.SqlClient;

public abstract class Database : IDisposable
{
    protected SqlConnection connection;

    public Database()
    {
        connection = new SqlConnection("Data Source=localhost; Initial Catalog=Intercomm; Integrated Security=True");
        connection.Open();
    }

    public void Dispose()
    {
        connection.Close();
    }
}