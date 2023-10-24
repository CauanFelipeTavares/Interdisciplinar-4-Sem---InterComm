public interface IEnderecosData
{
    public List<Enderecos> Read();

    public List<Enderecos> Read(string CEP);

    public void Create (Enderecos endereco);
}