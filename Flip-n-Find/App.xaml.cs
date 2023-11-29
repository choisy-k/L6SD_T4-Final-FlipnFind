using CommunityToolkit.Mvvm.Messaging;
using Flip_n_Find.Data;
using Flip_n_Find.Models.Themes;
using Flip_n_Find.Views;

namespace Flip_n_Find
{
    public partial class App : Application
    {
        public static RepositoryData DataBase {  get; set; }
        public App(RepositoryData repo)
        {
            InitializeComponent();

            DataBase = repo;

            MainPage = new AppShell();
            //MainPage = new CongratsPage("Medium");

            // callback to ThemeChangedMessage
            WeakReferenceMessenger.Default.Register<ThemeChangedMessage>(this, (r, m) =>
            {
                LoadTheme(m.Value);
            });

            var theme = Preferences.Get("Fantasy", "Fantasy");
            //var theme = "Fantasy";
            LoadTheme(theme);
        }

        private void LoadTheme(string theme)
        {
            // if method is not called from main thread, executes it on main thread
            if(!MainThread.IsMainThread)
            {
                MainThread.BeginInvokeOnMainThread(() => LoadTheme(theme));
                return;
            }

            ResourceDictionary dictionary = theme switch
            {
                "Fantasy" => new Resources.Styles.Fantasy(),
                "Thriller" => new Resources.Styles.Thriller(),
                "Mystery" => new Resources.Styles.Mystery(),
            };

            if (dictionary != null)
            {
                Resources.MergedDictionaries.Clear();
                Resources.MergedDictionaries.Add(dictionary);
            }
        }
    }
}