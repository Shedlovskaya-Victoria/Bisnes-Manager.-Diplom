using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace Система_учета_сотрудников._Дипломный_проект.Tools
{
    public class Base : INotifyPropertyChanged
    {       

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
            =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}
