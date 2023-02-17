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
    public partial class _2_Paint : Form
    {
        /* We have 2 modes (Drawing,Eraseing) and based on the mode
           We select the color.
        note: Erasing is done by choosing the BackgroundColor.
         */
        private bool _isDrawing = false;
        private bool _isErasing = false;

        /*Storing locations in points instead of passing (x,y)*/
        private Point _lastPoint;
        private Color _currentColor = Color.Black;

        public _2_Paint()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Fill the background with the default color
            var brush = new SolidBrush(BackColor);
                e.Graphics.FillRectangle(brush, ClientRectangle);
            
        }

        private void _2_Paint_MouseDown(object sender, MouseEventArgs e)
        {
            /*Sending what is last clicked location to either
             * the Drawer or Eraser.
            */
            _lastPoint = e.Location;
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = true;
            }
            else if (e.Button == MouseButtons.Right)
            {
                _isErasing = true;
            }
        }

        private void _2_Paint_MouseMove(object sender, MouseEventArgs e)
        {
            var g = CreateGraphics();
            if (_isDrawing)
            {
                g.DrawLine(new Pen(_currentColor, 10), _lastPoint, e.Location);
            }
            else if (_isErasing)
            {
                g.DrawLine(new Pen(BackColor, 10), _lastPoint, e.Location);
            }
            _lastPoint = e.Location;
        }

        private void _2_Paint_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _isDrawing = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                _isErasing = false;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog1.Color;
                /* We also change the button's background color as an indecation
                 for the color we are using to draw right now.
                */
                btnColor.BackColor = _currentColor;
            }
        }
    }
}
