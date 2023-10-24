public class TransporData : ITransporData
{
    private List<Transpor> Transpor = new();

    public List<Transpor> Read()
    {
        return Transpor;
    }

    public List<Transpor> Read(String nome)
    {

        var result = from l in Transpor
                        where l.TransporNomeFantasia.ToLower().Contains(nome.ToLower())
                        select l;

        return result.ToList();
    }

    public Transpor Read(int TransporId)
    {
        return Transpor.FirstOrDefault(tran => tran.TransporId == TransporId);
    }

    public void Create(Transpor transpor)
    {
        Transpor.Add(transpor);
    }

    public void Delete(int TransporId)
    {
        foreach (var tran in Transpor)
        {
            if (tran.TransporId== TransporId)
            {
                Transpor.Remove(tran);
            }
        }
    }

    public void Update(Transpor transpor)
    {
        Transpor TransporToUpdate = Transpor.First(tran => tran.TransporId == transpor.TransporId);

        TransporToUpdate = transpor;
    }  
}