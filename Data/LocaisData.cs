using Dapper;

public class LocaisData : Database, ILocaisData
{
    public List<Locais> Read()
    {
        string query =  "SELECT * FROM Locais";

        List<Locais> lista = (List<Locais>)connection.Query<Locais>(query);

        return lista;
    }

    public List<Locais> Read(String search)
    {
        string query =  "SELECT * FROM Locais WHERE LocalRazaoSocial LIKE @search";

        List<Locais> lista = connection.Query<Locais>(query, new{search = "%" + search + "%"}).AsList();

        return lista;
    }

    public Locais Read(int IdLocal)
    {
        string query =  "SELECT * FROM Locais WHERE IdLocal = @IdLocal";

        Locais lista = connection.Query<Locais>(query, new { IdLocal = IdLocal }).FirstOrDefault();

        return lista;
    }

    public void Create(Locais local)
    {
        string query = @"INSERT INTO Locais 
        (LocalNomeFantasia, LocalRazaoSocial, CNPJ, TipoLocal, ANTT, IE, CEP, Logradouro, Bairro, Cidade, Estado, Numero, Complemento)
        VALUES
        (@LocalNomeFantasia, @LocalRazaoSocial, @CNPJ, @TipoLocal, @ANTT, @IE, @CEP, @Logradouro, @Bairro, @Cidade, @Estado, @Numero, @Complemento)";

        connection.Execute(query, local);
    }

    public void Update(Locais local)
    {
        char[] removes = {' ', '.', '/', '\\'};

        local.CNPJ = local.CNPJ.Replace(".", "");
        local.CNPJ = local.CNPJ.Replace("/", "");
        local.CNPJ = local.CNPJ.Replace("-", "");

        string query = @"UPDATE Locais
                        SET LocalNomeFantasia = @LocalNomeFantasia,
                            LocalRazaoSocial = @LocalRazaoSocial,
                            CNPJ = @CNPJ,
                            TipoLocal = @TipoLocal,
                            ANTT = @ANTT,
                            IE = @IE,
                            CEP = @CEP,
                            Logradouro = @Logradouro,
                            Bairro = @Bairro,
                            Cidade = @Cidade,
                            Estado = @Estado,
                            Numero = @Numero,
                            Complemento = @Complemento
                        WHERE IdLocal = @IdLocal";

        connection.Execute(query, local);
    }

    public void Delete(int LocalId)
    {
        
    }
}