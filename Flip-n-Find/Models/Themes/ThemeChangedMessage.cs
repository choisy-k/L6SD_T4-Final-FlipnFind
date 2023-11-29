using CommunityToolkit.Mvvm.Messaging.Messages;

namespace Flip_n_Find.Models.Themes
{
    // specialised message class for communicating theme changes.
    // used to send and receive theme-related messages. The string value represents the theme name
    public class ThemeChangedMessage : ValueChangedMessage<string>
    {
        public ThemeChangedMessage(string value) : base(value) { }
    }
}
