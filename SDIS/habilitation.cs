using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{
    public class habilitation
    {
		private string nomHabilitation;

		public string NomHabilitation
		{
			get { return nomHabilitation; }
			set { nomHabilitation = value; }
		}
		private int numHabilitation;

		public int NumHabilitation
		{
			get { return numHabilitation; }
			set { numHabilitation = value; }
		}

        public habilitation(string nomHabilitation)
        {
            NomHabilitation = nomHabilitation;

        }
        public static ObservableCollection<habilitation> Read()
        {
            ObservableCollection<habilitation> lesHabilitations= new ObservableCollection<habilitation>();
            String sql = "SELECT distinct nom_habilitation from habilitation";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                habilitation nouveau = new habilitation(res["nom_habilitation"].ToString());
                lesHabilitations.Add(nouveau);
            }
            return lesHabilitations;
        }

        public override string? ToString()
        {
            return this.NomHabilitation;
        }
    }
}
