// System.Collections.Generic.List<string>
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MinesClient.ServiceReference1;
using System.ServiceModel;

namespace MinesClient
{
    public partial class GameForm : Form
    {
        string w;
        int gameProgress;
        int gameProgress_Maximum;

        int myscore = 0, escore = 0;
        public GameServiceClient Client;
        public ClientCallback Callback;
        public string me;
        List<string> enemy;
        public bool byeCount = false; 

        Button[,] btn = new Button[41, 41];
        int[,] btn_prop = new int[41, 41];
        int[,] saved_btn_prop = new int[41, 41];
        int[,] btn_prop2 = new int[41, 41];
        int[,] saved_btn_prop2 = new int[41, 41];
        Point coord;
        bool firstPlay = true;
        bool gameover = false;

        //Turns
        bool atie = false;
        bool iwin = false;
        bool myTurn;
        int player_num = 0;

        //Time
        int seconds = 0;
        int minutes = 0;

        //Points that are around
        int[] dx8 = { 1, 0, -1, 0, 1, -1, -1, 1 };
        int[] dy8 = { 0, 1, 0, -1, 1, -1, 1, -1 };

        //Table aspect
        int start_x, start_y;
        int height, width;

        //Game variables
        int mines;
        int flag_value = 10;
        int flags;

        //Button aspect
        int buttonSize = 20;
        int distance_between = 20;

        public rightNowGame B { get; set; } = null;


        public GameForm(int p_num, string m, string e)
        {
            Callback = new ClientCallback();
            Client = new GameServiceClient(
                       new InstanceContext(Callback));
            player_num = p_num;
            
            me = m;
            enemy = new List<string>();
            enemy.Add(e);

            InitializeComponent();
            this.Text = me;
        }

        public void GetMap (GameState gg)
        {
            height = gg.xh;
            width = gg.yw;
            mines = gg.mine;
            btn_prop2 = gg.btn_prop;
            saved_btn_prop2 = gg.saved_btn_prop;
            Play_Click2();
        }

        public void GetMove(GameState gg)
        {
            escore = gg.mine;
            if (gg.isaRightClick() == false)
            {
                btn[gg.xh, gg.yw].Enabled = false;
                btn[gg.xh, gg.yw].Text = "";
                btn[gg.xh, gg.yw].BackgroundImageLayout = ImageLayout.Stretch;
                
                Check_ClickWin(false);

                set_ButtonImage(gg.xh, gg.yw, false);
            }
            else
            {
                if (btn_prop[gg.xh, gg.yw] != flag_value && flags > 0)
                {
                    btn[gg.xh, gg.yw].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[gg.xh, gg.yw].BackgroundImage = MinesClient.Properties.Resources.flag;
                    btn_prop[gg.xh, gg.yw] = flag_value;
                    flags--;
                    Check_FlagWin(false);
                }
                else if (btn_prop[gg.xh, gg.yw] == flag_value)
                {
                    btn_prop[gg.xh, gg.yw] = saved_btn_prop[gg.xh, gg.yw];
                    btn[gg.xh, gg.yw].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[gg.xh, gg.yw].BackgroundImage = null;
                    flags++;
                }

                remainingFlags.Text = ": " + flags;
            }

            myTurn = true;
        }

        private void OneClick(object sender, EventArgs e)
        {
            if (myTurn == false)
            {
                return;
            }

            coord = ((Button)sender).Location;
            int x = (coord.X - start_x) / buttonSize;
            int y = (coord.Y - start_y) / buttonSize;

            if (btn_prop[x, y] != flag_value)
            {

                ((Button)sender).Enabled = false;
                ((Button)sender).Text = "";

                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (btn_prop[x, y] != -1 && !gameover)
                {
                    gameProgress++;
                    this.mscore.Text = "My Score: " + gameProgress.ToString();
                    Check_ClickWin(true);
                }

                set_ButtonImage(x, y, true);
            }

            if (player_num != 0) // if  NOT single player
            {
                myscore = gameProgress;
                GameState g = new GameState(player_num, null, null, false, x, y, false, myscore);
                string msg = GameState.ObjectToString(g);

                Client.SendMessage(new MessageInfo
                {
                    Message = msg,
                    FromCLient = me,
                    ToClients = enemy
                });

                myTurn = false;
                return;
            }
            else
                myTurn = true;
        }

