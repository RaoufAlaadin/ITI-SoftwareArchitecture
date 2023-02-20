namespace _2_DetailedView
{
    public partial class DetailedView : Form
    {
        public DetailedView()
        {
            InitializeComponent();
        }

        SqlConnection sqlCn;
        SqlDataAdapter ProductAdapter;

        DataTable DTproduct;
        SqlCommand sqlCmd;

        private void DetailedView_Load(object sender, EventArgs e)
        {
            sqlCn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString
            );

            /* We hade to write sqlCmd reference here, to specify that we are going
             To use a stored procedure, just to spice it up.
                We could have used a normal query as usual.
            */
            sqlCmd = new SqlCommand("SelectAllProducts", sqlCn);
            sqlCmd.CommandType = CommandType.StoredProcedure;

            ProductAdapter = new SqlDataAdapter(sqlCmd);

            DTproduct = new DataTable();

            ProductAdapter.Fill(DTproduct);

            // Binding source Decleration
            BindingSource bs1 = new BindingSource();
            bs1.DataSource = DTproduct;  

            lstProducts.DisplayMember = "ProductName";
            lstProducts.ValueMember = "ProductID";
            lstProducts.DataSource = bs1;

            

            BindingNavigator bindNav = new BindingNavigator(bs1);
            this.Controls.Add(bindNav);

            lblProductID.DataBindings.Add("Text", bs1, "ProductID");
            txtProductName.DataBindings.Add("Text", bs1, "ProductName");

            InitComboBox(cmbSupplierName, "SELECT * FROM Suppliers", "CompanyName", "SupplierID");
            InitComboBox(cmbCategoryName, "SELECT * FROM Categories", "CategoryName", "CategoryID");

            /* 
             We get the selected value in the current binding source, and by retriving the Id's
             We can know the corspondant displayMember value
            */
            cmbSupplierName.DataBindings.Add("SelectedValue", bs1, "SupplierID");
            cmbCategoryName.DataBindings.Add("SelectedValue",  bs1, "CategoryID");

            numUnitsInStock.DataBindings.Add("Value", bs1, "UnitsInStock");
            txtUnitPrice.DataBindings.Add("Text", bs1, "UnitPrice");


            
            
        }

        private void InitComboBox(ComboBox comboBox, string query, string displayMember, string valueMember)
        {

            /* We don't need these sources again after we get the Data once, 
             As we are not going to write back to their original tables.
            */
            SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCn);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox.DataSource = dataTable;
            comboBox.DisplayMember = displayMember;
            comboBox.ValueMember = valueMember;

        }

        private void btnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                /* 
                 We declared the sqlCommandBuilder here as it's only use
                 when sending updates back to the original data.
                */
                SqlCommandBuilder builder = new SqlCommandBuilder(ProductAdapter);
                ProductAdapter.Update(DTproduct);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving data: " + ex.Message);
            }
        }
    }
}
