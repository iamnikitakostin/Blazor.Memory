using BlazorCardGame.Client.Models;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace BlazorCardGame.Client.Services;

public static class GameService
{
    private static string url = "https://localhost:7151/api/Cardgames";

    public static async Task<List<Cardgame>> GetAll ()
    {
        HttpClient Http = new HttpClient();
        var list = await Http.GetFromJsonAsync<List<Cardgame>>(url);
        list=list.OrderByDescending(x=> x.GameDate).ToList();
        return list;
    }


    public static async Task<Cardgame> GetGameById (int id)
    {
        HttpClient Http = new HttpClient();
        var newurl = url + $"/{id}";
        try
        {
            var game = await Http.GetFromJsonAsync<Cardgame>(url);
            return game;
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex.Message);
            return null;
        }
    }

    public static async Task AddGame (Cardgame game)
    {
        HttpClient Http = new HttpClient();
        var jsonData = JsonConvert.SerializeObject(game);
        var content = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
        var response = await Http.PostAsync(url, content);
        var answer = response.Content.ReadAsStringAsync().Result;
        if (response.IsSuccessStatusCode)
        {
            var resultContent = response.Content.ReadAsStringAsync().Result;
        }
    }

    public static async Task DeleteGame (int id)
    {
        HttpClient Http = new HttpClient();
        var newurl = url + $"/{id}";

        var response = await Http.DeleteAsync(newurl);
        if (response.IsSuccessStatusCode)
        {
            var resultContent = response.Content.ReadAsStringAsync().Result;
        }
    }

    public static async Task<List<Cardgame>> GetGamesBetweenDates (DateTime startD, DateTime endD)
    {
        string startDateString = startD.Date.ToString("dd-MM-yyyy").Split()[0];
        string endDateString = endD.Date.ToString("dd-MM-yyyy").Split()[0];

        HttpClient Http = new HttpClient();
        var newurl = url + $"?dateS={startDateString}&dateE={endDateString}";
        var filteredList = await Http.GetFromJsonAsync<List<Cardgame>>(newurl);
        filteredList=filteredList.OrderByDescending(x=> x.GameDate).ToList();
        return filteredList;
    }
}
