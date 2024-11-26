using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SDIS
{
    /// <summary>
    /// Logique d'interaction pour Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        private ImageBrush imgFond = new ImageBrush();
        public Menu()
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            InitializeComponent();
            imgFond.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "img/pompiers2.png"));
            dockMenu.Background = imgFond;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
        }

        private void buttonRechercher_Click(object sender, RoutedEventArgs e)
        {
            Rechercher fenetreRechercher = new Rechercher();
            fenetreRechercher.ShowDialog();
            this.Hide();
            if (fenetreRechercher.DialogResult == true)
                this.Show();
        }

        private void buttonVisualiser_Click(object sender, RoutedEventArgs e)
        {
            Visualiser fenetreVisualiser = new Visualiser();
            fenetreVisualiser.ShowDialog();
            this.Hide();
        }


        private void MenuItem_Checked(object sender, RoutedEventArgs e)
        {
            Menu fenetreMenu = new Menu();
            fenetreMenu.Show();
            this.Close();
        }
    }
}
