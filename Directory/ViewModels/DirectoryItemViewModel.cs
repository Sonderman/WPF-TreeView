
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace TreeView
{
    public class DirectoryItemViewModel : BaseViewModel
    {
        public DirectoryItemType Type { get; set; }
        public string FullPath { get; set; }
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }

        public ObservableCollection<DirectoryItemViewModel> Children { get; set; }
        public bool CanExpand { get { return this.Type != DirectoryItemType.File; } }

        public ICommand ExpandCommand { get; set; }

        public DirectoryItemViewModel(string Fullpath, DirectoryItemType Type)
        {
            this.ExpandCommand = new RelayCommand(Expand);
            this.FullPath = Fullpath;
            this.Type = Type;
            this.ClearChildren();
        }

        public bool IsExpanded
        {
            get
            {

                return this.Children.Count(f => f != null) > 0;
            }
            set
            {

                if (value == true) Expand();
                else this.ClearChildren();
            }
        }

        private void ClearChildren()
        {
            this.Children = new ObservableCollection<DirectoryItemViewModel>();
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);
        }

        private void Expand()
        {
            if (this.Type == DirectoryItemType.File) return;
            this.Children = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetDirectoryContents(this.FullPath).Select(content => new DirectoryItemViewModel(content.FullPath, content.Type)));
        }
    }
}
