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
