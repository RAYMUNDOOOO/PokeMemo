using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;

namespace PokeMemo.ViewModels
{
    public partial class ModifyDeckViewModel : ViewModelBase
    {
        public ICommand NavigateToDeckLibraryViewCommand { get; }

        public ModifyDeckViewModel()
        {
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
        }

        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }
    }
}