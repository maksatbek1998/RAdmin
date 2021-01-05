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
    /// Логика взаимодействия для Mode.xaml
    /// </summary>
    public partial class Mode : UserControl
    {
        Base Base1;
        public Mode()
        {
            InitializeComponent();
            Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int result = 0;
            if (UserNameTextBox.Text != "")
            {
                if (!int.TryParse(UserNameTextBox.Text, out result))
                {
                    MessageBox.Show("Дайте целое число!", "", MessageBoxButton.OK);
                }
                else
                {
                    if (result >= 1)
                    {
                        Base1 = new Base();
                        Base1.RegistrToBase("UPDATE options SET value='" + UserNameTextBox.Text + "' WHERE id=5");
                        MessageBox.Show("Успешно сохранено", "", MessageBoxButton.OK);
                        UserNameTextBox.Text = "";
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
                Chakuruu.Text = "Время вызова клиента в минутах";
                UserNameTextBox.Tag = "Время вызова клиента в минутах";
                Save.Content = "Сохранить";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
             Chakuruu.Text = "Клиент чакыруу убакты минута менен";
                UserNameTextBox.Tag = "Клиент чакыруу убакты минута менен";
                Save.Content = "Сактоо";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
      Chakuruu.Text = "Client call time in minutes";
                UserNameTextBox.Tag = "Client call time in minutes";
                Save.Content = "Save";
            }
        }
    }
}