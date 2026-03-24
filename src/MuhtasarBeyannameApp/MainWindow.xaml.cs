using System.Windows;
using MuhtasarBeyannameApp.ViewModels;

namespace MuhtasarBeyannameApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainWindowViewModel();
    }
}
