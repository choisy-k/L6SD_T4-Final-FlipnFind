using Flip_n_Find.Models;

namespace Flip_n_Find.Views;

public partial class CongratsPage : ContentPage
{
    string difficultyLevel;

	public CongratsPage(string difficultyLevel)
	{
		InitializeComponent();

        //disable back button
        NavigationPage.SetHasBackButton(this, false);

        this.difficultyLevel = difficultyLevel;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        List<object> scoreList;

        switch(difficultyLevel)
        {
            case "Easy":
                List<EasyScores> easyScore = await App.DataBase.GetEasyScoreList();
                scoreList = easyScore.Cast<object>().ToList();
                break;
            case "Medium":
                List<MediumScores> mediumScore = await App.DataBase.GetMediumScoreList();
                scoreList = mediumScore.Cast<object>().ToList();
                break;
            case "Hard":
                List<HardScores> hardScore = await App.DataBase.GetHardScoreList();
                scoreList = hardScore.Cast<object>().ToList();
                break;
            default:
                return;
        }
        var seeScore = scoreList.Skip(Math.Max(0, scoreList.Count() - 3));
        scoreView.ItemsSource = seeScore;
    }

    private async void mainMenuButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopToRootAsync();
    }
}