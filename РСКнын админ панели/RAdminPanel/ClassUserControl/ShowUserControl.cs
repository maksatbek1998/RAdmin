using System.Windows.Controls;

namespace RAdminPanel.ClassUserControl
{
    public static class ShowUserControl
    {
        public static void Show(Grid grd,UserControl userControl)
        {
            grd.Children.Clear();
            grd.Children.Add(userControl);
        }
    }
}
