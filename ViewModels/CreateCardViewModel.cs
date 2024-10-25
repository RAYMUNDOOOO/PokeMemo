using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using CommunityToolkit.Mvvm.Input;
using PokeMemo.Utility;
using PokeMemo.Models;
using ReactiveUI;

namespace PokeMemo.ViewModels
{
    public class CreateCardViewModel : ViewModelBase
    {
        public Deck? CurrentDeck { get; }

        private Card? _cardToBeModified;
        
        /*
         * Fields used for the creation of a card; generating the card preview
         * and determining which controls are visible
         */
        private string? _question;
        public string? Question
        {
            get => _question;
            set
            {
                _question = value;
                OnPropertyChanged();
            }
        }

        private string? _answer;

        public string? Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                OnPropertyChanged();
            }
        }

        private bool _isQuestionEmpty;
        public bool IsQuestionEmpty
        {
            get => _isQuestionEmpty;
            set
            {
                _isQuestionEmpty = value;
                OnPropertyChanged();
            }
        }
        
        private bool _isAnswerEmpty;

        public bool IsAnswerEmpty
        {
            get => _isAnswerEmpty;
            set
            {
                _isAnswerEmpty = value;
                OnPropertyChanged();
            }
        }

        private string _leftButtonText;

        public string LeftButtonText
        {
            get => _leftButtonText;
            set
            {
                _leftButtonText = value;
                OnPropertyChanged();
            }
        }

        private bool _isCreateNextCardEnabled = true;

        public bool IsCreateNextCardEnabled
        {
            get => _isCreateNextCardEnabled;
            set
            {
                _isCreateNextCardEnabled = value;
                OnPropertyChanged();
            }
        }

        /*
         * Setting up view navigation by creating RelayCommands that call on functions
         * that update the CurrentViewModel in MainWindowViewModel
         */
        public ICommand NavigateToPreviewDeckViewCommand { get; }
        public ICommand SaveCardAndExitCommand { get; }
        public ICommand SaveAndCreateNextCardCommand { get; }

        /*
         * Initialise the view with empty fields to create a new card and
         * set the content of the button to indicate to the user that they
         * are creating a new card, adding it to the deck and then
         * exiting.
         */
        public CreateCardViewModel()
        {
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToPreviewDeckViewCommand = new RelayCommand(NavigateToPreviewDeckView);
            SaveCardAndExitCommand = new RelayCommand(SaveCardAndExit);
            SaveAndCreateNextCardCommand = new RelayCommand(SaveAndCreateNextCard);

            LeftButtonText = "Save card and exit";
        }

        /*
         * If there is a card to be modified, set this and the corresponding fields
         * in the view to its existing Question and Answer fields. This will also
         * set the button to indicate to the user that they're modifying an existing
         * card and then exiting.
         */
        public CreateCardViewModel(Card? cardToBeModified)
        {
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToPreviewDeckViewCommand = new RelayCommand(NavigateToPreviewDeckView);
            SaveCardAndExitCommand = new RelayCommand(SaveCardAndExit);
            SaveAndCreateNextCardCommand = new RelayCommand(SaveAndCreateNextCard);

            _cardToBeModified = cardToBeModified;
            Question = cardToBeModified?.Question;
            Answer = cardToBeModified?.Answer;
            LeftButtonText = "Modify card and exit";
            IsCreateNextCardEnabled = false;
        }

        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

        private void SaveCardAndExit()
        {
            if (_cardToBeModified != null)
            {
               _cardToBeModified.Question = Question;
               _cardToBeModified.Answer = Answer;
               NavigateToPreviewDeckView();
               return;
            }
            
            if (CheckIfFieldsAreValid())
            {
                CreateCardAndRefreshFields();
                NavigateToPreviewDeckView();
            }
        }

        private void SaveAndCreateNextCard()
        {
            if (CheckIfFieldsAreValid())
            {
                CreateCardAndRefreshFields();
            }
        }

        private bool CheckIfFieldsAreValid()
        {
            /* Return if either the question or answer field is empty */
            IsQuestionEmpty = string.IsNullOrEmpty(Question);
            IsAnswerEmpty = string.IsNullOrEmpty(Answer);
            if (IsQuestionEmpty || IsAnswerEmpty) return false;
            
            return true;
        }

        private void CreateCardAndRefreshFields()
        {
            /* Add a new card to the currently selected deck */
            var backgroundColour = CurrentDeck?.BackgroundColour ?? "#FFFFFF";
            var foregroundColour = CurrentDeck?.ForegroundColour ?? "#000000";
            var borderColour = CurrentDeck?.BorderColour ?? "#000000";
            var imagePath = ImageHelper.GetImageByType(CurrentDeck?.Type);

            CurrentDeck?.AddCard(new Card(Question, Answer, backgroundColour, foregroundColour, borderColour, imagePath));

            /* Refresh the fields and update the corresponding view */
            Question = string.Empty;
            Answer = string.Empty;
            IsQuestionEmpty = false;
            IsAnswerEmpty = false;
        }
    }
}
