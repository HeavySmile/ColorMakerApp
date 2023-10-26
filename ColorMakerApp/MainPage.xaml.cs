using Aspose.Svg;
using CommunityToolkit.Maui.Alerts;
using System;

namespace ColorMakerApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SetSliderValues(Color color)
        {
            sliderRed.Value = color.Red;
            sliderGreen.Value = color.Green;
            sliderBlue.Value = color.Blue;
        }

        private void SetColor(Color color)
        {
            container.BackgroundColor = color;
            buttonRandom.BackgroundColor = color;
            labelHex.Text = color.ToArgbHex();
        }
        
        private void slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            var red = sliderRed.Value;
            var green = sliderGreen.Value;
            var blue = sliderBlue.Value;

            Color color = Color.FromRgb(red, green, blue);
            SetColor(color);
        }

        private void buttonRandom_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            SetSliderValues(Color.FromRgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await Clipboard.SetTextAsync(labelHex.Text);
            var toast = Toast.Make("Copied!", CommunityToolkit.Maui.Core.ToastDuration.Short, 16);

            await toast.Show();
        }
    }
}