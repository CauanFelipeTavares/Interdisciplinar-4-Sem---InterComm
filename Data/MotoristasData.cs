public class MotoristasData : IMotoristasData
{
    private List<Motoristas> Motoristas = new();

    public List<Motoristas> Read()
    {
        return Motoristas;
    }

    public List<Motoristas> Read(String nome)
    {
        return Motoristas;
    }

    public Motoristas Read(int IdMotorista)
    {
        return Motoristas[0];
    }

    public void Create(Motoristas motorista)
    {

    }

    public void Delete(int IdMotorista)
    {

    }

    public void Update(Motoristas motorista)
    {

    }
}