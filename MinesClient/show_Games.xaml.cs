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
    /// Interaction logic for show_Games.xaml
    /// </summary>
    public partial class show_Games : Window
    {
        public show_Games()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (sweeper_DBEntities ctx = new sweeper_DBEntities())
            {
                var glob = from m in ctx.Games
                           select new
                           {
                               Date = m.Date,
                               UserName1 = m.UserName1,
                               UserName2 = m.UserName2,
                               Winner = m.Winner
                           };
                gsgrid.ItemsSource = glob.ToList();
            }
        }       
    }
}
