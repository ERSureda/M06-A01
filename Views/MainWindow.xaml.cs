using M06_A01.DataAccess.Repositories;
using M06_A01.Domain;
using M06_A01.Views;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace M06_A01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async void ButtonAfegir_Click(object sender, RoutedEventArgs e)
        {
            //FirebaseDomainFacory firebaseDomainFactory = new FirebaseDomainFacory();
            //IFirebaseDomain firebaseDomain = firebaseDomainFactory.GetFirebaseDomain();

            //bool student = await firebaseDomain.ExistStudent("Anna Maria");
            ////bool student = await firebaseDomain.RemoveStudent("Eduard Ribas");
            //MessageBox.Show("" + student.ToString());

            AddWindow window = new AddWindow();
            window.ShowDialog();

        }

        private void ButtonModificar_Click(object sender, RoutedEventArgs e)
        {
            UpdateWindow window = new UpdateWindow();
            window.ShowDialog();
        }

        private void ButtonMostrar_Click(object sender, RoutedEventArgs e)
        {
            MostrarWindow window = new MostrarWindow();
            window.ShowDialog();
        }
    }
}