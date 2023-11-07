public interface IContratosData
{
    public List<Contratos> Read();

    public List<Contratos> Read(string nome); //Razão social do local

    public Contratos Read(int ContratoId);

    public void Create(Contratos contrato);

    public void Delete(int ContratoId);

    public void Update(Contratos contrato);
}