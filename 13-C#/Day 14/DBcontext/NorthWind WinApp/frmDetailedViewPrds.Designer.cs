namespace NorthWind_WinApp
{
    partial class frmDetailedViewPrds
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
            this.components = new System.ComponentModel.Container();
            this.txtTitleName = new System.Windows.Forms.TextBox();
            this.titleBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.txtType = new System.Windows.Forms.TextBox();
            this.cmbPublisherName = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.RichTextBox();
            this.Title_ID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtTitleID = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitleName
            // 
            this.txtTitleName.Location = new System.Drawing.Point(109, 104);
            this.txtTitleName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTitleName.Name = "txtTitleName";
            this.txtTitleName.Size = new System.Drawing.Size(110, 23);
            this.txtTitleName.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(587, 88);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(82, 22);
            this.button1.TabIndex = 3;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtType
            // 
            this.txtType.Location = new System.Drawing.Point(109, 147);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(100, 23);
            this.txtType.TabIndex = 4;
            // 
            // cmbPublisherName
            // 
            this.cmbPublisherName.FormattingEnabled = true;
            this.cmbPublisherName.Location = new System.Drawing.Point(364, 104);
            this.cmbPublisherName.Name = "cmbPublisherName";
            this.cmbPublisherName.Size = new System.Drawing.Size(121, 23);
            this.cmbPublisherName.TabIndex = 5;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(343, 150);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(196, 137);
            this.txtNotes.TabIndex = 6;
            this.txtNotes.Text = "";
            // 
            // Title_ID
            // 
            this.Title_ID.AutoSize = true;
            this.Title_ID.Location = new System.Drawing.Point(40, 68);
            this.Title_ID.Name = "Title_ID";
            this.Title_ID.Size = new System.Drawing.Size(45, 15);
            this.Title_ID.TabIndex = 7;
            this.Title_ID.Text = "Title_ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Title_Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 147);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(288, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Price";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(251, 107);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Publisher_Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(283, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Notes";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(364, 60);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(100, 23);
            this.txtPrice.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(587, 140);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(82, 22);
            this.button2.TabIndex = 14;
            this.button2.Text = "Delete";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtTitleID
            // 
            this.txtTitleID.Location = new System.Drawing.Point(109, 65);
            this.txtTitleID.Name = "txtTitleID";
            this.txtTitleID.Size = new System.Drawing.Size(100, 23);
            this.txtTitleID.TabIndex = 15;
            // 
            // frmDetailedViewPrds
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 338);
            this.Controls.Add(this.txtTitleID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Title_ID);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cmbPublisherName);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTitleName);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmDetailedViewPrds";
            this.Text = "frmDetailedViewPrds";
            this.Load += new System.EventHandler(this.frmDetailedViewPrds_Load);
            ((System.ComponentModel.ISupportInitialize)(this.titleBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtTitleName;
        private BindingSource titleBindingSource;
        private Button button1;
        private TextBox txtType;
        private ComboBox cmbPublisherName;
        private RichTextBox txtNotes;
        private Label Title_ID;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label1;
        private TextBox txtPrice;
        private Button button2;
        private TextBox txtTitleID;
    }
}