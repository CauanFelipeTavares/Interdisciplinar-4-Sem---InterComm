using Dapper;
public class ContratosData : Database, IContratosData
{
    private List<Contratos> Contratos = new();

    public List<Contratos> Read()
    {
        string querry = "SELECT * FROM Contratos C INNER JOIN Locais L ON C.CodLocal = L.IdLocal";

        List<Contratos> lista = connection.Query<Contratos, Locais, Contratos>(querry, (C, L) =>
        {
            C.Locais = L;
            return C;
        },
        splitOn: "IdLocal"
        ).ToList();

        return lista;
    }

    public Contratos Read(int IdContrato)
    {
        return Contratos[0];
    }

    public void Create(Contratos contrato)
    {

    }

    public void Delete(int IdContrato)
    {

    }

    public void Update(Contratos contrato)
    {
        
    }
}