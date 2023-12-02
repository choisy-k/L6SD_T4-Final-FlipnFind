namespace Flip_n_Find.Models.Themes
{
    public static class SelectedTheme
    {
        public static string GetCurrentTheme()
        {
            string defaultTheme = "Fantasy";

            if (Preferences.ContainsKey("theme"))
            {
                return Preferences.Get("theme", defaultTheme);
            }

            Preferences.Set("theme", defaultTheme );
            return defaultTheme; //retrieves default theme (Fantasy) if no other theme is selected
        }
    }
}
