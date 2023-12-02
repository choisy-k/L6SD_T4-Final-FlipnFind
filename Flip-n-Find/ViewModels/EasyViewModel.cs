using CommunityToolkit.Mvvm.ComponentModel;
using Flip_n_Find.Models;
using PropertyChanged;
using System.Diagnostics;

namespace Flip_n_Find.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class EasyViewModel : ObservableObject
    {
        public Stopwatch sw = new Stopwatch();
        public bool win = false;

        // Declare TimeTaken at the class level
        public int TimeTaken { get; private set; }

        public EasyViewModel()
        {

        }

        [ObservableProperty]
        string timer = "00:00";
        [ObservableProperty]
        int moveCount = 0;

        public async void TimerAsync()
        {
            while (!win) //timer will continues to run until win = true
            {
                await Task.Delay(100);
                TimeSpan ts = sw.Elapsed; // retrieves elapsed time from the stopwatch and stored as Timespan variable

                //update the UI on main thread
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
                EasyScores score = new EasyScores()
                {
                    TimeTaken = TimeTaken,
                    MoveCount = MoveCount,
                    DateAchieved = DateTime.Now
                };
                await App.DataBase.AddScoreEasy(score);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"{ex}", "OK");
            }
        }
    }
}
