using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BisnesManager.Client.Tools
{
    public class Navigation : Base
    {
        static Navigation navigation;
        private Page currentPage;

        public Navigation()
        {
            if (CurrentPage == null)
                CurrentPage = new();
        }

        public static Navigation Instance()
        {
            return navigation ?? (navigation = new());
        }
        public Page CurrentPage 
        { 
            get => currentPage;
            set
            {             
                currentPage = value;
                Signal();
            }
        }
    }
}
