using CommunityToolkit.Mvvm.ComponentModel;
using Flip_n_Find.Models;
using Java.Lang;

namespace Flip_n_Find.ViewModels
{
    public partial class CongratsViewModel : ObservableObject
    {
        string difficultyLevel;

        [ObservableProperty]
        int timeTaken;
        [ObservableProperty]
        int moveCount;

        public CongratsViewModel(string difficultyLevel)
        {
            this.difficultyLevel = difficultyLevel;
            GetScore();
        }

        private async void GetScore()
        {
            List<object> scoreList;

            switch (difficultyLevel)
            {
                case "Easy":
                    List<EasyScores> easyScore = await App.DataBase.GetEasyScoreList();
                    scoreList = easyScore
                        .OrderByDescending(item => item.TimeTaken)
                        .Take(1)  // Take the latest entry
                        .Select(item => new { TimeTaken = item.TimeTaken, MoveCount = item.MoveCount })
                        .Cast<object>()
                        .ToList();
                    break;
                case "Medium":
                    List<MediumScores> mediumScore = await App.DataBase.GetMediumScoreList();
                    scoreList = mediumScore
                        .OrderByDescending(item => item.TimeTaken)
                        .Take(1)
                        .Select(item => new { TimeTaken = item.TimeTaken, MoveCount = item.MoveCount })
                        .Cast<object>()
                        .ToList();
                    break;
                case "Hard":
                    List<HardScores> hardScore = await App.DataBase.GetHardScoreList();
                    scoreList = hardScore
                        .OrderByDescending(item => item.TimeTaken)
                        .Take(1)
                        .Select(item => new { TimeTaken = item.TimeTaken, MoveCount = item.MoveCount })
                        .Cast<object>()
                        .ToList();
                    break;
                default:
                    return;
            }
        }

    }
}
