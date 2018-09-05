namespace MinesClient
{
    partial class GameForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.mscore = new System.Windows.Forms.Label();
            this.Play = new System.Windows.Forms.Button();
            this.difficulty = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.remainingFlags = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.secondsBox = new System.Windows.Forms.TextBox();
            this.minutesBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.wineer = new System.Windows.Forms.PictureBox();
            this.lsser = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.wineer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // mscore
            // 
            this.mscore.AutoSize = true;
            this.mscore.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mscore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mscore.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mscore.Location = new System.Drawing.Point(499, 20);
            this.mscore.Margin = new System.Windows.Forms.Padding(0);
            this.mscore.MaximumSize = new System.Drawing.Size(145, 29);
            this.mscore.MinimumSize = new System.Drawing.Size(0, 29);
            this.mscore.Name = "mscore";
            this.mscore.Size = new System.Drawing.Size(105, 29);
            this.mscore.TabIndex = 1;
            this.mscore.Text = "My Score";
            // 
            // Play
            // 
            this.Play.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Play.Location = new System.Drawing.Point(232, 403);
            this.Play.Name = "Play";
            this.Play.Size = new System.Drawing.Size(206, 38);
            this.Play.TabIndex = 6;
            this.Play.Text = "Start to play";
            this.Play.UseVisualStyleBackColor = true;
            this.Play.Click += new System.EventHandler(this.Play_Click);
            // 
            // difficulty
            // 
            this.difficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.difficulty.FormattingEnabled = true;
            this.difficulty.Items.AddRange(new object[] {
            "Easy",
            "Medium",
            "Hard"});
            this.difficulty.Location = new System.Drawing.Point(302, 376);
            this.difficulty.Name = "difficulty";
            this.difficulty.Size = new System.Drawing.Size(131, 21);
            this.difficulty.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.SteelBlue;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(232, 376);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 12;
            this.label5.Text = "difficulty:";
            // 
            // remainingFlags
            // 
            this.remainingFlags.AutoSize = true;
            this.remainingFlags.BackColor = System.Drawing.SystemColors.ControlLight;
            this.remainingFlags.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.remainingFlags.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainingFlags.Location = new System.Drawing.Point(312, 20);
            this.remainingFlags.MaximumSize = new System.Drawing.Size(100, 29);
            this.remainingFlags.MinimumSize = new System.Drawing.Size(10, 29);
            this.remainingFlags.Name = "remainingFlags";
            this.remainingFlags.Size = new System.Drawing.Size(10, 29);
            this.remainingFlags.TabIndex = 15;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // secondsBox
            // 
            this.secondsBox.BackColor = System.Drawing.Color.Bisque;
            this.secondsBox.Enabled = false;
            this.secondsBox.Location = new System.Drawing.Point(49, 20);
            this.secondsBox.Name = "secondsBox";
            this.secondsBox.Size = new System.Drawing.Size(23, 20);
            this.secondsBox.TabIndex = 16;
            // 
            // minutesBox
            // 
            this.minutesBox.BackColor = System.Drawing.Color.Bisque;
            this.minutesBox.Enabled = false;
            this.minutesBox.Location = new System.Drawing.Point(15, 20);
            this.minutesBox.Name = "minutesBox";
            this.minutesBox.Size = new System.Drawing.Size(23, 20);
            this.minutesBox.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.SteelBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 20);
            this.label1.TabIndex = 19;
            this.label1.Text = ":";
            // 
            // wineer
            // 
            this.wineer.Image = ((System.Drawing.Image)(resources.GetObject("wineer.Image")));
            this.wineer.Location = new System.Drawing.Point(401, 127);
            this.wineer.Name = "wineer";
            this.wineer.Size = new System.Drawing.Size(258, 266);
            this.wineer.TabIndex = 20;
            this.wineer.TabStop = false;
            this.wineer.Visible = false;
            // 
            // lsser
            // 
            this.lsser.Image = ((System.Drawing.Image)(resources.GetObject("lsser.Image")));
            this.lsser.Location = new System.Drawing.Point(3, 6);
            this.lsser.Name = "lsser";
            this.lsser.Size = new System.Drawing.Size(392, 387);
            this.lsser.TabIndex = 21;
            this.lsser.TabStop = false;
            this.lsser.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::MinesClient.Properties.Resources.מוקש1;
            this.pictureBox1.Location = new System.Drawing.Point(276, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(30, 29);
            this.pictureBox1.TabIndex = 22;
            this.pictureBox1.TabStop = false;
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::MinesClient.Properties.Resources.דגן_אפור_צבע_קיר_גראנג_רקע_מאגר_תמונות__k17107196;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(661, 453);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lsser);
            this.Controls.Add(this.wineer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minutesBox);
            this.Controls.Add(this.secondsBox);
            this.Controls.Add(this.remainingFlags);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.difficulty);
            this.Controls.Add(this.Play);
            this.Controls.Add(this.mscore);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(677, 500);
            this.MinimumSize = new System.Drawing.Size(200, 400);
            this.Name = "GameForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GameForm_FormClosed);
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wineer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lsser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label mscore;
        private System.Windows.Forms.Button Play;
        private System.Windows.Forms.ComboBox difficulty;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label remainingFlags;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.TextBox secondsBox;
        private System.Windows.Forms.TextBox minutesBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox wineer;
        private System.Windows.Forms.PictureBox lsser;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}