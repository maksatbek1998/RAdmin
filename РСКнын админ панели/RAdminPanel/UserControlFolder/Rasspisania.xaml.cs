using RAdminPanel.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для Rasspisania.xaml
    /// </summary>
    public partial class Rasspisania : UserControl
    {
        Base Bases = new Base();
        string id_1;
        public Rasspisania()
        {
            InitializeComponent();
            UpdateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_key,t_ON,t_OF,t_date)VALUES('2','f','f','f','2020.02.02')");
            Power_Date.Text = "";
            Power_OF.Text = "";
            Power_ON.Text = "";
            UpdateData();
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,t_ON,t_OF, DATE_FORMAT(t_date,'%d.%m.%Y') as t_date FROM terminals_options WHERE NOT t_day IS null", ref RaspisaniaData);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)RaspisaniaData.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "terminals_options";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }
        public void UpdateComboBox()
        {
            Bases.eventDysplay2 += delegate (string[] mass)
             {
                 TerminalName.ItemsSource = mass;
             };
            Bases.Display("SELECT id,t_ON,t_OF, DATE_FORMAT(t_date,'%d.%m.%Y') as t_date FROM terminals_options WHERE NOT t_day IS null",10);
        }
    }
}
