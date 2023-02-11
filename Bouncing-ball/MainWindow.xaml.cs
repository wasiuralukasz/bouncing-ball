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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Bouncing_ball
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double moveX = 0.1, moveY = 0.1;
        DispatcherTimer timer = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
            timer.Tick += timer_Tick;
            timer.Interval = TimeSpan.FromMicroseconds(500);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Canvas.SetLeft(Ball, Canvas.GetLeft(Ball) + moveX);
            Canvas.SetTop(Ball, Canvas.GetTop(Ball) + moveY);

            if(Canvas.GetLeft(Ball) > MyCanvas.ActualWidth - Ball.Width || Canvas.GetLeft(Ball) <= 0)
            {
                moveX *= -1;
            }
            if (Canvas.GetTop(Ball) > MyCanvas.ActualHeight - Ball.Height || Canvas.GetTop(Ball) <= 0)
            {
                moveY *= -1;
            }
        }

        public void StartButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();
        }
    }
}
