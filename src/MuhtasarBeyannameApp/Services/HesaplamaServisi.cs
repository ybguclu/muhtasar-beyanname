using MuhtasarBeyannameApp.Models;

namespace MuhtasarBeyannameApp.Services;

public sealed class HesaplamaServisi
{
    public BeyannameSatiri SatirOlustur(int siraNo, string odemeTuru, decimal brutTutar, decimal stopajOrani)
    {
        if (brutTutar < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(brutTutar), "Brüt tutar negatif olamaz.");
        }

        if (stopajOrani is < 0 or > 100)
        {
            throw new ArgumentOutOfRangeException(nameof(stopajOrani), "Stopaj oranı 0-100 arasında olmalıdır.");
        }

        return new BeyannameSatiri
        {
            SiraNo = siraNo,
            OdemeTuru = odemeTuru,
            BrutTutar = brutTutar,
            StopajOrani = stopajOrani
        };
    }
}
