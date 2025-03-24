using System.Windows;
using CuratorJournal.Desktop.DTOs;

namespace CuratorJournal.Desktop.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(CuratorDTO curatorDTO)
        {
            InitializeComponent();
        }
    }
}
