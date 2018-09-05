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
    /// Interaction logic for showplayers.xaml
    /// </summary>
    public partial class showplayers : Window
    {
        public showplayers()
        {
            InitializeComponent();
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (sweepers_DBEntities ctx = new sweepers_DBEntities())
            {
                var glob = from m in ctx.Players
                           orderby m.UserName
                           select new
                           {
                                   UserName = m.UserName,
                                   Wins = m.Wins,
                                   Losses = m.Losses,
                                   Ties = m.Ties,
                                   Percentage = m.Percentage.ToString(),
                                   Participated_Games = m.Participated_Games
                           };
                playersgrid.ItemsSource = glob.ToList();
            }
        }

        

    }
}
