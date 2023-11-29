using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using Flip_n_Find.Models.Themes;

namespace Flip_n_Find.ViewModels
{
    public partial class ThemeViewModel : ObservableObject
    {

        [ObservableProperty]
        List<Themes> themes;
        [ObservableProperty]
        Themes selectedTheme;

        public ThemeViewModel()
        {
            // get the list based on variables in Themes.cs
            var defaultThemes = new List<Themes>()
            {
                new Themes("Fantasy", "Fantasy"),
                new Themes("Thriller", "Thriller"),
                new Themes("Mystery", "Mystery"),
            };
            Themes = new List<Themes>(defaultThemes);

            // Only set the theme if it's not already set
            if (!Preferences.ContainsKey("theme"))
            {
                var theme = Preferences.Get("Fantasy", "Fantasy");
                SelectedTheme = Themes.Single(x => x.Key == theme);
            }
            else
            {
                // Theme is already set, retrieve it and set SelectedTheme
                var selectedThemeKey = Preferences.Get("theme", "Fantasy");
                SelectedTheme = Themes.Single(x => x.Key == selectedThemeKey);
            }
        }

        partial void OnSelectedThemeChanged(Themes value)
        {
            if (value == null) { return; }

            Preferences.Set("theme", value.Key);

            WeakReferenceMessenger.Default.Send(new ThemeChangedMessage(value.Key));
        }
    }
}
