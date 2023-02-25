using BLL.Entity;
using BLL.EntityList;
using BLL.EntityManager;
using Microsoft.EntityFrameworkCore;
using NorthWind_WinApp.Context;
using System.CodeDom;
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

            // instead of finally for closing connection I guess.
            this.FormClosed += (sender, e) => context?.Dispose();
        }


        pubsContext context = new pubsContext();

        DataGridViewComboBoxColumn publisherColumn = new DataGridViewComboBoxColumn()
        {
            DataPropertyName = "PubId",
            HeaderText = "Publisher",
            Name = "Publisher",
            DisplayMember = "PubName",
            ValueMember = "PubId"
        };

        private void readToolStripMenuItem_Click(object sender, EventArgs e)
        {
            grdViewPrds.Columns.Clear();
            grdViewPrds.DataSource = null;

             // this also an option that might work.
            //context = new pubsContext();

            context.Titles.Load();
            context.Publishers.Load();

            this.grdViewPrds.DataSource = context.Titles.Local.ToBindingList();
            this.publisherColumn.DataSource = context.Publishers.Local.ToBindingList();

            int PupColumnIndex = grdViewPrds.Columns["PubId"].Index + 1;
            grdViewPrds.Columns.Insert(PupColumnIndex, publisherColumn);

            //if (!grdViewPrds.Columns.Contains(publisherColumn))
            //{
            //    grdViewPrds.Columns.Insert(PupColumnIndex, publisherColumn);
            //}

            this.WindowState = FormWindowState.Maximized;
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
        }

        private void addRowToolStripMenuItem_Click(object sender, EventArgs e) { }

        private void deleteRowToolStripMenuItem_Click(object sender, EventArgs e) { }
    }
}