        private void RightClick(object sender, MouseEventArgs e)
        {
            if (myTurn == false)
            {
                return;
            }

            if (e.Button != MouseButtons.Right)
                return;

                coord = ((Button)sender).Location;
                int x = (coord.X - start_x) / buttonSize;
                int y = (coord.Y - start_y) / buttonSize;

                if (btn_prop[x, y] != flag_value && flags > 0)
                {
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources.flag;
                    btn_prop[x, y] = flag_value;
                    flags--;
                    Check_FlagWin(true);
                }
                else
                    if (btn_prop[x, y] == flag_value)
                {
                    btn_prop[x, y] = saved_btn_prop[x, y];
                    btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    btn[x, y].BackgroundImage = null;
                    flags++;
                }

                remainingFlags.Text = ": " + flags;
            

            if (player_num != 0) // if  NOT single player
            {
                myscore = gameProgress;
                GameState g = new GameState(player_num, null, null, false, x, y, true, myscore);
                string msg = GameState.ObjectToString(g);                

                Client.SendMessage(new MessageInfo
                {
                    Message = msg,
                    FromCLient = me,
                    ToClients = enemy
                });

                myTurn = false;
                return;
            }
            else
                myTurn = true;
        }

        void StartGame()
        {
            flags = mines;
            gameover = false;

            gameProgress = 0;
            gameProgress_Maximum = height * width - mines;

            timer.Start();
            seconds = 0;
            minutes = 0;

            remainingFlags.Text = ": " + flags;
            mscore.Text = "My Score: " + 0;

            if (firstPlay)
                CreateButtons(width, height);

            GenerateMap(width, height, mines);
            SetMapNumbers(width, height);

           if (player_num == 1)
            {
                GameState g = new GameState(player_num, btn_prop, saved_btn_prop, true, 
                    height, width, false, mines);
                string msg = GameState.ObjectToString(g);

                Client.SendMessage(new MessageInfo
                {
                    Message = msg,
                    FromCLient = me,
                    ToClients = enemy
                });
            }
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (player_num == 2)
            {
                MessageBox.Show(me+" you must wait for your turn");
                return;
            }

            SetDimensions();
            TableMargins(height, width);
            myTurn = true;

            if (firstPlay)
            {
                CreateButtons(width, height);
                difficulty.Visible = false;
                label5.Visible = false;
                firstPlay = false;
            }
            else if (!firstPlay)
            {
                ResetGame(width, height);
            }

            if (player_num == 1)
            {
                B = new rightNowGame
                {
                    UserName1 = me,
                    UserName2 = enemy[0],
                    Time = DateTime.Now.ToString()
                };
                using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                {
                    ctx.rightNowGames.Add(B);
                    ctx.SaveChanges();
                }
            }
            StartGame();
        }

        private void Play_Click2()
        {
            TableMargins(height, width);
            myTurn = false;

            if (firstPlay)
            {
                CreateButtons(width, height);
                difficulty.Visible = false;
                label5.Visible = false;
                firstPlay = false;
            }
            else if (!firstPlay)
            {
                ResetGame(width, height);
            }

            flags = mines;
            gameover = false;

            gameProgress = 0;
            gameProgress_Maximum = height * width - mines;

            timer.Start();
            seconds = 0;
            minutes = 0;

            remainingFlags.Text = ": " + flags;
            mscore.Text = "My Score: " + 0;        

            btn_prop = btn_prop2;
            saved_btn_prop =saved_btn_prop2;
        }


        void SetDimensions()
        {
            switch (difficulty.Text)
            {
                case "Easy":
                    mines = 10;
                    height = 8;
                    width = 8;
                    break;

                case "Medium":
                    mines = 40;
                    height = 16;
                    width = 16;
                    break;

                case "Hard":
                    mines = 99;
                    height = 16;
                    width = 30;
                    break;

                default:
                    mines = 40;
                    height = 16;
                    width = 16;
                    break;
            }
        }

        void TableMargins(int x, int y)
        {
            start_x = (this.Size.Width - (width + 2) * distance_between) / 2;
            start_y = (this.Size.Height - (height + 2) * distance_between) / 2;
        }

        void CreateButtons(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                {
                    btn[i, j] = new Button();
                    btn[i, j].SetBounds(i * buttonSize + start_x-2, j * buttonSize + start_y-12, distance_between,
                        distance_between);
                    btn[i, j].Click += new EventHandler(OneClick);
                    btn[i, j].MouseUp += new MouseEventHandler(RightClick);                    
                        btn_prop[i, j] = 0;
                        saved_btn_prop[i, j] = 0;
                    btn[i, j].TabStop = false;
                    Controls.Add(btn[i, j]);
                }
        }

