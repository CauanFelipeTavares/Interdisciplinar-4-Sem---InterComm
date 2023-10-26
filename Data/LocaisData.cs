using Dapper;

public class LocaisData : Database, ILocaisData
{
    public List<Locais> Read()
    {
        string querry =  "SELECT * FROM Locais";

        List<Locais> lista = (List<Locais>)connection.Query<Locais>(querry);

        return lista;
    }

    public List<Locais> Read(String search)
    {
        string querry =  "SELECT * FROM Locais WHERE LocalRazaoSocial LIKE @search";

        List<Locais> lista = (List<Locais>)connection.Query<Locais>(querry, new{search = "%" + search + "%"});

        return lista;
    }

    public Locais Read(int IdLocal)
    {
        string querry =  "SELECT * FROM Locais WHERE IdLocal = @IdLocal";

        Locais lista = (Locais)connection.Query<Locais>(querry, new{IdLocal = IdLocal});

        return lista;
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