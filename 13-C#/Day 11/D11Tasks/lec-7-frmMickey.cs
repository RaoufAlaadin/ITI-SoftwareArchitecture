using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D11Tasks
{
    public partial class lec_7_frmMickey : Form
    {
        public lec_7_frmMickey()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }

        /*Remember to add this following using:
         *
                    using System.Drawing.Drawing2D;
         *
         */
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath path = new GraphicsPath();

            path.AddEllipse(0, 0, 610, 420);
            path.AddEllipse(0, 0, 150, 150);
            path.AddEllipse(450, 0, 150, 150);

            // this will remove the transparency when having 2 shapes together.
            path.FillMode = FillMode.Winding;

            this.Region = new Region(path);

            base.OnPaint(e);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lec_7_frmMickey_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Are you sure you want to exit? (Y|N)",
                "Warning",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2
            );

            if (result == DialogResult.No)
                e.Cancel = true;
        }


        private bool isDragging = false;
        private Point lastLocation;

        /*  Invokes the dragging and intilize the first location*/
        private void btnMove_MouseDown(object sender, MouseEventArgs e)
        {

            isDragging = true;
            lastLocation = e.Location;

          
        }

        /* keeps calculating the difference in mouse movement and 
         set that value to the window location, and so we get a smooth movement.
        */
        private void btnMove_MouseMove(object sender, MouseEventArgs e)
        {

            if (isDragging)
            {
                int deltaX = e.Location.X - lastLocation.X;
                int deltaY = e.Location.Y - lastLocation.Y;

                this.Location = new Point(this.Location.X + deltaX, this.Location.Y + deltaY);
            }

        }

        /* this prevents the movement of the window if i pass by the button
           without pressing.*/
        private void btnMove_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        
    }
}
