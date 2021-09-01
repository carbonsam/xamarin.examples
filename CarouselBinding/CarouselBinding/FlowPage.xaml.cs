using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using CarouselBinding.Core.Models;
using CarouselBinding.Core.ViewModels;
using CarouselBinding.FlowViews;
using Xamarin.Forms;
using Xamarin.Forms.Internals;

namespace CarouselBinding
{
    public partial class FlowPage
    {
        private readonly FlowViewModel viewModel;

        public ObservableCollection<ContentView> FlowViews { get; } = new ObservableCollection<ContentView>();

        public FlowPage(FlowViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;

            viewModel.StepCollection.CollectionChanged += StepCollectionOnCollectionChanged;
            
            viewModel.StepCollection.ForEach(step => FlowViews.Add(FlowStepToView(step)));
        }

        private void StepCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (var item in e.NewItems)
                {
                    FlowViews.Add(FlowStepToView((FlowStep)item));
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (var item in e.OldItems)
                {
                    var currentView = FlowStepToView((FlowStep)item);
                    var lastMatchingView = FlowViews.LastOrDefault(view => view.GetType() == currentView.GetType());
                    FlowViews.Remove(lastMatchingView);
                }
            }
        }

        private static ContentView FlowStepToView(FlowStep flowStep)
            => flowStep switch
            {
                FlowStep.BlueScreen => new BlueScreenView(),
                FlowStep.RedScreen => new RedScreenView(),
                FlowStep.GreenScreen => new GreenScreenView(),
                _ => throw new ArgumentOutOfRangeException(nameof(flowStep), flowStep, null)
            };

        private void OnNextButtonTapped(object sender, EventArgs e)
            => viewModel.GoToNextStep();

        private void OnPreviousButtonTapped(object sender, EventArgs e)
            => viewModel.GoToPreviousStep();

        private void OnAddButtonTapped(object sender, EventArgs e)
            => viewModel.AddStepToEnd(FlowStep.RedScreen);

        private void OnRemoveButtonTapped(object sender, EventArgs e)
            => viewModel.RemoveStepFromEnd(viewModel.StepCollection.Count - 1);
    }
}