        void GenerateMap(int x, int y, int mines)
        {
            Random rand = new Random();
            List<int> coordx = new List<int>();
            List<int> coordy = new List<int>();

            while (mines > 0)
            {
                coordx.Clear();
                coordy.Clear();

                for (int i = 1; i <= x; i++)
                    for (int j = 1; j <= y; j++)
                        if (btn_prop[i, j] != -1)
                        {
                            coordx.Add(i);
                            coordy.Add(j);
                        }

                int randNum = rand.Next(0, coordx.Count);
                btn_prop[coordx[randNum], coordy[randNum]] = -1;
                saved_btn_prop[coordx[randNum], coordy[randNum]] = -1;
                mines--;
            }
        }

        void SetMapNumbers(int x, int y)
        {
            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                    if (btn_prop[i, j] != -1)
                    {
                        btn_prop[i, j] = MinesAround(i, j);
                        //Debugging
                        //btn[i, j].Text = btn_prop[i, j].ToString();
                        saved_btn_prop[i, j] = MinesAround(i, j);
                    }
        }

        void set_ButtonImage(int x, int y, bool im)
        {
            btn[x, y].Enabled = false;
            btn[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            if (gameover && btn_prop[x, y] == flag_value)
                btn_prop[x, y] = saved_btn_prop[x, y];

            if (gameover)
                timer.Stop();

            switch (btn_prop[x, y])
            {
                case 0:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources.blank;
                    EmptySpace(x, y, im);
                    break;

                case 1:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._1;
                    break;

                case 2:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._2;
                    break;

                case 3:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._3;
                    break;

                case 4:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._4;
                    break;

                case 5:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._5;
                    break;

                case 6:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._6;
                    break;

                case 7:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._7;
                    break;

                case 8:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources._8;
                    break;

                case -1:
                    btn[x, y].BackgroundImage = MinesClient.Properties.Resources.bmb;
                    if (!gameover)
                        GameOver(im);
                    break;
            }

        }
        void EmptySpace(int x, int y, bool im)
        {
            if (btn_prop[x, y] == 0)
            {
                for (int i = 0; i < 8; i++)
                {
                    int cx = x + dx8[i];
                    int cy = y + dy8[i];

                    if (isPointOnMap(cx, cy) == 1)
                        if (btn[cx, cy].Enabled == true && btn_prop[cx, cy] != -1 && !gameover)
                        {
                            if (im)
                            {
                                gameProgress++;
                                mscore.Text = "My Score: " + gameProgress.ToString();
                            }
                            set_ButtonImage(cx, cy,im);
                        }
                }
            }
        }
        void ResetGame(int x, int y)
        {
            if (!gameover)
                Update_database();

            for (int i = 1; i <= x; i++)
                for (int j = 1; j <= y; j++)
                {
                    btn[i, j].Enabled = true;
                    btn[i, j].Text = "";
                    btn[i, j].BackgroundImage = null;
                    btn_prop[i, j] = 0;
                    saved_btn_prop[i, j] = 0;
                }
            iwin = false;
            atie = false;
            gameover = false;
            wineer.Visible = false;
            lsser.Visible = false;
        }
        int MinesAround(int x, int y)
        {
            int score = 0;
            for (int i = 0; i < 8; i++)
            {
                int cx = x + dx8[i];
                int cy = y + dy8[i];

                if (isPointOnMap(cx, cy) == 1 && btn_prop[cx, cy] == -1)
                    score++;
            }
            return score;
        }
        int isPointOnMap(int x, int y)
        {
            if (x < 1 || x > width || y < 1 || y > height)
                return 0;
            return 1;
        }
        void Check_FlagWin(bool im)
        {
            bool win = true;

            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn_prop[i, j] == -1)
                        win = false;

            if (win)
            {
                WinGame(im);
            }
        }
        void Check_ClickWin(bool im)
        {
            bool win = true;
            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn[i, j].Enabled == true && saved_btn_prop[i, j] != -1)
                        win = false;

            if (win)
            {
                WinGame(im);
            }
        }

        void WinGame(bool im)
        {
            gameover = true;
            Discover_Map(im);
            gameProgress = 0;
            atie = true;
            Update_database();
            wineer.Visible = true;
            MessageBox.Show("its a tie");

        }
        void GameOver(bool im)
        {
            gameover = true;
            Discover_Map(im);
            Update_database();
            if (im)
            {
                lsser.Visible = true;
                MessageBox.Show("Game Over! u lose :(");
            }
            else
            {
                iwin = true;
                wineer.Visible = true;
                MessageBox.Show("yaaaauuh you Win!");
            }
        }
        void Discover_Map(bool im)
        {
            for (int i = 1; i <= width; i++)
                for (int j = 1; j <= height; j++)
                    if (btn[i, j].Enabled == true)
                    {
                        set_ButtonImage(i, j, im);
                    }
        }

