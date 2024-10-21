using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PokeMemo.Models
{
    public class Quiz : ObservableObject
    {
        private int _score;
        public int Score
        {
            get => _score;
            set
            {
                if (_score != value)
                {
                    _score = value;
                    OnPropertyChanged();
                }
            }
        }

        private int _totalCards;
        public int TotalCards
        {
            get => _totalCards;
            set
            {
                if (_totalCards != value)
                {
                    _totalCards = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }

        public Quiz(int totalCards)
        {
            Score = 0;
            TotalCards = totalCards;
        }
    }
}
