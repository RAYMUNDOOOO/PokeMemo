using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class CreateCardWindow : Window
{
    public CreateCardWindow()
    {
        InitializeComponent();
        DataContext = new AddCardViewModel();
    }
}