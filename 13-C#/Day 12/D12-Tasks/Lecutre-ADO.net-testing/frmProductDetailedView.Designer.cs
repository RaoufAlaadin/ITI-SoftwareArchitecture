namespace Lecutre_ADO.net_testing
{
    partial class frmProductDetailedView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstPrd = new System.Windows.Forms.ListBox();
            this.txtNewPrice = new System.Windows.Forms.TextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.numUnitsInstock = new System.Windows.Forms.NumericUpDown();
            this.txtPrdName = new System.Windows.Forms.TextBox();
            this.lblPrdID = new System.Windows.Forms.Label();
            this.btnMovePrevious = new System.Windows.Forms.Button();
            this.btnMoveNext = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInstock)).BeginInit();
            this.SuspendLayout();
            // 
            // lstPrd
            // 
            this.lstPrd.FormattingEnabled = true;
            this.lstPrd.ItemHeight = 15;
            this.lstPrd.Location = new System.Drawing.Point(592, 35);
            this.lstPrd.Name = "lstPrd";
            this.lstPrd.Size = new System.Drawing.Size(147, 334);
            this.lstPrd.TabIndex = 0;
            this.lstPrd.SelectedIndexChanged += new System.EventHandler(this.lstPrd_SelectedIndexChanged);
            // 
            // txtNewPrice
            // 
            this.txtNewPrice.Location = new System.Drawing.Point(208, 346);
            this.txtNewPrice.Name = "txtNewPrice";
            this.txtNewPrice.PlaceholderText = "Enter a new price";
            this.txtNewPrice.Size = new System.Drawing.Size(204, 23);
            this.txtNewPrice.TabIndex = 1;
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(449, 346);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 2;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // numUnitsInstock
            // 
            this.numUnitsInstock.Location = new System.Drawing.Point(92, 152);
            this.numUnitsInstock.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUnitsInstock.Name = "numUnitsInstock";
            this.numUnitsInstock.Size = new System.Drawing.Size(120, 23);
            this.numUnitsInstock.TabIndex = 3;
            // 
            // txtPrdName
            // 
            this.txtPrdName.Location = new System.Drawing.Point(92, 98);
            this.txtPrdName.Name = "txtPrdName";
            this.txtPrdName.PlaceholderText = "Enter the Product name...";
            this.txtPrdName.Size = new System.Drawing.Size(204, 23);
            this.txtPrdName.TabIndex = 4;
            // 
            // lblPrdID
            // 
            this.lblPrdID.AutoSize = true;
            this.lblPrdID.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPrdID.Location = new System.Drawing.Point(92, 69);
            this.lblPrdID.Name = "lblPrdID";
            this.lblPrdID.Size = new System.Drawing.Size(75, 20);
            this.lblPrdID.TabIndex = 6;
            this.lblPrdID.Text = "ProductID";
            this.lblPrdID.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnMovePrevious
            // 
            this.btnMovePrevious.Location = new System.Drawing.Point(83, 209);
            this.btnMovePrevious.Name = "btnMovePrevious";
            this.btnMovePrevious.Size = new System.Drawing.Size(75, 23);
            this.btnMovePrevious.TabIndex = 7;
            this.btnMovePrevious.Text = "<\r\n";
            this.btnMovePrevious.UseVisualStyleBackColor = true;
            // 
            // btnMoveNext
            // 
            this.btnMoveNext.Location = new System.Drawing.Point(238, 209);
            this.btnMoveNext.Name = "btnMoveNext";
            this.btnMoveNext.Size = new System.Drawing.Size(75, 23);
            this.btnMoveNext.TabIndex = 8;
            this.btnMoveNext.Text = ">";
            this.btnMoveNext.UseVisualStyleBackColor = true;
            // 
            // frmProductDetailedView
            // 
            this.AcceptButton = this.btnExcute;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMoveNext);
            this.Controls.Add(this.btnMovePrevious);
            this.Controls.Add(this.lblPrdID);
            this.Controls.Add(this.txtPrdName);
            this.Controls.Add(this.numUnitsInstock);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.txtNewPrice);
            this.Controls.Add(this.lstPrd);
            this.Name = "frmProductDetailedView";
            this.Text = "frmProductDetailedView";
            this.Load += new System.EventHandler(this.frmProductDetailedView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numUnitsInstock)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListBox lstPrd;
        private TextBox txtNewPrice;
        private Button btnExcute;
        private NumericUpDown numUnitsInstock;
        private TextBox txtPrdName;
        private Label lblPrdID;
        private Button btnMovePrevious;
        private Button btnMoveNext;
    }
}