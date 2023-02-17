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
    
    public partial class lec__4_dlgCust : Form
    {
       

       public string userText
        {
            get => txtInput.Text; 
            set => txtInput.Text = value;
            
        }

        public string placeholder
        {
            get => txtInput.PlaceholderText;
            set => txtInput.PlaceholderText = value;    
        }
        public lec__4_dlgCust()
        {
            InitializeComponent();

           btnOk.TabIndex = 0;
            btnCancel.TabIndex = 1;

        }
        
    }
}
