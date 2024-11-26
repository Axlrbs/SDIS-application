using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{
    public class categorie
    {
		private int numCategorie;

		public int NumCategorie
		{
			get { return numCategorie; }
			set { numCategorie = value; }
		}
		private string nomCategorie;

		public string NomCategorie
		{
			get { return nomCategorie; }
			set { nomCategorie = value; }
		}

        public categorie(string nomCategorie)
        {
            NomCategorie = nomCategorie;
        }

        public static ObservableCollection<categorie> Read()
        {
            ObservableCollection<categorie> lesCategories = new ObservableCollection<categorie>();
            String sql = "SELECT distinct nom_categorie from categorie";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                categorie nouveau = new categorie(res["nom_categorie"].ToString());
                lesCategories.Add(nouveau);
            }
            return lesCategories;
        }

        public override string? ToString()
        {
            return this.NomCategorie;
        }
    }
}
