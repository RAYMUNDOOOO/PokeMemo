using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using PokeMemo.ViewModels;

namespace PokeMemo.Views;

public partial class ModifyDeckView : UserControl
{
    public ModifyDeckView()
    {
        InitializeComponent();
        DataContext = new ModifyDeckViewModel();
    }
}