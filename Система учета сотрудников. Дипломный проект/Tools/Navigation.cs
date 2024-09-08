using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Система_учета_сотрудников._Дипломный_проект.Tools
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
