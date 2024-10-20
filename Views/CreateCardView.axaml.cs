using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class CreateCardView : UserControl
{
    public CreateCardView()
    {
        InitializeComponent();
        DataContext = new CreateCardViewModel();
    }
}