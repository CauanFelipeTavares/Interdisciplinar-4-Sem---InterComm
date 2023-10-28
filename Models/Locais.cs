public class Locais
{
    public int IdLocal { get; set; }

    public string? LocalNomeFantasia { get; set; }

    public required string LocalRazaoSocial { get; set; }

    public required string CNPJ { get; set; }

    public TipoLocal TipoLocal { get; set; }

    public string? ANTT { get; set; }

    public string? IE { get; set; }

    public string? CEP { get; set; }

    public required string Logradouro { get; set; }

    public string? Bairro { get; set; }

    public required string Cidade { get; set; }

    public required Estados Estado { get; set; }

    public string? Numero { get; set; }

    public string? Complemento { get; set; }

    public required List<string> Responsaveis { get; set; }

    public required List<string> Telefones { get; set; }

    public required List<string> Emails { get; set; }
}