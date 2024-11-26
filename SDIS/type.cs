using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace SDIS
{
    public class Type
    {
		private int numType;

		public int NumType
		{
			get { return numType; }
			set { numType = value; }
		}
		private string nomType;

		public string NomType
		{
			get { return nomType; }
			set { nomType = value; }
		}

        public Type(int numType, string nomType)
        {
            NumType = numType;
            NomType = nomType;
        }

        public Type( string nomType)
        {
            NomType = nomType;
        }

        public static ObservableCollection<Type> Read()
        {
            ObservableCollection<Type> lesTypes = new ObservableCollection<Type>();
            String sql = "SELECT distinct type_materiel from type_materiel";
            DataTable dt = DataAccess.Instance.GetData(sql);
            foreach (DataRow res in dt.Rows)
            {
                Type nouveau = new Type(res["type_materiel"].ToString());
                Console.WriteLine(nouveau);
                lesTypes.Add(nouveau);
            }
            return lesTypes;
        }

        public override string? ToString()
        {
            return this.nomType;
        }
    }
}
