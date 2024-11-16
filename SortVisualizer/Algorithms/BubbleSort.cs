using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class BubbleSort : ISortable
    {
        // Best case: O(N)
        // Average case: O(N^2)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement Bubble Sort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested() after each iteration
            bool sorted = false;
            int unsortedUntilIndex = array.Length - 1; // checks off values on the right once they are sorted

            while (sorted == false)
            {
                cancellationToken.ThrowIfCancellationRequested();

                sorted = true;// loops through the array, asking the algorithm to prove you wrong

                for (int i = 0; i < unsortedUntilIndex; i++)
                {
                    // greater value is moved to the right
                    if (array[i].CompareTo(array[i + 1]) > 0)
                    {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        await Repaint(null);
                        sorted = false; // it made a swap and proved you wrong                        
                    }
                }

                // largest item has been sorted and you don't need to look at it anymore
                unsortedUntilIndex--;
            }
        }
    }
}
