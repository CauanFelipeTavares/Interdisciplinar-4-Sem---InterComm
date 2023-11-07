public class OrdemData : IOrdemData
{
    private List<Ordem> Ordem = new();

    public List<Ordem> Read()
    {   
        return Ordem;
    }

    public Ordem Read(int IdOrdem)
    {
        return Ordem[0];
    }

    public void Create(Ordem ordem)
    {

    }

    public void Delete(int IdOrdem)
    {

    }

    public void Update(Ordem ordem)
    {

    }
}