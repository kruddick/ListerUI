using ListerUI.Enums;
using System.ComponentModel;

namespace ListerUI.Models.ViewModels
{
    public class NavigationMenuViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public List<string> MenuItems { get; set; }
            = new List<string>() { "Lists", "Process List", "Edit List" };

        private NavItems _selectedMenuItem = NavItems.Lists;

        public NavItems SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }
            set
            {
                if (value != _selectedMenuItem)
                {
                    _selectedMenuItem = value;

                    PropertyChanged?.Invoke(this,
                        new PropertyChangedEventArgs(nameof(SelectedMenuItem)));
                }
            }
        }

    }
}
