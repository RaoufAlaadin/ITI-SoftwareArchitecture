using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using System.Diagnostics;
using System.Windows.Forms;

namespace NorthWind_WinApp
{
    public partial class frmPrdsGridView : Form
    {
        public frmPrdsGridView()
        {
            InitializeComponent();
            //this.Load += Form1_Load;
        }

        //private void Form1_Load(object sender, EventArgs e)
        //{

        //}



        TitleList TitleList;
        TitleManger TitleManger = new TitleManger();

        DataGridViewComboBoxColumn publisherColumn = new DataGridViewComboBoxColumn()
        {
            DataPropertyName = "pub_id",
            HeaderText = "Publisher",
            Name = "Publisher",
            DisplayMember = "pub_name",
            ValueMember = "pub_id"
        };

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /* Clearing everything so if `Read` is pressed agian, 
             There will be no duplicates. */
            grdViewPrds.DataSource = null;
            //grdViewPrds.Rows.Clear();
            grdViewPrds.Columns.Clear();
            

            // grid title data source
            TitleList = TitleManger.SelectAllTitles();
            grdViewPrds.DataSource = TitleList;

            // comboBox - Publisher data source
            publisherColumn.DataSource = PublisherManger.SelectAllPublishers();

            int PupColumnIndex = grdViewPrds.Columns["pub_id"].Index + 1; 
            grdViewPrds.Columns.Insert(PupColumnIndex,publisherColumn);



            this.WindowState = FormWindowState.Maximized;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Map the values in the grid to the Title objects
            foreach (DataGridViewRow row in grdViewPrds.Rows)
            {
                /*Skips empty rows like the one at the end of the grid,
                 that is there for you to input.
                */
                if (row.IsNewRow)
                    continue;

                int index = row.Index;
                Title title = TitleList[index];

                //1- title_ID

                title.title_id = row.Cells["title_id"].Value?.ToString() ?? "TC712";

                //2- title ( it's name)

                title.title = row.Cells["title"].Value?.ToString() ?? "NAzq";

                //3- title

                title.type = row.Cells["type"].Value?.ToString() ?? "Nazz";

                //4- title

                title.pub_id = row.Cells["pub_id"].Value?.ToString() ?? "0877";

                //5- title


                if (
                    decimal.TryParse(
                        row.Cells["price"].Value?.ToString() ?? "-1",
                        out decimal tempPrice
                    )
                )
                    title.price = tempPrice;

                //6- title

                if (
                    decimal.TryParse(
                        row.Cells["advance"].Value?.ToString() ?? "-1",
                        out decimal tempAdvance
                    )
                )
                    title.advance = tempAdvance;

                //7- title


                if (
                    int.TryParse(
                        row.Cells["royalty"].Value?.ToString() ?? "-1",
                        out int tempRoyalty
                    )
                )
                    title.royalty = tempRoyalty;

                //8- title


                if (
                    int.TryParse(
                        row.Cells["ytd_sales"].Value?.ToString() ?? "-1",
                        out int tempYtdSales
                    )
                )
                    title.ytd_sales = tempYtdSales;

                //9- title


                title.notes = row.Cells["notes"].Value?.ToString() ?? "NA";

                //10- title

                if (
                    DateTime.TryParse(
                        row.Cells["pubdate"].Value?.ToString() ?? "5/5/2020",
                        out DateTime tempPubDate
                    )
                )
                    title.pubdate = tempPubDate;

                if (title.State == EntityState.Added)
                {
                    //Insert the new record into the database
                    TitleManger.AddTitle(title);
                    MessageBox.Show($"Row added Row index( {row.Index} ) successfully.");
                }
                else if (title.State == EntityState.Changed)
                {
                    //Update the existing record in the database
                    TitleManger.UpdateTitle(title);
                    MessageBox.Show($"Update Row index( {row.Index} ) applied successfully.");
                }
                else if (title.State == EntityState.Deleted)
                {
                    //Delete the existing record from the database
                    TitleManger.DeleteTitle(title.title_id);
                    MessageBox.Show($"Row deleted Row index( {row.Index} ) successfully.");
                }

                //Reset the state of the Title object to Unchanged
                title.State = EntityState.UnChanged;
            }

            //Refresh the data in the grid
            //TitleList = TitleManger.SelectAllTitles();
            //    grdViewPrds.DataSource = TitleList;

            //MessageBox.Show("Changes saved successfully.");

            //grdViewPrds.Rows[newObjectIndex].Cells.
            foreach (var item in TitleList)
            {
                Trace.WriteLine(item.State);
            }
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TitleList.Add(new Title() { State = EntityState.Added });
            /*setting the DataSource resets the grid,before binding the TitleList again
             with the added updates*/
            grdViewPrds.DataSource = null;
            grdViewPrds.DataSource = TitleList;

            int PupColumnIndex = grdViewPrds.Columns["pub_id"].Index + 1;
            grdViewPrds.Columns.Insert(PupColumnIndex, publisherColumn);



        }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the selected row
            DataGridViewRow selectedRow = grdViewPrds.SelectedRows[0];

            // Get the corresponding Title object from the titleList
            Title selectedTitle = TitleList[selectedRow.Index];

            if (selectedTitle.State == EntityState.Added)
            {
                /* If it was just added, then it's not saved in the original
                 database yet, so just removing it's row from the grid
                and removing it's TitleList is enough for erasing the row*/

                // Remove the selected row from the grid
                grdViewPrds.Rows.Remove(selectedRow);
                TitleList.Remove(selectedTitle);
            }
            else
            {
                /*If not, then we have to keep the row alive until we save the changes
                 and remove his values from the original database,
                At the end of the save we a refreshing the dataSource,
                So we should be getting a clean view..*/
                // Set the deleted row's state to Deleted
                selectedTitle.State = EntityState.Deleted;
                selectedRow.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                selectedRow.DefaultCellStyle.BackColor = System.Drawing.Color.Red;

            }
        }
    }
}
