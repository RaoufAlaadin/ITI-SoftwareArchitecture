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
    public partial class frmGridView : Form
    {
        public frmGridView()
        {
            InitializeComponent();
        }

        SqlConnection sqlCn;
        SqlCommand sqlCmd;
        SqlDataAdapter sqlDA;

        /* This holds the Dissconnected copy from the data we imported.  */
        DataTable DtPrds;


        private void frmGridView_Load(object sender, EventArgs e)
        {

            sqlCn = new SqlConnection(ConfigurationManager.ConnectionStrings["NorthWindCN"].ConnectionString);
            sqlCmd = new SqlCommand("select * from products", sqlCn);

            // Must be given a select command, which is sqlCmd here.

            /* When you pass a sqlCmdd to the DataAdapter constructor, 
             It assumes it's a select command. 
            */
            sqlDA = new SqlDataAdapter(sqlCmd);
            DtPrds = new DataTable();


            /* 
             * The command builder gives the DataAdapter the rest of the CRUD
             without us writing them specificly for a table I guess.

         commandBuilder a template of stored procedures I guess
            */
            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(sqlDA);
            sqlDA.InsertCommand = commandBuilder.GetInsertCommand();
            sqlDA.UpdateCommand = commandBuilder.GetUpdateCommand();
            sqlDA.DeleteCommand = commandBuilder.GetDeleteCommand();



        }

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {

             /*
               Excutes select command for SqlDA
               This fills the DataTable we created by the data the DataAdapter got 
               when excuting the select command when the form loaded.
             */ 

                /* Note that: the DataAdapter opened and closed the conenction on it's own. !!  */
            sqlDA.Fill(DtPrds);

            /* `Complex Data binding`
             * this is double way binding by default, but we have to give the 
             * insert,update,delete commands.
             We set the source of the data.
                
             */


           
                grdPrds.DataSource = DtPrds;
            
        }

      

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                foreach (DataRow row in DtPrds.Rows)
                {
                    Debug.WriteLine(row.RowState);
                }
      

            /* 
             *Commits the edits you made to the grid. 
             */
            grdPrds.EndEdit();

                /* This is meant to Update the original database with 
                 all the insert,delete and update commadns we did on the DataTable (DtPrd)
                that we fetched. 
                
                it  DOES NOT mean the update statement.
                */
            sqlDA.Update(DtPrds);

        }
    }
}
