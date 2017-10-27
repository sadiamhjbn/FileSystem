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
        private bool _showHiddenFiles;

        /// <inheritdoc />
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

            LoadDrives();
        }

        private void LoadDrives()
        {
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
            FilesGridView.Rows[0].Selected = true;
        }

        /// <summary>
        /// Loads folder to GV
        /// </summary>
        /// <param name="path"></param>
        private void LoadGridViewFromPath(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                LoadDrives();
                return;
            }
            var directory = new DirectoryInfo(path);
            if (!directory.Exists)
            {
                return;
            }
            var files = directory.GetFiles()
                .Where(item => _showHiddenFiles || !item.Attributes.HasFlag(FileAttributes.Hidden))
                .Select(item => new
                {
                    item.Name,
                    DateModified = item.LastWriteTime.ToString(CultureInfo.InvariantCulture),
                    DateCreated = item.CreationTime.ToString(CultureInfo.InvariantCulture),
                    Size = (item.Length / 1024) + " KB",
                    Type = item.Extension,
                    FullPath = item.DirectoryName
                });
            var folders = directory.GetDirectories()
                .Where(item => !item.Attributes.HasFlag(FileAttributes.Hidden))
                .Select(item => new
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
            FilesGridView.Rows[0].Selected = true;
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
            if(e.RowIndex == -1) return;
            
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
            if (e.KeyCode == Keys.Enter)
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
            if (_historyIndex < _maxHistoryIndex)
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
            _historyIndex -= 2;
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

    

        private void LoadFromAddressBar(object sender, EventArgs e)
        {
            LoadGridViewFromPath(AddressTextBox.Text);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var row = FilesGridView.SelectedRows[0];
            var oldName = row.Cells["Name"].Value.ToString();
            var newName = Prompt.ShowDialog("Rename", "Rename to", oldName);
            if (newName == null) return;

            var path = row.Cells["FullPath"].Value.ToString();

            if (Directory.Exists(path + "\\..\\" + newName) || File.Exists(path + "\\" + newName))
            {
                MessageBox.Show(newName + @" already exists.");
                return;
            }
           
            if (File.Exists(path + "\\" + oldName))
            {
                Directory.Move(path + "/" + oldName, path + "/" + newName);
            }
            else
            {
                var lastSlashPos = path.LastIndexOf('\\');
                var parentDir = path.Substring(0, lastSlashPos + 1);
                new DirectoryInfo(path).MoveTo(parentDir + newName);
            }

            LoadGridViewFromPath(AddressTextBox.Text);
        }

        private void newFolderButton_Click(object sender, EventArgs e)
        {
           
            var folderName = Prompt.ShowDialog("New Folder", "Folder Name", null);
            if (folderName == null) return;

            var path = AddressTextBox.Text;

            if (Directory.Exists(path + "\\" + folderName))
            {
                MessageBox.Show(@"Target folder already exists.");
                return;
            }

            Directory.CreateDirectory(path + "\\" + folderName);

            LoadGridViewFromPath(path);
        }

        private void newFileButton_Click(object sender, EventArgs e)
        {

            var fileName = Prompt.ShowDialog("New File", "File Name", null);
            if (fileName == null) return;

            var path = AddressTextBox.Text;

            if (File.Exists(path + "\\" + fileName))
            {
                MessageBox.Show(@"Target file already exists.");
                return;
            }
            if (Directory.Exists(path + "\\" + fileName))
            {
                MessageBox.Show(@"A folder with indentical name already exists.");
                return;
            }

            File.Create(path + "\\" + fileName);

            LoadGridViewFromPath(path);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var res = MessageBox.Show(@"Are you sure?", @"Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (res == DialogResult.No)
                return;
            
            var rows = FilesGridView.SelectedRows;
            foreach (DataGridViewRow row in rows)
            {
                var oldName = row.Cells["Name"].Value.ToString();
                var path = row.Cells["FullPath"].Value.ToString();

                if (File.Exists(path + "\\" + oldName))
                {
                    try
                    {
                        File.Delete(path + "\\" + oldName);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
                else
                {
                    try
                    {
                        Directory.Delete(path);
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }
            }

            LoadGridViewFromPath(AddressTextBox.Text);
        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            _showHiddenFiles = !_showHiddenFiles;

            LoadFromAddressBar(sender, e);
        }
    }
}