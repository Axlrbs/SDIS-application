using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace SDIS
{
    public class Commande
    {
        private int numcommande;

        public int Numcommande
        {
            get { return numcommande; }
            set { numcommande = value; }
        }

        private int numtransport;

        public int Numtransport
        {
            get { return numtransport; }
            set { numtransport = value; }
        }

        private int numcaserne;

        public int Numcaserne
        {
            get { return numcaserne; }
            set { numcaserne = value; }
        }

        private DateTime dateLivraison;

        public DateTime DateLivraison
        {
            get { return dateLivraison; }
            set { dateLivraison = value; }
        }

        private DateTime dateCommande;

        public DateTime DateCommande
        {
            get { return dateCommande; }
            set { dateCommande = value; }
        }

        public Commande(int numcommande, int numcaserne, int numtransport, DateTime dateCommande, DateTime dateLivraison)
        {
            Numcommande = numcommande;
            Numcaserne = numcaserne;
            Numtransport = numtransport;
            DateCommande = dateCommande;
            DateLivraison = dateLivraison;
        }


        public Commande( int numcaserne, int numtransport, DateTime dateCommande, DateTime dateLivraison)
        {
            Numcommande= 10;
            Numcaserne = numcaserne;
            Numtransport = numtransport;
            DateCommande = dateCommande;
            DateLivraison = dateLivraison;
        }

        DataAccess data =  DataAccess.Instance;



        public static ObservableCollection<Commande> Read()
        {
            ObservableCollection<Commande> lesCommandes = new ObservableCollection<Commande>();
            String sql = "SELECT C.num_commande,num_transport,num_caserne,date_commande,date_livraison FROM commande C ;";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Commande nouveau = new Commande(int.Parse(res["num_commande"].ToString()), int.Parse(res["num_transport"].ToString()), int.Parse(res["num_caserne"].ToString()),DateTime.Parse(res["date_commande"].ToString()), DateTime.Parse(res["date_livraison"].ToString()));
                lesCommandes.Add(nouveau);
            }
            Console.WriteLine(lesCommandes);
            return lesCommandes;
        }

        public int Create()
        {
            String sql1 = $"insert into commande (num_transport,num_caserne,date_commande,date_livraison)"
             + $" values ({this.Numtransport},{this.Numcaserne},'{this.DateCommande.ToString("d")}'"
             + $",'{this.DateLivraison.ToString("d")}'); ";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql1, data.Connexion);
                int nb = cmd.ExecuteNonQuery();
                return nb;
                //nb permet de connaître le nb de lignes affectées par un insert, update, delete
            }
            catch (Exception sqlE)
            {
                Console.WriteLine("pb de requete : " + sql1 + "" + sqlE);
                // juste pour le debug : à transformer en MsgBox 
                return 0;
            }
        }
    }
}
