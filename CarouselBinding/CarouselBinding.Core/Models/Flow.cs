using System;
using System.ComponentModel;

namespace CarouselBinding.Core.Models
{
    public class Flow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        
        public FlowStep CurrentStep { get; private set; }

        public void GoToNextStep()
        {
            var nextStep = CurrentStep switch
            {
                FlowStep.BlueScreen => FlowStep.RedScreen,
                FlowStep.RedScreen => FlowStep.GreenScreen,
                FlowStep.GreenScreen => FlowStep.GreenScreen,
                _ => throw new ArgumentOutOfRangeException()
            };
            CurrentStep = nextStep;
        }

        public void GoToPreviousStep()
        {
            var previousStep = CurrentStep switch
            {
                FlowStep.BlueScreen => FlowStep.BlueScreen,
                FlowStep.RedScreen => FlowStep.BlueScreen,
                FlowStep.GreenScreen => FlowStep.RedScreen,
                _ => throw new ArgumentOutOfRangeException()
            };
            CurrentStep = previousStep;
        }
    }
}
