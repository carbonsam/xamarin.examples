using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using PropertyChanged;

namespace CarouselBinding.Core
{
    public class OrderedFlow<T> : INotifyPropertyChanged where T : Enum
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        private int position;

        /// <summary>
        /// The currently selected index of StepCollection.
        /// </summary>
        public int Position
        {
            get => position;
            set
            {
                if (value == position) return;
                if (value >= StepCollection.Count || value < 0) return;

                position = value;
                // TODO: Remove these lines and leverage Fody.PropertyChanged instead
                NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(Position)));
                NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(Progress)));
                NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(CurrentStep)));
                NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(CanGoToNext)));
                NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(CanGoToPrevious)));
            }
        }

        [DependsOn(nameof(Position))]
        public T CurrentStep => StepCollection[Position];

        [DependsOn(nameof(Position))]
        public bool CanGoToNext => GetCanGoToNext();

        [DependsOn(nameof(Position))]
        public bool CanGoToPrevious => GetCanGoToPrevious();

        /// <summary>
        /// Percentage of the flow completed.
        /// </summary>
        [DependsOn(nameof(Position))]
        public decimal Progress => GetProgress();

        /// <summary>
        /// Order of steps in the flow.
        /// </summary>
        public ObservableCollection<T> StepCollection { get; }

        protected OrderedFlow(ObservableCollection<T> stepCollection)
        {
            StepCollection = new ObservableCollection<T>(stepCollection);

            StepCollection.CollectionChanged += StepCollectionOnCollectionChanged;
        }

        public virtual void GoToNextStep()
        {
            if (!CanGoToNext)
            {
                return;
            }
            Position++;
        }

        public virtual void GoToPreviousStep()
        {
            if (!CanGoToPrevious)
            {
                return;
            }
            Position--;
        }

        /// <summary>
        /// Add step to the end of the flow.
        /// </summary>
        /// <param name="step">The step to add</param>
        public void AddStep(T step) => StepCollection.Add(step);

        /// <summary>
        /// Add step to the specified index.
        /// </summary>
        /// <param name="step">The step to add</param>
        /// <param name="index">The index to add it at</param>
        public void InsertStepAt(T step, int index)
        {
            if (index <= Position) return;
            if (index > StepCollection.Count) return;

            StepCollection.Insert(index, step);
        }

        /// <summary>
        /// Remove step at the specified index.
        /// </summary>
        /// <param name="index">The index of the step to remove</param>
        public void RemoveStepAt(int index)
        {
            if (index <= Position) return;
            if (index >= StepCollection.Count) return;

            StepCollection.RemoveAt(index);
        }

        /// <summary>
        /// Logic for when we can navigate forward in the flow.
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetCanGoToNext() => Position < StepCollection.Count - 1;
        
        /// <summary>
        /// Logic for when we can navigate backwards in the flow.
        /// </summary>
        /// <returns></returns>
        protected virtual bool GetCanGoToPrevious() => Position > 0;

        private void StepCollectionOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(StepCollection)));
            NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(Progress)));
            NotifyPropertyChanged(new PropertyChangedEventArgs(nameof(Position)));
        }

        private decimal GetProgress()
        {
            var normalizedCurrentStep = Position + 1;
            var progress = (decimal)normalizedCurrentStep / StepCollection.Count;
            return Math.Round(progress, 2);
        }

        protected void NotifyPropertyChanged(PropertyChangedEventArgs eventArgs)
            => PropertyChanged?.Invoke(this, eventArgs);
    }
}
