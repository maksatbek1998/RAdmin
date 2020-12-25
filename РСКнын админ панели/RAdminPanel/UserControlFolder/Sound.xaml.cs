using RAdminPanel.DataBase;
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
    /// Логика взаимодействия для Sound.xaml
    /// </summary>
    public partial class Sound : UserControl
    {
        Base Base1 = new Base();
        string Option = "";
        public Sound()
        {
            InitializeComponent();
            ToSourseCombo();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Option != "")
            {
                Base1.RegistrToBase("UPDATE options SET VALUE='" + Option + "' WHERE id=1");
                MessageBox.Show("Успешно сохранено", "", MessageBoxButton.OK);
                Option = "";
                SoundCombo.Text = "";
            }
            else
            {
                MessageBox.Show("Заполните все поли!", "Внимание !", MessageBoxButton.OK);
            }
            LanguageCombo.Visibility = Visibility.Hidden;
        }
        private void Sound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = SoundCombo.SelectedIndex;
            if (index == 0)
            {
                LanguageCombo.Visibility = Visibility.Visible;
            }
            else if (index == 1)
            {
                Option = "ALL";
                LanguageCombo.Visibility = Visibility.Hidden;
            }
            else if (index == 2)
            {
                Option = "SOUND";
                LanguageCombo.Visibility = Visibility.Hidden;
            }
        }
        void ToSourseCombo()
        {
            Base1 = new Base();
            Base1.eventDysplay2 += delegate (List<string> list)
            {
                SoundCombo_Copy.ItemsSource = list;
            };
            Base1.Display("SELECT locale FROM langs");
        }
        private void SoundCombo_Copy_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            Option = SoundCombo_Copy.SelectedValue.ToString();
        }
    }
}
