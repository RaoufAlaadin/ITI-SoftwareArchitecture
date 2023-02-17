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
    public partial class _3_DragANDdrop : Form
    {
        private Rectangle _rect;
        private bool _isDragging;
        private Point _lastMousePosition;

        public _3_DragANDdrop()
        {
            InitializeComponent();

                /* 
                 Invalidate() keeps drawing all the lines behind it,
                 so we can use it for deletion or creation.
                */
            // Create a rectangle in the center of the form
            int rectSize = 100;
            int x = (ClientSize.Width - rectSize) / 2;
            int y = (ClientSize.Height - rectSize) / 2;
            _rect = new Rectangle(x, y, rectSize, rectSize);

         
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            // Check if the mouse is over the rectangle
            if (_rect.Contains(e.Location))
            {
                _isDragging = true;
                _lastMousePosition = e.Location;
            }
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                // Erase the old rectangle
                Invalidate(_rect);

                // Calculate the new position of the rectangle
                int dx = e.Location.X - _lastMousePosition.X;
                int dy = e.Location.Y - _lastMousePosition.Y;
                _rect.X += dx;
                _rect.Y += dy;

                // Redraw the rectangle at the new position
                Invalidate(_rect);

                // Update the last mouse position
                _lastMousePosition = e.Location;
            }
        }

        private void Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (_isDragging)
            {
                // Stop dragging
                _isDragging = false;

                // Redraw the rectangle at the final position
                Invalidate(_rect);
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw the rectangle
            e.Graphics.FillRectangle(Brushes.Red, _rect);
        }
    }
}
