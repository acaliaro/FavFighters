using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using FavFighters.Models;
using FavFighters.Services;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace FavFighters.ViewModels
{
    public class FavFightersViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Fighter> Fighters { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public Command<Fighter> FavoriteCommand { get; set; }

        public FavFightersViewModel()
        {
            LoadFighters();

            FavoriteCommand = new Command<Fighter>((f) =>
            {
                MessagingCenter.Send(f, "Favorited");
            });
        }

        void LoadFighters()
        {
            Fighters = new ObservableCollection<Fighter>(FakeFightersService.Instance.GetFighters());
        }

        internal void SetIsEnabled(Fighter swipedFighter)
        {

            if (swipedFighter != null)
                Fighters.Where(o => o.Name != swipedFighter.Name).ForEach(o => o.IsEnabled = false); // I Disable all SwipeViews excepts the one selected
            else
                Fighters.Where(o => o.IsEnabled == false).ForEach(o => o.IsEnabled = true); // I enable all SwipeViews

        }
    }
}