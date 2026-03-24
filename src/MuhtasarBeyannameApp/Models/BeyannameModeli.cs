namespace MuhtasarBeyannameApp.Models;

public sealed class BeyannameModeli
{
    public string VknTckn { get; set; } = string.Empty;
    public string Unvan { get; set; } = string.Empty;
    public int DonemYil { get; set; } = DateTime.Today.Year;
    public int DonemAy { get; set; } = DateTime.Today.Month;
    public List<BeyannameSatiri> Satirlar { get; } = [];

    public decimal ToplamMatrah => Satirlar.Sum(x => x.BrutTutar);
    public decimal ToplamStopaj => Satirlar.Sum(x => x.StopajTutari);
    public decimal ToplamDamgaVergisi => Satirlar.Sum(x => x.DamgaVergisiTutari);
}
