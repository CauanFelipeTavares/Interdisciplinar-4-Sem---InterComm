public class Ordem 
{
    public int IdOrdem { get; set; }

    public required Contratos Contrato { get; set; }

    public required Motoristas Motorista { get; set; }

    public required Locais Transpor { get; set; }

    public required Locais Destino { get; set; }

    public required Conjuntos Conjunto { get; set; }

    public Status Status { get; set; }
}