using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using PokeMemo.Models;
using CommunityToolkit.Mvvm.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Utility;

namespace PokeMemo.ViewModels
{
    // This ViewModel is responsible for handling the logic of the DeckLibrary view.
    public partial class DeckLibraryViewModel : ViewModelBase
    {
        // The DeckLibrary instance is initialized with the DataService's DeckLibrary instance
        private DeckLibrary DeckLibrary { get; }

        // Commands to navigate to other views
        public ICommand NavigateToCreateDeckViewCommand { get; }
        public ICommand NavigateToQuizViewCommand { get; }
        public ICommand NavigateToPreviewDeckViewCommand { get; }

        public DeckLibraryViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToCreateDeckViewCommand = new RelayCommand(NavigateToCreateDeckView);
            NavigateToQuizViewCommand = new RelayCommand(NavigateToQuizView);
            NavigateToPreviewDeckViewCommand = new RelayCommand(NavigateToPreviewDeckView);
        }

        // The following methods are used to navigate to other views - they link to the commands above
        private void NavigateToCreateDeckView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateDeckViewCommand.Execute(null);
        }
        private void NavigateToQuizView()
        {
            if (DeckLibrary.SelectedDeck != null)
            {
                var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
                mainWindowViewModel?.NavigateToQuizViewCommand.Execute(null);
            }
        }
        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

    }
}