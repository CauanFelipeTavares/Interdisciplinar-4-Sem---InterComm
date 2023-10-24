public class Locais
{
    public int IdLocal { get; set; }

    public string LocalNomeFantasia { get; set; }

    public string LocalRazaoSocial { get; set; }

    public string CNPJ { get; set; }

    public TipoLocal TipoLocal { get; set; }

    public string CEP { get; set; }

    public string Rua { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Estado { get; set; }

    public string Numero { get; set; }

    public string Complemento { get; set; }

    public List<string> Responsaveis { get; set; }

    public List<string> Telefones { get; set; }

    public List<string> Emails { get; set; }
}