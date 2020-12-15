using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RAdminPanel.ViewModel.Models;
using RAdminPanel.DataBase;
using System.Windows.Data;
using RAdminPanel.ClassUserControl;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace RAdminPanel.ViewModel
{
   internal class MainView : BaseView.BaseView
    {
        Base dataBase;
        private ObservableCollection<GridVariables> _GridVar = new ObservableCollection<GridVariables>();
        public ObservableCollection<GridVariables> GridVar 
        {
            get => _GridVar;
            set => Set(ref _GridVar, value);
        }

        private GridVariables _ComboItem;
        public GridVariables ComboItem
        {
            get => _ComboItem;
            set => Set(ref _ComboItem, value);
        }
        public MainView()
        {

        }
    }
}
