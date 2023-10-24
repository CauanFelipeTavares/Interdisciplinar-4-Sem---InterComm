public class MotoristasData : IMotoristasData
{
    private List<Motoristas> Motoristas = new();

    public List<Motoristas> Read()
    {
        return Motoristas;
    }

    public List<Motoristas> Read(String nome)
    {

        var result = from l in Motoristas
                        where l.MotoristaNome.ToLower().Contains(nome.ToLower())
                        select l;

        return result.ToList();
    }

    public Motoristas Read(int MotoristaId)
    {
        return Motoristas.FirstOrDefault(moto => moto.MotoristaId == MotoristaId);
    }

    public void Create(Motoristas motorista)
    {
        Motoristas.Add(motorista);
    }

    public void Delete(int MotoristaId)
    {
        foreach (var motorista in Motoristas)
        {
            if (motorista.MotoristaId == MotoristaId)
            {
                Motoristas.Remove(motorista);
            }
        }
    }

    public void Update(Motoristas motorista)
    {
        Motoristas MotoristasToUpdate = Motoristas.First(moto => moto.MotoristaId == motorista.MotoristaId);

        MotoristasToUpdate = motorista;
    }
}