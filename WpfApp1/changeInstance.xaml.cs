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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for changeInstance.xaml
    /// </summary>
    public partial class changeInstance : Page
    {
        public changeInstance()
        {
            InitializeComponent();
            NavigationService.LoadCompleted += NavigationService_LoadCompleted;
        }
        public changeInstance(int val) : this()
        private void NavigationService_LoadCompleted(object sender, NavigationEventArgs e)
        {
            string str = (string)e.ExtraData;
        }
    }
}
