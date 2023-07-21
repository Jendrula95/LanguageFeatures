using System.Collections;

namespace LanguageFeatures.Models
{
    public class ShoppingCart : IEnumerable<Product>
    {
        public List<Product> Products { get; set; }
        public IEnumerable<Product> GetEnumerator()
        {
            return Products;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        IEnumerator<Product> IEnumerable<Product>.GetEnumerator()
        {
            return ((IEnumerable<Product>)Products).GetEnumerator();
        }
    }
}
