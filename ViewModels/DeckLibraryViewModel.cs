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

        public ICommand NavigateToCreateDeckViewCommand { get; }
        public ICommand NavigateToQuizViewCommand { get; }
        public ICommand NavigateToPreviewDeckViewCommand { get; }

        public DeckLibraryViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToCreateDeckViewCommand = new RelayCommand(o => NavigateToCreateDeckView());
            NavigateToQuizViewCommand = new RelayCommand(o => NavigateToQuizView());
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NavigateToCreateDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateDeckViewCommand.Execute(null);
        }
        private void NavigateToQuizView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToQuizViewCommand.Execute(null);
        }
        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

    }
}