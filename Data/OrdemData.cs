public class OrdemData : IOrdemData
{
    private List<Ordem> Ordem = new();

    public List<Ordem> Read()
    {   
        return Ordem;
    }

    public Ordem Read(int OrdemId)
    {
        return Ordem.FirstOrDefault(ord => ord.OrdemId == OrdemId);
    }

    public void Create(Ordem ordem)
    {
        Ordem.Add(ordem);
    }

    public void Delete(int OrdemId)
    {
        foreach (var ord in Ordem)
        {
            if (ord.OrdemId == OrdemId)
            {
                Ordem.Remove(ord);
            }
        }
    }

    public void Update(Ordem ordem)
    {
        Ordem OrdemToUpdate = Ordem.First(ord => ord.OrdemId == ordem.OrdemId);

        OrdemToUpdate = ordem;
    }
}