using Caliburn.Micro;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FireVape.WPF.Helpers
{
    public static class EnumerableExtensions
    {
        public static BindableCollection<T> AsBindable<T>(this IEnumerable<T> collection)
        {
            return new BindableCollection<T>(collection);
        }
        public static async Task<BindableCollection<T>> AsBindableAsync<T>(this Task<IEnumerable<T>> collection)
        {
            var source = await collection;
            return new BindableCollection<T>(source);
        }
    }
}
