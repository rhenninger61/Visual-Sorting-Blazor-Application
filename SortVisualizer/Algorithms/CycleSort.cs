
using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class CycleSort : ISortable
    {
        // Best case: O(NlogN)
        // Average case: O(NlogN)
        // Worst case: O(NlogN)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested(); after each iteration

            int writes = 0;

            // traverse the list
            for (int startPoint = 0; startPoint <= array.Length - 2; startPoint++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                // initialize an item as a starting point
                int item = array[startPoint];

                // find the correct location
                // count all elements on right side of item that are smaller
                int position = startPoint;
                for (int i = startPoint + 1; i < array.Length; i++)
                {
                    if (array[i].CompareTo(item) < 0)
                    {
                        position++;
                    }
                }

                // check if the item is already in the correct location
                if (position == startPoint)
                {
                    continue;
                }

                // ignores dupes
                while (item.CompareTo(array[position]) == 0)
                {
                    position += 1;
                }

                // performs a swap to put item in correction location
                if (position != startPoint)
                {
                    int temp = item;
                    item = array[position];
                    array[position] = temp;
                    await Repaint(null);
                    writes++;
                }

                // rotate through the rest of the cycle by repeating the steps
                while (position != startPoint)
                {
                    position = startPoint;

                    for (int i = startPoint + 1; i < array.Length; i++)
                    {
                        if (array[i].CompareTo(item) < 0)
                        {
                            position += 1;
                        }
                    }

                    while (item.CompareTo(array[position]) == 0)
                    {
                        position += 1;
                    }

                    if (item.CompareTo(array[position]) != 0)
                    {
                        int temp = item;
                        item = array[position];
                        array[position] = temp;
                        await Repaint(null);
                        writes++;
                    }
                }
            }
        }
    }
}
