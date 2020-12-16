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
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (Option!="")
            {
                Base1.RegistrToBase("UPDATE options SET VALUE='" + Option + "' WHERE id=1");
                Option = "";
                SoundCombo.Text = "";
            }
        }
        private void Sound_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = SoundCombo.SelectedIndex;
            if (index==0)
            {
                Option = "ON_Sound_Speech";
            }
            else if (index == 1)
            {
                Option = "Sound";
            }
            else if (index == 2)
            {
                Option = "OF_Sound_Speech";
            }
        }
    }
}
