using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using MuhtasarBeyannameApp.Models;
using MuhtasarBeyannameApp.Services;

namespace MuhtasarBeyannameApp.ViewModels;

public sealed class MainWindowViewModel : INotifyPropertyChanged
{
    private readonly HesaplamaServisi _hesaplamaServisi = new();
    private readonly XmlDisaAktarmaServisi _xmlDisaAktarmaServisi = new();

    private string _vknTckn = "1234567890";
    private string _unvan = "Örnek Ltd. Şti.";
    private int _donemYil = DateTime.Today.Year;
    private int _donemAy = DateTime.Today.Month;
    private string _odemeTuru = "Maaş";
    private decimal _brutTutar = 50000;
    private decimal _stopajOrani = 15;

    public event PropertyChangedEventHandler? PropertyChanged;

    public ObservableCollection<BeyannameSatiri> Satirlar { get; } = [];

    public ICommand SatirEkleKomutu { get; }
    public ICommand XmlKaydetKomutu { get; }

    public MainWindowViewModel()
    {
        SatirEkleKomutu = new RelayCommand(_ => SatirEkle());
        XmlKaydetKomutu = new RelayCommand(_ => XmlKaydet(), _ => Satirlar.Count > 0);
    }

    public string VknTckn
    {
        get => _vknTckn;
        set => SetProperty(ref _vknTckn, value);
    }

    public string Unvan
    {
        get => _unvan;
        set => SetProperty(ref _unvan, value);
    }

    public int DonemYil
    {
        get => _donemYil;
        set => SetProperty(ref _donemYil, value);
    }

    public int DonemAy
    {
        get => _donemAy;
        set => SetProperty(ref _donemAy, value);
    }

    public string OdemeTuru
    {
        get => _odemeTuru;
        set => SetProperty(ref _odemeTuru, value);
    }

    public decimal BrutTutar
    {
        get => _brutTutar;
        set => SetProperty(ref _brutTutar, value);
    }

    public decimal StopajOrani
    {
        get => _stopajOrani;
        set => SetProperty(ref _stopajOrani, value);
    }

    public decimal ToplamMatrah => Satirlar.Sum(x => x.BrutTutar);
    public decimal ToplamStopaj => Satirlar.Sum(x => x.StopajTutari);
    public decimal ToplamDamgaVergisi => Satirlar.Sum(x => x.DamgaVergisiTutari);

    private void SatirEkle()
    {
        try
        {
            var satir = _hesaplamaServisi.SatirOlustur(Satirlar.Count + 1, OdemeTuru, BrutTutar, StopajOrani);
            Satirlar.Add(satir);
            ToplamlariGuncelle();
            (XmlKaydetKomutu as RelayCommand)?.RaiseCanExecuteChanged();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Doğrulama Hatası", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    private void XmlKaydet()
    {
        var dialog = new SaveFileDialog
        {
            Filter = "XML Dosyası (*.xml)|*.xml",
            FileName = $"muhtasar_{DonemYil}_{DonemAy:00}.xml"
        };

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        var model = new BeyannameModeli
        {
            VknTckn = VknTckn,
            Unvan = Unvan,
            DonemYil = DonemYil,
            DonemAy = DonemAy
        };

        foreach (var satir in Satirlar)
        {
            model.Satirlar.Add(satir);
        }

        _xmlDisaAktarmaServisi.Kaydet(model, dialog.FileName);
        MessageBox.Show("XML başarıyla oluşturuldu.", "Bilgi", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private void ToplamlariGuncelle()
    {
        OnPropertyChanged(nameof(ToplamMatrah));
        OnPropertyChanged(nameof(ToplamStopaj));
        OnPropertyChanged(nameof(ToplamDamgaVergisi));
    }

    private void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value))
        {
            return;
        }

        field = value;
        OnPropertyChanged(propertyName);
    }

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