        private void Update_database()
        {
            if (firstPlay)
                return;

            if (player_num == 1)
            {
                if (gameover)
                {
                    if (iwin)
                        w = me;
                    else
                        w = enemy[0];

                    if (atie)
                        w = "a tie";

                }
                else
                {
                    if (!byeCount) //ראשון שיוצא - מפסיד
                        w = enemy[0];
                    if (byeCount) // שני שיוצא - ניצח
                        w = me;
                }

                Game C = new Game
                {
                    Date = DateTime.Now.ToString(),
                    Player_Name1 = me,
                    Player_Name2 = enemy[0],
                    Player1_score = myscore.ToString(),
                    Player2_score = escore.ToString(),
                    Winner = w
                };

                int winn1 = 0, winn2 = 0, loss1 = 0, loss2 = 0, tiee = 0;
                if (w == me)
                {
                    winn1 = 1;
                    loss2 = 1;
                }
                if (w == enemy[0])
                {
                    winn2 = 1;
                    loss1 = 1;
                }
                if (w == "a tie")
                    tiee = 1;

                using (sweepers_DBEntities ctx = new sweepers_DBEntities())
                {
                    ctx.Games.Add(C);
                    ctx.SaveChanges();

                    rightNowGame ss = null;
                    ss = (from s in ctx.rightNowGames
                                       where s.nowId == B.nowId
                                       select s).First();
                    if (ss != null)
                    {
                        ctx.rightNowGames.Remove(ss);
                        ctx.Entry(ss).State = System.Data.Entity.EntityState.Deleted;
                        ctx.SaveChanges();
                    }

                    Player ses = (from s in ctx.Players
                                  where me.Equals(s.UserName)
                                  select s).First();

                    Player A = new Player
                    {
                        UserName = ses.UserName,
                        Password = ses.Password,
                        Wins = ses.Wins + winn1,
                        Losses = ses.Losses + loss1,
                        Ties = ses.Ties + tiee,
                        Participated_Games = ses.Participated_Games + 1,
                        Percentage = (((double)ses.Wins + (double) winn1) / (ses.Participated_Games + 1))*100
                    };
                    //A.Percentage *= 100;

                    ctx.Players.Add(A);
                    ctx.Players.Remove(ses);
                    ctx.Entry(ses).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();

                    String y = enemy[0];
                    Player ses2 = (from s in ctx.Players
                                  where y.Equals(s.UserName)
                                  select s).First();

                    Player A2 = new Player
                    {
                        UserName = ses2.UserName,
                        Password = ses2.Password,
                        Wins = ses2.Wins + winn2,
                        Losses = ses2.Losses + loss2,
                        Ties = ses2.Ties + tiee,
                        Participated_Games = ses2.Participated_Games + 1,
                        Percentage = ((double)(ses2.Wins + winn2)/ (ses2.Participated_Games + 1))*100
                    };
                    ctx.Players.Add(A2);
                    ctx.Players.Remove(ses2);
                    ctx.Entry(ses2).State = System.Data.Entity.EntityState.Deleted;
                    ctx.SaveChanges();                    
                }
            }
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!gameover)
                Update_database();

            if (player_num == 0)
                return;
            if (byeCount)
                return;

            string msg = "bye" + player_num;
            Client.SendMessage(new MessageInfo
            {
                Message = msg,
                FromCLient = me,
                ToClients = enemy
            });

            string msg1 = "addtolist " + me + " " + enemy[0];
            Client.SendMessage(new MessageInfo
            {
                Message = msg1,
                FromCLient = me,
                ToClients = enemy
            });            
        }  

        private void Game_Load(object sender, EventArgs e)
        {            
                if(player_num==1)
               {
                string msg = "removefromlist " + me + " " + enemy[0];
                Client.SendMessage(new MessageInfo
                {
                    Message = msg,
                    FromCLient = me,
                    ToClients = enemy
                });
               }                 
        }
        public void getBye()
        {
            byeCount = true;
        }
        private void timer_Tick(object sender, EventArgs e)
        {
            seconds++;

            if (seconds == 60)
            {
                minutes++;
                seconds = 0;
            }

            secondsBox.Text = seconds.ToString();
            minutesBox.Text = minutes.ToString();
        }
    }
}
