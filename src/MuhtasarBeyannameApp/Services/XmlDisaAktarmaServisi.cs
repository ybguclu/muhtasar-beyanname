using System.Globalization;
using System.Xml.Linq;
using MuhtasarBeyannameApp.Models;

namespace MuhtasarBeyannameApp.Services;

public sealed class XmlDisaAktarmaServisi
{
    public void Kaydet(BeyannameModeli model, string dosyaYolu)
    {
        var xml = new XDocument(
            new XElement("MuhtasarBeyanname",
                new XElement("Mukellef",
                    new XElement("VknTckn", model.VknTckn),
                    new XElement("Unvan", model.Unvan)),
                new XElement("Donem",
                    new XAttribute("Yil", model.DonemYil),
                    new XAttribute("Ay", model.DonemAy)),
                new XElement("Satirlar",
                    model.Satirlar.Select(s => new XElement("Satir",
                        new XAttribute("No", s.SiraNo),
                        new XElement("OdemeTuru", s.OdemeTuru),
                        new XElement("BrutTutar", s.BrutTutar.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("StopajOrani", s.StopajOrani.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("StopajTutari", s.StopajTutari.ToString("F2", CultureInfo.InvariantCulture)),
                        new XElement("DamgaVergisi", s.DamgaVergisiTutari.ToString("F2", CultureInfo.InvariantCulture))))),
                new XElement("Toplamlar",
                    new XElement("ToplamMatrah", model.ToplamMatrah.ToString("F2", CultureInfo.InvariantCulture)),
                    new XElement("ToplamStopaj", model.ToplamStopaj.ToString("F2", CultureInfo.InvariantCulture)),
                    new XElement("ToplamDamgaVergisi", model.ToplamDamgaVergisi.ToString("F2", CultureInfo.InvariantCulture)))));

        xml.Save(dosyaYolu);
    }
}
