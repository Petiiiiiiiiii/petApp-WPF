using System.IO;
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

namespace petApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<Allat> allatok;
        public MainWindow()
        {
            InitializeComponent();
            allatok = new List<Allat>();
            Beolvasas();

            AllatokDG.ItemsSource = allatok;
        }

        public static void Beolvasas() 
        {
            try
            {
                StreamReader sr = new(@"..\..\..\src\animals.txt");
                while (!sr.EndOfStream)
                {
                    allatok.Add(new Allat(sr.ReadLine()));
                }
            }
            catch
            {
                MessageBox.Show("Hiba a fájl beolvasása során!","Hiba",MessageBoxButton.OK,MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        private void Kedveles(object sender, RoutedEventArgs e)
        {
            if (AllatokDG.SelectedItem == null)
            {
                MessageBox.Show("Válassz ki egy állatot!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                if (KedvencekLB.Items.Contains(AllatokDG.SelectedItem))
                {
                    MessageBox.Show("Már egyszer hozzáadtad a kedvencekhez ezt az állatot!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    KedvencekLB.Items.Add(AllatokDG.SelectedItem);
                }
            }
        }

        private void Torles(object sender, RoutedEventArgs e)
        {
            if (KedvencekLB.SelectedItem == null)
            {
                MessageBox.Show("Válassz ki egy állatot!", "Hiba", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else 
            {
                KedvencekLB.Items.Remove(KedvencekLB.SelectedItem);
            }
        }

        private void AllatokDG_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (AllatokDG.SelectedItem is Allat selected)
            {
                AllatImage.Source = new BitmapImage(new Uri(@$"\{selected.ImageUrl}", UriKind.Relative));
            }
        }

    }
}