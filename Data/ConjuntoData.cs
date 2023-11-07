public class ConjuntoData : IConjuntoData
{
    private List<Conjuntos> Conjuntos = new();

    public List<Conjuntos> Read()
    {
        return Conjuntos;
    }

    public List<Conjuntos> Read(string search)
    {
        return Conjuntos;
    }

    public Conjuntos Read(int IdConjunto)
    {
        return Conjuntos[0];
    }


    public void Create(Conjuntos conjunto)
    {

    }

    public void Delete(int IdConjunto)
    {

    }

    public void Update(Conjuntos conjunto)
    {
        
    }
}