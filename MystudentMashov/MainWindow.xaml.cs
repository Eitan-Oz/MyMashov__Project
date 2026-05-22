using System.Windows;
namespace MystudentMashov
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DAL.BaseDal connect = new DAL.BaseDal();
        }
    }
}
