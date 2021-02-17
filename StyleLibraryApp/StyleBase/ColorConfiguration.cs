using Xamarin.Forms;

namespace StyleBase
{
    public sealed class ColorConfiguration : BindableObject
    {
        public static readonly BindableProperty BackgroundColorProperty =
            BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(Color), Color.FromHex("#EAEAEA"));

        public Color BackgroundColor
        {
            get => (Color) GetValue(BackgroundColorProperty);
            set => SetValue(BackgroundColorProperty, value);
        }
    }
}