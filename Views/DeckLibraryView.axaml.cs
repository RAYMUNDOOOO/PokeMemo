using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class DeckLibraryView : UserControl
{
    public DeckLibraryView()
    {
        InitializeComponent();
        DataContext = new DeckLibraryViewModel();
    }
}