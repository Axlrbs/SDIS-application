

using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{

    public class ApplicationData
    {

        private ObservableCollection<Sapeur> lesSapeur = new ObservableCollection<Sapeur>();
        private ObservableCollection<Sapeur> leSapeurConnecte = new ObservableCollection<Sapeur>();
        private ObservableCollection<Materiel> lesMateriel = new ObservableCollection<Materiel>();
        private ObservableCollection<Materiel> lesMaterielselectionne = new ObservableCollection<Materiel>();
        private ObservableCollection<Commande> lesCommandes = new ObservableCollection<Commande>();
        private ObservableCollection<Type> lesTypes = new ObservableCollection<Type>();
        private ObservableCollection<habilitation> lesHabilitations = new ObservableCollection<habilitation>();
        private ObservableCollection<categorie> lesCategories = new ObservableCollection<categorie>();
        private ObservableCollection<DetailCommance> lesDetails = new ObservableCollection<DetailCommance>();
      

        public ObservableCollection<Commande> LesCommandes
        {
            get
            {
                return this.lesCommandes;
            }

            set
            {
                this.lesCommandes = value;
            }
        }
        public ObservableCollection<Sapeur> LeSapeurConnecte
        {
            get
            {
                return this.leSapeurConnecte;
            }

            set
            {
                this.leSapeurConnecte = value;
            }
        }

        public ObservableCollection<DetailCommance> LesDetails
        {
            get
            {
                return this.lesDetails;
            }

            set
            {
                this.lesDetails = value;
            }
        }
        public ObservableCollection<Materiel> LesMaterielselectionne
        {
            get
            {
                return this.lesMaterielselectionne;
            }

            set
            {
                this.lesMaterielselectionne = value;
            }
        }
        public ObservableCollection<Sapeur> LesSapeur
        {
            get
            {
                return this.lesSapeur;
            }

            set
            {
                this.lesSapeur = value;
            }
        }

        public ObservableCollection<Materiel> LesMateriel
        {
            get
            {
                return this.lesMateriel;
            }

            set
            {
                this.lesMateriel = value;
            }
        }

        public ObservableCollection<Type> LesTypes
        {
            get
            {
                return this.lesTypes;
            }

            set
            {
                this.lesTypes = value;
            }
        }

        public ObservableCollection<habilitation> LesHabilitations
        { get => lesHabilitations;
          set => lesHabilitations = value; 
        }
        public ObservableCollection<categorie> LesCategories 
        { get => lesCategories; 
          set => lesCategories = value; 
        }

        public ApplicationData()
        {

            this.LesSapeur = Sapeur.Read();
            this.LesMateriel = Materiel.Read();
            this.LesCommandes = Commande.Read();
            this.LesTypes = Type.Read();
            this.LesHabilitations = habilitation.Read();
            this.lesCategories = categorie.Read();
            this.LesTypes = Type.Read();
        }
    }
    
}
