using Flip_n_Find.Models;
using Flip_n_Find.ViewModels;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Diagnostics;

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