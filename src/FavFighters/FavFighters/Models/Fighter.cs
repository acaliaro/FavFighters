using System.ComponentModel;

namespace FavFighters.Models
{
    public class Fighter : System.ComponentModel.INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string Tier { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }

        public bool IsEnabled { get; set; } = true;

        public event PropertyChangedEventHandler PropertyChanged;
    }
}