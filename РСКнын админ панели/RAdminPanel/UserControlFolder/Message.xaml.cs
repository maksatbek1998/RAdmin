using RAdminPanel.DataBase;
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
    }
}
