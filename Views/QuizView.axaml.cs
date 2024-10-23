using Avalonia.Controls;
using Avalonia.Input;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class QuizView : UserControl
{
    public QuizView()
    {
        InitializeComponent();
        DataContext = new QuizViewModel();
    }

    private void InputElement_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        QuizViewModel vm = (QuizViewModel)DataContext;
        vm.RevealAnswerCommand.Execute(null);
    }
}