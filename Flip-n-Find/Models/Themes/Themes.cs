namespace Flip_n_Find.Models.Themes
{
    public class Themes
    {
        // variables for the theme names
        public string Name { get; set; }
        public string Key { get; set; }
        public Themes(string name, string key)
        {
            Name = name;
            Key = key;
        }
    }
}
