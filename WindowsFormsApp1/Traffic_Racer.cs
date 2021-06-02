using System;
using System.Windows.Forms;
using Traffic_Racer.Core.Controller;
using Traffic_Racer.Core.Model;
using Traffic_Racer.Helpers;
using System.Drawing;

namespace Traffic_Racer
{
    public partial class Traffic_Racer : Form
    {
        private Timer gameTimer;
        public static bool canMove;// = true;
        public static Button StartGameButton;
        public static PictureBox GameField;
        public static Label ScoreLabel;

        public Traffic_Racer()
        {
            InitializeComponent();
            Initialize();
            Invalidate();
            //gameTimer.Start();
        }


        public void Initialize()
        {
            canMove = true;
            ScoreLabel = new Label() { Location = new Point(270, 830), Text = "Score: " + GameModel.Score.ToString(), 
                Font = new Font("Arial", 16), Width = 200, Height = 50 };
            GameField = new PictureBox() { Location = new Point(40, 0), Width = 600, Height = 750, BackColor = Color.Black };
            StartGameButton = new Button() { Text = "Start Game", Location = new Point(270, 780), Width = 100, Height = 40 };
            Controls.Add(ScoreLabel);
            Controls.Add(GameField);
            Controls.Add(StartGameButton);
            StartGameButton.Click += (sender, e) => gameTimer.Start();
            StartGameButton.Click += (sender, e) => Controls.Remove(StartGameButton);
            GameModel.Initialize(new PlayerCar(GameField.Width / 2, GameField.Height - 100), 6, 3);
            gameTimer.Interval = 1;
            gameTimer.Tick += (object sender, EventArgs e) =>
            {
                Controller.UpdateFormState(sender, e);
                Invalidate();
            };
            //gameTimer.Tick += (sender, e) => ResetGame();
            //gameTimer.Start();
        }

        
    }
}
