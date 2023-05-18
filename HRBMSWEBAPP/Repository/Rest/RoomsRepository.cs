using System.Text;
using Newtonsoft.Json;
using HRBMSWEBAPP.Models;
using System.Net.Http.Headers;
using HRBMSWEBAPP.Data;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using NuGet.Common;

namespace HRBMSWEBAPP.Repository.Rest;

public class RoomsRepository : IRoomsRepository
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configs;
    HRBMSDBCONTEXT _context;
    public RoomsRepository(IConfiguration configs, HRBMSDBCONTEXT context)
    {
        _httpClient = new HttpClient();
        // Local server
        _httpClient.BaseAddress = new Uri("https://localhost:7098/api");
        _configs = configs;
        _context = context;

    }

    public async Task<Room?> CreateRoom(Room newRoom, string token)
    {
       
        _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var newRoomAsString = JsonConvert.SerializeObject(newRoom);
        var responseBody = new StringContent(newRoomAsString, Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:7098/api/Room", responseBody);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<Room>(content);
            return room;
        }

        return null;
    }

    public async Task DeleteRoom(int roomId, string token)
    {

        _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

        //var newRoomAsString = JsonConvert.SerializeObject(newRoom);

        var response = await _httpClient.DeleteAsync($"https://localhost:7098/api/Room/{roomId}");
        if (response.IsSuccessStatusCode)
        {
            var data = await response.Content.ReadAsByteArrayAsync();
            Console.WriteLine("Delete Room Response: ", data);
        }
    }
  

    public async Task<List<Room>> GetAllRooms(string token)
    {
        _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var response = await _httpClient.GetAsync("https://localhost:7098/api/Room");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var rooms = JsonConvert.DeserializeObject<List<Room>>(content);
            return rooms ?? new List<Room>();
        }
        return new List<Room>();
    }

    //stored procedure for getting all rooms
    public List<Room> spGetAllRooms()
    {
        return _context.Room.FromSqlRaw($"exec getallrooms").ToList();
    }
    

    public async Task<Room?> GetRoomById(int roomId)
    {
        var response = await _httpClient.GetAsync($"/Room/{roomId}");
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<Room>(content);
            return room;
        }

        return null;
    }

    public async Task<Room?> UpdateRoom(int id, Room updatedRoom, string token)
    {
        _httpClient.DefaultRequestHeaders.Add("ApiKey", _configs.GetValue<string>("ApiKey"));
        _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
        var newRoomAsString = JsonConvert.SerializeObject(updatedRoom);
        var responseBody = new StringContent(newRoomAsString, Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"/Room/{id}", responseBody);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var room = JsonConvert.DeserializeObject<Room>(content);
            return room;
        }

        return null;
    }
}