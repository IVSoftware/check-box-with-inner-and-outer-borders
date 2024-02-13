# Custom check box with Inner and Outer borders.

You could "almost" just make a custom `Button` with an `IsChecked` property but the problem is how the border wants to draw in 3D. So one decent way to do this is to take a `Button`, remove its border entirely and put it inside a view (`_innerBorder`) that is inside of another view. This makes it very customizable in terms of border widths (inner and outer) which are now a function of the `Padding` and `Margin` values of the `_innerBorder`, and both width and height requests can now be set as using a new `Dimension` property that makes a square.

```xaml
<!--Style Test-->
<local:CheckBoxEx
    x:Name="Styled1"
    Dimension="30"
    CheckedColor="Yellow"
    OuterBorderColor="Fuchsia"
    InnerBorderColor="Aqua"
    OuterBorderWidth="3"
    InnerBorderWidth="3"
    HorizontalOptions="Center"
    IsCheckedChanged="Any_CheckedChanged" />
```

[![android and iPhone showing checkboxes][1]][1]


```csharppublic class CheckBoxEx : ContentView
{
    public CheckBoxEx()
    {
        BackgroundColor = OuterBorderColor;
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
            BackgroundColor = InnerBorderColor,
        };
        _impl.Clicked += (sender, e) =>
        {
            if (IsEnabled) IsChecked = !IsChecked;
        };
        Content = _innerBorder;
    }
    public event EventHandler IsCheckedChanged;
    public bool IsChecked
    {
        get => _isChecked;
        set
        {
            if (!Equals(_isChecked, value))
            {
                _isChecked = value;
                _impl.BackgroundColor = IsChecked ? CheckedColor : UncheckedColor; 
                IsCheckedChanged?.Invoke(this, EventArgs.Empty);
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
    Color _outerBorderColor = Colors.Black;
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
    Color _innerBorderColor = Colors.WhiteSmoke;


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
```


  [1]: https://i.stack.imgur.com/hHUEZ.png