

/* VERY IMPORTANT !!! */
global using Microsoft.Data.SqlClient;
global using System.Configuration;
global using System.Data;


namespace Lecutre_ADO.net_testing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection sqlCn;
        SqlCommand sqlCmd;

        private void Form1_Load(object sender, EventArgs e)
        {
            sqlCn = new SqlConnection();
            /* The connectionSrting is like a config file for when I later want to open the connection.*/

            /* Trust server certificate = true  or Encrypt = false
             are essintial step nowaday,
            else we would get an error.

            We should write this connection string in the config file, So won't need to re-build the
            whole program just to change the name of the server we are importing from.
                        ===> App.config --- written in XML. 

            @ symbol ==> verbatim string literal , helps you write without needing escape characters.
            */

            sqlCn.ConnectionString = ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString;

            /*     sqlCn.ConnectionString = 
                     @"Data source = .;" +
                     " initial catalog = NorthWind;" +
                     " integrated security = true;" +
                     " Encrypt = false ";*/
            /* DO NOT WRITE ID/PASS IN C# CODE => as it can be reversed back using ILSPY
                So most of the time we use windows authentication.
             */


            /*sqlCn have 3 avialable events => 1-disposed...  2-info messge...3-  stateChange*/
            /* note: Anonymous function captures outer variable.*/

            /* When fired it takes the arguments from sqlCn... I guess. */


            this.Text = $" BranchID: {ConfigurationManager.AppSettings["branchID"]}";
           /* sqlCn.StateChange += (sender, e) =>
                    this.Text = $"State was {e.OriginalState}, currentState{e.CurrentState}";*/

            /* if we are using the Dissconnected method. 
             * then this means the opening and closing of connection is done automatically. 
             */
            sqlCmd = new SqlCommand();

            sqlCmd.Connection = sqlCn;

            //sqlCmd.CommandType = CommandType.Text; // default
            // we can also set it to == > //sqlCmd.CommandType = CommandType.StoredProcedure;

          /*This will generate a Scalar value as it returnds a single value.*/
            //sqlCmd.CommandText = "select count(*) from Products";
            sqlCmd.CommandText = "select * from Products";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            /* Without including the using upthere I would have to write
             System.Data.ConnectionState
            They only available enums and Open and closed, the others are placeholders
            */
            if (sqlCn.State == ConnectionState.Closed)
                sqlCn.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (sqlCn.State == ConnectionState.Open)

                sqlCn.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (sqlCn.State == ConnectionState.Closed)
                sqlCn.Open();


            /* How can we Excute ?!   ExcuteNonQuery  ==> return int ==> insert,update,delete and revoke.
                                      ExcuteReader => returns sqlReader => select
                                      ExcuteScalar => one value
                                      ExcuteXmlReader => xml file. 
             */

            //this.Text = sqlCmd.ExecuteScalar()?.ToString()?? "-1";

            SqlDataReader Dr = sqlCmd.ExecuteReader();
                /*  .Read() keeps advancing the pointer to the next row and return
                     false when it reaches the end. 
                */
             while(Dr.Read())
            {   
                // we reach the list box items property, then we add the rows
                // from the specificed column , row by row.
                this.lstProductName.Items.Add(Dr.GetString("ProductName"));

                // DataReader is Read only, you can't use it to modify the `Column name`; 
                //Dr["ProductName"] = "newProductName"; 
            }
             
             // Invalid, data reader doesn't support Binding// Invalid, data reader doesn't support Binding
            //lstProductName.DataSource = Dr; 

            sqlCn.Close();

        }

        private void lstProductName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
