using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bouncing_ball
{
    public partial class MainWindow : Window
    {
        private Random random;
        private double move = 0.1;

        private List<Ball> bouncingBall;

        public bool isStop = false;
        private Thread BallThread;
        private delegate void MoveBallHandler(Ball ball);

        public MainWindow()
        {
            InitializeComponent();

            this.bouncingBall = new List<Ball>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.random = new Random();
            Ball ball = new Ball(this.random);
            this.bouncingBall.Add(ball);
            this.MyCanvas.Children.Add(ball.Circle);
            this.BallThread = new Thread(BallThreadProc);
            this.BallThread.Start();
        }

        private void BallThreadProc()
        {
            MoveBallHandler handler = new MoveBallHandler(this.MoveBall);

            while(!isStop)
            {
                Monitor.Enter(this);
                Dispatcher.BeginInvoke(handler, bouncingBall[0]);
                Monitor.Exit(this);
                Thread.Sleep(1);
            }
        }

        private void MoveBall(Ball ball)
        {
            ball.LeftPosition += ball.Direction.X * move;
            ball.TopPosition += ball.Direction.Y * move;

            CheckWall(ball);
        }

        private void CheckWall(Ball ball)
        {
            //Top wall
            if( ball.TopPosition < 0)
            {
                ball.Direction = new Vector(ball.Direction.X, -ball.Direction.Y);
            }
            //Bottom wall
            else if(ball.TopPosition > MyCanvas.ActualHeight - ball.Radius*2)
            {
                ball.Direction = new Vector(ball.Direction.X, -ball.Direction.Y);
            }
            //Right wall
            else if (ball.LeftPosition < 0)
            {
                ball.Direction = new Vector(-ball.Direction.X, ball.Direction.Y);
            }
            //Left wall
            else if (ball.LeftPosition > MyCanvas.ActualWidth - ball.Radius * 2)
            {
                ball.Direction = new Vector(-ball.Direction.X, ball.Direction.Y);
            }
        }
    }
}
