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

        Locais lista = connection.Query<Locais>(query, new { IdLocal }).FirstOrDefault();

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

        local.CNPJ = local.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
        local.IE = local.IE.Replace(".", "").Replace("/", "").Replace("-", "");
        local.ANTT = local.ANTT.Replace(".", "").Replace("/", "").Replace("-", "");
        local.CEP = local.CEP.Replace(".", "").Replace("/", "").Replace("-", "");

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

    public List<Responsaveis> ReadResponaveis(int CodLocal)
    {
        string query = "SELECT * FROM Responsaveis WHERE CodLocal = @CodLocal";

        List<Responsaveis> responsaveis = connection.Query<Responsaveis>(query, new{ CodLocal }).AsList();

        return responsaveis;
    }

    public Responsaveis CreateResponsaveis(Responsaveis responsavel)
    {
        string query = @"
            DECLARE @IdResponsavell INT;
            EXEC Sp_Insert_Responsaveis @Responsavel, @CodLocal, @IdResponsavel = @IdResponsavell;
            ";

        using (var Teste = connection.QueryMultiple(query, new { responsavel.Responsavel, responsavel.CodLocal})){
            var Respon = Teste.Read<Responsaveis>().FirstOrDefault();
            responsavel.IdResponsavel = Respon.IdResponsavel;
        }

        return responsavel;
    }   
}