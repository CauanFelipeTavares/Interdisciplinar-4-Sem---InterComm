public interface ITransporData
{
    public List<Transpor> Read();

    public List<Transpor> Read(String nome);

    public Transpor Read(int TransporId);

    public void Create(Transpor transpor);

    public void Delete(int TransporId);

    public void Update(Transpor transpor);
}