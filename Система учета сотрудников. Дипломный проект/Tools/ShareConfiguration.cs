using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Client.Tools
{
    public class ShareConfiguration : Base
    {
        #region Name

        private string name = String.Empty;

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                Signal("Name");
            }
        }

        #endregion

        #region NetworkLocation

        private string netLocation = String.Empty;


        public string NetworkLocation
        {
            get { return netLocation; }
            set
            {
                netLocation = value;
                Signal("NetworkLocation");
            }
        }
        #endregion

    }
}
