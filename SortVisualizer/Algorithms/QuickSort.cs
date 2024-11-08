using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class QuickSort : ISortable
    {
        // Best case: O(NlogN)
        // Average case: O(NlogN)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement SelectionSort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested(); after each iteration

            await QuicksortAsync(0, array.Length - 1);

            async Task<int> PartitionAsync(int leftPointer, int rightPointer)
            {
                // choose the right most point to be pivot point
                int pivotIndex = rightPointer;
                int pivot = array[pivotIndex];

                rightPointer--; // decrement to not include the pivot point

                while (true)
                {
                    //check leftPointer against pivot
                    while (array[leftPointer].CompareTo(pivot) < 0)
                    {
                        //move leftpointer until you find a value that is >= pivot
                        leftPointer++;
                    }

                    while (rightPointer > 0 && array[rightPointer].CompareTo(pivot) > 0)
                    {
                        //move rightpointer until you find a value that is <= pivot
                        rightPointer--;
                    }

                    if (leftPointer >= rightPointer) break; //when the pointers reach or surpass the same value the while loop breaks

                    // swap values at pointers and then the loop restarts
                    int temp = array[leftPointer];
                    array[leftPointer] = array[rightPointer];
                    array[rightPointer] = temp;
                    await Repaint(null);


                    leftPointer++;
                }

                // swaps the pivot value and the leftpointer value
                array[pivotIndex] = array[leftPointer];
                array[leftPointer] = pivot;

                await Repaint(null);
                cancellationToken.ThrowIfCancellationRequested();
                return leftPointer;
            }

            async Task QuicksortAsync(int leftIndex, int rightIndex)
            {
                if (rightIndex - leftIndex <= 0) return;

                int pivotIndex = await PartitionAsync(leftIndex, rightIndex); // devides into two sub-arrays

                // continues until base-case is reached
                await QuicksortAsync(leftIndex, pivotIndex - 1); //recursively sort the left sub-array
                await QuicksortAsync(pivotIndex + 1, rightIndex); //recursively sort the right sub-array
            }

        }
        
        
    }
}
