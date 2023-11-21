public interface ILocaisData
{
    public List<Locais> Read();

    public List<Locais> Read(String nome, int local);

    public Locais Read(int LocalId);

    public void Create(Locais local);

    public void Update(Locais local);
    
    public void Delete(int LocalId);



    //RESPONSAVEIS
    public List<Responsaveis> ReadResponsaveis(int CodLocal);

    public Responsaveis CreateResponsaveis(Responsaveis responsavel);

    public int DeleteResponsaveis(int IdResponsavel);



    //EMAILS
    public List<Emails> ReadEmails(int CodLocal);

    public Emails CreateEmails(Emails Email);

    public int DeleteEmails(int IdEmail);



    //TELEFONE
    public List<Telefones> ReadTelefones(int CodLocal);

    public Telefones CreateTelefones(Telefones Telefone);

    public int DeleteTelefones(int IdTelefone);
}