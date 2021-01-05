using RAdminPanel.DataBase;
using RAdminPanel.ViewModel;
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
            Restart();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int result1 = 0;
            if (Metr.Text != "")
            {
                if (!int.TryParse(Metr.Text, out result1))
                {
                    MessageBox.Show("Дайте целое число!", "", MessageBoxButton.OK);
                }
                else
                {
                    if (result1 >= 1)
                    {
                        int result = Convert.ToInt32(Metr.Text) * 100;
                        Base1 = new Base();
                        Base1.RegistrToBase("UPDATE `rskbank`.`options` SET `value`='" + result + "' WHERE  `key`='Terminal_Paper'");
                        MessageBox.Show("Успешно сохранено", "", MessageBoxButton.OK);
                        Metr.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Не указывайте 0 или отрицательное число!", "", MessageBoxButton.OK);
                    }
                }
            }
            else
            {
                MessageBox.Show("Заполните поли!", "Внимание !", MessageBoxButton.OK);
            }
        }
        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            {
                Chek.Text = "Метр чека";
                Metr.Tag = "Метр чека";
                button.Content = "Сохранить";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
                Chek.Text = "Чектин метири";
                Metr.Tag = "Чектин метири";
                button.Content = "Сактоо";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                Chek.Text = "Check meter";
                Metr.Tag = "Check meter";
                button.Content = "Save";
            }
        }
    }
}
