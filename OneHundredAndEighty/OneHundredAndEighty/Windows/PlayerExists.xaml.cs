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
using System.Windows.Shapes;

namespace OneHundredAndEighty.Windows
{
    /// <summary>
    /// Логика взаимодействия для PlayerExists.xaml
    /// </summary>
    public partial class PlayerExists : Window
    {
        public PlayerExists()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e) //  Кнопка ОК
        {
            this.Close();
        }
    }
}
