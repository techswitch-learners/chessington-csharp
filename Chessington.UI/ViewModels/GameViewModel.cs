﻿using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media.Imaging;
using Chessington.GameEngine;
using Chessington.UI.Caliburn.Micro;
using Chessington.UI.Factories;
using Chessington.UI.Notifications;
using Chessington.UI.Properties;

namespace Chessington.UI.ViewModels
{
    public class GameViewModel : INotifyPropertyChanged, IHandle<PieceTaken>, IHandle<CurrentPlayerChanged>
    {
        private string currentPlayer;

        public GameViewModel()
        {
            CapturedPieces = new ObservableCollection<BitmapImage>();
            ChessingtonServices.EventAggregator.Subscribe(this);
            CurrentPlayer = Enum.GetName(typeof(Player), Player.White);
        }

        public ObservableCollection<BitmapImage> CapturedPieces { get; private set; }

        public string CurrentPlayer
        {
            get { return currentPlayer; }
            private set
            {
                if (value == currentPlayer) return;
                currentPlayer = value;
                OnPropertyChanged();
            }
        }

        public void Handle(PieceTaken message)
        {
            CapturedPieces.Add(PieceImageFactory.GetImage(message.Piece));
        }

        public void Handle(CurrentPlayerChanged message)
        {
            CurrentPlayer = Enum.GetName(typeof(Player), message.Player);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
