using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Flip_n_Find.Models;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Flip_n_Find.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class ScoreboardViewModel: ObservableObject
    {
        [ObservableProperty]
        ObservableCollection<EasyScores> easyScores;
        [ObservableProperty]
        ObservableCollection<MediumScores> mediumScores;
        [ObservableProperty]
        ObservableCollection<HardScores> hardScores;

        [ObservableProperty]
        bool isRefreshing;

        public ScoreboardViewModel()
        {
            EasyScores = new ObservableCollection<EasyScores>();
            MediumScores = new ObservableCollection<MediumScores>();
            HardScores = new ObservableCollection<HardScores>();
            Refresh();
        }

        [RelayCommand]
        private async void Refresh()
        {
            // Simulate delay
            await Task.Delay(2000);

            await LoadAllScores();

            IsRefreshing = false;
        }

        private async Task LoadAllScores()
        {
            try
            {
                var easyScores = await App.DataBase.GetEasyScoreList();
                var mediumScores = await App.DataBase.GetMediumScoreList();
                var hardScores = await App.DataBase.GetHardScoreList();

                EasyScores.Clear();
                MediumScores.Clear();
                HardScores.Clear();

                // Add retrieved scores to the existing collections
                foreach (var score in easyScores)
                    EasyScores.Add(score);

                foreach (var score in mediumScores)
                    MediumScores.Add(score);

                foreach (var score in hardScores)
                    HardScores.Add(score);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex.ToString());
            }
        }
    }
}
