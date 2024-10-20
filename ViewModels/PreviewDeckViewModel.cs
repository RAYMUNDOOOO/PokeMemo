using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Models;
using PokeMemo.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia;

namespace PokeMemo.ViewModels
{
    public partial class PreviewDeckViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }

        public PreviewDeckViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(o => NavigateToDeckLibraryView());
            NavigateToCreateCardViewCommand = new RelayCommand(o => NavigateToCreateCardView());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToCreateCardView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
        }
    }
}