

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TreeView
{
    public static class  DirectoryStructure
    {
        public static List<DirectoryItem> GetlogicalDrives()
        {
            return  Directory.GetLogicalDrives().Select(drive => new DirectoryItem
            {
                FullPath = drive,
                Type = DirectoryItemType.Drive
            }).ToList();
           
        }

        public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();

            #region GetFolders
            
            try
            {
                var dirs = Directory.GetDirectories(fullPath);
                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir=> new DirectoryItem { 
                    FullPath=dir,Type=DirectoryItemType.Folder
                    }));;
            }
            catch (Exception)
            { }
           
            #endregion

            #region GetFiles
             
            try
            {
                var fs = Directory.GetFiles(fullPath);
                if (fs.Length > 0)
                    items.AddRange(fs.Select(file => new DirectoryItem {FullPath=file,Type=DirectoryItemType.File }));
            }
            catch (Exception)
            { }

            #endregion
            return items;
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
