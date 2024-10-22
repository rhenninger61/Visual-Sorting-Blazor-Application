namespace SortVisualizer.Algorithms
{
    public interface ISortable
    {
        // Ensure all sorting algorithms are async
        Task SortAsync(int[] array, Func<int?, Task> Repaint, CancellationToken cancellationToken);
    }
}
