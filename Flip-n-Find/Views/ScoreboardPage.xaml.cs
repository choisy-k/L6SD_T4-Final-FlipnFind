using Flip_n_Find.ViewModels;

namespace Flip_n_Find.Views;

public partial class ScoreboardPage : ContentPage
{
    public ScoreboardViewModel vm = new ScoreboardViewModel();

    public ScoreboardPage()
    {
        InitializeComponent();
        BindingContext = vm;
    }
}