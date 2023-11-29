namespace Flip_n_Find.Views;

public partial class LevelPage : ContentPage
{
	public LevelPage()
	{
		InitializeComponent();
	}
    private async void EasyButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new EasyPage());
    }

    private async void MediumButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new MediumPage());
    }

    private async void HardButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new HardPage());
    }
}