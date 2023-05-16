using Microsoft.AspNetCore.Identity;
using HRBMSWEBAPP.ViewModel;
using HRBMSWEBAPP.Models;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;

namespace HRBMSWEBAPP.Repository.Rest
{
    public class AccountRepository : IAccountRepository
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configs;

        public AccountRepository(IConfiguration configs)
        {
            _httpClient = new HttpClient();
            _configs = configs;
            _httpClient.BaseAddress = new Uri("https://localhost:7098/api");
        //https://localhost:7098/api/Account/login
        }
        public async Task<bool> SignUpUserAsync(RegisterViewModel user)
        {
            var newTodoAsString = JsonConvert.SerializeObject(user);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("/signup", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return true;
            }

            return false;
        }

        public async Task<string> SignInUserAsync(LoginUserViewModel loginUserViewModel)
        {
            // rest api call
            var newTodoAsString = JsonConvert.SerializeObject(loginUserViewModel);
            var requestBody = new StringContent(newTodoAsString, Encoding.UTF8, "application/json");
            _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
            var response = await _httpClient.PostAsync("/Account/login", requestBody);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                // extract token from responce and store it in session
                var token = JObject.Parse(content)["token"].ToString();
                
                return token ;
            }

            return null;
        }

    }
}
