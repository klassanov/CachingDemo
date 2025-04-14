using Microsoft.Extensions.Primitives;

namespace Caching.Demo.Web.GetProductsFeature
{
    public interface IProductsChangeTokenProvider
    {
        IChangeToken GetChangeToken();

        void SignalChange();
    }
}