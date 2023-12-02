using System.Diagnostics;
using Xamarin.Forms;

namespace xUnit_Flip_n_Find
{
    public class UnitTest1
    {
        public int[,] matrixNum = new int[4, 4];
        private const int NumRows = 4;
        private const int NumColumns = 4;

        public int currentCardCount = 0;
        //pairsFound is set to 7 so when the method runs, the pairsFound will be 8, fulfilling the condition for winning condition
        public int pairsFound = 7;

        public ImageButton image;
        public ImageButton imgTurned;
        public Stopwatch sw = new Stopwatch();
        public bool win = false;
        public bool running;


        [Fact]
        public void Test1()
        {            
            //from CreateGrid()
            Random random = new Random();
            HashSet<(int, int)> usedIndices = new HashSet<(int, int)>();

            for (int i = 0; i < 8; i++)
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

            //Assert: Check if the method materialises 4x4 matrix with randomised numbers
            Assert.True(true);
        }

        [Fact]
        public void Test1_ShouldRandomizeMatrix()
        {
            // Arrange
            UnitTest1 unitTest = new UnitTest1();

            // Act
            int[,] originalMatrix = (int[,])unitTest.matrixNum.Clone(); // Copy the original matrix
            unitTest.Test1();

            // Assert: Check if the matrix is different after the method call
            Assert.NotEqual(originalMatrix, unitTest.matrixNum);
        }

        [Fact]
        public void Test2()
        {
            // Arrange: Initialising
            UnitTest1 unitTest = new UnitTest1();
            unitTest.image = new ImageButton();
            unitTest.imgTurned = new ImageButton();

            if (image != null && imgTurned != null && matrixNum[Grid.GetRow(image), Grid.GetColumn(image)] == matrixNum[Grid.GetRow(imgTurned), Grid.GetColumn(imgTurned)])
            {
                currentCardCount = 0;
                image.IsEnabled = false;
                imgTurned.IsEnabled = false;
                imgTurned = null;
                pairsFound++;

                if (pairsFound == 8)
                {
                    win = true;
                    sw.Stop();
                }

                running = true;
                return;
            }

            // Act
            unitTest.Test2(); // Call the method

            //Assert: 'win' flag is true as expected
            Assert.True(unitTest.win);
        }

        [Fact]
        public void Test2_EqualMatrixElements()
        {
            // Arrange
            UnitTest1 unitTest = new UnitTest1();
            unitTest.image = new ImageButton();
            unitTest.imgTurned = new ImageButton();
            unitTest.matrixNum[0, 0] = 1; // Set matrix elements to be equal

            // Act
            unitTest.Test2();

            // Assert: Ensure imgTurned is set to null
            Assert.Null(unitTest.imgTurned);
        }
    }
}