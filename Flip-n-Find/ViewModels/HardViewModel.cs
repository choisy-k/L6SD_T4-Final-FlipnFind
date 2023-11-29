using CommunityToolkit.Mvvm.ComponentModel;
using Flip_n_Find.Models;
using PropertyChanged;
using System.Diagnostics;

namespace Flip_n_Find.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class HardViewModel : ObservableObject
    {
        public Stopwatch sw = new Stopwatch();
        public bool win = false;

        // Declare TimeTaken at the class level
        public int TimeTaken { get; private set; }

        public HardViewModel()
        {

        }

        [ObservableProperty]
        string timer = "00:00";
        [ObservableProperty]
        int moveCount = 0;

        public async void TimerAsync()
        {
            while (!win)
            {
                await Task.Delay(100);
                TimeSpan ts = sw.Elapsed;

                Device.BeginInvokeOnMainThread(() =>
                {
                    Timer = String.Format("{0:00}:{1:00}", ts.Minutes, ts.Seconds);
                    TimeTaken = ts.Minutes * 60 + ts.Seconds;
                });
            }
        }
        public async void AddData()
        {
            try
            {
                HardScores score = new HardScores()
                {
                    TimeTaken = TimeTaken,
                    MoveCount = MoveCount,
                    DateAchieved = DateTime.Now
                };
                await App.DataBase.AddScoreHard(score);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"{ex}", "OK");
            }
        }
    }
}
