using Flip_n_Find.Views;

namespace Flip_n_Find
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            FloatingAnimation(logoFloat);
        }

        private async void FloatingAnimation(View view)
        {
            while (true) // infinite animation
            {
                await view.TranslateTo(0, -20, 2500, Easing.SinInOut); // Float up
                await view.TranslateTo(0, 10, 2500, Easing.SinInOut); // Float down
            }
        }

        private async void startButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new LevelPage());
        }

        private async void scoreButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScoreboardPage());
        }

        private async void themeButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThemePage());
        }

        private async void feedbackButton_Clicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("https://docs.google.com/forms/d/e/1FAIpQLSf631JT5_8j6DWAl7HWrx_l43txR7u1mX0pqqYTo-tMJaLtbA/viewform");
        }

        private async void creditButton_Clicked(object sender, EventArgs e)
        {
            await Launcher.Default.OpenAsync("https://github.com/choisy-k/L6SD_T4-Final-FlipnFind");
        }
    }
}