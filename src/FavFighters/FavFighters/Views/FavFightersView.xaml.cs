using FavFighters.Models;
using FavFighters.ViewModels;
using Xamarin.Forms;

namespace FavFighters.Views
{
    public partial class FavFightersView : ContentPage
    {
        public FavFightersView()
        {
            InitializeComponent();
            BindingContext = new FavFightersViewModel();

            MessagingCenter.Subscribe<Fighter>(this, "Favorited", (f) =>
            {
                DisplayAlert("Added favorite", $"{f.Name} is added to your favorites!", "Thanks");
            });
        }

        // Uncomment this for the event way
        void SwipeItemView_Invoked(System.Object sender, System.EventArgs e)
        {
            var selectedFighter = ((SwipeItemView)sender).BindingContext as Fighter;

            DisplayAlert("Added favorite", $"{selectedFighter.Name} is added to your favorites!", "Thanks");
        }

        private void SwipeView_SwipeEnded(object sender, SwipeEndedEventArgs e)
        {
            var swipedFighter = ((SwipeView)sender).BindingContext as Fighter;

            ((FavFightersViewModel)BindingContext).SetIsEnabled(swipedFighter);
        }

        // This not works
        // https://github.com/xamarin/Xamarin.Forms/issues/10466#issuecomment-713139352
        private void SwipeView_CloseRequested(object sender, System.EventArgs e)
        {
            ((FavFightersViewModel)BindingContext).SetIsEnabled(null);
        }
    }
}