using System.Windows;
using System.Windows.Data;

using Microsoft.Xaml.Behaviors;

namespace ObjectInformation.Infrastructure.Behavior
{
    public class BindingToElementPropertyBehavior : Behavior<DependencyObject>
    {
        #region Fields
        private readonly Binding _binding = new() { Mode = BindingMode.OneWay };
        #endregion

        #region Properties
        public PropertyPath Property
        {
            get => _binding.Path;
            set => _binding.Path = value;
        }

        public object Source
        {
            get => GetValue(SourceProperty);
            set => SetValue(SourceProperty, value);
        }

        public static readonly DependencyProperty SourceProperty =
            DependencyProperty.Register("Source",
                            typeof(object),
                            typeof(BindingToElementPropertyBehavior),
                            new PropertyMetadata(null, PropertyChangedCallback));

        public object Target
        {
            get => GetValue(TargetProperty);
            set => SetValue(TargetProperty, value);
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target",
                            typeof(object),
                            typeof(BindingToElementPropertyBehavior),
                            new PropertyMetadata(null));

        private static void PropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e) =>
            ((BindingToElementPropertyBehavior)d).Target = e.NewValue;
        #endregion

        #region Methods
        protected override void OnAttached()
        {
            _binding.Source = AssociatedObject;
            BindingOperations.SetBinding(this, SourceProperty, _binding);
        }
        #endregion
    }
}
