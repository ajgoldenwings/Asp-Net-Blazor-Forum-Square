using ForumSquare.Client.Extensions;
using ForumSquare.Client.Models;
using ForumSquare.Client.Models.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace ForumSquare.Client.Services
{
    public class MessagesService
    {
        private readonly HttpClient _httpClient;
        
        public MessagesService(HttpClient httpClient)
        {
            _httpClient = httpClient;

            //_httpClient.BaseAddress = new Uri("http://localhost:7777/");
            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Origin", "*");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Methods", "*");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Allow-Headers", "*");
            //_httpClient.DefaultRequestHeaders.Add("Access-Control-Max-Age", "86400");
        }

        public async Task<ApiObjectResponse<Collection<Message>>> GetMessages()//Category filterByCategory = null
        {
            var queryParams = new Dictionary<string, string>();
            //if (filterByCategory != null)
            //{
            //    queryParams.Add("search", $"categoryid eq {filterByCategory.Id}");
            //}
            var returnValue = await _httpClient.ApiGetAsync<Collection<Message>>("api/Messages", queryParams);

            return returnValue;
            //return new ApiObjectResponse<Collection<Message>>();
        }

        public async Task<ApiObjectResponse<Message>> CreateMessage(MessageForm form)
        {
            return await _httpClient.ApiPostAsync<Message>("api/messages", form);
        }
        //public Task<Message[]> GetMessagesAsync()
        //{
        //return new Message();
        //return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //{
        //    Date = startDate.AddDays(index),
        //    TemperatureC = rng.Next(-20, 55),
        //    Summary = Summaries[rng.Next(Summaries.Length)]
        //}).ToArray());
        //}
    }
}
