using IVSoftware.Portable;

namespace toggle_button
{
    public partial class MainPage : ContentPage
    {
        int count = 0;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void Any_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkBox)
            {
                string state = checkBox.IsChecked ? "Checked" : "Unchecked";
                string name;
                if (sender == CheckBox1) name = nameof(CheckBox1);
                else if (sender == CheckBox2) name = nameof(CheckBox2);
                else if (sender == Styled1) name = nameof(Styled1);
                else if (sender == Styled2) name = nameof(Styled2);
                else return;
                labelMessage.Text = $"{name} {state}!";
                _wdtOverlay.StartOrRestart(
                    initialAction: () => overlay.IsVisible = true,
                    completeAction: () => overlay.IsVisible = false);
                overlay.IsVisible = true;
            }
        }
        WatchdogTimer _wdtOverlay = new WatchdogTimer { Interval = TimeSpan.FromSeconds(1) };
    }
}
