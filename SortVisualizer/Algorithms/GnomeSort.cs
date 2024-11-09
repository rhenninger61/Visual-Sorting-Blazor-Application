
using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class GnomeSort : ISortable
    {
        // Best case: O(N^2)
        // Average case: O(N)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested(); after each iteration

            int index = 0; // keeps track of the index with the lwest value

            while (index < array.Length) // iterate through the array until its sorted
            {
                cancellationToken.ThrowIfCancellationRequested();

                if (index == 0)// moves to the next index if the lowest value is found
                    index++;
                if (array[index] >= array[index - 1]) // increase the index if the two values are sorted
                    index++;
                else // swaps values to sort them
                {
                    int temp = array[index];
                    array[index] = array[index - 1];
                    array[index - 1] = temp;
                    await Repaint(null);

                    index--; // resets index to make sure the value before the index value is also sorted correctly
                }
            }
        }
    }
}
