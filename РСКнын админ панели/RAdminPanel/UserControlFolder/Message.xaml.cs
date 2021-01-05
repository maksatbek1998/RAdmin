using RAdminPanel.DataBase;
using RAdminPanel.ViewModel;
using System.Windows;


namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        public delegate void MessageDel();
        public event MessageDel del_;
        Base dbCon = new Base();
        public string Id { get; set; }
        public string TableBasa { get; set; }
        public Message()
        {
            InitializeComponent();
            Restart();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            if (Id != "" && TableBasa != "")
                dbCon.RemoveData(TableBasa, Id);
            del_();
            this.Close();
        }
        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            {
                message.Text = "Вы уверренно хотите удалить?";
                button.Content = "Да";
                button2.Content = "Нет";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
                message.Text = "Чын эле жок кылгыңыз келеби ? ";
                button.Content = "Ооба";
                button2.Content = "Жок";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                message.Text = "Are you sure you want to delete ? ";
                button.Content = "Yes";
                button2.Content = "No";
            }
        }
    }
}
