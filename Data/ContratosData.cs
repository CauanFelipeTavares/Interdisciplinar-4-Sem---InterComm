using Dapper;

public class ContratosData : Database, IContratosData
{
    private List<Contratos> Contratos = new();

    /*
    ---- READ ----
    */
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
        param: new {IdContrato = IdContrato}
        ).First();

        return lista;

    }



    /*
    ---- CREATE ----
    */
    public void Create(Contratos contrato)
    {

            Console.WriteLine(contrato.DataInicio);

            string query = @"INSERT INTO Contratos
            (CodLocal, CodCommodity, DataInicio, Volume, ValorUnitario)
            VALUES
            (@CodLocal, @CodCommodity, @DataInicio, @Volume, @ValorUnitario)";

            connection.Execute(query, new{
                CodLocal = contrato.Locais.IdLocal, 
                CodCommodity = contrato.Commodits,
                contrato.DataInicio,
                contrato.Volume,
                contrato.ValorUnitario
            });
    }



    /*
    ---- UPDATE ----
    */
    public void Update(Contratos contrato)
    {
        Console.WriteLine(contrato.ValorUnitario);

        string query = @"UPDATE Contratos
            SET 
                CodLocal = @CodLocal,
                CodCommodity = @CodCommodity,
                DataInicio = @DataInicio,
                Volume = @Volume,
                VolumeAtual = VolumeAtual,
                VolumePendente = VolumePendente,
                ValorUnitario = @ValorUnitario,
                Status = Status
            WHERE
                IdContrato = @IdContrato
        ";

        connection.Execute(query, new{
            CodLocal = contrato.Locais.IdLocal, 
            CodCommodity = contrato.Commodits,
            contrato.DataInicio,
            contrato.Volume,
            contrato.ValorUnitario,
            contrato.IdContrato
        });
    }



    /*
    ---- DELETE ----
    */
    public void Delete(int IdContrato)
    {
        string query = @"DELETE FROM Contratos WHERE IdContrato = @IdContrato";

        connection.Execute(query, new {IdContrato});
    }
    
}