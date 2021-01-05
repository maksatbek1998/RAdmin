using RAdminPanel.DataBase;
using RAdminPanel.ViewModel;
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
        int ID=0;
        public Rasspisania()
        {
            InitializeComponent();
            UpdateData();
            UpdateComboBox();
            Day_Grafik1();
            Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ID!=0 && Power_Date.Text != "" && Power_OF.Text != "" && TerminalName.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_OF,t_date)VALUES(" + ID + ",'" + Power_OF.Text + "','" + Power_Date.SelectedDate.Value.Date.ToString("yyyy-M-dd") + "')");
                Power_Date.Text = "";
                Power_OF.Text = "";
                ID = 0;
                TerminalName.Text = "";
                UpdateData();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!", MessageBoxButton.OK);
            }
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT tm.id,tm.t_OF,t.name AS t_name, DATE_FORMAT(tm.t_date,'%d.%m.%Y') as t_date FROM terminals_options tm INNER JOIN terminals t ON tm.terminal_id=t.id and t_date IS not null", ref RaspisaniaData);
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
            Bases.eventDysplay2 += delegate (List<string> mass)
             {
                 foreach (var item in mass)
                 {
                     TerminalName.ItemsSource = mass;
                     TerminalName_Copy.ItemsSource = mass;
                 }
             };
            Bases.Display("SELECT NAME AS name,id FROM terminals");
        }

        private void TerminalName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName.SelectedValue!=null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName.SelectedValue.ToString() + "'");
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (ID != 0 && OF_Time.Text !="" && TerminalName_Copy.Text !="" && TerminalPower_Copy.Text != "" && DayCombobox.Text != "")
            {
                Bases.RegistrToBase("insert INTO terminals_options(terminal_id,t_key,t_OF,t_day) VALUES (" + ID + ",'" + TerminalPower_Copy.Text + "','" + OF_Time.Text + "','" + DayCombobox.Text + "')");
                ID = 0;
                TerminalPower_Copy.Text = "";
                OF_Time.Text = "";
                DayCombobox.Text = "";
                TerminalName_Copy.Text = "";
                Day_Grafik1();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Внимание!",MessageBoxButton.OK);
            }
        }
        void Day_Grafik1()
        {
            Bases.SoursDataGrid("SELECT tm.id as id,tm.t_OF as t_of,t.name AS t_name,tm.t_key as t_key, d.day as day FROM terminals_options tm INNER JOIN terminals t INNER JOIN day d ON tm.terminal_id=t.id AND tm.t_day=d.day and t_day IS not null", ref Day_Grafik);
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            DataRowView dataRow = (DataRowView)Day_Grafik.SelectedItem;
            if (dataRow != null)
            {
                id_1 = dataRow.Row.ItemArray[0].ToString();
                Message messageO = new Message();
                if (id_1 != "")
                {
                    messageO.Id = id_1;
                    messageO.TableBasa = "terminals_options";
                    messageO.del_ += () => Day_Grafik1();
                    messageO.ShowDialog();
                }
            }
        }

        private void TerminalName_Copy_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TerminalName_Copy.SelectedValue != null)
            {
                ID = Bases.ReturnID("SELECT id FROM terminals WHERE NAME='" + TerminalName_Copy.SelectedValue.ToString() + "'");
            }
        }
        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            {
                tab1.Header = "CEO праздники";
                tab2.Header = "Согласно расписанию SEO";
                terminal.Text = "Время отдыха на терминале";
                ter_name.Text = "Терминал";
                Ochuu.Text = "Время выключить";
                save.Content = "Сохранить";
                Ochuu_ubakty.Header = "Время выключить";
                Ochuu_Terminal.Header = "Терминал";
                Ochuu_data.Header = "Дата";
                Ochuu_delete.Header = "Удалить";
                T_ochuu.Text = "Время выключить";
                T_abaly.Text = "Состояние";
                T_name.Text = "Терминал";
                T_day.Text = "Дни недели";
                save_button.Content = "Сохранить";
                D_Ochuu.Header = "Время выключить";
                D_day.Header = "Дни недели";
                D_terminal.Header = "Терминал";
                D_abal.Header = "Состояние";
                D_delete.Header = "Удалить";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
                tab1.Header = "СЭО майрам кундору";
                tab2.Header = "СЭО график боюнча";
                terminal.Text = "Терминалдын дем алуу убакыттары";
                ter_name.Text = "Терминал";
                Ochuu.Text = "Өчүү убакты";
                save.Content = "Сактоо";
                Ochuu_ubakty.Header = "Өчүү убакты";
                Ochuu_Terminal.Header = "Терминал";
                Ochuu_data.Header = "Дата";
                Ochuu_delete.Header = "Өчүрүү";
                T_ochuu.Text = "Өчүү убакты";
                T_abaly.Text = "Абалы";
                T_name.Text = "Терминал";
                T_day.Text = "Апта күндөрү";
                save_button.Content = "Сактоо";
                D_Ochuu.Header = "Өчүү убакты";
                D_day.Header = "Апта күндөрү";
                D_terminal.Header = "Терминал";
                D_abal.Header = "Абалы";
                D_delete.Header = "Өчүрүү";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                tab1.Header = "CEO holidays";
                tab2.Header = "According to the SEO schedule";
                terminal.Text = "Terminal rest periods";
                ter_name.Text = "Terminal";
                Ochuu.Text = "Turn off time";
                save.Content = "Save";
                Ochuu_ubakty.Header = "Turn off time";
                Ochuu_Terminal.Header = "Terminal";
                Ochuu_data.Header = "Date";
                Ochuu_delete.Header = "Delete";
                T_ochuu.Text = "Turn off time";
                T_abaly.Text = "Condition";
                T_name.Text = "Terminal";
                T_day.Text = "Days of the week";
                save_button.Content = "Save";
                D_Ochuu.Header = "Turn off time";
                D_day.Header = "Days of the week";
                D_terminal.Header = "Terminal";
                D_abal.Header = "Condition";
                D_delete.Header = "Delete";
            }
        }
    }
}
