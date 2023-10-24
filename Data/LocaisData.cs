public class LocaisData : ILocaisData
{
    private List<Locais> locais = new();

    public List<Locais> Read()
    {
        return locais;
    }

    public List<Locais> Read(String nome)
    {

        var result = from l in locais
                        where l.LocalNomeFantasia.ToLower().Contains(nome.ToLower())
                        select l;

        return result.ToList();
    }

    public Locais Read(int LocalId)
    {
        return locais.FirstOrDefault(local => local.LocalId == LocalId);
    }

    public void Create(Locais local)
    {
        locais.Add(local);
    }

    public void Delete(int LocalId)
    {
        foreach (var local in locais)
        {
            if (local.LocalId == LocalId)
            {
                locais.Remove(local);
            }
        }
    }

    public void Update(Locais local)
    {
        Locais LocaisToUpdate = locais.First(status => status.LocalId == local.LocalId);

        LocaisToUpdate = local;
    }
}