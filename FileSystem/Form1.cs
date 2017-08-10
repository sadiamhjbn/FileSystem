using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class FormWindow : Form
    {
        string[] history;
        int historyIndex;
        int maxHistoryIndex;

        public FormWindow()
        {
            InitializeComponent();
            history = new string[20];
            historyIndex = 0;
            maxHistoryIndex = 0;
        }

        private void FormWindow_Load(object sender, EventArgs e)
        {
            listDirectory(FolderTreeView, "D:\\");
            LoadGridViewFromPath("D:\\");
        }

        private void listDirectory(TreeView treeView, string path)
        {
            treeView.Nodes.Clear();
            var rootDirectroyInfo = new DirectoryInfo(path);
            treeView.Nodes.Add(CreateDirectoryNode(rootDirectroyInfo));
        }

        private static TreeNode CreateDirectoryNode(DirectoryInfo rootDirectroyInfo)
        {
            var directoryNode = new TreeNode(rootDirectroyInfo.Name);
            try
            {
                foreach (var folder in rootDirectroyInfo.GetDirectories())
                {
                    directoryNode.Nodes.Add(CreateDirectoryNode(folder));
                }
            }
            catch (Exception)
            {
                
            }
            
            return directoryNode;
        }


        private void LoadFilesGridView(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadGridViewFromPath(e.Node.FullPath);
        }

        private void LoadGridViewFromPath(string path)
        {
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                return;
            }
            var files = directory.GetFiles().Select(item => new
            {
                Name = item.Name,
                DateModified = item.LastWriteTime.ToString(),
                DateCreated = item.CreationTime.ToString(),
                Size = (item.Length / 1024) + " KB",
                Type = item.Extension,
                FullPath = item.DirectoryName
            });
            var folders = directory.GetDirectories().Select(item => new
            {
                Name = item.Name,
                DateModified = item.LastWriteTime.ToString(),
                DateCreated = item.CreationTime.ToString(),
                Size = "",
                Type = "File Folder",
                FullPath = item.FullName
            }); ;

            var data = folders.Union(files).ToList();

            FilesGridView.DataSource = data;
            AddressTextBox.Text = path;

            history[historyIndex++] = path;
            maxHistoryIndex = (historyIndex > maxHistoryIndex) ? historyIndex : maxHistoryIndex;
        }

        private void OpenFolder(object sender, DataGridViewCellEventArgs e)
        {
            var row = FilesGridView.Rows[e.RowIndex];
            var cell = row.Cells[e.ColumnIndex];
            var path = row.Cells["FullPath"].Value.ToString();
            LoadGridViewFromPath(path);
        }

        private void LoadFromAddressBar(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadGridViewFromPath(AddressTextBox.Text);
            }
        }

        private void ForwardButtonClicked(object sender, EventArgs e)
        {
            if(historyIndex < maxHistoryIndex)
            {
                LoadGridViewFromPath(history[historyIndex]);
            }
        }

        private void BackwardButtonClicked(object sender, EventArgs e)
        {
            if(historyIndex > 1)
            {
                historyIndex-=2;
                LoadGridViewFromPath(history[historyIndex]);
            }
        }
    }
}
