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

namespace Lecutre_ADO.net_testing
{
    public partial class frmProductDetailedView : Form
    {
        public frmProductDetailedView()
        {
            InitializeComponent();
        }

        SqlConnection sqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;

        /* This holds the Dissconnected copy from the data we imported.  */
        DataTable DtPrds;

        SqlCommand sqlcmdUpdatePrice;


        private void frmProductDetailedView_Load(object sender, EventArgs e)
        {
            // 1- Establish a connection
            sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString);
            // 2- Choosing our main command and it's type. 
            sqlCmd = new SqlCommand("SelectAllProducts", sqlCn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            // 3- Creating the Data Adapter and giving it a main sqlCmd.

            sqlDA = new SqlDataAdapter(sqlCmd);

            // 4- Initiating The dissconnected table that we are going to fetch
            // the data into. 
            DtPrds = new DataTable();


            // 5- Use the Data Adapter to fill the dissconeted table with data from the database.
            sqlDA.Fill(DtPrds);


            ///         *************Complex Data Binding **************
            // 6- Show the data on the screen by adding it to the list as a `source`. 
            // Here we are using (  DATA BINDING )

            lstPrd.DataSource = DtPrds;

            //this is the displayed name in the list
            lstPrd.DisplayMember = "ProductName";
            // this is the real value of an item you select on the list. 
            lstPrd.ValueMember = "ProductID";


            sqlcmdUpdatePrice = new();

            sqlcmdUpdatePrice.CommandText = " UPDATE Products SET  UnitPrice = @UnitPrice WHERE(ProductID = @ProductID)";
            sqlcmdUpdatePrice.Connection = sqlCn;


                /* storign variable parameter that we gonna detctat it's value later on.  */
            sqlcmdUpdatePrice.Parameters.Add("@UnitPrice", SqlDbType.Money);
            sqlcmdUpdatePrice.Parameters.Add("@ProductID", SqlDbType.Int);

            // this needs a save button at the end. 
            //sqlDA.Update(DtPrds);


            BindingSource PrdBindingSource = new BindingSource(DtPrds, "");

            ///         *************Simple Data Binding **************
            ///     This is single way binding. 
            /// That do not accept data source.
            /// Labels, 
            lblPrdID.DataBindings.Add("Text", PrdBindingSource, "ProductID");
            txtPrdName.DataBindings.Add("Text", PrdBindingSource, "ProductName");
            numUnitsInstock.DataBindings.Add("Value", PrdBindingSource, "UnitsInStock");


            btnMoveNext.Click += (sender, e) => PrdBindingSource.MoveNext();
            btnMovePrevious.Click += (sender, e) => PrdBindingSource.MovePrevious();

            BindingNavigator bindingNavigator = new BindingNavigator(PrdBindingSource);
            this.Controls.Add(bindingNavigator);
        }

        private void lstPrd_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Text = lstPrd.SelectedValue?.ToString() ?? "0";
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {

            sqlCn.Open();
                /*                      *******Very Important**********
                 The DataAdapter opend and closed a connection automatically when it getting the data.
                
                 But when we want to excute the update query on the original database, we have
                To open a conection manually on our own. 
                
                 */


            if ((decimal.TryParse(txtNewPrice.Text, out decimal PrdPrice)) && (lstPrd.SelectedItems.Count > 0))
            {
                 /* So we take the text box input as the unit price
                  * and when we select a productName from the Listbox, this 
                    Automatically gives us the ID
                 */
                sqlcmdUpdatePrice.Parameters["@UnitPrice"].Value = PrdPrice;
                sqlcmdUpdatePrice.Parameters["@ProductID"].Value =lstPrd.SelectedValue;

                // We still need to excute the cmd, we choose the non-query as it's an row update.
                // this just returns the `number of rows affected` but do not display any data. 
                if (sqlcmdUpdatePrice.ExecuteNonQuery() > 0)
                {

                    this.Text = "Done";
                }
                else
                    this.Text = "Error";
            }

            sqlCn.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
