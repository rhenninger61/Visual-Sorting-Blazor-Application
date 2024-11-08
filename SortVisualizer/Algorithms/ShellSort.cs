using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class ShellSort : ISortable
    {
        // Best case: O(NlogN)
        // Average case: O(NlogN)^2
        // Worst case: O(NlogN)^2
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested(); after each iteration

            // starts with a large gap to sort and then divides that gap into smaller ones
            for (int gap = array.Length / 2; gap > 0; gap /= 2)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // performs an insertion sort on each gap until each one is sorted
                for (int i = gap; i < array.Length; i++)
                {
                    int temp = array[i];

                    // finishes sorting the presorted elements until everything is in it's propper location
                    int j;
                    for (j = i; j >= gap && array[j - gap].CompareTo(temp) > 0; j -= gap)
                    {
                        array[j] = array[j - gap];
                        await Repaint(null);
                    }
                    array[j] = temp;
                }
            }
        }
    }
}
