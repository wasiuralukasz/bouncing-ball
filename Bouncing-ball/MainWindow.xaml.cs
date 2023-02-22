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
        private int defaultSpeed = 1;

        private List<Ball> bouncingBall;

        public bool isStop;
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
            this.BallThread = new Thread(() => BallThreadProc(this.defaultSpeed));
            this.isStop = false;
            this.BallThread.Start();
        }

        private void BallThreadProc(int speed)
        {
            MoveBallHandler handler = new MoveBallHandler(this.MoveBall);

            while(!isStop)
            {
                Monitor.Enter(this);
                Dispatcher.BeginInvoke(handler, bouncingBall[0]);
                Monitor.Exit(this);
                Thread.Sleep(speed);
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

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            //TODO, Generate new ball in 
            bouncingBall[0].Circle.Fill = Brushes.Blue;
            if(!(CanvasHeightInput.Text == ""))
            {
                MyCanvas.Height = double.Parse(CanvasHeightInput.Text);
                CanvasBorder.Height = double.Parse(CanvasHeightInput.Text);
            }
            else if(!(CanvasWidthInput.Text == ""))
            {
                MyCanvas.Width = double.Parse(CanvasWidthInput.Text);
                CanvasBorder.Width = double.Parse(CanvasWidthInput.Text);
            }


            //Check CheckBox, if checked border is visible.
            if (CanvasBorderCheckBox.IsChecked == true)
            {
                CanvasBorder.Visibility = Visibility.Visible;
            }
            else
            {
                CanvasBorder.Visibility = Visibility.Hidden;
            }


            //Get value from slider and create new Thread with new speed.
            int valueFromSlider = (int)(BallSpeedSlider.Value);
            this.isStop = true;
            this.BallThread.Join();
            this.BallThread = new Thread(() => BallThreadProc(valueFromSlider));
            this.isStop = false;
            this.BallThread.Start();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            this.BallThread = new Thread(() => BallThreadProc(this.defaultSpeed));
            this.isStop = false;
            this.BallThread.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            this.isStop = true;
            this.BallThread.Join();
        }
    }
}
