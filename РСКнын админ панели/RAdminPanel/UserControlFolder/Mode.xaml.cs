﻿using RAdminPanel.DataBase;
using System;
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

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Mode.xaml
    /// </summary>
    public partial class Mode : UserControl
    {
        Base Base1;
        public Mode()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Base1 = new Base();
            Base1.RegistrToBase("UPDATE options SET value='" + UserNameTextBox.Text + "' WHERE id=5");
            UserNameTextBox.Text = "";
        }
    }
}