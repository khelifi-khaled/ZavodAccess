using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavodAccess.Models;

namespace ZavodAccess.Utilities.Interfaces
{
    public interface IDataAccesse
    {
        /// <summary>
        /// Access string to the external source (file path, connections tring ...)
        /// </summary>
        string AccessPath
        {
            get;
            set;
        }


        /// <summary>
        /// retrieve Car's informations from the external source
        /// </summary>
        /// <returns>a CarCollection </returns>
        CarCollection GetCarsDatas();



    }
}
