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
    /// Interaction logic for reg.xaml
    /// </summary>
    public partial class reg : Window
    {
        public reg()
        {
            InitializeComponent();
        }
        public Player A { get; set; } = null;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbfName.Text)
                && !string.IsNullOrEmpty(tbpas.Text))
            {
                try
                {
                    using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                    {
                        var acto = from g in ctx.Players
                                   select g.UserName;
                        List<string> uo = acto.ToList();
                        if (uo.Contains(tbfName.Text.Trim()))
                            throw new DoubleException();
                    }
                    A = new Player
                    {
                        UserName = tbfName.Text.Trim(),
                        Password = tbpas.Text.Trim(),
                        Wins = 0,
                        Losses = 0,
                        Ties = 0,
                        Percentage = 0,
                        Participated_Games = 0
                    };
                }
                catch (DoubleException)
                {
                    MessageBox.Show("item with this name already exists", " ",
                                    MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                catch (FormatException)
                {
                    MessageBox.Show("מחרוזת קלט לא הייתה בתבנית הנכונה",
                                   "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }               

                this.Close();
            }

            else
                MessageBox.Show("You must fill all the fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
