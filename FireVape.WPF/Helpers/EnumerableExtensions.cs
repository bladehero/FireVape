using Caliburn.Micro;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FireVape.WPF.Helpers
{
    public static class EnumerableExtensions
    {
        public static string GetDescription<T>(this T source)
        {
            var fi = source.GetType().GetField(source.ToString());

            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            else return source.ToString();
        }

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
