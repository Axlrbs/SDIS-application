using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SDIS
{
    public class Materiel
    {
		private int numMateriel;
		private int numFounisseur;
		private string codeType;
		private string descriptionMateriel;
		private string lienPhoto;
		private string marque;
		private string description;
		private double prix;

		public double Prix
		{
			get { return prix; }
			set { 
				
				prix = value; }
		}


		public string Description
		{
			get { return description; }
			set {
                if (value.Length > 300) throw new ArgumentOutOfRangeException("La grande description de materiel doit être inférieur ou égal à 300");
                description = value; }
		}


		public string Marque
		{
			get { return marque; }
			set {
                if (value.Length > 30) throw new ArgumentOutOfRangeException("La marque de materiel doit être inférieur ou égal à 30");
                marque = value; }
		}

		public string LienPhoto
		{
			get { return lienPhoto; }
			set {
                if (value.Length > 100) throw new ArgumentOutOfRangeException("Le lien photo de materiel doit être inférieur ou égal à 100");
                lienPhoto = value; }
		}


		public string DescriptionMateriel
		{
			get { return descriptionMateriel; }
			set {
                if (value.Length > 500) throw new ArgumentOutOfRangeException("La description de materiel doit être inférieur ou égal à 500");
                descriptionMateriel = value; }
		}




		public string CodeType
		{
			get { return codeType; }
			set {
				if (value.Length > 3 && value!=null) throw new ArgumentOutOfRangeException("Le code type de materiel doit être remplit et inférieur ou égal à 3");
				codeType = value; }
		}

		private string categorie;

		public string Categorie
		{
			get { return categorie; }
			set { categorie = value; }
		}



		private string habilitation;

		public string Habilitation
		{
			get { return habilitation; }
			set { habilitation = value; }
		}



		public int NumFournisseur
		{
			get { return numFounisseur; }
			set { numFounisseur = value; }
		}
		private string nomType;

		public string NomType
		{
			get { return nomType; }
			set { nomType = value; }
		}



		public int NumMateriel
		{
			get { return numMateriel; }
			set { numMateriel = value; }
		}

        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix)
        {
            NumMateriel = numMateriel;
            NumFournisseur = numFournisseur;
            CodeType = codeType;
            DescriptionMateriel = descriptionMateriel;
            LienPhoto = lienPhoto;
            Marque = marque;
            Description = description;
            Prix = prix;
        }

        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix, string habilitation) : this(numMateriel, numFournisseur, codeType, descriptionMateriel, lienPhoto, marque, description, prix)
        {
            Habilitation = habilitation;
        }

        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix, string habilitation, string categorie) : this(numMateriel, numFournisseur, codeType, descriptionMateriel, lienPhoto, marque, description, prix, habilitation)
        {
            Categorie = categorie;
        }
        public Materiel(int numMateriel, int numFournisseur, string codeType, string descriptionMateriel, string lienPhoto, string marque, string description, double prix, string habilitation, string categorie,string nomType) : this(numMateriel, numFournisseur, codeType, descriptionMateriel, lienPhoto, marque, description, prix, habilitation,categorie)
        {
            NomType= nomType;
        }



        public static ObservableCollection<Materiel> Read()
        {
            ObservableCollection<Materiel> lesMateriel = new ObservableCollection<Materiel>();
            String sql = "SELECT m.num_materiel,num_fournisseur,nom_habilitation,c.nom_categorie,m.code_type,description_materiel,lien_photo,marque,description,prix,type_materiel FROM materiel m join dispose d on d.num_materiel=m.num_materiel join type_materiel t on t.code_type=m.code_type join categorie c on c.num_categorie=t.num_categorie";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Materiel nouveau = new Materiel(int.Parse(res["num_materiel"].ToString()),
					int.Parse(res["num_fournisseur"].ToString()), 
					res["code_type"].ToString(), 
					res["description_materiel"].ToString(), 
					res["lien_photo"].ToString(), 
					res["marque"].ToString(), 
					res["description"].ToString(), 
					double.Parse(res["prix"].ToString()),
					res["nom_habilitation"].ToString(),
                    res["nom_categorie"].ToString(),
					res["type_materiel"].ToString());
                lesMateriel.Add(nouveau);
            }
            return lesMateriel;
        }

        
    }
}
