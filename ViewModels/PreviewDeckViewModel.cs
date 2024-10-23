using System;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Models;
using PokeMemo.Utility;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;

namespace PokeMemo.ViewModels
{
    public partial class PreviewDeckViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }
        public ICommand ModifyCardCommand { get; }
        
        public Card SelectedCard { get; set; }

        public PreviewDeckViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToCreateCardViewCommand = new RelayCommand<Card>(NavigateToCreateCardView);
            ModifyCardCommand = new RelayCommand(ModifyCard);
        }

        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        private void NavigateToCreateCardView(Card? selectedCard)
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;

            if (selectedCard == null)
            {
                mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
            }
            else
            {
                mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(selectedCard);
            }
        }

        private void ModifyCard()
        {
            NavigateToCreateCardViewCommand.Execute(SelectedCard);
        }
    }
}
