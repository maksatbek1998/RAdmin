using RAdminPanel.ClassUserControl;
using RAdminPanel.UserControlFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
                lbl_menu8111.Visibility = Visibility.Collapsed;
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
                lbl_menu8111.Visibility = Visibility.Visible;
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
            Checked(7);
            ShowUserControl.Show(Lists, new Language());
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Checked(3);
            ShowUserControl.Show(Lists, new AddOperator());
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Checked(2);
            ShowUserControl.Show(Lists, new WorkPlaces());
        }

        private void fil_Click(object sender, RoutedEventArgs e)
        {
            Checked(0);
            ShowUserControl.Show(Lists, new Branches());            
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Checked(5);
            ShowUserControl.Show(Lists, new Terminal());
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            Checked(6);
            ShowUserControl.Show(Lists, new Client());
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            Checked(4);
            ShowUserControl.Show(Lists, new Rasspisania());
        }

        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Checked(8);
            ShowUserControl.Show(Lists, new Sound());
        }

        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Checked(1);
            ShowUserControl.Show(Lists, new Departament());
        }

        private void Button_Click_11(object sender, RoutedEventArgs e)
        {
            Checked(9);
            ShowUserControl.Show(Lists, new Mode());
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ShowUserControl.Show(Lists, new Branches());
            OpenWindows();
        }

        private void OpenWindows()
        {
            Password window1 = new Password();
            window1.ValueChanged += new Action<string>((x) =>//подписываемся на событие
            {
                blur.Radius = Convert.ToInt32(x);

            });

            if (blur.Radius == 15)
                blur.Radius = 0;
            else
            {

                window1.Owner = this;
                blur.Radius = 15;
                window1.ShowDialog();
            }
        }

        private void Button_Click_12(object sender, RoutedEventArgs e)
        {
            OpenWindows();
        }

        private void Checked(int button)
        {
            fil.IsChecked = false;
            button1.IsChecked = false;
            button2.IsChecked = false;
            button3.IsChecked = false;
            button4.IsChecked = false;
            button5.IsChecked = false;
            button6.IsChecked = false;
            button7.IsChecked = false;
            button8.IsChecked = false;
            button9.IsChecked = false;
            button10.IsChecked = false;
            if (button == 0)
            {
                fil.IsChecked = true;
            }
            else if(button==1)
            {
                button1.IsChecked = true;
            }
            else if (button == 2)
            {
                button2.IsChecked = true;
            }
            else if (button == 3)
            {
                button3.IsChecked = true;
            }
            else if (button == 4)
            {
                button4.IsChecked = true;
            }
            else if (button == 5)
            {
                button5.IsChecked = true;
            }
            else if (button == 6)
            {
                button6.IsChecked = true;
            }
            else if (button == 7)
            {
                button7.IsChecked = true;
            }
            else if (button == 8)
            {
                button8.IsChecked = true;
            }
            else if (button == 9)
            {
                button9.IsChecked = true;
            }
            else if (button == 10)
            {
                button10.IsChecked = true;
            }
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
