using System.Runtime.CompilerServices;

namespace toggle_button
{
    public class CheckBoxEx : ContentView
    {
        public CheckBoxEx()
        {
            BackgroundColor = Colors.Black;
            Padding = new Thickness(0);
            _impl = new Button
            {
                CornerRadius = 0,
                BorderWidth = 0,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                Margin = new Thickness(0),
                Padding = new Thickness(0),
                BackgroundColor = UncheckedColor,
            };
            _innerBorder = new ContentView
            {
                Content = _impl,
                Margin = new Thickness(2),
                Padding = new Thickness(2),
                BackgroundColor = Colors.WhiteSmoke,
            };
            _impl.Clicked += (sender, e) =>
            {
                if (IsEnabled) IsChecked = !IsChecked;
            };
            Content = _innerBorder;
        }
        public bool IsChecked
        {
            get => _isChecked;
            set
            {
                if (!Equals(_isChecked, value))
                {
                    _isChecked = value;
                    _impl.BackgroundColor = IsChecked ? CheckedColor : UncheckedColor;
                    OnPropertyChanged();
                }
            }
        }
        bool _isChecked = false;
        public Color CheckedColor
        {
            get => _checkedColor;
            set
            {
                if (!Equals(_checkedColor, value))
                {
                    _checkedColor = value;
                    if(IsChecked) _impl.BackgroundColor = CheckedColor;
                }
            }
        }
        Color _checkedColor = Colors.CornflowerBlue;

        public Color UncheckedColor
        {
            get => _uncheckedColor;
            set
            {
                if (!Equals(_uncheckedColor, value))
                {
                    _uncheckedColor = value;
                    if (!IsChecked) _impl.BackgroundColor = UncheckedColor;
                }
            }
        }
        Color _uncheckedColor = Colors.White;

        public double Dimension
        {
            get => _dimension;
            set
            {
                if (!Equals(_dimension, value))
                {
                    _dimension = value;
                    HeightRequest = Dimension;
                    WidthRequest = Dimension;
                }
            }
        }
        double _dimension = default;


        private readonly ContentView _innerBorder;
        private readonly Button _impl;
    }
}
