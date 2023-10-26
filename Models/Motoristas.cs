public class Motoristas
{
    public int IdMotorista { get; set; }

    public int CodTransportadora { get; set; }

    public required string NomeMotorista { get; set; }

    public string? CPF { get; set; }

    public required string CNH { get; set; }
}