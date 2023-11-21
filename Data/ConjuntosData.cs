using Dapper;

public class ConjuntosData : Database, IConjuntosData
{
    private List<Conjuntos> Conjuntos = new();



    /*
    ----- READ -----
    */
    public List<Conjuntos> Read()
    {
        string query = @"SELECT * 
                            FROM Conjuntos C 
                            INNER JOIN Motoristas M ON M.IdMotorista = C.CodMotorista";

        List<Conjuntos> lista = connection.Query<Conjuntos, Motoristas, Conjuntos>(query, (C, M) =>
        {
            C.Motorista = M;
            return C;
        },
        splitOn: "IdMotorista"
        ).ToList();

        return lista;
    }

    public List<Conjuntos> Read(string nome)
    {
        string query = @"SELECT * 
                            FROM Conjuntos C 
                            INNER JOIN Motoristas M ON M.IdMotorista = C.CodMotorista WHERE M.NomeMotorista LIKE @nome";

        List<Conjuntos> lista = connection.Query<Conjuntos, Motoristas, Conjuntos>(query, (C, M) =>
        {
            C.Motorista = M;
            return C;
        },
        splitOn: "IdMotorista",
        param: new {nome = "%" + nome + "%"}
        ).ToList();

        return lista;
    }

    public Conjuntos Read(int IdConjunto)
    {
        return Conjuntos[0];
    }


    /*
    ----- CREATE -----
    */
    public void Create(Conjuntos conjunto)
    {
        if(conjunto.PlacaA != null) conjunto.PlacaA = conjunto.PlacaA.Replace("-", "");
        if(conjunto.PlacaB != null) conjunto.PlacaB = conjunto.PlacaB.Replace("-", "");
        if(conjunto.PlacaC != null) conjunto.PlacaC = conjunto.PlacaC.Replace("-", "");

        string query = @"INSERT INTO Conjuntos
                                (CodMotorista, TipoConjunto, PlacaA, PlacaB, PlacaC)
                            VALUES
                                (@CodMotorista, @TipoConjunto, @PlacaA, @PlacaB, @PlacaC)";

        connection.Execute(query, new{
            @CodMotorista = conjunto.Motorista.IdMotorista, 
            conjunto.TipoConjunto, 
            conjunto.PlacaA, 
            conjunto.PlacaB, 
            conjunto.PlacaC,
        });
    }

    public void Delete(int IdConjunto)
    {

    }

    public void Update(Conjuntos conjunto)
    {
        
    }
}