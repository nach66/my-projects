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
    /// Interaction logic for showGames.xaml
    /// </summary>
    public partial class showGames : Window
    {
        public showGames()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Games
                           orderby m.Date
                           select new
                           {
                               Date = m.Date,
                               Player_Name1 = m.Player_Name1,
                               Player_Name2 = m.Player_Name2,
                               Player1_score = m.Player1_score,
                               Player2_score = m.Player2_score,
                               Winner = m.Winner
                           };
                gamesgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Games
                           orderby m.Player_Name1
                           select new
                           {
                               Date = m.Date,
                               Player_Name1 = m.Player_Name1,
                               Player_Name2 = m.Player_Name2,
                               Player1_score = m.Player1_score,
                               Player2_score = m.Player2_score,
                               Winner = m.Winner
                           };
                gamesgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Games
                           orderby m.Player_Name2
                           select new
                           {
                               Date = m.Date,
                               Player_Name1 = m.Player_Name1,
                               Player_Name2 = m.Player_Name2,
                               Player1_score = m.Player1_score,
                               Player2_score = m.Player2_score,
                               Winner = m.Winner
                           };
                gamesgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Games
                           orderby m.Winner
                           select new
                           {
                               Date = m.Date,
                               Player_Name1 = m.Player_Name1,
                               Player_Name2 = m.Player_Name2,
                               Player1_score = m.Player1_score,
                               Player2_score = m.Player2_score,
                               Winner = m.Winner
                           };
                gamesgrid.ItemsSource = glob.ToList();
            }
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Games
                           orderby m.Date
                           select new
                           {
                               Date = m.Date,
                               Player_Name1 = m.Player_Name1,
                               Player_Name2 = m.Player_Name2,
                               Player1_score = m.Player1_score,
                               Player2_score = m.Player2_score,
                               Winner = m.Winner
                           };
                gamesgrid.ItemsSource = glob.ToList();
            }
        }
    }
}
