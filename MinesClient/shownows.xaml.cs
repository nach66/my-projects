using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace MinesClient
{
    /// <summary>
    /// Interaction logic for shownows.xaml
    /// </summary>
    public partial class shownows : Window
    {
        public shownows()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (sweeper_DBEntities ctx = new sweeper_DBEntities())
            {
                var glob = from m in ctx.rightNowGames
                           select new
                           {
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Time = m.Time
                           };
                nsgrid.ItemsSource = glob.ToList();
            }
        }
    }
}
