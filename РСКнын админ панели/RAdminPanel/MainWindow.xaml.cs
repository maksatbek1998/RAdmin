using RAdminPanel.ClassUserControl;
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
                lbl_menu0.Visibility = Visibility.Collapsed;
                lbl_menu_1.Visibility = Visibility.Collapsed;
                lbl_menu_2.Width = 32;
                lbl_menu_2.Margin = new Thickness(7,0,20,0);
                //JOK.Height = 0;
                //JOK.Width = 0;
                lbl_menu1.Visibility = Visibility.Collapsed;
                lbl_menu2.Visibility = Visibility.Collapsed;
                lbl_menu3.Visibility = Visibility.Collapsed;
                lbl_menu4.Visibility = Visibility.Collapsed;
                lbl_menu5.Visibility = Visibility.Collapsed;
                lbl_menu6.Visibility = Visibility.Collapsed;
                lbl_menu8.Visibility = Visibility.Collapsed;
                lbl_menu9.Visibility = Visibility.Collapsed;
                lbl_menu81.Visibility = Visibility.Collapsed;
                lbl_menu22.Visibility = Visibility.Collapsed;
                lbl_menu811.Visibility = Visibility.Collapsed;
                MyChangingColorText.Visibility = Visibility.Collapsed;
                Skryt.Width = 20;
            }

            else
            {
                GridLength grd = new GridLength(250, GridUnitType.Pixel);
                grclm_0.Width = grd;
                //JOK.Width = 230;
                //JOK.Height = 50;
                lbl_menu0.Visibility = Visibility.Visible;
                lbl_menu_1.Visibility = Visibility.Visible;
                lbl_menu1.Visibility = Visibility.Visible;
                lbl_menu2.Visibility = Visibility.Visible;
                lbl_menu_2.Width = 40;
                lbl_menu_2.Margin = new Thickness(10, 0, 20, 0);
                lbl_menu81.Visibility = Visibility.Visible;
                lbl_menu22.Visibility = Visibility.Visible;
                lbl_menu3.Visibility = Visibility.Visible;
                lbl_menu4.Visibility = Visibility.Visible;
                lbl_menu5.Visibility = Visibility.Visible;
                lbl_menu6.Visibility = Visibility.Visible;
                lbl_menu8.Visibility = Visibility.Visible;
                lbl_menu9.Visibility = Visibility.Visible;
                lbl_menu811.Visibility = Visibility.Visible;
                MyChangingColorText.Visibility = Visibility.Visible;
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
            ShowUserControl.Show(Lists, new Language());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new AddOperator());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new WorkPlaces());
        }

        private void fil_Click(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Branches());            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Terminal());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Client());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Rasspisania());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Sound());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Departament());
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Mode());
        }
    }
}
