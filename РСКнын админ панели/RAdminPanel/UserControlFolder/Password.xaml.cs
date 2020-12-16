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
using System.Windows.Shapes;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Password.xaml
    /// </summary>
    public partial class Password : Window
    {
        Base Base1;
        string flag = String.Empty;
        public Password()
        {
            InitializeComponent();
        }

        private void button_1_Click(object sender, RoutedEventArgs e)
        {
            Base1 = new Base();
            if (LogTextBox.Text!=String.Empty && PassTextBox.Text!=String.Empty)
            {
                flag = Base1.ReturnIDString("SELECT id FROM parol WHERE LOG='" + LogTextBox.Text + "' AND pass='" + PassTextBox.Text + "'");
                if (flag != String.Empty)
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Логин или парол не верно!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поли!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Error);
            }
          
        }

        private void button_2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void TextBlock_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            if (Win.Height==200)
            {
                Win.Height = 365;
            }
            else
            {
                Win.Height = 200;
            }
        }

        private void button_1_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (LogTextBox.Text != String.Empty && PassTextBox.Text != String.Empty)
            {
                flag = Base1.ReturnIDString("SELECT id FROM parol WHERE LOG='" + LogTextBox.Text + "' AND pass='" + PassTextBox.Text + "'");
                if (flag != String.Empty)
                {
                    if (OldPass.Text != String.Empty && NewPass.Text != String.Empty)
                    {
                        if (NewPass.Text == OldPass.Text)
                        {

                            Base1.RegistrToBase("update parol SET pass='" + NewPass.Text + "' WHERE id =1 ");
                            NewPass.Text = "";
                            OldPass.Text = "";
                            Win.Height = 200;
                        }
                        else
                        {
                            MessageBox.Show("Повторить пароль не совпадает!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Question);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Заполните все поли!", "Внимание !", MessageBoxButton.OK, MessageBoxImage.Error);
                    }      
                }
            }
        }
    }
}
