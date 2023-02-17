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
    public partial class lec_2_login : Form
    {
        public lec_2_login()
        {
            InitializeComponent();

             /*
             all the events are already declared by class, we just register a method
             to activate when the event happens.
             What we wrote is just a quick syntax shortcut because we won't call the method
             in anything else. so it does not need a name. 
             */
             // using `this` because we are closing our login form.
            btnClose.Click += (sender, e) => this.Close();
           
        }

        /* We are creating an object from the form class we just created previously.*/
        lec_1 frmHomePage = new();

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "ABC" && txtPassword.Text == "123" )
            {
                this.Hide();
                frmHomePage.ShowDialog();
                this.Visible= true;
            }
        }
    }
}
