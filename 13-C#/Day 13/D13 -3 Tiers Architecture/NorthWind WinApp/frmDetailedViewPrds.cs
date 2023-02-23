using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace NorthWind_WinApp
{
    public partial class frmDetailedViewPrds : Form
    {
        public frmDetailedViewPrds()
        {
            InitializeComponent();


            //titleBindingSource.ListChanged += titleBindingSource_ListChanged;

        }

        TitleList TitleList;
        PublisherList PublisherList;
        TitleManger TitleManger = new TitleManger();

        BindingNavigator bindingNavigator;
        private void frmDetailedViewPrds_Load(object sender, EventArgs e)
        {




            TitleList = TitleManger.SelectAllTitles();

            titleBindingSource.DataSource = TitleList;

            PublisherList = PublisherManger.SelectAllPublishers();



            cmbPublisherName.DataSource = PublisherList;
            cmbPublisherName.DisplayMember = "pub_name";
            cmbPublisherName.ValueMember = "pub_id";

           

            bindingNavigator = new BindingNavigator(titleBindingSource);
            this.Controls.Add(bindingNavigator);

           


            txtTitleID.DataBindings.Add("Text", titleBindingSource, "title_id");
            txtTitleName.DataBindings.Add("Text", titleBindingSource, "title");
            txtType.DataBindings.Add("Text", titleBindingSource, "type");

            /* The story of why the price needs the extra config ( anything that is float decimal and double)
             This issue might be caused by the Price property of the Title class being of a numeric type (such as decimal, float, or double) and not having a valid default value. When the form is first loaded, the data binding system reads the Price value from the Title object and displays it in the txtPrice text box. However, if the Price property is uninitialized, it might have a default value of zero, which would be displayed in the text box.

                When the user enters a new value in the txtPrice text box and then navigates away from the control (e.g., by clicking on another text box), the data binding system updates the Price property of the Title object with the new value. However, if the new value is invalid (e.g., an empty string or a non-numeric value), the data binding system might replace it with the default value of zero.

                To fix this issue, you could initialize the Price property of new Title objects to a valid default value (e.g., 0.00). You could also add some input validation to the txtPrice text box to ensure that the user enters a valid numeric value. Finally, you could handle the Leave or Validating event of the txtPrice text box to force the data binding system to update the Price property of the Title object with the current value of the text box, even if it is invalid.

            It's not necessary to use something else to hold the price. You can keep using the text box, but you need to make sure that the binding is properly set up. In your case, the binding for the price text box might not be set up correctly, which is why the text is getting cleared. Here are a few things you can try:

            Check the DataSourceUpdateMode property of the binding for the price text box. It should be set to OnPropertyChanged to update the underlying data source as soon as the user types in the text box.

            Make sure that the AcceptsReturn property of the price text box is set to false, so that the Enter key does not trigger a new line and clear the text.

            Try setting the BindingFormat property of the binding for the price text box to "C2" to format the value as currency with two decimal places. This can help ensure that the user enters a valid value.

            Here's an example of how you can set up the binding for the price text box with these changes:


            txtPrice.DataBindings.Add("Text", titleBindingSource, "price", true, DataSourceUpdateMode.OnPropertyChanged, null, "C2");
            txtPrice.AcceptsReturn = false;


             */

            txtPrice.DataBindings.Add("Text", titleBindingSource, "price", true, DataSourceUpdateMode.OnPropertyChanged, "C2");


            cmbPublisherName.DataBindings.Add("SelectedValue", titleBindingSource, "pub_id");

            txtNotes.DataBindings.Add("Text", titleBindingSource, "Notes");


            /*This event is important because it gives an `EntityState.Added` for the new objects
            Without it the object will have the state of changed.*/
            titleBindingSource.AddingNew += (sender, e) =>
            e.NewObject = new Title() { State = EntityState.Added };

            

            bindingNavigator.DeleteItem.MouseDown += navigatorDeletion;


        }

        //private void titleBindingSource_ListChanged(object sender, ListChangedEventArgs e)
        //{
        //    if (e.ListChangedType == ListChangedType.ItemDeleted)
        //    {
        //        Title deletedTitle = TitleList[e.NewIndex];
        //        deletedTitle.State = EntityState.Deleted;
        //        // you can now save the changes to the original database
        //    }
        //}


        private void navigatorDeletion (object sender , MouseEventArgs e)
        {
             /* This will let us use the `x` in the binding navigator */
            if (titleBindingSource.Current != null)
            {

                Title currentTitle = (Title)titleBindingSource.Current;
                currentTitle.State = EntityState.Deleted;

                /* This will delete the item also from the original database
                 * 
                    if you want to keep track of all the objects and delete them
                    later for real on `save`.
                Then you can store their `title_id` in a list. 

                then call deleteTitle() for each `title_id` in that list on save
                and if we don't call deleteTitle() at `save`, then if we read the data
                again, we will find that the object is still there.

                 */


                /* 
                 Maybe we can use the `x` as permenant delete option,
                 And `delete button` as remove from the view and warnning on
                `save` that we are going to permentalty delete it from the database.
                */
                TitleManger.DeleteTitle(currentTitle.title_id);


            }

        }




        private void button1_Click(object sender, EventArgs e)
        {
            // Save button clicked

            /* Saves all the changes we did to the TitleList data, */
            titleBindingSource.EndEdit();


            // tracker using the debug mode. 
            foreach (var item in TitleList)
                Trace.WriteLine(item.State);



            foreach (var item in TitleList)
            {
                switch (item.State)
                {
                   
                    case EntityState.Added:
                        TitleManger.AddTitle(item);
                        MessageBox.Show($"Title_id :( {item.title_id} ) added successfully.");

                        break;
                    case EntityState.Deleted:
                        TitleManger.DeleteTitle(item.title_id);
                        MessageBox.Show($"Title_id :( {item.title_id} ) Deleted successfully.");

                        break;
                    case EntityState.Changed:
                        TitleManger.UpdateTitle(item);
                        MessageBox.Show($"Title_id :( {item.title_id} ) updated successfully.");

                        break;
                   
                }

                item.State = EntityState.UnChanged;
            }
            TitleList = TitleManger.SelectAllTitles();
            titleBindingSource.DataSource = TitleList;



           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (titleBindingSource.Current != null)
            {
         
                Title currentTitle = (Title)titleBindingSource.Current;
                currentTitle.State = EntityState.Deleted;


            }

        }
    }
}
