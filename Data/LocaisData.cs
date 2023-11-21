using Dapper;

public class LocaisData : Database, ILocaisData
{
    /*
    ----- READ -----
    */
    public List<Locais> Read()
    {
        string query =  "SELECT * FROM Locais";

        List<Locais> lista = (List<Locais>)connection.Query<Locais>(query);

        return lista;
    }

    public List<Locais> Read(String nome, int local)
    {
        string query = "";
        if (local >= 0)
        {
            query =  "SELECT * FROM Locais WHERE LocalRazaoSocial LIKE @nome and TipoLocal = @local";
        }
        else
        {
            query =  "SELECT * FROM Locais WHERE LocalRazaoSocial LIKE @nome";
        }

        List<Locais> lista = connection.Query<Locais>(query, new{nome = "%" + nome + "%", local}).AsList();

        return lista;
    }

    public Locais Read(int IdLocal)
    {
        string query =  "SELECT * FROM Locais WHERE IdLocal = @IdLocal";

        Locais lista = connection.Query<Locais>(query, new { IdLocal }).FirstOrDefault();

        return lista;
    }



    /*
    ----- CREATE -----
    */
    public void Create(Locais local)
    {
        if (local.CNPJ != null) local.CNPJ = local.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.ANTT != null) local.ANTT = local.ANTT.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.IE != null) local.IE = local.IE.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.CEP != null) local.CEP = local.CEP.Replace(".", "").Replace("/", "").Replace("-", "");

        string query = @"INSERT INTO Locais 
        (LocalNomeFantasia, LocalRazaoSocial, CNPJ, TipoLocal, ANTT, IE, CEP, Logradouro, Bairro, Cidade, Estado, Numero, Complemento)
        VALUES
        (@LocalNomeFantasia, @LocalRazaoSocial, @CNPJ, @TipoLocal, @ANTT, @IE, @CEP, @Logradouro, @Bairro, @Cidade, @Estado, @Numero, @Complemento)";

        connection.Execute(query, local);
    }



    /*
    ----- UPDATE -----
    */
    public void Update(Locais local)
    {

        if (local.CNPJ != null) local.CNPJ = local.CNPJ.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.ANTT != null) local.ANTT = local.ANTT.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.IE != null) local.IE = local.IE.Replace(".", "").Replace("/", "").Replace("-", "");
        if (local.CEP != null) local.CEP = local.CEP.Replace(".", "").Replace("/", "").Replace("-", "");

        string query = @"UPDATE Locais
                        SET 
                            LocalNomeFantasia = @LocalNomeFantasia,
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
                        WHERE 
                            IdLocal = @IdLocal";

        connection.Execute(query, local);
    }



    /*
    ----- DELETE -----
    */
    public void Delete(int IdLocal)
    {
        string query = @"DELETE FROM Locais WHERE IdLocal = @IdLocal";

        connection.Execute(query, IdLocal);
    }



    /*
    ----- RESPONSAVEIS -----
    */
    //READ
    public List<Responsaveis> ReadResponsaveis(int CodLocal)
    {
        string query = "SELECT * FROM Responsaveis WHERE CodLocal = @CodLocal";

        List<Responsaveis> responsaveis = connection.Query<Responsaveis>(query, new{ CodLocal }).AsList();

        return responsaveis;
    }

    //CREATE
    public Responsaveis CreateResponsaveis(Responsaveis responsavel)
    {
        string query = @"
            DECLARE @IdResponsavell INT;
            EXEC Sp_Insert_Responsaveis @Responsavel, @CodLocal, @IdResponsavel = @IdResponsavell;
            ";

        using (var NewResponsavel = connection.QueryMultiple(query, new { responsavel.Responsavel, responsavel.CodLocal})){
            var Respon = NewResponsavel.Read<Responsaveis>().FirstOrDefault();
            responsavel.IdResponsavel = Respon.IdResponsavel;
        }

        return responsavel;
    }   

    //DELETE
    public int DeleteResponsaveis(int IdResponsavel)
    {
        string query = "DELETE FROM Responsaveis WHERE IdResponsavel = @IdResponsavel";

        connection.Execute(query, new {IdResponsavel});

        return IdResponsavel;
    }



    /*
    ----- EMAILS -----
    */
    //READ
    public List<Emails> ReadEmails(int CodLocal)
    {
        string query = "SELECT * FROM Emails WHERE CodLocal = @CodLocal";

        List<Emails> emails = connection.Query<Emails>(query, new{ CodLocal }).AsList();

        return emails;
    }

    //CREATE
    public Emails CreateEmails(Emails email)
    {
        string query = @"
            DECLARE @IdEmaill INT;
            EXEC Sp_Insert_Emails @Email, @CodLocal, @IdEmail = @IdEmaill;
            ";

        using (var NewEmail = connection.QueryMultiple(query, new { email.Email, email.CodLocal})){
            var Respon = NewEmail.Read<Emails>().FirstOrDefault();
            email.IdEmail = Respon.IdEmail;
        }

        return email;
    }   

    //DELETE
    public int DeleteEmails(int IdEmail)
    {
        string query = "DELETE FROM Emails WHERE IdEmail = @IdEmail";

        connection.Execute(query, new { IdEmail });

        return IdEmail;
    }



    /*
    ----- TELEFONEs -----
    */
    //READ
    public List<Telefones> ReadTelefones(int CodLocal)
    {   
        string query = @"SELECT * FROM Telefones WHERE CodLocal = @CodLocal";

        List<Telefones> telefones = connection.Query<Telefones>(query, new{ CodLocal }).AsList();

        return telefones;
    }

    //CREATE
    public Telefones CreateTelefones(Telefones telefone)
    {   
        telefone.Telefone = telefone.Telefone.Replace(".", "").Replace("/", "").Replace("-", "").Replace("(", "").Replace(")", "");

        string query = @"
            DECLARE @IdTelefonee INT;
            EXEC Sp_Insert_Telefones @Telefone, @CodLocal, @IdTelefone = @IdTelefonee;
            ";

        using (var NewTelefone = connection.QueryMultiple(query, new { telefone.Telefone, telefone.CodLocal})){
            var Respon = NewTelefone.Read<Emails>().FirstOrDefault();
            telefone.IdTelefone = Respon.IdEmail;
        }

        return telefone;
    }

    //DELETE
    public int DeleteTelefones(int IdTelefone)
    {
        string query = @"DELETE FROM Telefones WHERE IdTelefone = @IdTelefone";

        connection.Execute(query, new{ IdTelefone });

        return IdTelefone;
    }
}