# PokeMemo

A simple flashcards desktop application built with Avalonia UI for Application Development with .NET.

# Prerequisites

Unfortunately I do not know at this time whether you need to have anything else besides simply Visual Studio and .NET installed on your computer. 

## Visual Studio

If you are using Visual Studio, you can install the [Avalonia for Visual Studio](https://marketplace.visualstudio.com/items?itemName=AvaloniaTeam.AvaloniaVS) extension.

## JetBrains Rider

If you are using JetBrains Rider, you shouldn't have to install anything and it should work out of the box.

# Install
```powershell
git clone git@github.com:RAYMUNDOOOO/PokeMemo.git
```

Afterwards, open the `PokeMemo` solution file in the editor of your choice and build the project. **If it does not build**, you may need to install the **Avalonia templates** which can be done with `dotnet new install Avalonia.Templates`
on the command line; and you will need to add the `Avalonia.ReactiveUI` package to your project via NuGet.

Upon successfully building and running the project, you should see the following and be able to click on the button to increment the counter in the middle of the window.

![image](https://github.com/user-attachments/assets/f1c1e25a-5ca5-4eb2-8b58-0a1323254a08)
