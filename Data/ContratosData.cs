public class ContratosData : IContratosData
{
    private List<Contratos> Contratos = new();

    public List<Contratos> Read()
    {
        return Contratos;
    }

    public Contratos Read(int IdContrato)
    {
        return Contratos[0];
    }

    public void Create(Contratos contrato)
    {

    }

    public void Delete(int IdContrato)
    {

    }

    public void Update(Contratos contrato)
    {
        
    }
}