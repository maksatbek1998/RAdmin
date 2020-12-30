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
    /// Логика взаимодействия для Printer.xaml
    /// </summary>
    public partial class Printer : UserControl
    {
        Base Base1;
        public Printer()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Metr.Text!="")
            {
                /*                object iBoxed = Metr.Text;
                                if (iBoxed is int)
                                {*/
                int result = Convert.ToInt32(Metr.Text)*100;
                Base1 = new Base();
                Base1.RegistrToBase("UPDATE `rskbank`.`options` SET `value`='"+ result + "' WHERE  `key`='Terminal_Paper'");
                MessageBox.Show("Успешно сохранено", "", MessageBoxButton.OK);
                Metr.Text= "";
/*                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите число !", "Внимание !", MessageBoxButton.OK);
                }*/
            }
            else
            {
                MessageBox.Show("Заполните поли!", "Внимание !", MessageBoxButton.OK);
            }     
        }
    }
}
