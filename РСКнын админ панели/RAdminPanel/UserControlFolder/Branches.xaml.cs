﻿using RAdminPanel.DataBase;
using System.Data;
using System.Windows;
using System.Windows.Controls;
using RAdminPanel.ViewModel;
using System;

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
            Restart();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (FilialName.Text!=String.Empty && FilialAdress.Text != String.Empty)
            {
                Bases.RegistrToBase("INSERT INTO branches(name_b,address)VALUES ('" + FilialName.Text + "','" + FilialAdress.Text + "')");
                FilialName.Text = "";
                FilialAdress.Text = "";
                UpdateData();
            }
            else
            {

            }
        }
        public void UpdateData()
        {
            Bases.SoursDataGrid("SELECT id,name_b,address, DATE_FORMAT(created_at,'%d.%m.%Y') as 'created_at' FROM branches", ref DataList);
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
            else
            {
                MessageBox.Show("Заполните все поли!", "Внимание !", MessageBoxButton.OK);
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
        private void Restart()
        {
            if (staticClaseForLangue.Lang == "RUS")
            { 
                FilialNameT.Text= "Название филиала";
                FilialName.Tag= "Название филиала";
                FilialAdressT.Text = "Адрес филиала";
                FilialAdress.Tag = "Адрес филиала";
                FiliAddressDG.Header = "Адрес филиала";
                FiliNameDG.Header = "Название филиала";
                Save.Content = "Сохранить";
                DeleteDG.Header = "Удалить";
                CreatedDateDG.Header = "Дата создания";
            }
           else if (staticClaseForLangue.Lang == "KG")
            {
                FilialNameT.Text = "Филиалдын аты";
                FilialName.Tag = "Филиалдын аты";
                FilialAdressT.Text = "Филиалдын адреси";
                FilialAdress.Tag = "Филиалдын адреси";
                FiliAddressDG.Header = "Филиалдын адреси";
                FiliNameDG.Header = "Филиалдын аты";
                Save.Content = "Сакто";
                DeleteDG.Header = "Очуруу";
                CreatedDateDG.Header = "Тузулгон убакты";
            }
            if (staticClaseForLangue.Lang == "EN")
            {
                FilialNameT.Text = "Branches name";
                FilialName.Tag = "Branches name";
                FilialAdressT.Text = "Branches address";
                FilialAdress.Tag = "Branches address";
                FiliAddressDG.Header = "Branches address";
                FiliNameDG.Header = "Branches name";
                Save.Content = "Save";
                DeleteDG.Header = "Delete";
                CreatedDateDG.Header = "Created date";
            }
        }
        public static void Res()
        {
            Branches bra = new Branches();
            bra.Restart();
        }
    }
}
