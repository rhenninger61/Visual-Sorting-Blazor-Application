
namespace SortVisualizer.Algorithms
{
    public class OddEvenSort : ISortable
    {
        // Best case: O(N)
        // Average case: O(N^2)
        // Worst case: O(N^2)
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            bool sorted = false;

            while (sorted == false)
            {
                sorted = true;

                //odd index sort
                for (int i = 1; i < array.Length - 1; i += 2)
                {
                    if (array[i] > array[i + 1]) // checks if value to the right is greater
                    {
                        // larger value moved to the right

                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        await Repaint(null);

                        sorted = false; // I was proven wrong :(
                    }
                }
                // even index sort
                for (int i = 0; i < array.Length - 1; i += 2) // checks if value to the right is greater
                {
                    if (array[i] > array[i + 1]) // checks if value to the right is greater
                    {
                        // larger value moved to the right
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        await Repaint(null);
                        sorted = false; // I was proven wrong :(
                    }
                }
            }
        }
    }
}
