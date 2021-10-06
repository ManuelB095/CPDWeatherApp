using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace CPDWeatherApp
{
    public class ItemTappedBehavior : Behavior<ListView>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(
                "Command",
                typeof(ICommand),
                typeof(ItemTappedBehavior)
            );

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(ListView bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.ItemTapped += OnItemSelected;
            bindable.BindingContextChanged += OnBindingContextChanged;
        }

        protected override void OnDetachingFrom(ListView bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.BindingContextChanged -= OnBindingContextChanged;
            bindable.ItemTapped -= OnItemSelected;
        }

        private void OnBindingContextChanged(object sender, EventArgs args)
        {
            if (sender is ListView listView)
                BindingContext = listView.BindingContext;
        }

        private void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            if (Command.CanExecute(args.Item))
                Command.Execute(args.Item);
        }
    }
}
