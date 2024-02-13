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
                Padding = InnerBorderWidth,
                Margin = OuterBorderWidth,
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

        public Color OuterBorderColor
        {
            get => _outerBorderColor;
            set
            {
                if (!Equals(_outerBorderColor, value))
                {
                    _outerBorderColor = value;
                    BackgroundColor = OuterBorderColor;
                }
            }
        }
        Color _outerBorderColor = default;
        public Color InnerBorderColor
        {
            get => _innerBorderColor;
            set
            {
                if (!Equals(_innerBorderColor, value))
                {
                    _innerBorderColor = value;
                    _innerBorder.BackgroundColor = InnerBorderColor;
                }
            }
        }
        Color _innerBorderColor = default;



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

        public int OuterBorderWidth
        {
            get => _outerBorderWidth;
            set
            {
                if (!Equals(_outerBorderWidth, value))
                {
                    _outerBorderWidth = value;
                    _innerBorder.Margin = OuterBorderWidth;
                }
            }
        }
        int _outerBorderWidth = 2;

        public int InnerBorderWidth
        {
            get => _innerBorderWidth;
            set
            {
                if (!Equals(_innerBorderWidth, value))
                {
                    _innerBorderWidth = value;
                    _innerBorder.Padding = InnerBorderWidth;
                }
            }
        }
        int _innerBorderWidth = 2;

        private readonly ContentView _innerBorder;
        private readonly Button _impl;
    }
}
