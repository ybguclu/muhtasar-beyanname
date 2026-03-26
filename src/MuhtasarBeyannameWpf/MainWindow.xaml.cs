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

        SecimAlanlariniHazirla();
        OrnekVeriYukle();
        ToplamlariGuncelle();
    }

    private void SecimAlanlariniHazirla()
    {
        VergiDairesiComboBox.ItemsSource = new[] { "Lütfen Vergi Dairesi Seçiniz", "Kadıköy", "Beşiktaş", "Çankaya", "Konak" };
        DonemTipiComboBox.ItemsSource = new[] { "Lütfen Dönem Seçiniz", "Aylık", "Üç Aylık" };
        AyComboBox.ItemsSource = new[]
        {
            "Lütfen Ay Seçiniz", "Ocak", "Şubat", "Mart", "Nisan", "Mayıs", "Haziran",
            "Temmuz", "Ağustos", "Eylül", "Ekim", "Kasım", "Aralık"
        };

        BeyanDurumComboBox.ItemsSource = new[] { "Yok", "Var" };
        BeyannameDurumComboBox.ItemsSource = new[] { "Durum Seçiniz", "Taslak", "Hazır", "Gönderildi" };

        VergiDairesiComboBox.SelectedIndex = 0;
        DonemTipiComboBox.SelectedIndex = 0;
        AyComboBox.SelectedIndex = 0;
        BeyanDurumComboBox.SelectedIndex = 0;
        BeyannameDurumComboBox.SelectedIndex = 0;
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


    private void Kopyala_OnClick(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Kopyalama işlemi örnek uygulamada pasiftir.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
    }
    private void XmlOlustur_OnClick(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(SoyadiUnvaniTextBox.Text) || string.IsNullOrWhiteSpace(VergiNoTextBox.Text))
        {
            MessageBox.Show("Lütfen vergi sorumlusu ünvanı ve vergi numarasını girin.", "Eksik Bilgi", MessageBoxButton.OK, MessageBoxImage.Warning);
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

        XmlBeyannameYazici.Kaydet(diyalog.FileName, SoyadiUnvaniTextBox.Text.Trim(), VergiNoTextBox.Text.Trim(), _kalemler);
        XmlYolTextBox.Text = diyalog.FileName;

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
        ToplamNetText.Text = $"Toplam Net: {toplamNet.ToString("N2", CultureInfo.GetCultureInfo("tr-TR"))} TL";
    }

    private void OrnekVeriYukle()
    {
        YilTextBox.Text = DateTime.Now.Year.ToString(CultureInfo.InvariantCulture);
        SubeNoTextBox.Text = "0";
        VergiNoTextBox.Text = "1234567890";
        SoyadiUnvaniTextBox.Text = "Örnek Ltd. Şti.";
        EpostaTextBox.Text = "info@ornek.com";
        TelefonAlanKodTextBox.Text = "212";
        TelefonNoTextBox.Text = "5551234";
        XmlYolTextBox.Text = @"C:\E-Beyanname\{firma}\Muhtasar\{Dosya Adı}";

        _kalemler.Add(new StopajKalemi { Aciklama = "Personel Ücreti", BrutTutar = 100000, StopajOrani = 15 });
        _kalemler.Add(new StopajKalemi { Aciklama = "İşyeri Kirası", BrutTutar = 40000, StopajOrani = 20 });
    }
}
