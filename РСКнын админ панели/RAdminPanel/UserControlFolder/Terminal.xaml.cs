using RAdminPanel.DataBase;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Terminal.xaml
    /// </summary>
    public partial class Terminal : UserControl
    {
        Base Base1;
        string id_1;
        string ID = "";
        public Terminal()
        {
            InitializeComponent();
            UpdateLang();
            UpdateDataGrid();
        }
        public void UpdateLang()
        {
            Base1 = new Base();
            Base1.eventDysplay2 += delegate (List<string> list)
            {
                LangTerminal.ItemsSource = list;
            };
            Base1.Display("SELECT locale FROM langs");
        }
        public void UpdateDataGrid()
        {
            Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,locale FROM langs WHERE is_aktiv=1", ref LangData);
        }

        private void Button_Click_1(object sender, System.Windows.RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)LangData.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    Base1.SoursDataGrid("UPDATE langs SET is_aktiv=0 WHERE id= " + id_1 + "", ref LangData);
                }
            }
            UpdateDataGrid();
        }

        private void LangTerminal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ID = Base1.ReturnID1("SELECT id FROM langs WHERE locale='"+LangTerminal.SelectedValue+ "'");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Base1 = new Base();
            if (ID!="")
            {
                Base1.SoursDataGrid("UPDATE langs SET is_aktiv=1 WHERE id= " + ID + "", ref LangData);
            }
            UpdateDataGrid();
        }
        public void UpdateTerminalDataGrid()
        {
            
               Base1 = new Base();
            Base1.SoursDataGrid("SELECT id,locale FROM langs WHERE is_aktiv=1", ref LangData);
        }
    }
}
