using Flip_n_Find.Models.Themes;
using Flip_n_Find.ViewModels;
using System.Diagnostics;

namespace Flip_n_Find.Views;

public partial class HardPage : ContentPage
{
    public HardViewModel vm = new HardViewModel();

    public int[,] matrixNum = new int[5, 4];
    private const int NumRows = 5;
    private const int NumColumns = 4;

    public int currentCardCount = 0;
    public int pairsFound = 0;
    public int currentRow;
    public int currentColumn;

    public ImageButton imgTurned;

    public bool win = false;
    public bool running = true;

    public HardPage()
	{
		InitializeComponent();
        BindingContext = vm;
        CreateGrid();
	}

    // the method will materialises 5 x 4 matrix with randomised set of numbers (10 sets)
    private void CreateGrid()
    {
        Random random = new Random();
        HashSet<(int, int)> usedIndices = new HashSet<(int, int)>();

        for (int i = 0; i < 10; i++)
        {
            int count = 0;

            while (count < 2)
            {
                int r = random.Next(0, NumRows);
                int c = random.Next(0, NumColumns);

                if (usedIndices.Add((r, c)))
                {
                    matrixNum[r, c] = i + 1;
                    count++;
                }
            }
        }
    }
    private async void BackButton_Clicked(object sender, EventArgs e)
    {
        bool result = await DisplayAlert("Warning!", "Exiting the level will reset the game. Are you sure you want to go back?", "Yes", "No");

        if (result)
        {
            // User clicked "Yes"
            await Navigation.PopAsync();
        }
    }

    private async void ImageButton_Clicked(object sender, EventArgs e)
    {
        var sw = vm.sw;
        if (!(sender is ImageButton)) return;
        ImageButton image = (ImageButton)sender;

        if (!running || image.IsEnabled == false) return;
        else running = false;

        //start stopwatch when card is tapped
        if (!sw.IsRunning)
        {
            sw.Start();
            vm.TimerAsync();
        }

        // Animation of the card flipping, while matching the image with the theme set
        await image.RotateYTo(90, 250, Easing.CubicIn);
        CardTheme(image);
        await image.RotateYTo(0, 250, Easing.CubicIn);

        currentCardCount++;

        //checking for pair matching
        if (currentCardCount >= 2)
        {
            //when two cards have been selected, continue executing
            if (currentRow == Grid.GetRow(image) && currentColumn == Grid.GetColumn(image))
            {
                running = true;
                return;
            }
            vm.MoveCount++;
            await Task.Delay(125);

            if (matrixNum[Grid.GetRow(image), Grid.GetColumn(image)] == matrixNum[Grid.GetRow(imgTurned), Grid.GetColumn(imgTurned)])
            {
                //if there's a match between current card (image) and previously turned card (imgTurned), updates the game state
                currentCardCount = 0;
                image.IsEnabled = false;
                imgTurned.IsEnabled = false;
                imgTurned = null;
                pairsFound++;

                if (pairsFound == 10)
                {
                    win = true;
                    sw.Stop();
                    vm.AddData();
                    await Navigation.PushAsync(new CongratsPage("Hard"));
                }

                running = true;
                return;
            }
            // If the cards don't match, reset the images and flip them back
            await Task.Delay(500);
            await Task.WhenAll(
                image.RotateYTo(90, 250, Easing.CubicIn),
                imgTurned.RotateYTo(90, 250, Easing.CubicIn)
            );

            image.Source = "memory.png";
            imgTurned.Source = "memory.png";

            await Task.WhenAll(
                image.RotateYTo(0, 250, Easing.SpringOut),
                imgTurned.RotateYTo(0, 250, Easing.SpringOut)
            );
            currentCardCount = 0;
            running = true;
        }
        else
        {
            imgTurned = image;
            currentRow = Grid.GetRow(image);
            currentColumn = Grid.GetColumn(image);
            running = true;
        }
    }

    private void CardTheme(ImageButton image)
    {
        string selectedTheme = SelectedTheme.GetCurrentTheme();
        var row = Grid.GetRow(image);
        var col = Grid.GetColumn(image);

        switch (selectedTheme)
        {
            case "Fantasy":
                image.Source = "fan" + matrixNum[row, col].ToString() + ".png";
                Debug.WriteLine($"Image clicked: {image.Source}");
                break;
            case "Thriller":
                image.Source = "thr" + matrixNum[row, col].ToString() + ".png";
                Debug.WriteLine($"Image clicked: {image.Source}");
                break;
            case "Mystery":
                image.Source = "mys" + matrixNum[row, col].ToString() + ".png";
                Debug.WriteLine($"Image clicked: {image.Source}");
                break;
            default:
                break;
        }
    }
}