using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MuhtasarBeyannameWpf.Models;

public class StopajKalemi : INotifyPropertyChanged
{
    private string _aciklama = string.Empty;
    private decimal _brutTutar;
    private decimal _stopajOrani;

    public string Aciklama
    {
        get => _aciklama;
        set
        {
            _aciklama = value;
            OnPropertyChanged();
        }
    }

    public decimal BrutTutar
    {
        get => _brutTutar;
        set
        {
            _brutTutar = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(StopajTutari));
            OnPropertyChanged(nameof(NetOdenecek));
        }
    }

    public decimal StopajOrani
    {
        get => _stopajOrani;
        set
        {
            _stopajOrani = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(StopajTutari));
            OnPropertyChanged(nameof(NetOdenecek));
        }
    }

    public decimal StopajTutari => decimal.Round(BrutTutar * StopajOrani / 100m, 2);

    public decimal NetOdenecek => decimal.Round(BrutTutar - StopajTutari, 2);

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
