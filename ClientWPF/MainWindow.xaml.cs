using System.Windows;
using ClientWPF.ViewModels;

namespace ClientWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}