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
            Bases.RegistrToBase("INSERT INTO  position value(null,'" + OtdelName.Text + "','" + OtdelPrioritet.Text + "')");
            OtdelName.Text = "";
            OtdelPrioritet.Text = "";
            UpdateData();
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,name_p,index_p FROM position ORDER BY index_p desc", ref OtdelData);
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
    }
}
