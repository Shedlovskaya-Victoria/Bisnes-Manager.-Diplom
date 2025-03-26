using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Client.Model
{
    public class ForGragAndDrop
    {
        public ObservableCollection<BisnesTaskDTO> Children { get; private set; }

        public bool CanAcceptChildren { get; set; }
    }
}
