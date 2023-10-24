public class ContratosData : IContratosData
{
    private List<Contratos> Contratos = new();

    public List<Contratos> Read()
    {
        return Contratos;
    }

    public Contratos Read(int ContratoId)
    {
        return Contratos.FirstOrDefault(local => local.ContratoId == ContratoId);
    }

    public void Create(Contratos contrato)
    {
        Contratos.Add(contrato);
    }

    public void Delete(int ContratoId)
    {
        foreach (var contrato in Contratos)
        {
            if (contrato.ContratoId == ContratoId)
            {
                Contratos.Remove(contrato);
            }
        }
    }

    public void Update(Contratos contrato)
    {
        Contratos ContratosToUpdate = Contratos.First(status => status.ContratoId == contrato.ContratoId);

        ContratosToUpdate = contrato;
    }
}