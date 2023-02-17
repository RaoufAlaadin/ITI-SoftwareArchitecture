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
    public partial class lec_6_frmNotRect : Form
    {
        public lec_6_frmNotRect()
        {
            InitializeComponent();
        }

        private void lec_6_frmNotRect_Load(object sender, EventArgs e)
        {
            /* This will make anything with the color black transpernt,
             So we will be able to see what's behind the window.
            
             ===> not the best method as it depends on the image quality used.*/
            this.TransparencyKey = Color.Black;
        }
    }
}
