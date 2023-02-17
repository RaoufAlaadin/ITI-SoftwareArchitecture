using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace D11Tasks
{
    public partial class _5_MovingBall : Form
    {

       
        private Timer timer;
        private int ballX;
        private int ballSpeed = 50;

        public _5_MovingBall()
        {
            InitializeComponent();
           
            timer = new Timer();
            timer.Interval = 100;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

            /* The event keep getting activated as time passes,
             and  so we keep*/
        private void Timer_Tick(object sender, EventArgs e)
        {
            /* Increases the x value weather it's in either directions.*/
            ballX += ballSpeed;

            if (ballX + 200 >= 650)
            {   /* 1- if this condition is true,
                 then we reached the right stickman,
                and we intilize x again with the exact value just in case
                we passed it's body.
                2- then we add the reverse sign to go back in reverse to the
                left stickman.
                */
                ballX = 650 - 200;
                ballSpeed = -ballSpeed;
            }
            else if (ballX < 60)
            {
                /* if true we reacded the left stickman, 
                 we intilize X with an exact value just to be sure. 
                
                 then we reverse the sign to go to the right again. 
                */
                ballX = 60;
                ballSpeed = -ballSpeed;
            }

             /*
              Refereshes the form to re-draw the shapes again.
              The ball won't move without it. 
             */
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            DrawLeftPlayer(e.Graphics);
            DrawRightPlayer(e.Graphics);
            DrawBall(e.Graphics);

         
            
        }

        private void DrawLeftPlayer(Graphics g)
        {
            Pen leftPen = new Pen(Color.DarkBlue, 3);


            g.DrawEllipse(leftPen, new Rectangle(10, 0, 100, 100));
            g.DrawLine(leftPen, new Point(60, 100), new Point(60, 350));
            g.DrawLine(leftPen, new Point(60, 150), new Point(30, 180));
            g.DrawLine(leftPen, new Point(60, 150), new Point(90, 180));
            g.DrawLine(leftPen, new Point(60, 350), new Point(30, 380));
            g.DrawLine(leftPen, new Point(60, 350), new Point(90, 380));
        }

        private void DrawRightPlayer(Graphics g)
        {
            Pen blackPen = new Pen(Color.Purple, 3);

            g.DrawEllipse(blackPen, new Rectangle(600, 0, 100, 100));
            g.DrawLine(blackPen, new Point(650, 100), new Point(650, 350));
            g.DrawLine(blackPen, new Point(650, 150), new Point(620, 180));
            g.DrawLine(blackPen, new Point(650, 150), new Point(680, 180));
            g.DrawLine(blackPen, new Point(650, 350), new Point(620, 380));
            g.DrawLine(blackPen, new Point(650, 350), new Point(680, 380));

            g.DrawLine(blackPen, new Point(560, 69), new Point(618, 16));
            g.DrawLine(blackPen, new Point(682, 16), new Point(776, 61));

        }

        private void DrawBall(Graphics g)
        {
                /*
                 The x value is a variable that we calcualte by using the 
                 timer event. 
                */
            g.DrawEllipse(Pens.Black, new Rectangle(ballX, 190, 200, 200));
            g.FillEllipse(Brushes.Red, new Rectangle(ballX, 190, 200, 200));


        }
    }
}
