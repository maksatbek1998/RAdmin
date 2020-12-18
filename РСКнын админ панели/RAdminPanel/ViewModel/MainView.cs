﻿using RAdminPanel.ViewModel.Models;
using RAdminPanel.ViewModel.BaseView;
using System.Windows.Input;
using System;

namespace RAdminPanel.ViewModel
{
    internal class MainView : BaseView.BaseView
    {
        #region Commands

        public ICommand ToRu { get; set; }
        public ICommand ToKg { get; set; }
        public ICommand ToEn { get; set; }

        #endregion

        #region Языки

        private string _Filial = "Филиалы";
        public string Filial
        {
            get => _Filial;
            set => Set(ref _Filial, value);
        }

        private string _Block = "Блокировка";
        public string Block
        {
            get => _Block;
            set => Set(ref _Block, value);
        }

        private string _Auto = "Автовызов";
        public string Auto
        {
            get => _Auto;
            set => Set(ref _Auto, value);
        }

        private string _Operators = "Операторы";
        public string Operators
        {
            get => _Operators;
            set => Set(ref _Operators, value);
        }

        private string _Otdels = "Отделы";
        public string Otdels
        {
            get => _Otdels;
            set => Set(ref _Otdels, value);
        }

        private string _WorkPlace = "Рабочие места" ;
        public string WorkPlace
        {
            get => _WorkPlace;
            set => Set(ref _WorkPlace, value);
        }

        private string _Raspisanie = "Управление расписанием";
        public string Raspisanie
        {
            get => _Raspisanie;
            set => Set(ref _Raspisanie, value);
        }

        private string _TerminalSetting = "Настройки терминала";
        public string TerminalSetting
        {
            get => _TerminalSetting;
            set => Set(ref _TerminalSetting, value);
        }

        private string _Clients = "Клиенты";
        public string Clients
        {
            get => _Clients;
            set => Set(ref _Clients, value);
        }

        private string _LangSetting = "Настройки языков";
        public string LangSetting
        {
            get => _LangSetting;
            set => Set(ref _LangSetting, value);
        }

        private string _SoundSetting = "Настройки звуков";
        public string SoundSetting
        {
            get => _SoundSetting;
            set => Set(ref _SoundSetting, value);
        }

        private string _BranchName = "Название филиала";
        public string BranchName
        {
            get => _BranchName;
            set => Set(ref _BranchName, value);
        }

        private string _BranchAdres = "Адрес филиала";
        public string BranchAdres
        {
            get => _BranchAdres;
            set => Set(ref _BranchAdres, value);
        }

        private string _CreatedTime = "Дата создания";
        public string CreatedTime
        {
            get => _CreatedTime;
            set => Set(ref _CreatedTime, value);
        }

        private string _Delete = "Удалить";
        public string Delete
        {
            get => _Delete;
            set => Set(ref _Delete, value);
        }

        private string _Save = "Сохранить";
        public string Save
        {
            get => _Save;
            set => Set(ref _Save, value);
        }

        #endregion

        public MainView()
        {
            #region Реализация Комманд
            ToEn = new ViewCommand(new Action<object>(ToEng));
            ToRu = new ViewCommand(new Action<object>(ToRus));
            ToKg = new ViewCommand(new Action<object>(ToKgr));
            #endregion
        }

        #region Методы Изменение языков

        private void ToKgr(object obj)
        {
            Filial = "Филиалдар";
            Operators = "Операторлор";
            Otdels = "Бөлүмдөр";
            WorkPlace = "Иш орундары";
            Raspisanie = "Расписаниени башкаруу";
            TerminalSetting = "Терминал жөндөөсү";
            Clients = "Кардарлар";
            LangSetting = "Тил жөндөөсү";
            SoundSetting = "Үндөрдү орнотуу";
            BranchAdres = "Филиалдын адреси";            
            CreatedTime = "Түзүлгөн күнү";
            Delete = "Очүрүү";
            Save = "Сактоо";
            BranchName = "Филиалдын аты";
            Auto = "АвтоЧакыруу";
            Block = "Бекитүү";

        }

        private void ToRus(object obj)
        {
            Filial = "Филиалы";
            Operators = "Операторы";
            Otdels = "Отделы";
            WorkPlace = "Рабочие места";
            Raspisanie = "Управление расписанием";
            TerminalSetting = "Настройки терминала";
            Clients = "Клиенты";
            LangSetting = "Настройки языков";
            SoundSetting = "Настройки звуков";
            BranchAdres = "Адрес филиала";
            CreatedTime = "Дата создание";
            Delete = "Удалить";
            Save = "Сохранить";
            BranchName = "Название филиала";
            Auto = "АвтоВызов";
            Block = "Блокировка";
        }

        private void ToEng(object obj)
        {
            Filial = "Branches";
            Operators = "Operators";
            Otdels = "Departments";
            WorkPlace = "Workplaces";
            Raspisanie = "Schedule management";
            TerminalSetting = "Terminal settings";
            Clients = "Сlients";
            LangSetting = "Languages settings";
            SoundSetting = "Sounds settings";
            BranchAdres = "Branches address";
            CreatedTime = "Created date";
            Delete = "Delete";
            Save = "Save";
            BranchName = "Baranches name";
            Auto = "Auto";
            Block = "Block";
        }

        #endregion

    }
}
