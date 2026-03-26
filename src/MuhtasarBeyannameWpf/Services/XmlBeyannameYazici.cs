using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Xml;
using MuhtasarBeyannameWpf.Models;

namespace MuhtasarBeyannameWpf.Services;

public static class XmlBeyannameYazici
{
    public static void Kaydet(string dosyaYolu, string mukellefUnvani, string vergiNo, ObservableCollection<StopajKalemi> kalemler)
    {
        var ayarlar = new XmlWriterSettings
        {
            Indent = true,
            Encoding = Encoding.UTF8
        };

        using var yazar = XmlWriter.Create(dosyaYolu, ayarlar);
        yazar.WriteStartDocument();
        yazar.WriteStartElement("MuhtasarBeyanname");
        yazar.WriteElementString("MukellefUnvani", mukellefUnvani);
        yazar.WriteElementString("VergiNo", vergiNo);
        yazar.WriteElementString("OlusturmaTarihi", DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));

        yazar.WriteStartElement("Kalemler");
        foreach (var kalem in kalemler)
        {
            yazar.WriteStartElement("Kalem");
            yazar.WriteElementString("Aciklama", kalem.Aciklama);
            yazar.WriteElementString("BrutTutar", kalem.BrutTutar.ToString("0.00", CultureInfo.InvariantCulture));
            yazar.WriteElementString("StopajOrani", kalem.StopajOrani.ToString("0.##", CultureInfo.InvariantCulture));
            yazar.WriteElementString("StopajTutari", kalem.StopajTutari.ToString("0.00", CultureInfo.InvariantCulture));
            yazar.WriteElementString("NetOdenecek", kalem.NetOdenecek.ToString("0.00", CultureInfo.InvariantCulture));
            yazar.WriteEndElement();
        }

        yazar.WriteEndElement();
        yazar.WriteEndElement();
        yazar.WriteEndDocument();
    }
}
