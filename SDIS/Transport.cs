using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS
{
    public class Transport
    {
		private string nomTransport;
        private int numTransport;

        public int NumTransport
        {
            get { return numTransport; }
            set { numTransport = value; }
        }


        public string NomTransport
		{
			get { return nomTransport; }
			set { nomTransport = value; }
		}

        public Transport(string nomTransport)
        {
            NomTransport = nomTransport;
        }

        public static ObservableCollection<Transport> Read()
        {
            ObservableCollection<Transport> lesTransport = new ObservableCollection<Transport>();
            String sql = "SELECT distinct nom_transport from mode_transport";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Transport nouveau = new Transport(res["nom_transport"].ToString());
                lesTransport.Add(nouveau);
            }
            return lesTransport;
        }
    }
}
