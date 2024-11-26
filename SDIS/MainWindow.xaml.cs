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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SDIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {   ApplicationData data = new ApplicationData();
        private ImageBrush imgFond = new ImageBrush();
        public MainWindow()
        {
            InitializeComponent();
            data.LeSapeurConnecte.Clear();
            imgFond.ImageSource = new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "img/pompiers2.png"));
            fondPageConnexion.Background = imgFond;
        }

        private void butSeConnecter_Click(object sender, RoutedEventArgs e)
        {
            /*bool ok = true;
            foreach (UIElement uie in formulaireConnexion.Children)
            {
                if (uie is TextBox)
                {
                    TextBox txt = (TextBox)uie;
                    txt.GetBindingExpression(TextBox.TextProperty).UpdateSource();
                }
                if (Validation.GetHasError(uie))
                    ok = false;

            }
            if (ok)
            {
                Menu fenetre = new Menu();
                fenetre.Show();
                this.Close();
            }*/
            string log = tbLogin.Text;
            string mdp = pbmdp.Password;
            DataAccess.Instance.ConnexionBD(log,mdp);
            if (DataAccess.Instance.ConnexionBD(log, mdp) == true)
            {
                this.Hide();
            }
            else
            {
                tbLogin.Text = "";
                pbmdp.Password = "";
            }
        }
    }
}
