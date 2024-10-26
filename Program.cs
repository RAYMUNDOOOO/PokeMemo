using Avalonia;
using Avalonia.ReactiveUI;
using System;

namespace PokeMemo;

/******************************************************************************************************************

                    31927 – Application Development with .NET - Spring 2024
                                    
                            Assignment 2 - Group Project - PokeMemo

                            Authors: Ria Narai, Ramon Tovar, Andreas Skotadis
                            Student No: 14326957, 12918761, 14183370

    Example of useful Polymorphism - The CreateCardViewModel and CreateDeckViewModel have examples of constructor 
                                     overloading, as both view models can be used to both Create new decks and 
                                     cards as well as modify existing ones.
  

    Bonus:
    Use of another UI library - We used AvaloniaUI to create the PokeMemo application.

******************************************************************************************************************/


sealed class Program
{
    // Initialization code. Don't use any Avalonia, third-party APIs or any
    // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
    // yet and stuff might break.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<App>()
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}