using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class InsertionSort : ISortable
    {
        // Best case: O(N)
        // Average case: O(N^2)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested() after each iteration

            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                int temp = array[i]; //references current lowest number in different variable

                //looks at element to the left and sees if there is anything greater than it
                // if not true, either the end of the array has been reached or a value has been found that is less than that value
                for (; j >= 0 && array[j].CompareTo(temp) > 0; j--)
                {
                    //preform a shift to the right
                    array[j + 1] = array[j];
                }

                // inserts the value to the right of the next lowest number in the array
                array[j + 1] = temp;
                await Repaint(null);
                cancellationToken.ThrowIfCancellationRequested();
            }
        }
    }
}
