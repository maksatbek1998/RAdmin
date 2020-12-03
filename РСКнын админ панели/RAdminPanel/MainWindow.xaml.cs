using RAdminPanel.UserControlFolder;
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

namespace RAdminPanel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void Skryt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Skryt.Width != 20)
            {
                GridLength grd = new GridLength(50, GridUnitType.Pixel);
                grclm_0.Width = grd;
                lbl_menu0.Width = 0;
                lbl_menu_1.Width = 0;
                lbl_menu_2.Width = 30;
                //JOK.Height = 0;
                //JOK.Width = 0;
                lbl_menu1.Width = 0;
                lbl_menu2.Width = 0;
                lbl_menu3.Width = 0;
                lbl_menu4.Width = 0;
                lbl_menu5.Width = 0;
                lbl_menu6.Width = 0;
                lbl_menu7.Width = 0;
                lbl_menu8.Width = 0;
                lbl_menu9.Width = 0;
                MyChangingColorText.Width = 0;
                Skryt.Width = 20;
            }

            else
            {
                GridLength grd = new GridLength(200, GridUnitType.Pixel);
                grclm_0.Width = grd;
                //JOK.Width = 230;
                //JOK.Height = 50;
                lbl_menu1.Width = 150;
                lbl_menu2.Width = 150;
                lbl_menu0.Width = 150;
                lbl_menu_1.Width = 50;
                lbl_menu_2.Width = 40;
                lbl_menu3.Width = 150;
                lbl_menu4.Width = 150;
                lbl_menu5.Width = 150;
                lbl_menu6.Width = 150;
                lbl_menu7.Width = 150;
                lbl_menu8.Width = 150;
                lbl_menu9.Width = 150;
                MyChangingColorText.Width = 160;
                Skryt.Width = 32;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.WindowState==WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {            
            Lists.Children.Add(new Language());
        }
    }
}
