using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{
    public class Sapeur
    {
		private int numSapeur;
        private int numCaserne;
        private string loginSapeur;
        private string mdpSapeur;


        public int NumSapeur
		{
			get { return numSapeur; }
			set { numSapeur = value; }
		}
		
		public int NumCaserne
		{
			get { return numCaserne; }
			set { numCaserne = value; }
		}
		
		public string LoginSapeur
		{
			get { return loginSapeur; }
			set {
				if (value.Length > 8 || String.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException("Le login doit être rempli et inférieur à 6 caractères.");				
				loginSapeur = value; }
		}

		public string MdpSapeur
		{
			get { return mdpSapeur; }
			set {
                if (value.Length > 20 || String.IsNullOrEmpty(value)) throw new ArgumentOutOfRangeException("Le mot de passe doit être rempli et inférieur à 20 caractères.");
                mdpSapeur = value; }
		}

        public Sapeur(int numSapeur, int numCaserne, string loginSapeur, string mdpSapeur)
        {
            NumSapeur = numSapeur;
            NumCaserne = numCaserne;
            LoginSapeur = loginSapeur;
            MdpSapeur = mdpSapeur;
        }

        public Sapeur(int numcaserne) 
        {
			NumCaserne = numcaserne;
		}

        public Sapeur()
        {
        }

        public static ObservableCollection<Sapeur> Read()
        {
            ObservableCollection<Sapeur> lesSapeurs = new ObservableCollection<Sapeur>();
            String sql = "SELECT num_sapeur,num_caserne,login_sapeur,mdp_sapeur FROM sapeur";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Sapeur nouveau = new Sapeur(int.Parse(res["num_sapeur"].ToString()), int.Parse(res["num_caserne"].ToString()), res["login_sapeur"].ToString(),
                res["mdp_sapeur"].ToString());
                Console.WriteLine(nouveau);
                lesSapeurs.Add(nouveau);
            }
            Console.WriteLine(lesSapeurs);
            return lesSapeurs;
        }


        public static Sapeur TrouverCaserne(string log)
        {
            Sapeur nouveau = new Sapeur();
            String sql = $"SELECT num_caserne FROM sapeur where login_sapeur='{log}';";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                nouveau = new Sapeur( int.Parse(res["num_caserne"].ToString()));
#if DEBUG
                Console.WriteLine(nouveau);
#endif
            }
            return nouveau;
        }
        public override string? ToString()
        {
            return this.LoginSapeur + " " + this.MdpSapeur;
        }

    }
}
