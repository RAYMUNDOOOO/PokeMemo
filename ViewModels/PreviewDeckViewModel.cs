using System;
using System.Collections.Generic;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Models;
using PokeMemo.Utility;
using System.ComponentModel;
using System.Runtime.CompilerServices;
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
        public ICommand ModifyCardCommand { get; }
        public ICommand DeleteSelectedCardsCommand { get; }
        
        public Card? SelectedCard { get; set; }
        public List<Card>? SelectedCards { get; set; }
        

        public PreviewDeckViewModel()
        {
            DeckLibrary = DataService.Instance.DeckLibrary;
            SelectedCards = new List<Card>();
            
            NavigateToDeckLibraryViewCommand = new RelayCommand(NavigateToDeckLibraryView);
            NavigateToCreateCardViewCommand = new RelayCommand<Card>(NavigateToCreateCardView);
            ModifyCardCommand = new RelayCommand(ModifyCard);
            DeleteSelectedCardsCommand = new RelayCommand(DeleteSelectedCards);
        }

        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        /*
         * Navigate to the same view to create a card, except overload the constructor of its
         * view model by passing in the selected card. This will prompt the view model
         * to set up the view for modification of the card instead.
         */
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

        private void DeleteSelectedCards()
        {
            if (SelectedCards?.Count > 0)
            {
                DeckLibrary?.SelectedDeck?.Cards.RemoveMany(SelectedCards);
            }
        }
    }
}
