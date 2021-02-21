using System.Collections.ObjectModel;
using System.Linq;

namespace TreeView
{
    public class DirectoryStructureViewModel: BaseViewModel
    {
        public ObservableCollection<DirectoryItemViewModel> Items { get; set; }

        public DirectoryStructureViewModel()
        {

            this.Items = new ObservableCollection<DirectoryItemViewModel>(DirectoryStructure.GetlogicalDrives().Select(drive => 
            new DirectoryItemViewModel(drive.FullPath,DirectoryItemType.Drive)));
        }
    }
}
