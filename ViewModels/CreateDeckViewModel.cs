using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;

namespace PokeMemo.ViewModels
{
    public partial class CreateDeckViewModel : ViewModelBase
    {

        public ICommand NavigateToDeckLibraryViewCommand { get; }

        public CreateDeckViewModel()
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
