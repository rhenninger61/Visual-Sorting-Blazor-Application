using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class SelectionSort : ISortable
    {
        // Best case: O(N^2)
        // Average case: O(N^2)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested() after each iteration
            
            // going left to right through the array
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minIndex = i; //min value always starts at the beginning of the array

                for (int j = i + 1; j < array.Length; j++)// another "prove me wrong" scenario, does a check to see if any of the values to the right are smaller than the current minimum
                {
                    if (array[j].CompareTo(array[minIndex]) < 0)
                    {
                        minIndex = j; // updates to the next smallest amount
                    }
                }
                if (minIndex != i)// preforms a swap if items[j] is smaller than items[i]
                {
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                    await Repaint(null);
                }
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}

