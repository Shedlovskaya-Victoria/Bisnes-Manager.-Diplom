﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using BisnesManager.Client.Tools;
using BisnesManager.Client.ViewModel;

namespace BisnesManager.Client.View
{
    /// <summary>
    /// Логика взаимодействия для Enter.xaml
    /// </summary>
    public partial class Enter : Page
    {
        public Enter()
        {
            InitializeComponent();
            DataContext = new EnterVM(password);

          
        }
    }
}
