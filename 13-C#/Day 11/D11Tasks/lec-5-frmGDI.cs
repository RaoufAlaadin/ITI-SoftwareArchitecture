using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D11Tasks
{
    public partial class lec_5_frmGDI : Form
    {
        public lec_5_frmGDI()
        {
            InitializeComponent();

            /* To handle the resizing issue we have 2 methods 
                1- protected property in form class, it's protected so
            it won't be seen outside the class. 

            ===>     this.ResizeRedraw = true; 

            2- Handle Resize Event, which is the one we are going to use now.
             */
            /* `Invalidate()` is an old school windows forms method, 
             that is responsible for the redrawing when the resizing ruins
            our drawing. 
            */
            this.Resize += (sender, e) => Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            /* Draw me the the following string,
             same default font 
            shape of the static brush
            and at the point (x,y)

            note: x,y relative to the grey area only, as the top left corner for
            it is (0,0).
            You will be able to notice that using paint.

            the grey part is called `client size`. 

            */

                /* keeping the same fontFamily, but changign the default size.*/
            Font myFont = new Font(this.Font.FontFamily, 18);

            string str = "Hello GDI+";
            var textSize = e.Graphics.MeasureString(str, myFont);   

                /* The mod `%` makes sure that if the value gets over 255.
                 it get set to 255. 
                and here we just user width and height as random values that do change
                when we resize our window, so it will lead to colors being changed as well.*/
            Brush myBrush = new SolidBrush(Color.FromArgb(this.Height % 255
                ,this.Width % 255,
                (this.Height /2 + this.Width /2) %255)
                );

            e.Graphics.DrawString(str,
                myFont,
                myBrush,
                (this.ClientSize.Width - textSize.Width) /2,
                (this.ClientSize.Height - textSize.Height)/2
                );

            Pen myP = new Pen(Brushes.Black, 3);

            foreach (var item in Clst)
            {

                /* WARNING: 
                 * CHOOSE THE SAME COLORS HERE AS BELOW TO
                     GET THE EFFECT OF REDRAWN IN PLACE. 
                ===> MIND GAMES. 
                */
                e.Graphics.FillEllipse(Brushes.Blue,
               item.X - 15, item.Y - 15, // mouse coordinates when clicking.
               30, 30);
                e.Graphics.DrawEllipse(myP,
                item.X - 15, item.Y- 15, // mouse coordinates when clicking.
                30, 30 // size of the circle
                );
            }

            base.OnPaint(e);
        }




            /* We will add that list to the onPaint, so the Invalidate can redraw it
             when we resize our screen. 
            */
        List<Point> Clst = new List<Point>();
        private void lec_5_frmGDI_MouseClick(object sender, MouseEventArgs e)
        {
            /* e.Graphics gets sent only in the paint event.
             * so we have to create our own graphics object. */

            /*it considers the click postion as the (0,0) for the circle
             so we ( e.X - (circle size /2) ) so that circle center shifts from where 
            the mouse actually clicked.

            so now the mouse click will be at the center of the circle. 
             */

            Graphics grfx = this.CreateGraphics();


            /*  Pen myP = new Pen(Color.FromArgb(this.Height % 255
                  , this.Width % 255,
                  (this.Height / 2 + this.Width / 2) % 255) , 20);*/

            Pen myP = new Pen(Brushes.Black, 3);
            if (e.Button == MouseButtons.Left)
            {
                grfx.FillEllipse(Brushes.Red,
               e.X - 15, e.Y - 15, // mouse coordinates when clicking.
               30, 30);

                grfx.DrawEllipse(myP,
               e.X - 15, e.Y - 15, // mouse coordinates when clicking.
               30, 30 // size of the circle
               );
                // each time we add the location of the new circle
                // to our list.
                Clst.Add(e.Location);

            }
           
        }
    }
}
