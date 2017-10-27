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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWindow));
            this.FolderTreeView = new System.Windows.Forms.TreeView();
            this.FilesGridView = new System.Windows.Forms.DataGridView();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.hideButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.fileButton = new System.Windows.Forms.Button();
            this.folderButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.backwardButton = new System.Windows.Forms.Button();
            this.ForwardButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderTreeView
            // 
            this.FolderTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.FolderTreeView.Location = new System.Drawing.Point(12, 97);
            this.FolderTreeView.Name = "FolderTreeView";
            this.FolderTreeView.Size = new System.Drawing.Size(300, 452);
            this.FolderTreeView.TabIndex = 0;
            this.FolderTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeClicked);
            this.FolderTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodeDoubleClicked);
            // 
            // FilesGridView
            // 
            this.FilesGridView.AllowUserToOrderColumns = true;
            this.FilesGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilesGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.FilesGridView.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.FilesGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.FilesGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.FilesGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Sunken;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Lucida Sans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.FilesGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.FilesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FilesGridView.Location = new System.Drawing.Point(318, 97);
            this.FilesGridView.Name = "FilesGridView";
            this.FilesGridView.ReadOnly = true;
            this.FilesGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.FilesGridView.RowHeadersVisible = false;
            this.FilesGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.FilesGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.FilesGridView.Size = new System.Drawing.Size(454, 452);
            this.FilesGridView.TabIndex = 1;
            this.FilesGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.OpenFolder);
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AddressTextBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextBox.Location = new System.Drawing.Point(134, 65);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(557, 26);
            this.AddressTextBox.TabIndex = 2;
            this.AddressTextBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.LoadFromAddressBar);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 14F);
            this.label1.Location = new System.Drawing.Point(12, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Address Bar";
            // 
            // button5
            // 
            this.button5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(697, 65);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 26);
            this.button5.TabIndex = 10;
            this.button5.Text = "Load";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.LoadFromAddressBar);
            // 
            // hideButton
            // 
            this.hideButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.hideButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hideButton.FlatAppearance.BorderSize = 0;
            this.hideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.hideButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.hideButton.Image = global::FileSystem.Properties.Resources.hidden;
            this.hideButton.Location = new System.Drawing.Point(392, 12);
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(50, 50);
            this.hideButton.TabIndex = 11;
            this.hideButton.UseVisualStyleBackColor = true;
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.FlatAppearance.BorderSize = 0;
            this.deleteButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteButton.Image = global::FileSystem.Properties.Resources.remove1;
            this.deleteButton.Location = new System.Drawing.Point(720, 12);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(50, 50);
            this.deleteButton.TabIndex = 8;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // fileButton
            // 
            this.fileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.fileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.fileButton.FlatAppearance.BorderSize = 0;
            this.fileButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.fileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.fileButton.Image = global::FileSystem.Properties.Resources.file;
            this.fileButton.Location = new System.Drawing.Point(620, 12);
            this.fileButton.Name = "fileButton";
            this.fileButton.Size = new System.Drawing.Size(50, 50);
            this.fileButton.TabIndex = 7;
            this.fileButton.UseVisualStyleBackColor = true;
            this.fileButton.Click += new System.EventHandler(this.newFileButton_Click);
            // 
            // folderButton
            // 
            this.folderButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.folderButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.folderButton.FlatAppearance.BorderSize = 0;
            this.folderButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.folderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.folderButton.Image = global::FileSystem.Properties.Resources.folder;
            this.folderButton.Location = new System.Drawing.Point(564, 12);
            this.folderButton.Name = "folderButton";
            this.folderButton.Size = new System.Drawing.Size(50, 50);
            this.folderButton.TabIndex = 6;
            this.folderButton.UseVisualStyleBackColor = true;
            this.folderButton.Click += new System.EventHandler(this.newFolderButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.editButton.Image = global::FileSystem.Properties.Resources.edit;
            this.editButton.Location = new System.Drawing.Point(464, 12);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(50, 50);
            this.editButton.TabIndex = 5;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // backwardButton
            // 
            this.backwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.backwardButton.FlatAppearance.BorderSize = 0;
            this.backwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.backwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.backwardButton.Image = ((System.Drawing.Image)(resources.GetObject("backwardButton.Image")));
            this.backwardButton.Location = new System.Drawing.Point(12, 9);
            this.backwardButton.Name = "backwardButton";
            this.backwardButton.Size = new System.Drawing.Size(50, 50);
            this.backwardButton.TabIndex = 4;
            this.backwardButton.UseVisualStyleBackColor = false;
            this.backwardButton.Click += new System.EventHandler(this.BackwardButtonClicked);
            // 
            // ForwardButton
            // 
            this.ForwardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ForwardButton.FlatAppearance.BorderSize = 0;
            this.ForwardButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.ForwardButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ForwardButton.Image = global::FileSystem.Properties.Resources.next;
            this.ForwardButton.Location = new System.Drawing.Point(68, 9);
            this.ForwardButton.Name = "ForwardButton";
            this.ForwardButton.Size = new System.Drawing.Size(50, 50);
            this.ForwardButton.TabIndex = 3;
            this.ForwardButton.UseVisualStyleBackColor = true;
            this.ForwardButton.Click += new System.EventHandler(this.ForwardButtonClicked);
            // 
            // FormWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.hideButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.fileButton);
            this.Controls.Add(this.folderButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.backwardButton);
            this.Controls.Add(this.ForwardButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.FilesGridView);
            this.Controls.Add(this.FolderTreeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormWindow";
            this.Text = "File System";
            this.Load += new System.EventHandler(this.FormWindow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FilesGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView FolderTreeView;
        private System.Windows.Forms.DataGridView FilesGridView;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button ForwardButton;
        private System.Windows.Forms.Button backwardButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button folderButton;
        private System.Windows.Forms.Button fileButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button hideButton;
    }
}

