public class Contratos 
{
    public int ContratoId{ get; set; }

    public Locais Locais { get; set; }

    public Commodits Commodits { get; set; }

    public double Volume { get; set; }

    public double VolumeAtual { get; set; }

    public double VolumePendente{ get; set; }

    public Status Status { get; set; }
}