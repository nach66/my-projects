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
//using Minesweeper;
using MinesClient.ServiceReference1;
using System.ServiceModel;

namespace MinesClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private Minesweeper.Game game;
        string username;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tbfName.Text)
                && !string.IsNullOrEmpty(tbpas.Text))
            {
                using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                {
                    var acto = from g in ctx.Players
                               where g.UserName.Equals(tbfName.Text.Trim()) && g.Password.Equals(tbpas.Text.Trim())
                               select g.UserName;

                    List<string> uo = acto.ToList();
                    if (!uo.Contains(tbfName.Text.Trim()))
                    {
                        MessageBox.Show("You are not registered yet!",
                              "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    username = tbfName.Text.Trim();
                }
                ConnectToServer();
 //               (new chooseTypeOfGame(username)).Show();
            }
            else
                MessageBox.Show("You must fill all the fields!", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void ConnectToServer()
        {
            ClientCallback callback = new ClientCallback();
            try
            {
                GameServiceClient client = new GameServiceClient(
                        new InstanceContext(callback));
                username = tbfName.Text.Trim();
                client.ClientConnected(username);

                ChatWindow mainWindow = new ChatWindow();
                mainWindow.Client = client;
                mainWindow.Callback = callback;
                mainWindow.Username = username;
                mainWindow.Title = username;
                this.Close();
                mainWindow.Show();
            }
//            catch (FaultException<UserExistsFault> ex)
            catch (FaultException ex)
            {

                MessageBox.Show("this user already connected!",
                      "Error", MessageBoxButton.OK, MessageBoxImage.Error);
//                MessageBox.Show(ex.Detail.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            reg window = new reg();
            window.ShowDialog();
            if (window.A != null)
            {
                using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                {
                    ctx.Players.Add(window.A);
                    ctx.SaveChanges();
                }
            }
        }
    }
}