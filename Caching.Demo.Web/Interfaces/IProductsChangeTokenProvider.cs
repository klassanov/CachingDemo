using Microsoft.Extensions.Primitives;

namespace Caching.Demo.Web.Interfaces
{
    public interface IProductsChangeTokenProvider
    {
        IChangeToken GetChangeToken();

        void SignalChange();
    }
}