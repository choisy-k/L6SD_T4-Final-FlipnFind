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
            while(!win)
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
                EasyScores score = new EasyScores()
                {
                    TimeTaken = TimeTaken,
                    MoveCount = MoveCount,
                    DateAchieved = DateTime.Now
                };
                await App.DataBase.AddScoreEasy(score);

                //bool isSuccess = await App.DataBase.AddScoreEasy(score);

                //if (isSuccess)
                //{
                //    // Data added successfully
                //    Debug.WriteLine("EasyScores data added successfully");
                //}
                //else
                //{
                //    // Failed to add data
                //    Debug.WriteLine("Failed to add EasyScores data");
                //}
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error!", $"{ex}", "OK");
            }
        }
    }
}
