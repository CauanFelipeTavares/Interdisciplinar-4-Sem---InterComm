public interface IMotoristasData
{
    public List<Motoristas> Read();

    public List<Motoristas> Read(String nome);

    public Motoristas Read(int MotoristaId);

    public void Create(Motoristas motorista);

    public void Delete(int MotoristaId);

    public void Update(Motoristas motorista);
}