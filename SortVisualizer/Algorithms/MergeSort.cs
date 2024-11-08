using System.Reflection;

namespace SortVisualizer.Algorithms
{
    public class MergeSort : ISortable
    {
        // Best case: O(NlogN)
        // Average case: O(NlogN)
        // Worst case: O(NlogN)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested(); after each iteration

            await MergeSortAsync(0, array.Length - 1);

            async Task MergeAsync(int left, int middle, int right)
            {
                int n1 = middle - left + 1; // size of the left sub array
                int n2 = right - middle; // size of the right sub array

                // creating two temp arrays
                int[] leftArray = new int[n1];
                int[] rightArray = new int[n2];

                for (int i = 0; i < n1; i++)
                {
                    leftArray[i] = array[left + i];
                }
                for (int i = 0; i < n2; i++)
                {
                    rightArray[i] = array[middle + 1 + i];
                }

                int leftIndex = 0;
                int rightIndex = 0;
                int mergeIndex = left;

                // combines the sub-arrays back together
                while (leftIndex < n1 && rightIndex < n2)
                {
                    if (leftArray[leftIndex].CompareTo(rightArray[rightIndex]) < 0) // checking and swapping values as needed
                    {
                        array[mergeIndex] = leftArray[leftIndex];
                        leftIndex++;
                        await Repaint(null);
                    }
                    else
                    {
                        array[mergeIndex] = rightArray[rightIndex];
                        rightIndex++;
                        await Repaint(null);
                    }

                    cancellationToken.ThrowIfCancellationRequested();
                    mergeIndex++;
                }

                // for uneven sub-arrays, it makes sure the rest of the values get put back in order
                while (leftIndex < n1)
                {
                    array[mergeIndex] = leftArray[leftIndex];
                    leftIndex++;
                    mergeIndex++;
                    await Repaint(null);
                    cancellationToken.ThrowIfCancellationRequested();
                }

                while (rightIndex < n2)
                {
                    array[mergeIndex] = rightArray[rightIndex];
                    rightIndex++;
                    mergeIndex++;
                    await Repaint(null);
                    cancellationToken.ThrowIfCancellationRequested();
                }
            }

            async Task MergeSortAsync(int left, int right)
            {
                if (left >= right)
                {
                    return;
                }
                int middle = (left + right) / 2;

                await MergeSortAsync(left, middle);
                await MergeSortAsync(middle + 1, right); //middle + 1 to ensure a seperate left side from the previos mergeSort

                // merging sub-arrays
                await MergeAsync(left, middle, right);
            }

        }
    }
}
