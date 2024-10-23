using System;
using System.Collections.Generic;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Models;
using PokeMemo.Utility;
using System.Windows.Input;
using Avalonia;
using CommunityToolkit.Mvvm.Input;
using DynamicData;

namespace PokeMemo.ViewModels
{
    public partial class PreviewDeckViewModel : ViewModelBase
    {
        private DeckLibrary DeckLibrary { get; }
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }
        public ICommand DeleteSelectedCardCommand { get; }
        
        public List<Card> SelectedCards { get; set; }

        public PreviewDeckViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToCreateCardViewCommand = new RelayCommand(NavigateToCreateCardView);
            DeleteSelectedCardCommand = new RelayCommand(DeleteSelectedCards);
            
            SelectedCards = new List<Card>();
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

        private void DeleteSelectedCards()
        {
            try
            {
                DeckLibrary?.SelectedDeck?.Cards.RemoveMany(SelectedCards);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
