using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{
    public class DetailCommance
    {
		private int numcommande;

		public int Numcommande
		{
			get { return numcommande; }
			set { numcommande = value; }
		}

		private int nummateriel;

		public int Nummateriel
		{
			get { return nummateriel; }
			set { nummateriel = value; }
		}

		private int quantite;

		public int Quantite
		{
			get { return quantite; }
			set { quantite = value; }
		}

        public DetailCommance( int nummateriel, int quantite)
        {
			Numcommande ++;
            Nummateriel = nummateriel;
            Quantite = quantite;
        }
    }
}
