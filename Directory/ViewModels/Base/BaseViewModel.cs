using PropertyChanged;
using System.ComponentModel;

namespace TreeView
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged =(sender, e)=>{};
    }
}
