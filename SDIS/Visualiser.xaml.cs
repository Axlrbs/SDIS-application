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
    /// Logique d'interaction pour Visualiser.xaml
    /// </summary>
    public partial class Visualiser : Window
    {
        public Visualiser()
        {
            InitializeComponent();
            ImageBrush fond = new ImageBrush();
            fond.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "img/pompiers.png"));
            gridmain.Background = fond;
            //dgcommande.Items.Filter = ContientMotClef;
        }

        /*private bool ContientMotClef(object obj)
        {
            Commande mat = obj as Commande;
            if (String.IsNullOrEmpty(tbrechercher.Text))
                return true;
            else
                return mat.DateCommande.StartsWith(tbrechercher.Text, StringComparison.OrdinalIgnoreCase);
        }*/

        private void tbrechercher_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgcommande.ItemsSource).Refresh();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Menu fenetreMenu = new Menu();
            fenetreMenu.ShowDialog();
            this.Close();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            this.Close();
        }
    }
}
