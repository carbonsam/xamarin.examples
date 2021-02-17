using Xamarin.Forms;

namespace StyleBase
{
    public sealed class Configuration : BindableObject
    {
        public static readonly BindableProperty ColorConfigurationProperty =
            BindableProperty.Create(nameof(ColorConfiguration), typeof(ColorConfiguration), typeof(ColorConfiguration));

        public ColorConfiguration ColorConfiguration
        {
            get => (ColorConfiguration) GetValue(ColorConfigurationProperty);
            set => SetValue(ColorConfigurationProperty, value);
        }
    }
}