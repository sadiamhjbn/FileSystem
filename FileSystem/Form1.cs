using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FileSystem
{
    public partial class FormWindow : Form
    {
        private readonly string[] _history;
        private int _historyIndex;
        private int _maxHistoryIndex;

        public FormWindow()
        {
            InitializeComponent();
            _history = new string[20];
            _historyIndex = 0;
            _maxHistoryIndex = 0;
        }

        private void FormWindow_Load(object sender, EventArgs e)
        {
            FolderTreeView.Nodes.Clear();
            foreach (var path in Directory.GetLogicalDrives())
            {
                FolderTreeView.Nodes.Add(path);
            }

            var drives = Directory.GetLogicalDrives().Select(drive => new
            {
                Name = drive,
                DateModified = "N\\A",
                DateCreated = "N\\A",
                Size = "N\\A",
                Type = "Disk Drive",
                FullPath = drive
            }).ToList();

            FilesGridView.DataSource = drives;
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
                item.Name,
                DateModified = item.LastWriteTime.ToString(CultureInfo.InvariantCulture),
                DateCreated = item.CreationTime.ToString(CultureInfo.InvariantCulture),
                Size = (item.Length / 1024) + " KB",
                Type = item.Extension,
                FullPath = item.DirectoryName
            });
            var folders = directory.GetDirectories().Select(item => new
            {
                item.Name,
                DateModified = item.LastWriteTime.ToString(CultureInfo.InvariantCulture),
                DateCreated = item.CreationTime.ToString(CultureInfo.InvariantCulture),
                Size = "",
                Type = "File Folder",
                FullPath = item.FullName
            }); 

            var data = folders.Union(files).ToList();

            FilesGridView.DataSource = data;
            AddressTextBox.Text = path;

            _history[_historyIndex++] = path;
            _maxHistoryIndex = (_historyIndex > _maxHistoryIndex) ? _historyIndex : _maxHistoryIndex;
        }

        private void OpenFolder(object sender, DataGridViewCellEventArgs e)
        {
            var row = FilesGridView.Rows[e.RowIndex];
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
            if(_historyIndex < _maxHistoryIndex)
            {
                LoadGridViewFromPath(_history[_historyIndex]);
            }
        }

        private void BackwardButtonClicked(object sender, EventArgs e)
        {
            if(_historyIndex > 1)
            {
                _historyIndex-=2;
                LoadGridViewFromPath(_history[_historyIndex]);
            }
        }

        private void NodeClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            var path = e.Node.FullPath;
            var directory = new DirectoryInfo(path);
            DirectoryInfo[] folders;

            try
            {
                folders = directory.GetDirectories();
            }
            catch (Exception)
            {
                folders = new DirectoryInfo[0];
            }

            if (e.Node.Nodes.Count == 0 || e.Node.Nodes.Count != folders.Length)
            {
                foreach (var folder in folders)
                {
                    e.Node.Nodes.Add(folder.Name);
                }

                e.Node.Expand();

                LoadGridViewFromPath(path);
            }
        }

        private void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadGridViewFromPath(e.Node.FullPath);
        }
    }
}
