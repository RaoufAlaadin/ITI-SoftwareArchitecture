using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_GridView
{
    public partial class GridView : Form
    {
        /* Important Notes:
           1- I used the following Query to change the productID as foreign to `cascade
               on delete`, so when we delete a row from `products table`, it deletes it's row's
               from other tables also.

            // We first dropped the previous constraint, and then added a new one.

            ALTER TABLE [Order Details] DROP CONSTRAINT [FK_Order_Details_Products];

            ALTER TABLE [Order Details] ADD CONSTRAINT [FK_Order_Details_Products]
            FOREIGN KEY (ProductID) REFERENCES Products(ProductID) ON DELETE CASCADE;

        2- We are using data binding implicitly by using :
                a- DataTable and DataAdapter for retrival of data from the database
                b- sqlCommandBuilder and .update() in sending the changes back to the
                    original database.

        3- Data binding types `one way`and `2-way` ,, in `2-way` both elements are binded to
        the same data object so any change reflect in the other, 
        this is done using the .DataBinding property of the element. 

        but what don't have to always use the .DataBinding as most controls already implement the 
        `IBindingList` interface.. 


 
	
      */

        /*  Example on Classes that implement `IBindingList` interface
		

		  1-BindingList<T> - A generic list that implements IBindingList and supports data binding.
        2-DataView - A view of a DataTable that implements IBindingList and supports sorting and filtering.
        3-DataSet - A disconnected, in-memory representation of data that implements IBindingList.
        4-DataGridView - A WinForms control that displays data in a grid and implements IBindingList.
        5-ListBox - A WinForms control that displays a list of items and implements IBindingList.
        6-ListView - A WinForms control that displays a collection of items in various views and implements IBindingList.
        7-BindingSource - A component that simplifies data binding and implements IBindingList. 
         
         */

        /*Example on : 2-way binding
         
                             using System;
                    using System.ComponentModel;
                    using System.Windows.Forms;

                    namespace TwoWayBindingExample
                    {
                        public partial class Form1 : Form
                        {
                            private BindingSource _bindingSource;

                            public Form1()
                            {
                                InitializeComponent();

                                // Create a new BindingSource object and set its DataSource property to a new instance of a Person class
                                _bindingSource = new BindingSource();
                                _bindingSource.DataSource = new Person();

                                // Add the TextBox and Label controls to the form
                                this.Controls.Add(textBox1);
                                this.Controls.Add(label1);

                                // Create a new binding for the Text property of the TextBox control and the Name property of the Person object
                                Binding nameBinding = new Binding("Text", _bindingSource, "Name", true, DataSourceUpdateMode.OnPropertyChanged);

                                // Add the binding to the Bindings collection of the TextBox control
                                textBox1.DataBindings.Add(nameBinding);

                                // Create a new binding for the Text property of the Label control and the Greeting property of the Person object
                                Binding greetingBinding = new Binding("Text", _bindingSource, "Greeting");

                                // Add the binding to the Bindings collection of the Label control
                                label1.DataBindings.Add(greetingBinding);
                            }
                        }

                        public class Person : INotifyPropertyChanged
                        {
                            private string _name;

                            public string Name
                            {
                                get { return _name; }
                                set
                                {
                                    _name = value;
                                    OnPropertyChanged("Name");
                                    OnPropertyChanged("Greeting");
                                }
                            }

                            public string Greeting
                            {
                                get { return "Hello, " + _name; }
                            }

                            public event PropertyChangedEventHandler PropertyChanged;

                            protected virtual void OnPropertyChanged(string propertyName)
                            {
                                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                            }
                        }
                    }

         
         
         */


        public GridView()
        {
            InitializeComponent();
        }

        // connection
        SqlConnection sqlCn;

        // Adapters
        SqlDataAdapter ProductAdapter;
        SqlDataAdapter supplierAdapter;
        SqlDataAdapter categoriesAdapter;

        // Tables
        DataTable DtPrds;
        DataTable DTsuppliers;
        DataTable DTcategories;

        // ComboBoxColumn
        DataGridViewComboBoxColumn supplierNameColumn;
        DataGridViewComboBoxColumn categoriesNameColumn;

        int SupplierNameColumnIndex;
        int CategoryNameColumnIndex;

        private void frmGridView_Load(object sender, EventArgs e)
        {
            sqlCn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString
            );

            ProductAdapter = new SqlDataAdapter("select * from products", sqlCn);
            supplierAdapter = new SqlDataAdapter("select * from Suppliers", sqlCn);
            categoriesAdapter = new SqlDataAdapter("select * from categories", sqlCn);

            DtPrds = new DataTable();
            DTsuppliers = new DataTable();
            DTcategories = new DataTable();

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ProductAdapter);

            //grdPrds.CellValueChanged += onCellValueChange;
        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Fill the dissconted tables with data from the database using adapters*/
            ProductAdapter.Fill(DtPrds);
            supplierAdapter.Fill(DTsuppliers);
            categoriesAdapter.Fill(DTcategories);

            /* Setting values for each comboBox.*/
            supplierNameColumn = new DataGridViewComboBoxColumn();
            supplierNameColumn.HeaderText = "SupplierName";
            supplierNameColumn.DisplayMember = "CompanyName";
            supplierNameColumn.ValueMember = "SupplierID";



            categoriesNameColumn = new DataGridViewComboBoxColumn();
            categoriesNameColumn.HeaderText = "CategoriesName";
            categoriesNameColumn.DisplayMember = "CategoryName";
            categoriesNameColumn.ValueMember = "CategoryID";

				

            /* Using the `dataPropertyname` basically sets the value of the suplier Name
             * Column, to the value of the column Called SupplierID in the grid. 
             * 
             * It even states in it's definition - if you hover over it - that it takes 
             * The value of the column with that name in the `DataGridView that it's connected to. 
            */

            /*This basically replaced the `foreach` we made and the onCellChange Event
                 */

            supplierNameColumn.DataPropertyName = "SupplierID";
            categoriesNameColumn.DataPropertyName = "CategoryID";


            /* Setting DATA SOURCE */

            grdPrds.DataSource = DtPrds;
            supplierNameColumn.DataSource = DTsuppliers;
            categoriesNameColumn.DataSource = DTcategories;

            /*
             Hiding some columns, we would have done that by adjusting the query.
             The columns are still there and have an index,But they are just invisible.
            */
            //grdPrds.Columns["SupplierID"].Visible = false;
            //grdPrds.Columns["CategoryID"].Visible = false;
			
			 

            /* Note:
             * Inserting the columns based on the location of others, because when I tried to
             * Access the SupplierName coloumn with it's name after adding it, it has always
               gave an error, so I had to use an index.
            */
            SupplierNameColumnIndex = grdPrds.Columns["SupplierID"].Index + 1;
            grdPrds.Columns.Insert(SupplierNameColumnIndex, supplierNameColumn);

            CategoryNameColumnIndex = grdPrds.Columns["CategoryID"].Index + 1;
            grdPrds.Columns.Insert(CategoryNameColumnIndex, categoriesNameColumn);

            /*
             This sets the default value, so when when the table is read, we find the
             corrispondent suppileerName is written for the row.
            */

            //foreach (DataGridViewRow row in grdPrds.Rows)
            //{
            //    row.Cells[SupplierNameColumnIndex].Value = row.Cells["SupplierID"].Value;
            //    row.Cells[CategoryNameColumnIndex].Value = row.Cells["CategoryID"].Value;
            //}

            /* This sets the form to `full screen` when data is read. */
			
			
			/* This Prevent edits on the ID Column*/
			grdPrds.Columns["ProductID"].ReadOnly = true;
			
			
            this.WindowState = FormWindowState.Maximized;
        }

        //private void onCellValueChange(object sender, DataGridViewCellEventArgs e)
        //{
        //    /*
        //     * The change is made to the column we created, but we want to save that change
        //        to the `products table`, that's why change the value of the hidden column `SupplierID`
        //        base on the comboBox column change.
        //    */
        //    if (e.ColumnIndex == SupplierNameColumnIndex)
        //    {
        //        grdPrds.Rows[e.RowIndex].Cells["SupplierID"].Value = grdPrds.Rows[e.RowIndex].Cells[
        //            SupplierNameColumnIndex
        //        ].Value;
        //    }
        //    else if (e.ColumnIndex == CategoryNameColumnIndex)
        //    {
        //        grdPrds.Rows[e.RowIndex].Cells["CategoryID"].Value = grdPrds.Rows[e.RowIndex].Cells[
        //            CategoryNameColumnIndex
        //        ].Value;
        //    }
        //}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in DtPrds.Rows)
            {
                Debug.WriteLine(row.RowState);
            }

            try
            {
                grdPrds.EndEdit();
                ProductAdapter.Update(DtPrds);

                MessageBox.Show("Data saved to Sql server.");
            }
            catch (Exception)
            {
                MessageBox.Show("Failed");
            }
        }
    }
}
