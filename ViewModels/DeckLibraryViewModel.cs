using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PokeMemo.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Utility;

namespace PokeMemo.ViewModels
{
    public partial class DeckLibraryViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }

        public ICommand NavigateToAddDeckViewCommand { get; }
        public ICommand NavigateToPreviewDeckViewCommand { get; }

        public DeckLibraryViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToAddDeckViewCommand = new RelayCommand(o => NavigateToAddDeckView());
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NavigateToAddDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToAddDeckViewCommand.Execute(null);
        }

        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }
    }
}


