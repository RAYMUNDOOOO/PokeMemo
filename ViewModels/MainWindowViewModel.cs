﻿using System;
using ReactiveUI;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PokeMemo.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set => SetProperty(ref _currentView, value);
        }

        public ICommand NavigateToDeckLibraryCommand { get; }
        public ICommand NavigateToAddDeckViewCommand { get; }

        public MainWindowViewModel()
        {
            NavigateToDeckLibraryCommand = new RelayCommand(o => NavigateToDeckLibrary());
            NavigateToAddDeckViewCommand = new RelayCommand(o => NavigateToAddDeckView());
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToDeckLibrary()
        {
            CurrentView = new DeckLibraryViewModel();
        }

        private void NavigateToAddDeckView()
        {
            CurrentView = new AddDeckViewModel();
        }
    }
}