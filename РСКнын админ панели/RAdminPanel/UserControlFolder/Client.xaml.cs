using RAdminPanel.ClassUserControl;
using RAdminPanel.DataBase;
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

        static  int returnedOper;

        static int returnedUslug;

        #region List
        List<gridvar> list = new List<gridvar>();
        List<gridvar> lister = new List<gridvar>();
        List<gridvar> listDt2 = new List<gridvar>();
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
                            window = db.Rows[i][4].ToString(),
                            oper = db.Rows[i][5].ToString(),
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = Convert.ToDateTime(db.Rows[i][7])
                        });
                    }
                    dataGrid.ItemsSource = list;
                }
            };
            dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') ='" + DateTime.Now.ToString("dd.MM.yyyy") + "'");
        }

        public void UpdateData2()
        {
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
                            window = db.Rows[i][4].ToString(),
                            oper = db.Rows[i][5].ToString(),
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = Convert.ToDateTime(db.Rows[i][7])
                        });
                    }
                    dataGrid2.ItemsSource = listDt2;
                }
            };
            dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') ='" + DateTime.Now.ToString("dd.MM.yyyy") + "'");
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
                    if (filtr.checkNum.Contains(filterTextBox.Text))
                    {
                        filterModeLisst.Add(filtr);
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
                    if (filtr.checkNum.Contains(FiltrTextBox2.Text))
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
                                window = db.Rows[i][4].ToString(),
                                oper = db.Rows[i][5].ToString(),
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = Convert.ToDateTime(db.Rows[i][7])
                            });
                        }
                        dataGrid.ItemsSource = list0;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') ='" + DateTime.Now.ToString("dd.MM.yyyy") + "' and status = 1");
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
                                start = Convert.ToDateTime(db.Rows[i][6]),
                                end = Convert.ToDateTime(db.Rows[i][7])
                            });
                        }
                        dataGrid.ItemsSource = list1;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') ='" + DateTime.Now.ToString("dd.MM.yyyy") + "' and status = 2"); 
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
                        dataGrid.ItemsSource = list2;
                    }
                };
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') ='" + DateTime.Now.ToString("dd.MM.yyyy") + "' and status = 3");
            }
        }
        private void tog1_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            dataGrid.ItemsSource = list;

        }
        private void tog1_Unchecked1(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            if (tog3.IsChecked == true) tog3.IsChecked = false;
            dataGrid.ItemsSource = list;
        }
        private void tog1_Unchecked2(object sender, System.Windows.RoutedEventArgs e)
        {
            if (tog2.IsChecked == true) tog2.IsChecked = false;
            if (tog1.IsChecked == true) tog1.IsChecked = false;
            dataGrid.ItemsSource = list;
        }

        #endregion     
       
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
                OperComBox.SelectedItem = null;
                UslugComBox.SelectedItem = null;
                dataPicker.SelectedDate = DateTime.Today;
                dataGrid2.ItemsSource = listDt2;           
        }

        #region Быстрое изменение Не доработано

        private void OperComBox_DropDownClosed(object sender, EventArgs e)
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
                            window = db.Rows[i][4].ToString(),
                            oper = db.Rows[i][5].ToString(),
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = Convert.ToDateTime(db.Rows[i][7])
                        });
                    }
                    dataGrid2.ItemsSource = listOper;
                }
            };
            if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + " AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + " and user_id = " + returnedOper + "");
            }
            else
            {
                MessageBox.Show("Неправильный запрос");
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
                    dataGrid2.ItemsSource = lister;
                }
            };
            if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + " AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + " and user_id = " + returnedOper + "");
            }
            else
            {
                MessageBox.Show("Неправильный запрос");
            }

        }

        private void UslugComBox_DropDownClosed(object sender, EventArgs e)
        {
            if (UslugComBox.SelectedItem != null)
            {
                dataBase = new Base();
                returnedUslug = dataBase.ReturnID("select id from position where name_p = '" + UslugComBox.SelectedValue.ToString() + "'");
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
                    dataGrid2.ItemsSource = listUslug;
                }
            };
            if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + " AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + " and user_id = " + returnedOper + "");
            }
            else
            {
                MessageBox.Show("Неправильный запрос");
            }
        }
        #endregion

        #region Search

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
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
                            window = db.Rows[i][4].ToString(),
                            oper = db.Rows[i][5].ToString(),
                            start = Convert.ToDateTime(db.Rows[i][6]),
                            end = Convert.ToDateTime(db.Rows[i][7])
                        });
                    }
                    dataGrid2.ItemsSource = listOper;
                }
            };
            if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " +returnedOper + " AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "'");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text == "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE user_id = " + returnedOper + "");
            }
            else if (dataPicker.Text != "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE DATE_FORMAT(t.created_at,'%d.%m.%Y') = '" + dataPicker.Text + "' AND service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text == "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + "");
            }
            else if (dataPicker.Text == "" && OperComBox.Text != "" && UslugComBox.Text != "")
            {
                dataBase.SoursData("SELECT t.id,t.nomer,t.`status`,p.name_p,w.windowName,u.name_u,t.created_at,t.updated_at from turns AS t JOIN users AS u ON t.user_id = u.id INNER JOIN position AS p ON t.service_id = p.id INNER JOIN workplaces AS w ON t.workplace_id = w.id  WHERE service_id = " + returnedUslug + " and user_id = " + returnedOper + "");
            }
            else
            {
                MessageBox.Show("Неправильный запрос");
            }
        }
        #endregion

        #region comBoxBinding with database

        public void UpdateComboBoxBranch()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (string[] db)
            {
                UslugComBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name_p FROM position");
        }
        public void UpdateComboBoxPosition()
        {
            dataBase = new Base();
            dataBase.eventDysplay2 += delegate (string[] db)
            {
               
                OperComBox.ItemsSource = db;
            };
            dataBase.Display("SELECT name_u FROM users ");
        }

        #endregion

    }
}
