using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Win32;
using MuhtasarBeyannameWpf.Models;
using MuhtasarBeyannameWpf.Services;

namespace MuhtasarBeyannameWpf;

public partial class MainWindow : Window
{
    private readonly ObservableCollection<StopajKalemi> _kalemler = new();

    public MainWindow()
    {
        InitializeComponent();
        KalemlerGrid.ItemsSource = _kalemler;
        OrnekVeriYukle();
        ToplamlariGuncelle();
    }

    private void SatirEkle_OnClick(object sender, RoutedEventArgs e)
    {
        _kalemler.Add(new StopajKalemi
        {
            Aciklama = "Yeni kalem",
            BrutTutar = 0,
            StopajOrani = 20
        });
        ToplamlariGuncelle();
    }

    private void XmlOlustur_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(MukellefUnvaniTextBox.Text) || string.IsNullOrWhiteSpace(VergiNoTextBox.Text))
        {
            MessageBox.Show("Lütfen mükellef ünvanı ve vergi numarası bilgilerini girin.", "Eksik Bilgi", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var diyalog = new SaveFileDialog
        {
            Filter = "XML Dosyası|*.xml",
            FileName = "muhtasar-beyanname.xml"
        };

        if (diyalog.ShowDialog() != true)
        {
            return;
        }

        XmlBeyannameYazici.Kaydet(diyalog.FileName, MukellefUnvaniTextBox.Text.Trim(), VergiNoTextBox.Text.Trim(), _kalemler);
        MessageBox.Show("XML dosyası başarıyla oluşturuldu.", "Başarılı", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void KalemlerGrid_CellEditEnding(object? sender, DataGridCellEditEndingEventArgs e)
    {
        Dispatcher.BeginInvoke(ToplamlariGuncelle);
    }

    private void ToplamlariGuncelle()
    {
        var toplamBrut = _kalemler.Sum(x => x.BrutTutar);
        var toplamStopaj = _kalemler.Sum(x => x.StopajTutari);
        var toplamNet = _kalemler.Sum(x => x.NetOdenecek);

        ToplamBrutText.Text = $"Toplam Brüt: {toplamBrut.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"))} TL";
        ToplamStopajText.Text = $"Toplam Stopaj: {toplamStopaj.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"))} TL";
        ToplamNetText.Text = $"Toplam Net Ödeme: {toplamNet.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"))} TL";
    }

    private void OrnekVeriYukle()
    {
        MukellefUnvaniTextBox.Text = "Örnek Ltd. Şti.";
        VergiNoTextBox.Text = "1234567890";

        _kalemler.Add(new StopajKalemi { Aciklama = "Personel Ücreti", BrutTutar = 100000, StopajOrani = 15 });
        _kalemler.Add(new StopajKalemi { Aciklama = "İşyeri Kirası", BrutTutar = 40000, StopajOrani = 20 });
        _kalemler.Add(new StopajKalemi { Aciklama = "Serbest Meslek", BrutTutar = 25000, StopajOrani = 20 });
    }
}
