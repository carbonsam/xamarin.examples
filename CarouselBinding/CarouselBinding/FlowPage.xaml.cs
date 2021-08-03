using System;
using System.Collections.Generic;
using CarouselBinding.Core.ViewModels;
using CarouselBinding.FlowViews;
using Xamarin.Forms;

namespace CarouselBinding
{
    public partial class FlowPage
    {
        private readonly FlowViewModel viewModel;
        
        public List<ContentView> FlowItems { get; } = new List<ContentView>
        {
            new BlueScreenView(),
            new RedScreenView(),
            new GreenScreenView()
        };

        public FlowPage(FlowViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.viewModel = viewModel;
        }

        private void OnNextButtonTapped(object sender, EventArgs e)
            => viewModel.GoToNextStep();

        private void OnPreviousButtonTapped(object sender, EventArgs e)
            => viewModel.GoToPreviousStep();
    }
}
