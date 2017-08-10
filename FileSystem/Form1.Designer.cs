namespace FileSystem
{
    partial class FormWindow
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
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.FilesGridView = new System.Windows.Forms.DataGridView();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.Backward = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FolderTreeView.Location = new System.Drawing.Point(12, 38);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.Size = new System.Drawing.Size(300, 511);
            this.FolderTreeView.TabIndex = 0;
            this.FolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.LoadFilesGridView);
            // 
            // FilesGridView
            // 
            this.FilesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.FilesGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FilesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.FilesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesGridView.Location = new System.Drawing.Point(318, 38);
            this.FilesGridView.Name = "FilesGridView";
            this.FilesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FilesGridView.Size = new System.Drawing.Size(454, 511);
            this.FilesGridView.TabIndex = 1;
            this.FilesGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OpenFolder);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(318, 12);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(454, 20);
            this.AddressTextBox.TabIndex = 2;
            this.AddressTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoadFromAddressBar);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(237, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Forward";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ForwardButtonClicked);
            // 
            // Backward
            // 
            this.Backward.Location = new System.Drawing.Point(12, 9);
            this.Backward.Name = "Backward";
            this.Backward.Size = new System.Drawing.Size(75, 23);
            this.Backward.TabIndex = 4;
            this.Backward.Text = "Backward";
            this.Backward.UseVisualStyleBackColor = true;
            this.Backward.Click += new System.EventHandler(this.BackwardButtonClicked);
            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.Backward);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.FilesGridView);
            this.Controls.Add(this.FolderTreeView);
            this.Name = "FormWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.DataGridView FilesGridView;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Backward;
    }
}

