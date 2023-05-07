using GeekShopping.Web.Models;
using GeekShopping.Web.Services.IServices;
using GeekShopping.Web.Utils;
using System.Net.Http.Headers;
using System.Reflection;

namespace GeekShopping.Web.Services
{
    public class CartService : ICartService
    {

        private readonly HttpClient _client;
        public const string BasePath = "api/v1/cart";

        public CartService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<CartViewModel> FindCartByUserId(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            var response = await _client.GetAsync($"{BasePath}/find-cart/{userId}");
            return await response.ReadContentsAs<CartViewModel>();
        }

        public async Task<CartViewModel> AddItemToCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.PostAsJson($"{BasePath}/add-cart/", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentsAs<CartViewModel>();

            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> UpdateCart(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await _client.PutAsJson($"{BasePath}/update-cart/", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentsAs<CartViewModel>();

            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> RemoveFromCart(long cartId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // TODO - GABRIEL ADICIONANDO O TOKEN NO HEADER

            var response = await _client.DeleteAsync($"{BasePath}/remove-cart/{cartId}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentsAs<bool>();

            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<CartViewModel> Checkout(CartHeaderViewModel cartHeader, string token)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ClearCart(long cartId, string token)
        {
            throw new NotImplementedException();
        }


        public async Task<bool> ApplyCoupon(CartViewModel model, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // TODO - GABRIEL ADICIONANDO O TOKEN NO HEADER

            var response = await _client.PostAsJson($"{BasePath}/apply-coupon", model);

            if (response.IsSuccessStatusCode)
                return await response.ReadContentsAs<bool>();

            else throw new Exception("Something went wrong when calling API");
        }

        public async Task<bool> RemoveCoupon(string userId, string token)
        {
            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token); // TODO - GABRIEL ADICIONANDO O TOKEN NO HEADER

            var response = await _client.DeleteAsync($"{BasePath}/remove-coupon/{userId}");

            if (response.IsSuccessStatusCode)
                return await response.ReadContentsAs<bool>();

            else throw new Exception("Something went wrong when calling API");
        }

    }
}
