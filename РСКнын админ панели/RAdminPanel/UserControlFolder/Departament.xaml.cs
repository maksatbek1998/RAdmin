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
        Base Bases = new Base();
        public Departament()
        {
            InitializeComponent();
            UpdateData();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (OtdelName.Text != "" )
            {
                Bases.RegistrToBase("INSERT INTO position (name_p) VALUES('" + OtdelName.Text + "')");
                OtdelName.Text = "";
                 UpdateData();
            }
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,name_p FROM position ", ref OtdelData);
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

        private void OtdelData2_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int columnIndex = OtdelData.CurrentColumn.DisplayIndex;
            DataRowView dataRow = (DataRowView)OtdelData.SelectedItem;
            if (dataRow != null)
            {
                
                string number_f = dataRow.Row.ItemArray[0].ToString();
            }
            //MessageBox.Show(number_f);
            Bases.SoursDataGrid("SELECT * FROM view_services v WHERE v.childrens='0' ", ref OtdelData2);
        }
    }
}
