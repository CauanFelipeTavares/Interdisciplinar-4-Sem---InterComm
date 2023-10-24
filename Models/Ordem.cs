public class Ordem 
{
    public int OrdemId { get; set; }

    public Contratos Contrato { get; set; }

    public Motoristas Motorista { get; set; }

    public Transpor Transpor { get; set; }

    public Status Status { get; set; }

    public List<string> Placas { get; set; }
}