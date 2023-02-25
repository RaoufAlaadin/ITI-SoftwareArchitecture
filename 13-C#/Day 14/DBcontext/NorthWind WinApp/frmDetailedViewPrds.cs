using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthWind_WinApp.Context;
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
        }

        pubsContext context = new pubsContext();

        BindingNavigator bindingNavigator;

        private void frmDetailedViewPrds_Load(object sender, EventArgs e)
        {
            context.Titles.Load();
            context.Publishers.Load();

            titleBindingSource.DataSource = context.Titles.Local.ToBindingList();

            cmbPublisherName.DataSource = context.Publishers.Local.ToBindingList();
            cmbPublisherName.DisplayMember = "PubName";
            cmbPublisherName.ValueMember = "PubId";

            bindingNavigator = new BindingNavigator(titleBindingSource);
            this.Controls.Add(bindingNavigator);

            txtTitleID.DataBindings.Add("Text", titleBindingSource, "TitleId");
            txtTitleName.DataBindings.Add("Text", titleBindingSource, "Title1");
            txtType.DataBindings.Add("Text", titleBindingSource, "Type");

            txtPrice.DataBindings.Add(
                "Text",
                titleBindingSource,
                "Price",
                true,
                DataSourceUpdateMode.OnPropertyChanged,
                "C2"
            );

            cmbPublisherName.DataBindings.Add("SelectedValue", titleBindingSource, "PubId");

            txtNotes.DataBindings.Add("Text", titleBindingSource, "Notes");

            /*This event is important because it gives an `EntityState.Added` for the new objects
            Without it the object will have the state of changed.*/
            //titleBindingSource.AddingNew += (sender, e) =>
            //e.NewObject = new Title() { State = EntityState.Added };
        }

       
        private void button1_Click(object sender, EventArgs e)
        {
            // Save button clicked

            /* Saves all the changes we did to the TitleList data, */
            titleBindingSource.EndEdit();
            context.SaveChanges();

            //// tracker using the debug mode.
            //foreach (var item in TitleList)
            //    Trace.WriteLine(item.State);

            //foreach (var item in TitleList)
            //{
            //    switch (item.State)
            //    {
            //        case EntityState.Added:
            //            TitleManger.AddTitle(item);
            //            MessageBox.Show($"Title_id :( {item.title_id} ) added successfully.");

            //            break;
            //        case EntityState.Deleted:
            //            TitleManger.DeleteTitle(item.title_id);
            //            MessageBox.Show($"Title_id :( {item.title_id} ) Deleted successfully.");

            //            break;
            //        case EntityState.Changed:
            //            TitleManger.UpdateTitle(item);
            //            MessageBox.Show($"Title_id :( {item.title_id} ) updated successfully.");

            //            break;
            //    }

            //    item.State = EntityState.UnChanged;
            //}
            //TitleList = TitleManger.SelectAllTitles();
            //titleBindingSource.DataSource = TitleList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //if (titleBindingSource.Current != null)
            //{
            //    Title currentTitle = (Title)titleBindingSource.Current;
            //    currentTitle.State = EntityState.Deleted;
            //}
        }
    }
}
