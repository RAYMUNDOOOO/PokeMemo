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

namespace PokeMemo.ViewModels
{
    public partial class DeckLibraryViewModel : ViewModelBase
    {
        public ObservableCollection<Deck> Decks { get; set; }
        public ICommand NavigateToAddDeckViewCommand { get; }
        public DeckLibraryViewModel()
        {
            Decks = new ObservableCollection<Deck>();
            Decks.Add(new Deck("Multiplication Deck", "Maths", "#87BBF1", "Black", "#4D91D7", "/Assets/water-type.png"));
            Decks.Add(new Deck("Addition Deck", "Maths", "#94D88D", "Black", "#61BB59", "/Assets/grass-type.png"));

            NavigateToAddDeckViewCommand = new RelayCommand(o => NavigateToAddDeckView());
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
    }
}


