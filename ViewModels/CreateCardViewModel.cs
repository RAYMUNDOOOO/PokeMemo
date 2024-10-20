using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Utility;
using PokeMemo.Models;
using ReactiveUI;

namespace PokeMemo.ViewModels
{
    public class CreateCardViewModel : ViewModelBase
    {
        public Deck CurrentDeck { get; }
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
                this.RaiseAndSetIfChanged(ref _question, value);
            }
        }

        private string? _answer;

        public string? Answer
        {
            get => _answer;
            set
            {
                _answer = value;
                this.RaiseAndSetIfChanged(ref _answer, value);
            }
        }

        private bool _isQuestionEmpty;
        public bool IsQuestionEmpty
        {
            get => _isQuestionEmpty;
            set
            {
                _isQuestionEmpty = value;
                this.RaiseAndSetIfChanged(ref _isQuestionEmpty, value);
            }
        }
        
        private bool _isAnswerEmpty;

        public bool IsAnswerEmpty
        {
            get => _isAnswerEmpty;
            set
            {
                _isAnswerEmpty = value;
                this.RaiseAndSetIfChanged(ref _isAnswerEmpty, value);
            }
        }

        /*
         * Setting up view navigation by creating RelayCommands that call on functions
         * that update the CurrentViewModel in MainWindowViewModel
         */
        public ICommand NavigateToPreviewDeckViewCommand { get; }
        public ICommand SaveCardAndExitCommand { get; }
        public ICommand SaveAndCreateNextCardCommand { get; }

        public event PropertyChangedEventHandler PropertyChanged;

        public CreateCardViewModel()
        {
            CurrentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            NavigateToPreviewDeckViewCommand = new RelayCommand(o => NavigateToPreviewDeckView());
            SaveCardAndExitCommand = new RelayCommand(o => SaveCardAndExit());
            SaveAndCreateNextCardCommand = new RelayCommand(o => SaveAndCreateNextCard());
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NavigateToPreviewDeckView()
        {
            var mainWindowViewModel = (Application.Current?.ApplicationLifetime as IClassicDesktopStyleApplicationLifetime)?.MainWindow?.DataContext as MainWindowViewModel;
            mainWindowViewModel?.NavigateToPreviewDeckViewCommand.Execute(null);
        }

        private void SaveCardAndExit()
        {
            if (!CheckIfFieldsAreValid())
            {
                // TODO: Update the view
                return;
            }
            
            CreateCardAndRefreshFields();
            NavigateToPreviewDeckView();
        }

        private void SaveAndCreateNextCard()
        {
            if (!CheckIfFieldsAreValid())
            {
                // TODO: Update the view
                return;
            }
            
            CreateCardAndRefreshFields();
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

            CurrentDeck?.AddCard(new Card(Question, Answer, backgroundColour, foregroundColour, borderColour, "/Assets/squirtle.png"));

            /* Refresh the fields and update the corresponding view */
            Question = string.Empty;
            Answer = string.Empty;
            IsQuestionEmpty = false;
            IsAnswerEmpty = false;
        }
    }
}
