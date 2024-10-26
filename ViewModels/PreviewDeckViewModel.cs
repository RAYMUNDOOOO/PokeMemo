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
    // This ViewModel is responsible for handling the logic of the PreviewDeck view (called View Deck in the app)
    public partial class PreviewDeckViewModel : ViewModelBase
    {
        // The DeckLibrary instance is initialized with the DataService's DeckLibrary instance
        private DeckLibrary DeckLibrary { get; }

        // Commands to navigate to other views
        public ICommand NavigateToDeckLibraryViewCommand { get; }
        public ICommand NavigateToCreateCardViewCommand { get; }
        public ICommand ModifyCardCommand { get; }
        public ICommand DeleteSelectedCardsCommand { get; }
        public ICommand ModifyDeckCommand { get; }
        public ICommand DeleteDeckCommand { get; }

        // The SelectedCard property / list of SelectedCards is used to store the card(s) that the user has selected
        // This is passed to the CreateCardViewModel when the user wants to modify a card
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
            ModifyDeckCommand = new RelayCommand(ModifyDeck);
            DeleteDeckCommand = new RelayCommand(DeleteDeck);
        }

        // The following methods are used to navigate to other views - they link to the commands above
        private void NavigateToDeckLibraryView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToDeckLibraryViewCommand.Execute(null);
        }

        /*
         * Navigate to the same view to create a card, except overload the constructor of its
         * view model by passing in the selected card. This will prompt the view model
         * to set up the view for modification of the card instead.
         */
        private void NavigateToCreateCardView(Card? selectedCard)
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;

            if (selectedCard == null)
            {
                mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(null);
            }
            else
            {
                mainWindowViewModel?.NavigateToCreateCardViewCommand.Execute(selectedCard);
            }
        }

        // Works with the above method to modify the selected card
        private void ModifyCard()
        {
            NavigateToCreateCardViewCommand.Execute(SelectedCard);
        }

        // Delete the selected card(s) from the deck
        private void DeleteSelectedCards()
        {
            if (SelectedCards?.Count > 0)
            {
                DeckLibrary?.SelectedDeck?.Cards.RemoveMany(SelectedCards);
            }
        }
        
        // Modify the selected deck
        private void ModifyDeck()
        {
            
        }
        
        // Delete the selected deck
        private void DeleteDeck()
        {
            
        }
    }
}
