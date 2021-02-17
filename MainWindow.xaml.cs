using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;


namespace TreeView
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructor
        public MainWindow()
        {
            InitializeComponent();
        }
        #endregion

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var drive in Directory.GetLogicalDrives())
            {
                var item = new TreeViewItem()
                {
                    Header = drive,
                    Tag = drive
                };

                //item.Header = drive;
                //item.Tag = drive;
                item.Items.Add(null);
                item.Expanded += Folder_expanded;
                FolderView.Items.Add(item);
            }

        }

        private void Folder_expanded(object sender, RoutedEventArgs e)
        {
            var item = (TreeViewItem)sender;
            if (item.Items.Count != 1 && item.Items[0] != null)
                return;
            item.Items.Clear();

            var fullPath = (string)item.Tag;
            #region GetFolders
            var directories = new List<string>();
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    directories.AddRange(dirs);
            }
            catch (Exception)
            { }
            directories.ForEach(directoryPath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(directoryPath),
                    Tag = directoryPath,
                };
                subItem.Items.Add(null);
                subItem.Expanded += Folder_expanded;
                item.Items.Add(subItem);
            });
            #endregion

            #region GetFiles
            var files = new List<string>();
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    directories.AddRange(fs);
            }
            catch (Exception)
            { }
            directories.ForEach(filePath =>
            {
                var subItem = new TreeViewItem()
                {
                    Header = GetFileFolderName(filePath),
                    Tag = filePath,
                };


                item.Items.Add(subItem);
            });
            #endregion
        }

        public static string GetFileFolderName(string path)
        {
            if (string.IsNullOrEmpty(path))
                return string.Empty;
            var nomalizedPath = path.Replace('/', '\\');
            var lastIndex = nomalizedPath.LastIndexOf('\\');
            if (lastIndex <= 0)
                return path;
            return path.Substring(lastIndex + 1);
        }
    }
}
