using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D11Tasks
{
    public partial class lec_1 : Form
    {
        public lec_1()
        {
            InitializeComponent();

            /* This will over-write anything choosen by the menu, as it's done in the intilizeComponent
             and we are after it's line.
            */
            this.BackColor = Color.MediumVioletRed;

            /*Also instead of using the built-in event, we create our own using the following.*/

            /* we wrote the function using lamda as a short-hand,
             using this line we registered to the event created in the form class 
             without overriding the method. */ 

            // this registers for when the resizing end to make the screen clear again.
            this.ResizeEnd += (sender, e) => this.Opacity = 1;


        }
        /* The publisher is the form class, 
            The subscriber is the lec_1 class which inherites from the form class
        this means we override the event and add our own conditions.*/

        /*I think this is a special case where we didn't need a registeration because the event is in the base,
         so we could just include our values on the side when the event is invoked.
        
         using  the following code will do the same. 

            this.ResizeBegin += (Sender, e) => this.Opacity = 0.75;
                
         */

        protected override void OnResizeBegin(EventArgs e)
        {
            base.OnResizeBegin(e);
            this.Opacity = 0.75;

        }

        private void DemoCallBackMethod(object sender, EventArgs e)
        {
                /* I can call the button1 object despite it being private, 
                 as it's in the other half of the partial class, so basically they are considered in the
                same class. 
                */
            button1.Text = "button clicked";
            
        }

        /* if you press on the reference, you will see the automatic registeration that 
            visual studio created for us. */




        /*Lecture notes: 
        
        1- class form and button have composition relation.
        2- form.designer.cs => is written by the complier, but form.cs is written by us.
            That's why both of them are `partial classes`, because they comepelete each other.
        3- there is an Enum for any control we have.
        4- Events steps: 
                a- declare an event and give it a name. 
                b- wrap the invoke with a function to allow overriding later by derived.
                c- call the event in main using an object from it's class, and let 
                    other methods register to it.
        
       */
    }
}
