using Flip_n_Find.ViewModels;

namespace Flip_n_Find.Views;

public partial class ThemePage : ContentPage
{
    private ThemeViewModel vm;

	public ThemePage()
	{
		InitializeComponent();
        BindingContext = vm;
    }

    private void FantasyButton_Clicked(object sender, EventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Fantasy");
    }

    private void ThrillerButton_Clicked(object sender, EventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Thriller");
    }

    private void MysteryButton_Clicked(object sender, EventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Mystery");
    }

    private void Fantasy_Tapped(object sender, TappedEventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Fantasy");
    }
    private void Thriller_Tapped(object sender, TappedEventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Thriller");
    }
    private void Mystery_Tapped(object sender, TappedEventArgs e)
    {
        vm = new ThemeViewModel();
        vm.SelectedTheme = vm.Themes.FirstOrDefault(t => t.Name == "Mystery");
    }
}