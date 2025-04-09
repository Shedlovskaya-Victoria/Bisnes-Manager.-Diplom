using BisnesManager.Client.View;
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
using Система_учета_сотрудников._Дипломный_проект.Tools.API;

namespace BisnesManager.Client.Tools
{
    public class Base : INotifyPropertyChanged
    {       

        public event PropertyChangedEventHandler? PropertyChanged;
        public void Signal([CallerMemberName] string prop = null)
            =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public static bool CheckResultAndGo(string requestAnsw, string systemMessage)
        {
            if (requestAnsw == systemMessage)
            {
                MessageBox.Show(requestAnsw);
                Navigation.Instance().CurrentPage = new Home(UserClient.user);
                return true;
            }
            else
            {
                MessageBox.Show(requestAnsw);
                return false;
            }
        }
    }
}
