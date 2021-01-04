using System.Collections.Generic;
using Xamarin.Forms;

namespace VisualChallengePocketCastsApp
{
    public partial class MainPage
    {
        public List<Color> Podcasts { get; set; }
        
        public MainPage()
        {
            BindingContext = this;
            
            Podcasts = new List<Color>
            {
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
                
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
                
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
                
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
                
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
                
                Color.FromHex("#8a8a8a"),
                Color.FromHex("#969696"),
                Color.FromHex("#a3a3a3"),
                Color.FromHex("#b0b0b0"),
                Color.FromHex("#bdbdbd"),
            };
            
            InitializeComponent();
        }
    }
}
