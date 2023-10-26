public interface ILocaisData
{
    public List<Locais> Read();

    public List<Locais> Read(String nome);

    public Locais Read(int LocalId);

    public void Create(Locais local);

    public void Update(Locais local);
    
    public void Delete(int LocalId);
}