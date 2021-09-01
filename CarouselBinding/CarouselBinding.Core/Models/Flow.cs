using System.Collections.ObjectModel;

namespace CarouselBinding.Core.Models
{
    public class Flow : OrderedFlow<FlowStep>
    {
        public Flow(ObservableCollection<FlowStep> stepCollection) : base(stepCollection)
        {
        }
    }
}
