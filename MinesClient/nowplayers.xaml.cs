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
    /// Interaction logic for nowplayers.xaml
    /// </summary>
    public partial class nowplayers : Window
    {
        public nowplayers()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.rightNowGames
                           orderby m.Time
                           select new
                           {
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Time = m.Time
                           };
                nowsgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.rightNowGames
                           orderby m.UserName1
                           select new
                           {
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Time = m.Time
                           };
                nowsgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.rightNowGames
                           orderby m.UserName2
                           select new
                           {
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Time = m.Time
                           };
                nowsgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.rightNowGames
                           orderby m.Time
                           select new
                           {
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Time = m.Time
                           };
                nowsgrid.ItemsSource = glob.ToList();
            }
        }
    }
}
