namespace MuhtasarBeyannameApp.Models;

public sealed class BeyannameSatiri
{
    public int SiraNo { get; set; }
    public string OdemeTuru { get; set; } = string.Empty;
    public decimal BrutTutar { get; set; }
    public decimal StopajOrani { get; set; }
    public decimal StopajTutari => Math.Round(BrutTutar * StopajOrani / 100m, 2);
    public decimal DamgaVergisiTutari => Math.Round(BrutTutar * 0.00759m, 2);
}
