using RAdminPanel.ClassUserControl;
using RAdminPanel.DataBase;
using RAdminPanel.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace RAdminPanel.UserControlFolder
{
    public partial class Client : UserControl
    {
        Base dataBase;

        static int returnedOper;

        static int returnedUslug;

        #region List
        List<gridvar> list = new List<gridvar>();
        List<gridvar> lister = new List<gridvar>();
        List<gridvar> Mainlist = new List<gridvar>();
        List<gridvar> listDt2 = new List<gridvar>();
        List<gridvar> MainlistDt2 = new List<gridvar>();
        List<gridvar> list0 = new List<gridvar>();
        List<gridvar> list1 = new List<gridvar>();
        List<gridvar> list2 = new List<gridvar>();
        List<gridvar> listOper = new List<gridvar>();
        List<gridvar> listUslug = new List<gridvar>();
        #endregion

        public Client()
        {
            InitializeComponent();
            dataPicker.SelectedDate = DateTime.Today;
            UpdateData2();
            UpdateData();
            UpdateComboBoxBranch();
            UpdateComboBoxPosition();
            Restart();
        }

        public void UpdateData()
        {
            list.Clear();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        list.Add(new gridvar
                        {
                            id = db.Rows[i][0].ToString(),
                            checkNum = db.Rows[i][1].ToString(),
                            status = db.Rows[i][2].ToString(),
                            uslugvid = db.Rows[i][3].ToString(),
                            window = db.Rows[i][4] != DBNull.Value ? db.Rows[i][4].ToString() : "",
                            oper = db.Rows[i][5] != DBNull.Value ? db.Rows[i][5].ToString() : "",
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = db.Rows[i][7] != DBNull.Value ? Convert.ToDateTime(db.Rows[i][7]) : DateTime.MinValue
                        });
                    }
                    Mainlist = list;
                    dataGrid.ItemsSource = list;
                }
            };
            dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`, (SELECT s.name FROM services AS s WHERE s.id = t.service_id) AS ser_nam, (SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam, (SELECT gg.name_u FROM users AS gg WHERE gg.id = t.user_id) AS nam_u, t.created_at, t.updated_at FROM `rskbank`.`turns` AS t WHERE CURRENT_DATE()< t.created_at");
        }

        public void UpdateData2()
        {
            dataGrid2.ItemsSource = null;
            listDt2.Clear();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        listDt2.Add(new gridvar
                        {
                            id = db.Rows[i][0].ToString(),
                            checkNum = db.Rows[i][1].ToString(),
                            status = db.Rows[i][2].ToString(),
                            uslugvid = db.Rows[i][3].ToString(),
                            window = db.Rows[i][4] != DBNull.Value ? db.Rows[i][4].ToString() : "",
                            oper = db.Rows[i][5] != DBNull.Value ? db.Rows[i][5].ToString() : "",
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = db.Rows[i][7] != DBNull.Value ? Convert.ToDateTime(db.Rows[i][7]) : DateTime.MinValue
                        });
                    }
                    MainlistDt2 = listDt2;
                    dataGrid2.ItemsSource = listDt2;
                }
            };
            dataBase.SoursData("SELECT t.id, t.nomer, (SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`, (SELECT s.name FROM services AS s WHERE s.id = t.service_id) AS ser_nam, (SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam, (SELECT gg.name_u FROM users AS gg WHERE gg.id = t.user_id) AS nam_u, t.created_at, t.updated_at FROM `rskbank`.`turns` AS t WHERE CURRENT_DATE()<t.created_at");
        }

        #region Filtr

        List<gridvar> filterModeLisst = new List<gridvar>();

        private void filterTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeLisst.Clear();

            if (filterTextBox.Text.Equals(""))
            {
                filterModeLisst.AddRange(list);
            }
            else
            {
                foreach (gridvar filtr in list)
                {
                    if (tog1.IsChecked == true)
                    {
                        if ((filtr.checkNum.Contains(filterTextBox.Text) || filtr.oper.Contains(filterTextBox.Text)) && filtr.status == "Новая очередь которая стоит в очереди")
                        {
                            filterModeLisst.Add(filtr);
                        }
                    }
                    else if (tog2.IsChecked == true)
                    {
                        if ((filtr.checkNum.Contains(filterTextBox.Text) || filtr.oper.Contains(filterTextBox.Text)) && filtr.status == "В ожидание")
                        {
                            filterModeLisst.Add(filtr);
                        }
                    }
                    else if (tog3.IsChecked == true)
                    {
                        if ((filtr.checkNum.Contains(filterTextBox.Text) || filtr.oper.Contains(filterTextBox.Text)) && filtr.status == "Очередь в данное время обслуживается")
                        {
                            filterModeLisst.Add(filtr);
                        }
                    }
                    else
                    {
                        if ((filtr.checkNum.Contains(filterTextBox.Text) || filtr.oper.Contains(filterTextBox.Text)))
                        {
                            filterModeLisst.Add(filtr);
                        }
                    }
                }
            }
            dataGrid.ItemsSource = filterModeLisst.ToList();
        }
        #endregion

        #region Filtr2

        List<gridvar> filterModeList = new List<gridvar>();

        private void filterTextBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
            filterModeList.Clear();

            if (FiltrTextBox2.Text.Equals(""))
            {
                filterModeList.AddRange(listDt2);
            }
            else
            {
                foreach (gridvar filtr in listDt2)
                {
                    if (filtr.checkNum.Contains(FiltrTextBox2.Text) || filtr.oper.Contains(FiltrTextBox2.Text) || filtr.window.Contains(FiltrTextBox2.Text))
                    {
                        filterModeList.Add(filtr);
                    }
                }
            }
            dataGrid2.ItemsSource = filterModeList.ToList();
        }
        #endregion

        #region ToggleButtonLogic

        private void ToggleButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            tog1.IsChecked = true;
            if (list0.Count > 0)
            {
                dataGrid.ItemsSource = list0;
            }
            else
            {
                dataGrid.ItemsSource = new List<gridvar>();
                list0.Clear();
                dataBase = new Base();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            list0.Add(new gridvar
                            {
                                id = db.Rows[i][0].ToString(),
                                checkNum = db.Rows[i][1].ToString(),
                                status = db.Rows[i][2].ToString(),
                                uslugvid = db.Rows[i][3].ToString(),
                                window = db.Rows[i][4] != DBNull.Value ? db.Rows[i][4].ToString() : "",
                                oper = db.Rows[i][5] != DBNull.Value ? db.Rows[i][5].ToString() : "",
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = db.Rows[i][7] != DBNull.Value ? Convert.ToDateTime(db.Rows[i][7]) : DateTime.MinValue
                            });
                        }
                        list = list0;
                        dataGrid.ItemsSource = list;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT g.`desc` FROM turns_status AS g WHERE g.name = t.`status`) AS `status`, (SELECT s.name FROM services AS s WHERE s.id = t.service_id) AS ser_nam, 'Нет','Нет', t.created_at, t.updated_at FROM `rskbank`.`turns` AS t WHERE CURRENT_DATE()< t.created_at and t.status ='new'");
                filterTextBox.Text = String.Empty;
            }

        }
        private void ToggleButton_Click1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            tog2.IsChecked = true;
            if (list1.Count > 0)
            {
                dataGrid.ItemsSource = list1;
            }
            else
            {
                dataGrid.ItemsSource = new List<gridvar>();
                list1.Clear();
                dataBase = new Base();
                dataBase.del += db => 
                {
                    if (db.Rows.Count > 0)
                    {
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            list1.Add(new gridvar
                            {
                                id = db.Rows[i][0].ToString(),
                                checkNum = db.Rows[i][1].ToString(),
                                status = db.Rows[i][2].ToString(),
                                uslugvid = db.Rows[i][3].ToString(),
                                window = db.Rows[i][4].ToString(),
                                oper = db.Rows[i][5].ToString(),
                                start = Convert.ToDateTime(db.Rows[i][6]).Date,
                                end = Convert.ToDateTime(db.Rows[i][7]).Date
                            });
                        }
                        list = list1;
                        dataGrid.ItemsSource = list;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT g.`desc` FROM turns_status AS g WHERE g.name = t.`status`) AS `status`, (SELECT s.name FROM services AS s WHERE s.id = t.service_id) AS ser_nam, (SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam, (SELECT gg.name_u FROM users AS gg WHERE gg.id = t.user_id) AS nam_u, t.created_at, t.updated_at FROM `rskbank`.`turns` AS t WHERE CURRENT_DATE()< t.created_at and t.status ='waiting'");
                filterTextBox.Text = String.Empty;
            }
        }
        private void ToggleButton_Click2(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            tog3.IsChecked = true;
            if (list2.Count > 0)
            {
                dataGrid.ItemsSource = list2;
            }
            else
            {
                dataGrid.ItemsSource = new List<gridvar>();
                list2.Clear();
                dataBase = new Base();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            list2.Add(new gridvar
                            {
                                id = db.Rows[i][0].ToString(),
                                checkNum = db.Rows[i][1].ToString(),
                                status = db.Rows[i][2].ToString(),
                                uslugvid = db.Rows[i][3].ToString(),
                                window = db.Rows[i][4].ToString(),
                                oper = db.Rows[i][5].ToString(),
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = Convert.ToDateTime(db.Rows[i][7])
                            });
                        }
                        list = list2;
                        dataGrid.ItemsSource = list;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT g.`desc` FROM turns_status AS g WHERE g.name = t.`status`) AS `status`, (SELECT s.name FROM services AS s WHERE s.id = t.service_id) AS ser_nam, (SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam, (SELECT gg.name_u FROM users AS gg WHERE gg.id = t.user_id) AS nam_u, t.created_at, t.updated_at FROM `rskbank`.`turns` AS t WHERE CURRENT_DATE()< t.created_at and t.status ='served'");
                filterTextBox.Text = String.Empty;
            }
        }
        private void tog1_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            dataGrid.ItemsSource = Mainlist;
            filterTextBox.Text = String.Empty;

        }
        private void tog1_Unchecked1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            dataGrid.ItemsSource = Mainlist;
            filterTextBox.Text = String.Empty;
        }
        private void tog1_Unchecked2(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            dataGrid.ItemsSource = Mainlist;
            filterTextBox.Text = String.Empty;
        }

        #endregion

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            OperComBox.SelectedItem = null;
            UslugComBox.SelectedItem = null;
            dataPicker.SelectedDate = DateTime.Today;
            UpdateData2();
            FiltrTextBox2.Text = String.Empty;
        }

        #region Быстрое изменение

        private void OperComBox_DropDownClosed(object sender, EventArgs e)
        {
            if (OperComBox.Text != String.Empty)
            {
                if (OperComBox.SelectedItem != null)
                {
                    dataBase = new Base();
                    returnedOper = dataBase.ReturnID("select id from users where name_u = '" + OperComBox.SelectedValue.ToString() + "'");
                }
                dataGrid2.ItemsSource = new List<gridvar>();
                listOper.Clear();
                dataBase = new Base();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            listOper.Add(new gridvar
                            {
                                id = db.Rows[i][0].ToString(),
                                checkNum = db.Rows[i][1].ToString(),
                                status = db.Rows[i][2].ToString(),
                                uslugvid = db.Rows[i][3].ToString(),
                                window = db.Rows[i][4] != DBNull.Value ? db.Rows[i][4].ToString() : "",
                                oper = db.Rows[i][5] != DBNull.Value ? db.Rows[i][5].ToString() : "",
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = Convert.ToDateTime(db.Rows[i][7])
                            });
                        }
                        listDt2 = listOper;
                        dataGrid2.ItemsSource = listDt2;
                    }
                };
                if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + " AND t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
                }
                else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE user_id = " + returnedOper + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE service_id = " + returnedUslug + " and t.user_id = " + returnedOper + "");
                }
                else
                {
                    MessageBox.Show("Неправильный запрос");
                }
            }
        }

        private void DatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            dataGrid2.ItemsSource = new List<gridvar>();
            lister.Clear();
            dataBase = new Base();
            dataBase.del += db =>
            {
                if (db.Rows.Count > 0)
                {
                    for (int i = 0; i < db.Rows.Count; i++)
                    {
                        lister.Add(new gridvar
                        {
                            id = db.Rows[i][0].ToString(),
                            checkNum = db.Rows[i][1].ToString(),
                            status = db.Rows[i][2].ToString(),
                            uslugvid = db.Rows[i][3].ToString(),
                            window = db.Rows[i][4].ToString(),
                            oper = db.Rows[i][5].ToString(),
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = Convert.ToDateTime(db.Rows[i][7])
                        });
                    }
                    listDt2 = lister;
                    dataGrid2.ItemsSource = listDt2;
                }
            };
            if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + " AND t.service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE t.service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE service_id = " + returnedUslug + " and t.user_id = " + returnedOper + "");
            }
            else
            {
                MessageBox.Show("Неправильный запрос");
            }

        }

        private void UslugComBox_DropDownClosed(object sender, EventArgs e)
        {
            if (UslugComBox.Text != String.Empty)
            {
                if (UslugComBox.SelectedItem != null)
                {
                    dataBase = new Base();
                    returnedUslug = dataBase.ReturnID("select id from services where name = '" + UslugComBox.SelectedValue.ToString() + "'");
                }
                dataGrid2.ItemsSource = new List<gridvar>();
                listUslug.Clear();
                dataBase = new Base();
                dataBase.del += db =>
                {
                    if (db.Rows.Count > 0)
                    {
                        for (int i = 0; i < db.Rows.Count; i++)
                        {
                            listUslug.Add(new gridvar
                            {
                                id = db.Rows[i][0].ToString(),
                                checkNum = db.Rows[i][1].ToString(),
                                status = db.Rows[i][2].ToString(),
                                uslugvid = db.Rows[i][3].ToString(),
                                window = db.Rows[i][4].ToString(),
                                oper = db.Rows[i][5].ToString(),
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = Convert.ToDateTime(db.Rows[i][7])
                            });
                        }
                        listDt2 = listUslug;
                        dataGrid2.ItemsSource = listDt2;
                    }
                };
                if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + " AND t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.user_id = " + returnedOper + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
                }
                else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE user_id = " + returnedOper + "");
                }
                else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE t.service_id = " + returnedUslug + "");
                }
                else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
                {
                    dataBase.SoursData("SELECT t.id,t.nomer,(SELECT ts.`desc` FROM turns_status AS ts WHERE ts.name = t.`status`) as `status`,s.name,(SELECT g.window_nomer FROM workplaces AS g WHERE g.id = t.workplace_id) AS nam,u.name_u,DATE_FORMAT(t.created_at,'%Y-%m-%d  %h:%i:%s'),DATE_FORMAT(t.updated_at,'%Y-%m-%d  %h:%i:%s') from turns AS t INNER JOIN users AS u ON t.user_id =u.id INNER JOIN services AS s ON s.id = t.service_id  WHERE service_id = " + returnedUslug + " and t.user_id = " + returnedOper + "");
                }
                else
                {
                    MessageBox.Show("Неправильный запрос");
                }
            }
        }
        #endregion      

        #region comBoxBinding with database

        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {
                UslugComBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name FROM services");
        }
        public void UpdateComboBoxPosition()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (List<string> db)
            {

                OperComBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name_u FROM users ");
        }

        #endregion

        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            {
                Tab1.Header = "Поток клиентов";
                Tab2.Header = "Список клиентов";
                Tdate.Text = "Поиск по дате";
                Namework.Text = "Имя работника";
                Otdel.Text = "Отдел";
                Defult1.Content = "Нормальное явление";
                SearchT.Text = "Поиск по номеру";
                FiltrTextBox2.Tag = "Поиск по номеру";
                //-------------------------------------------------
                name_chek.Header = "Номер чека";
                name_status.Header = "Статус";
                name_usluga.Header = "Тип услуги";
                name_tereze.Header = "Окно";
                name_operator.Header = "Опеоратор";
                name_ochered_algan.Header = "Очеред алган убакты";
                name_ochered_butkon.Header = "Очереди буткон убакты";
                //-------------------------------------------------
                nam_chek.Header = "Номер чека";
                nam_status.Header = "Статус";
                nam_usluga.Header = "Тип услуги";
                nam_window.Header = "Терезе";
                nam_operator.Header = "Опеоратор";
                nam_ochered_algan.Header = "Кезекке турган убак";
                nam_ochered_butkon.Header = "Очередь окончена";
                Search2.Text = "Поиск по номеру";
                Ochered.Text = "Те в очереди";
                Ochered1.Text = "Те, кто ждут";
                Ochered2.Text = "Те кто встречался с оператором";
            }
            else if (staticClaseForLangue.Lang == "KG")
            {
                Tab1.Header = "Клиенттер агымы";
                Tab2.Header = "Клиенттер тизмеси";
                Tdate.Text = "Датасы менен издөө";
                Namework.Text = "Жумушчунун аты";
                Otdel.Text = "Бөлүм";
                Defult1.Content = "Адаттагыдай көрүү";
                SearchT.Text = "Номери боюнча издөө";
                FiltrTextBox2.Tag= "Номери боюнча издөө";
                //-------------------------------------------------
                name_chek.Header = "Чектин номери";
                name_status.Header = "Статусу";
                name_usluga.Header = "Услуганын туру";
                name_tereze.Header = "Терезе";
                name_operator.Header = "Опеоратор";
                name_ochered_algan.Header = "Очеред алган убакты";
                name_ochered_butkon.Header = "Очереди буткон убакты";
                //-------------------------------------------------
                nam_chek.Header = "Чектин номери";
                nam_status.Header = "Статусу";
                nam_usluga.Header = "Услуганын туру";
                nam_window.Header = "Терезе";
                nam_operator.Header = "Опеоратор";
                nam_ochered_algan.Header = "Очеред алган убакты";
                nam_ochered_butkon.Header = "Очереди буткон убакты";
                Search2.Text = "Номери боюнча издөө";
                Ochered.Text = "Очереттегилер";
                Ochered1.Text = "Күтүп тургандар";
                Ochered2.Text = "Операторго жолуккандар";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                Tab1.Header = "Customer flow";
                Tab2.Header = "Customer list";
                Tdate.Text = "Датасы менен издөө";
                Namework.Text = "Search by date";
                Otdel.Text = "Section";
                Defult1.Content = "Normal vision";
                SearchT.Text = "Search by number";
                FiltrTextBox2.Tag = "Search by number";
                //-------------------------------------------------
                name_chek.Header = "Check number";
                name_status.Header = "Status";
                name_usluga.Header = "The type of service";
                name_tereze.Header = "Window";
                name_operator.Header = "Operator";
                name_ochered_algan.Header = "Time to get in line";
                name_ochered_butkon.Header = "It's time to dump her";
                //-------------------------------------------------
                nam_chek.Header = "Check number";
                nam_status.Header = "Status";
                nam_usluga.Header = "The type of service";
                nam_window.Header = "Window";
                nam_operator.Header = "Operator";
                nam_ochered_algan.Header = "Time to get in line";
                nam_ochered_butkon.Header = "It's time to dump her";
                Search2.Text = "Search by number";
                Ochered.Text = "Those in the queue";
                Ochered1.Text = "Those who are waiting";
                Ochered2.Text = "Those who met the operator";
            }
        }
    }
}
