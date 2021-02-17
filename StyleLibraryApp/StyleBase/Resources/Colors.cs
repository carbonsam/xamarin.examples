using Xamarin.Forms;

namespace StyleBase.Resources
{
    public partial class Colors : ResourceDictionary
    {
        internal Colors(ColorConfiguration colorConfiguration)
        {
            Add("BackgroundColor", colorConfiguration.BackgroundColor);
        }
    }
}