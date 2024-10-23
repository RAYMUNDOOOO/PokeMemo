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
    public partial class DeckLibraryViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }

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

        private void NavigateToCreateDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateDeckViewCommand.Execute(null);
        }
        private void NavigateToQuizView()
        {
            if (DeckLibrary.SelectedDeck != null)
            {
                var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
                mainWindowViewModel?.NavigateToQuizViewCommand.Execute(null);
            }
        }
        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

    }
}