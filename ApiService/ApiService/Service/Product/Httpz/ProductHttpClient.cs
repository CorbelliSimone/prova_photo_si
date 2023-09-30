using ApiService.Service.Httpz;

namespace ApiService.Service.Product.Httpz
{
    public class ProductHttpClient : BaseHttpClient, IProductHttpClient
    {
        public ProductHttpClient(HttpClient httpClient)
            : base(httpClient, "v1/product/")
        {
        }
    }
}
