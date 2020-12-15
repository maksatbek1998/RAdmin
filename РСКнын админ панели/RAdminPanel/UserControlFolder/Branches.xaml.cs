using RAdminPanel.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Branches.xaml
    /// </summary>
    public partial class Branches : UserControl
    {
        string id_1;
        Base Bases = new Base();
        public Branches()
        {
            InitializeComponent();
            UpdateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bases.RegistrToBase("INSERT INTO branches(NAME,address)VALUES ('" + FilialName.Text + "','" + FilialAdress.Text + "')");
            FilialName.Text = "";
            FilialAdress.Text = "";
            UpdateData();
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,NAME,address, DATE_FORMAT(created_at,'%d.%m.%Y') as 'created_at' FROM branches", ref DataList);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)DataList.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString(); 
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "branches";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }                                              
        }

        private void DataList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow2 = (DataRowView)DataList.SelectedItem;
            if (dataRow2 != null)
            {
                id_1 = dataRow2.Row.ItemArray[0].ToString();
            }       
        }
    }
}
