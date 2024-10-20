using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using PokeMemo.Utility;
using PokeMemo.Models;

namespace PokeMemo.ViewModels
{
    public class CreateCardViewModel : ViewModelBase
    {
        /*
         * Fields used for the creation of a card; generating the card preview
         * and determining which controls are visible
         */
        public string? Question { get; set; }
        public string? Answer { get; set; }
        public bool IsQuestionEmpty { get; set; } = false;
        public bool IsAnswerEmpty { get; set; } = false;

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
            var currentDeck = DataService.Instance.DeckLibrary.SelectedDeck;
            currentDeck?.AddCard(new Card(Question, Answer, "#F6BD60", "#F7EDE2", "#F7EDE2", "/Assets/squirtle.png"));
            
            /* Refresh the fields and update the corresponding view */
            Question = string.Empty;
            Answer = string.Empty;
            IsQuestionEmpty = false;
            IsAnswerEmpty = false;
        }
    }
}