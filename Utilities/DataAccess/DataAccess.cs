
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using ZavodAccess.Models;
using ZavodAccess.Utilities.Interfaces;

namespace ZavodAccess.Utilities.DataAccess
{
    public abstract  class DataAccess : IDataAccesse
    {

        private string _accessPath;

        public DataAccess(string filePath)
        {
            AccessPath = filePath;
        }

        public DataAccess(string filePath, string[] extensions)
        {
            Extensions = new List<string>(extensions.ToList());
            AccessPath = filePath;

        }



        /// <summary>
        /// List of authorized extensions .txt, csv, .Json, .xml ...for the AccessPath file
        /// </summary>
        private List<string> Extensions { get; set; }

        /// <summary>
        /// AccessPath file to the data source
        /// </summary>
        public virtual string AccessPath
        {
            get => _accessPath;

            set
            {
                if (CheckAccessPath(value))
                {
                    _accessPath = value;
                }
            }
        }

        public bool IsValidAccessPath => CheckAccessPath(AccessPath);


        private bool CheckAccessPath(string tryPath)
        {
            if (File.Exists(tryPath))
            {
                if (Extensions?.Any() ?? false)
                {
                    string pattern = "";
                    foreach (string ext in Extensions)
                    {
                        pattern += ext + "|";
                    }
                    pattern = pattern.Substring(0, pattern.Length - 1);
                    //check extension file
                    if (!Regex.IsMatch(tryPath, pattern + "$")) //pattern exemple = ".txt|.csv$"
                    {
                        MessageBox.Show($"L'extension du fichier {tryPath} n'est pas valide, extensions attendues{ pattern}", "Erreur de fichier", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }
                    return true;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                MessageBox.Show($"Le fichier {tryPath} n'existe pas", "Erreur de fichier", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;

            }
        }//end CheckAccessPath



        /// <summary>
        /// retrieve Car's informations from the external source
        /// </summary>
        /// <returns>a CarCollection </returns>        
        public  abstract CarCollection GetCarsDatas();

    }
}
