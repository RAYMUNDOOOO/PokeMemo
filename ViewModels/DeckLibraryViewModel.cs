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

namespace PokeMemo.ViewModels
{
    public partial class DeckLibraryViewModel : ObservableObject
    {
        public ObservableCollection<Deck> Decks { get; set; }
        public ICommand AddNewDeckCommand { get; }
        public DeckLibraryViewModel()
        {
            Decks = new ObservableCollection<Deck>();
            Decks.Add(new Deck("Multiplication Deck", "Maths", "#B3EFFF", "Black", "#5ADBFF"));
            Decks.Add(new Deck("Addition Deck", "Maths", "#93D48A", "Black", "#53A548"));

            AddNewDeckCommand = new RelayCommand(o => AddNewDeck());
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddNewDeck()
        {
            Decks.Add(new Deck("New Deck", "New Category", "#FFDD4A", "Black", "#FE9000"));
            OnPropertyChanged(nameof(Decks));
        }
    }
}
