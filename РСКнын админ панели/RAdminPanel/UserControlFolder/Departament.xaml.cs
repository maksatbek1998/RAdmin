using RAdminPanel.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;


namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Departament.xaml
    /// </summary>
    public partial class Departament : UserControl
    {
        string id_1="";
        string number_f = "", number_f2 = "";
        Base Bases = new Base();
        public Departament()
        {
            InitializeComponent();
            UpdateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OtdelName.Text != "")
            {
                Bases.RegistrToBase("INSERT INTO position (name_p) VALUES ('"+OtdelName.Text+"')");
                OtdelName.Text = "";
                UpdateData();
            }
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,name_p FROM position", ref OtdelData);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)OtdelData.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "position";
                    messageO.del_ += () => UpdateData();
                    messageO.ShowDialog();
                }
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            if (number_f2 != "")
                Bases.RegistrToBase(" DELETE FROM positions_services  " +
                    $"WHERE  position_id={number_f} and service_id={number_f2}");
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            if (number_f2 != "")
                Bases.RegistrToBase("INSERT INTO positions_services(position_id,service_id)" +
                    $"values('{number_f}','{number_f2}')");
        }

        private void OtdelData_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)OtdelData.SelectedItem;
            if (dataRow != null)
            {
                number_f = dataRow.Row.ItemArray[0].ToString();
            }
            //MessageBox.Show(number_f);
            Bases.SoursDataGrid("SELECT v.id,v.name, if(p.position_id=" + number_f + ",true,FALSE) AS flag " +
                "FROM view_services v LEFT JOIN positions_services p " +
                $"ON v.id = p.service_id AND p.position_id={number_f} ORDER BY v.id", ref OtdelData2);
            number_f2 = "";
        }

        private void OtdelData_SelectedCellsChanged2(object sender, SelectedCellsChangedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)OtdelData2.SelectedItem;
            if (dataRow != null)
            {
                number_f2 = dataRow.Row.ItemArray[0].ToString();
            }
        }
    }
}
