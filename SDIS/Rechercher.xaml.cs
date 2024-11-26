using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDIS
{
    /// <summary>
    /// Logique d'interaction pour Rechercher.xaml
    /// </summary>
    public partial class Rechercher : Window
    {
        private ImageBrush imgFond = new ImageBrush();
        public Rechercher()
        {
            InitializeComponent();
            datarechercher.LesMaterielselectionne.Clear();
            iniCombobox();
            dgMateriel.Items.Filter = FiltrageCategorie;
            imgFond.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "img/pompiers.png"));
            gridRechercher.Background = imgFond;
        }


        private bool FiltrageCategorie(object obj)
        {
            Materiel mat = obj as Materiel;
            if (mat == null)
                return false;

            bool filtreCategorie = cbfiltrecategorie.SelectedItem != null && cbfiltrecategorie.SelectedItem.ToString() != "";
            bool filtreType = cbfiltretype.SelectedItem != null && cbfiltretype.SelectedItem.ToString() != "";
            bool filtreHabilitation = cbfiltrehabilitation.SelectedItem != null && cbfiltrehabilitation.SelectedItem.ToString() != "";
            bool filtreRecherche = !string.IsNullOrEmpty(tbRechercher.Text);

            if (filtreRecherche)
            {
                if (filtreCategorie && !mat.Categorie.Equals(cbfiltrecategorie.SelectedItem))
                    return false;
                if (filtreType && !mat.NomType.Equals(cbfiltretype.SelectedItem))
                    return false;
                if (filtreHabilitation && !mat.Habilitation.Equals(cbfiltrehabilitation.SelectedItem))
                    return false;
                return mat.DescriptionMateriel.StartsWith(tbRechercher.Text, StringComparison.OrdinalIgnoreCase);
            }
            else
            {
                if (filtreCategorie && !mat.Categorie.Equals(cbfiltrecategorie.SelectedItem))
                    return false;
                if (filtreType && !mat.NomType.Equals(cbfiltretype.SelectedItem))
                    return false;
                if (filtreHabilitation && !mat.Habilitation.Equals(cbfiltrehabilitation.SelectedItem))
                    return false;
                return true;
            }
        }
        

        private void tbRechercher_TextChanged(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgMateriel.ItemsSource).Refresh();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            Menu mainWindow = new Menu();
            mainWindow.ShowDialog();
            this.Close();
        }

        private void cbfiltrecategorie_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if(cbfiltrecategorie.SelectedItem != null)
            {
                switch (cbfiltrecategorie.SelectedItem)
                {
                    case "Accessoire":
                        cbfiltretype.Items.Clear();
                        cbfiltretype.Items.Add("Bottes");
                        break;
                    case "Lampe":
                        cbfiltretype.Items.Clear();
                        cbfiltretype.Items.Add("Torche");
                        break;
                    case "Tenue":
                        cbfiltretype.Items.Clear();
                        cbfiltretype.Items.Add("Tee shirt");
                        cbfiltretype.Items.Add("Veste");
                        cbfiltretype.Items.Add("Pantalon");
                        break;
                    default:
                        cbfiltretype.Items.Clear();
                        cbfiltretype.Items.Add("");
                        break;

                }
            }
            CollectionViewSource.GetDefaultView(dgMateriel.ItemsSource).Refresh();

        }

        private void iniCombobox()
        {
            cbfiltrecategorie.Items.Add("");
            cbfiltrecategorie.Items.Add("Accessoire");
            cbfiltrecategorie.Items.Add("Lampe");
            cbfiltrecategorie.Items.Add("Tenue");

            cbfiltrehabilitation.Items.Add("");
            cbfiltrehabilitation.Items.Add("Tout public");
            cbfiltrehabilitation.Items.Add("Sapeur-Pompier");
            cbfiltrehabilitation.Items.Add("Tenue professionnelle");
        }

        private void cbfiltretype_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CollectionViewSource.GetDefaultView(dgMateriel.ItemsSource).Refresh();
        }

        private void cbfiltrehabilitation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            CollectionViewSource.GetDefaultView(dgMateriel.ItemsSource).Refresh();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void butAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (dgMateriel.SelectedItem != null || tbquantite==null )
            {
                Materiel materielSelectionne = (Materiel)dgMateriel.SelectedItem;
                Console.WriteLine(materielSelectionne +"  salut");
                int nummateriel = materielSelectionne.NumMateriel;
                int quantite = int.Parse(tbquantite.Text);
                DetailCommance detail = new DetailCommance(nummateriel,quantite);
                datarechercher.LesMaterielselectionne.Add(materielSelectionne);
                datarechercher.LesDetails.Add(detail);
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un materiel et la quantité");
        }

        private void butValider_Click(object sender, RoutedEventArgs e)
        {
            if (tbnumtransport != null || dplivraison.SelectedDate != DateTime.Now || tbNumCaserne != null)
            {
                DateTime date = new DateTime();
                DateTime.TryParse(dplivraison.SelectedDate.ToString(), out date);
                /*MainWindow log = new MainWindow();
                string login = log.tbLogin.Text.ToString();
                Console.WriteLine(login);
                Sapeur sapeur = Sapeur.TrouverCaserne(login);
                datarechercher.LeSapeurConnecte.Add(sapeur);*/
                // probleme pour recuperer la caserne
                Commande final = new Commande(int.Parse(tbNumCaserne.Text),int.Parse(tbnumtransport.Text),DateTime.Now.Date, date);
                final.Create();
                Menu menu = new Menu();
                menu.Show();
                this.Close();
            }
            else
                MessageBox.Show(this, "Veuillez selectionner un transport et la date");
        }
    }
}
