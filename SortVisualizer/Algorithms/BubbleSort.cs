using System.Drawing;

namespace SortVisualizer.Algorithms
{
    public class BubbleSort : ISortable
    {
        public async Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken)
        {
            // TODO: Implement Bubble Sort
            // Remember to call Repaint() (e.g. await Repaint(null);) after each swap
            // Remember to call cancellationToken.ThrowIfCancellationRequested() after each iteration
        }
    }
}
