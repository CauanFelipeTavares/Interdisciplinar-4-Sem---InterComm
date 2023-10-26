public interface IContratosData
{
    public List<Contratos> Read();

    public Contratos Read(int ContratoId);

    public void Create(Contratos contrato);

    public void Delete(int ContratoId);

    public void Update(Contratos contrato);
}