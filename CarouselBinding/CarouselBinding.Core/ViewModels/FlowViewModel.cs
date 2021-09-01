using System.Collections.ObjectModel;
using System.ComponentModel;
using CarouselBinding.Core.Models;

namespace CarouselBinding.Core.ViewModels
{
    public class FlowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private readonly Flow flow;

        public FlowStep CurrentStep => flow.CurrentStep;

        public int Position => flow.Position;
        public ObservableCollection<FlowStep> StepCollection => flow.StepCollection;

        public FlowViewModel(Flow flow)
        {
            this.flow = flow;
            flow.PropertyChanged += (_, args) => PropertyChanged?.Invoke(this, args);
        }

        public void GoToNextStep() => flow.GoToNextStep();

        public void GoToPreviousStep() => flow.GoToPreviousStep();

        public void AddStepToEnd(FlowStep step) => flow.AddStep(step);

        public void RemoveStepFromEnd(int index) => flow.RemoveStepAt(index);
    }
}
