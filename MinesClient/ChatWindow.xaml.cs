using MinesClient.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
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
    /// Interaction logic for ChatWindow.xaml
    /// </summary>
    public partial class ChatWindow : Window
    {
        public ChatWindow()
        {
           
            InitializeComponent();
        }
        MinesClient.GameForm game1;
        MinesClient.GameForm game2;
        public GameServiceClient Client;
        public ClientCallback Callback;
        public string Username;
        List<string> usernames;
        bool isLoggedOut = false;
       

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItems.Count == 0)
            {
                MessageBox.Show("You must select users to send to");
                return;
            }
            string username = lbUsers.SelectedItem.ToString();
            usernames = new List<string>();

            foreach (var item in lbUsers.SelectedItems)
            {
                usernames.Add(item as string);
            }
            if (username.Equals(Username))
            {
                MessageBox.Show("You cannot select yourself");
                return;
            }
            string msg = "play";
            Client.SendMessage(new MessageInfo
            {
                Message = msg,
                FromCLient = Username,
                ToClients = usernames
            });
        }

        private void PutMessage(string message, string fromClient)
        {
            if (message == "play")
            {
                openMessageBox(fromClient);
            }

            else if (message == "accept")
            {
                game1 = new MinesClient.GameForm(1, Username, fromClient);
                game1.Show();
            }
            else if (message.Contains("bye"))
            {
                if (message.Contains("1"))
                    game2.getBye();
                else if (message.Contains("2"))
                    game1.getBye();

                MessageBox.Show("oy, your friend is gone. you win! and lose your friend");
            }
            else if (message == "reject") { }
            else if (message.Contains("add to list")) { }
            else if (message.Contains("remove from list")) { }
            else
            {
                GameState gg = GameState.StringToObject(message);

                if (gg.isaMap())
                {
                    game2.GetMap(gg);
                }

                else
                {
                    if (gg.pl_num == 1)
                        game2.GetMove(gg);
                    else
                        game1.GetMove(gg);
                }
            }
        }

        private void openMessageBox(string fromClient)
        {
            string messageBoxText = Username + " Do you want to play with " + fromClient + " ";
            string caption = "Play request";
            MessageBoxButton button = MessageBoxButton.YesNo;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption, button, icon);

            List<string> challengingUser = new List<string>();
            challengingUser.Add(fromClient);
            // Process message box results
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Client.SendMessage(new MessageInfo
                    {
                        Message = "accept",
                        FromCLient = Username,
                        ToClients = challengingUser
                    });
                    game2 = new MinesClient.GameForm(2, Username, fromClient);
                    game2.Show();

                    break;
                case MessageBoxResult.No:
                    Client.SendMessage(new MessageInfo
                    {
                        Message = "reject",
                        FromCLient = Username,
                        ToClients = challengingUser
                    });
                    break;
            }
        }

        private void UpdateClients(List<string> clients)
        {
            lbUsers.ItemsSource = clients;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Callback.updateClients += UpdateClients;
            Callback.putMessage += PutMessage;
        }

       

        private void alone_Click(object sender, RoutedEventArgs e)
        {
            new MinesClient.GameForm(0, Username, Username).Show();
        }

        private void player_search(object sender, RoutedEventArgs e)
        {
            showplayers window = new showplayers();
            window.ShowDialog();
        }

        private void game_search(object sender, RoutedEventArgs e)
        {
            showGames window = new showGames();
            window.ShowDialog();
        }

        private void now_search(object sender, RoutedEventArgs e)
        {
            nowplayers window = new nowplayers();
            window.ShowDialog();
        }

        private void info_click(object sender, RoutedEventArgs e)
        {
            if (lbUsers.SelectedItems.Count != 0)
            {
                string user = lbUsers.SelectedItem.ToString();
                using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                {
                    Player f = (from m in ctx.Players
                                where user.Equals(m.UserName)
                                select m).First();

                    MessageBox.Show(f.UserName+" have a " 
                        + f.Percentage+"% winning, and "
                        +f.Ties+" ties, in "+
                        f.Participated_Games+" games that he played");
                }
            }
            else
                MessageBox.Show("You must select users");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!isLoggedOut)
            {
                ClientCallback callback = new ClientCallback();
                try
                {
                    GameServiceClient client = new GameServiceClient(
                            new InstanceContext(callback));
                    client.ClientDisconnected(Username);               
                }
                catch (FaultException<UserExistsFault> ex)
                {
                    MessageBox.Show(ex.Detail.Message);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                Environment.Exit(Environment.ExitCode);
            }       
        }
        private void Logout_Click(object sender, RoutedEventArgs e) //loguot
        {
            isLoggedOut = true;
            ClientCallback callback = new ClientCallback();
            try
            {
                GameServiceClient client = new GameServiceClient(
                        new InstanceContext(callback));
                client.ClientDisconnected(Username);
                MainWindow window = new MainWindow();
                this.Close();
                window.ShowDialog();
            }
            catch (FaultException<UserExistsFault> ex)
            {
                MessageBox.Show(ex.Detail.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}