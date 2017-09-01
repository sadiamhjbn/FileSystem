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

        /// <summary>
        /// Constructor
        /// </summary>
        public FormWindow()
        {
            InitializeComponent();
            _history = new string[20];
            _historyIndex = 0;
            _maxHistoryIndex = 0;
        }

        /// <summary>
        /// Initially loads GV and TV with drives    
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Loads folder to GV
        /// </summary>
        /// <param name="path"></param>
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

        /// <summary>
        /// Opens a folder on DG cell click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OpenFolder(object sender, DataGridViewCellEventArgs e)
        {
            var row = FilesGridView.Rows[e.RowIndex];
            var path = row.Cells["FullPath"].Value.ToString();
            LoadGridViewFromPath(path);
        }

        /// <summary>
        /// Opens a folder from address bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoadFromAddressBar(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                LoadGridViewFromPath(AddressTextBox.Text);
            }
        }

        /// <summary>
        /// Goes back to previous folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ForwardButtonClicked(object sender, EventArgs e)
        {
            if(_historyIndex < _maxHistoryIndex)
            {
                LoadGridViewFromPath(_history[_historyIndex]);
            }
        }

        /// <summary>
        /// Opens previous folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BackwardButtonClicked(object sender, EventArgs e)
        {
            if (_historyIndex <= 1) return;
            _historyIndex-=2;
            LoadGridViewFromPath(_history[_historyIndex]);
        }

        /// <summary>
        /// Opens corresponding folder on node click
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (e.Node.Nodes.Count != 0 && e.Node.Nodes.Count == folders.Length) return;
            foreach (var folder in folders)
            {
                e.Node.Nodes.Add(folder.Name);
            }

            e.Node.Expand();

            LoadGridViewFromPath(path);
        }

        /// <summary>
        /// Node double click handler
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NodeDoubleClicked(object sender, TreeNodeMouseClickEventArgs e)
        {
            LoadGridViewFromPath(e.Node.FullPath);
        }
    }
}
