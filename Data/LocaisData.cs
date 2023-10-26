using Microsoft.Data.SqlClient;

public class LocaisData : Database, ILocaisData
{
    private List<Locais> locais = new();

    public List<Locais> Read()
    {
        return locais;
    }

    public List<Locais> Read(String nome)
    {
        string querry =  "SELECT * FROM Locais";

        SqlCommand cmd = new(querry, connection);
        SqlDataReader reader = cmd.ExecuteReader();

        List<Locais> lista = new();

        while(reader.Read())
        {
            
        }

        return locais;
    }

    public Locais Read(int LocalId)
    {
        return locais[0];
    }

    public void Create(Locais local)
    {
        
    }

    public void Update(Locais local)
    {
        
    }

    public void Delete(int LocalId)
    {
        
    }
}