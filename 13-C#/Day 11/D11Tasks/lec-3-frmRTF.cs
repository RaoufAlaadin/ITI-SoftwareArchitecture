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
    public partial class lec_3_frmRTF : Form
    {
        public lec_3_frmRTF()
        {
            InitializeComponent();
        }

        /* This is an event on the window itself when we double clicked it.
            Event =>  when the form loads.
        */
        private void lec_3_frmRTF_Load(object sender, EventArgs e)
        {   

            /*a good practice to keep the size u are working with
             * as the min size.*/
            this.MinimumSize = this.Size;
            btnClose.Click += (sender, e) => this.Close();
        }


        /*
        Event =>  when the form is closing. not closed entirely.
         */
        private void lec_3_frmRTF_FormClosing(object sender, FormClosingEventArgs e)
        {
            /* msgboxes are our way of communicating with the user, 
             same as console.ReadLine and writeline was with the console.
            */
            /* .Show() is the only way to communicate with the msgbox class, it handles all
             the inputs and returns.
            That's why it has 20 overloads !!! 
            */

            var result = MessageBox.Show("Are you sure you want to exit? (Y|N)","Warning", 
                MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2 
                );

            if (result == DialogResult.No)
            {
                /* one of the default args is cancel, which cancels the event.
                 The event is closing the whole form.

                if we press yes, we won't go into the if statement,
                So we will close the form*/
                e.Cancel = true;
            }



        }

            /* Note: The event is on the button, The work is done by the dialogs.*/

        private void btnOpen_Click(object sender, EventArgs e)
        {
            dlgOpen.Filter = "Rich Text Files | *.rtf| Text Files|*.txt";

            if(dlgOpen.ShowDialog() == DialogResult.OK)
                // I load the file data into our Rich text box.

                switch (dlgOpen.FilterIndex)
                {
                    case 1:
                        rtfTxt.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.RichText);
                        break;
                    case 2:
                        rtfTxt.LoadFile(dlgOpen.FileName, RichTextBoxStreamType.PlainText);
                        break;

                }

                /* What if we want to write this in a simpler way? 
                 * ==> by chance that the enums plain text is 1 and richtext is 0
                 so we can take the filterIndexDirectly.
                Filter index order the same order as when we declared the filter.

                        (RichTextBoxStreamType)(dlgSave.FilterIndex-1)

                    casting is important to handle that the input is an integer.
            */


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            dlgSave.Filter = "Rich Text Files | *.rtf| Text Files|*.txt";
            dlgSave.InitialDirectory = "C:\\Users\\Reem\\Downloads";

            if (dlgSave.ShowDialog() == DialogResult.OK)
                /* The dialogs are just interfaces to give info to the rtf object,
                 It's the one that actually save the content*/
                rtfTxt.SaveFile(dlgSave.FileName,(RichTextBoxStreamType)(dlgSave.FilterIndex-1));
        }

            /* color and fonts dialog will be promoted. 
             then they return the selected value and apply it on the selected text.*/
        private void btnFont_Click(object sender, EventArgs e)
        {
                /*This part assigns the font of the currently selected text to the
                 dialog box, so I know the font I am already using
                
                 first we check that anything is selected and not null
                and the selection length is more that 0
                
                 only then we store the font.
               */
            if (rtfTxt.SelectedText?.Length > 0)
                dlgFont.Font = rtfTxt.SelectionFont;


            if(dlgFont.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionFont = dlgFont.Font;

        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (rtfTxt.SelectedText?.Length > 0)
                dlgFont.Color = rtfTxt.SelectionColor;


            // if we confirm the color we selected, only then that we
            // assign it to the selected text in the rtf
            if (dlgColor.ShowDialog() == DialogResult.OK)
                rtfTxt.SelectionColor = dlgColor.Color;
        }

            /* we create an object from the custom form once,
             to prevent creating an object each time we press the custBtn
            if we were to insert the creation in the event method.
            */
        lec__4_dlgCust dlgCust = new ();
        private void btnCust_Click(object sender, EventArgs e)
        {
            /* .userText is a public property we created in the dlgCust class
             to access the privet .text .
            
            also the enums ok and cancel where given to the dlgcust in it's file
            using the UI functionality.
            */

            /* I have also created a property for the placeholder text 
                 for the same reason.
            */
            dlgCust.placeholder = " Type anything here";
            if (dlgCust.ShowDialog() == DialogResult.OK)
            {
                rtfTxt.AppendText(dlgCust.userText.ToUpper());
            }

            /* General notes:

                1-We can give order to the buttons by using a property called
                tabIndex,, so if you press tab the highlight change based on that order

                also press view => tab order ... and a number will get shown on each button 
                 so you can check the current order.
                
                2-also what if I wanted enter to have a meaning and 
                    if pressed it will mean `ok` ? same for Escape. 

            We set the accpetButton for whole form as the btnOK
            and same for cancel button

             */

        }

        
    }
}
