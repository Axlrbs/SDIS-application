using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SDIS
{
    internal class DataAccess
    {
        private static DataAccess instance;
        private static string strConnexion = "Server=srv-peda-new;" +
                                "port=5433;" +
                                "Database=sdistp11B;" +
                                "Search Path = sdis;" +
                                "uid=akinb;" +
                                "password=7QFajK;";

        public DataAccess()
        {
        }

        public static DataAccess Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DataAccess();
                }
                return instance;
            }
        }

        public NpgsqlConnection? Connexion
        {
            get;
            set;
        }

        public void ConnexionBD()
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = strConnexion;
                Connexion.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de connexion", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public bool ConnexionBD(string log,string mdp)
        {
            try
            {
                Connexion = new NpgsqlConnection();
                Connexion.ConnectionString = "Server=srv-peda-new;" +
                                "port=5433;" +
                                "Database=sdistp11B;" +
                                "Search Path = sdis;" +
                                "uid=" + log + ";" +
                                "password=" + mdp + ";"; ;
                Connexion.Open();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Erreur de connexion, le login " + log + " ou le mot de passe " + mdp + " est incorrect.", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public void DeconnexionBD()
        {
            try
            {
                Connexion.Close();
            }
            catch (Exception e)
            { Console.WriteLine("pb à la déconnexion : " + e); }
        }

        public DataTable GetData(string selectSQL)
        {
            try
            {
                NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(selectSQL, strConnexion);
                DataTable dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + selectSQL + e.ToString());
                return null;
            }
        }

        public int SetData(string setSQL)
        {

            try
            {
                NpgsqlCommand sqlCommand = new NpgsqlCommand(setSQL, Connexion);
                int nbLines = sqlCommand.ExecuteNonQuery();
                return nbLines;
            }
            catch (Exception e)
            {
                Console.WriteLine("pb avec : " + setSQL + e.ToString());
                return 0;
            }
        }
    }
}
