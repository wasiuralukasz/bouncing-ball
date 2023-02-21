using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows;

namespace Bouncing_ball
{
    internal class Ball
    {

        private Ellipse circle;

        public readonly double Radius = 20;

        private double topPosition, leftPosition;

        private Vector direction;
        
        public Ball(Random rand)
        {
            //Setup ball
            this.circle = new Ellipse();
            this.circle.Stroke = Brushes.Red;
            this.circle.Fill = Brushes.Black;
            this.circle.Width= Radius * 2;
            this.circle.Height= Radius * 2;



            //Random location
            //random.NextDouble() * (maximum - minimum) + minimum;
            this.LeftPosition = rand.NextDouble() * ( 1000 - Radius) + Radius;
            this.TopPosition = rand.NextDouble() * ( 600 - Radius) + Radius;


            //Direction
            this.direction= new Vector(rand.Next(-5, 5), rand.Next(-5, 5));
            this.direction.Normalize();
        }

        public double TopPosition { 
            get { return this.topPosition; } 
            set { 
                this.topPosition = value; 
                this.circle.SetValue(Canvas.TopProperty, this.topPosition);
            } 
        }

        public double LeftPosition
        {
            get { return this.leftPosition; }
            set
            {
                this.leftPosition = value;
                this.circle.SetValue(Canvas.LeftProperty, this.leftPosition);
            }
        }

        public Vector Direction { get { return this.direction; } set { this.direction = value; } }

        public Ellipse Circle { get { return this.circle; } }
    }
}
