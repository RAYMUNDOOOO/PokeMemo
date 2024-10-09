using System;
using ReactiveUI;
using System.Windows.Input;

namespace PokeMemo.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private int? _counter = 0;
        public int? Counter
        {
            get => _counter;
            set => this.RaiseAndSetIfChanged(ref _counter, value);
        }
        
        public ICommand IncreaseCounter { get; }

        public MainWindowViewModel()
        {
            IncreaseCounter = ReactiveCommand.Create(() =>
            {
                Counter++;
            });
        }
    }
}