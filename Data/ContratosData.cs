using Dapper;
public class ContratosData : Database, IContratosData
{
    private List<Contratos> Contratos = new();

    public List<Contratos> Read()
    {
        string query = @"SELECT * 
                            FROM Contratos C 
                            INNER JOIN Locais L ON L.IdLocal = C.CodLocal";

        List<Contratos> lista = connection.Query<Contratos, Locais, Contratos>(query, (C, L) =>
        {
            C.Locais = L;
            return C;
        },
        splitOn: "IdLocal"
        ).ToList();

        return lista;
    }

    public List<Contratos> Read(string nome)//Razão social do local
    {

        string query = @"SELECT * 
                            FROM Contratos C 
                            INNER JOIN Locais L ON L.IdLocal = C.CodLocal WHERE L.LocalRazaoSocial LIKE @nome";

        List<Contratos> lista = connection.Query<Contratos, Locais, Contratos>(query, (C, L) =>
        {
            C.Locais = L;
            return C;
        },
        splitOn: "IdLocal",
        param: new {nome =  "%" + nome + "%"}
        ).ToList();

        return lista;

    }

    public Contratos Read(int IdContrato)
    {
        string query = @"SELECT * 
                            FROM Contratos C 
                            INNER JOIN Locais L ON L.IdLocal = C.CodLocal WHERE C.IdContrato = @IdContrato";

        Contratos lista = connection.Query<Contratos, Locais, Contratos>(query, (C, L) =>
        {
            C.Locais = L;
            return C;
        },
        splitOn: "IdLocal",
        param: new {IdContrato}
        ).First();

        return lista;

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