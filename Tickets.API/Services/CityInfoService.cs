using System.Net.Http;
using Tickets.API.Extensions;
using Tickets.API.Models;

namespace Tickets.API.Services
{
    public class CityInfoService : ICityInfoService
    {
        private readonly HttpClient _client;

        public CityInfoService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }


        public async Task<string> GetAuthToken()
        {
            var responseAuthentication = await _client.PostAsJson("api/authentication/authenticate",
                   new Authentication("Aleksandar", "Password"));

            return await responseAuthentication.ReadContentAsString();
        }

        public async Task<PointOfInterest> GetPointOfInterest(int cityId, int pointOfInterest, string accessToken)
        {

            _client.DefaultRequestHeaders.Add("Authorization", "Bearer " + accessToken);
            var response = await _client.GetAsync($"api/cities/{cityId}/pointsofinterest/{pointOfInterest}");

            return await response.ReadContentAs<PointOfInterest>();
        }
    }
}
