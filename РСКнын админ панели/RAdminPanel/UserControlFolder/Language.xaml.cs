using RAdminPanel.ClassUserControl;
using RAdminPanel.DataBase;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    /// <summary>
    /// Логика взаимодействия для Language.xaml
    /// </summary>
    public partial class Language : UserControl
    {
        Base dataBase;
        List<langgrid> list;
        public Language()
        {
            InitializeComponent();
            UpdateComboBoxBranch();
        }

        private void Languages_DropDownClosed(object sender, EventArgs e)
        {
            if (Languages.Text != String.Empty)
                UpdateData();
        }
        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                Languages.ItemsSource = db;
            };
            dataBase.Display("SELECT locale FROM langs");
        }

        public void UpdateData()
        {
            list = new List<langgrid>();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        list.Add(new langgrid
                        {
                            id = (i+1).ToString(),
                            currentlan = db.Rows[i][0].ToString(),
                            newlan = ""
                        });
                    }
                    dataGrid.ItemsSource = list;
                }
            };
            dataBase.SoursData("SELECT name FROM service_langs where locale = '" + Languages.Text + "'");
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            dataBase.RegistrToBase("insert into service_langs(service_id,name,locale) value (" + 1 + "," + NewLang.Text + "," + ShortName.Text + ")");
          
        }

    }
}
