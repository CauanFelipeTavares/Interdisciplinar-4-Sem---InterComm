public class Ordem 
{
    public int IdOrdem { get; set; }

    public Contratos Contrato { get; set; }

    public Motoristas Motorista { get; set; }

    public Transpor Transpor { get; set; }

    public Locais Local { get; set; }

    public Status Status { get; set; }

    public List<string> Placas { get; set; }
}