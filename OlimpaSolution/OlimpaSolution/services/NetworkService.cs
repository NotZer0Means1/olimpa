using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ExtremelySimpleLogger;
using Newtonsoft.Json;

namespace OlimpaSolution.services;

public static class NetworkService
{
    private static HttpClient _httpClient = new HttpClient();
    private const string ServerUri = "https://dt.miet.ru/ppo_it_final";
    private static readonly string DataPath = App.Path + "tmp/";

    private class RequestContent
    {
        [JsonProperty("X-Auth-Token")] public string Token { get; } = "daqazfdo";
    }
    
    public static async Task<bool> GetSensorsData()
    {
        var content = new RequestContent();
        var jsonString = JsonConvert.SerializeObject(content);

        HttpRequestMessage request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            Content = new StringContent(jsonString, Encoding.UTF8, "application/json"),
            RequestUri = new Uri(ServerUri)
        };

        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            App.Logger.Log(LogLevel.Error, $"Received response with {response.StatusCode} status for token = {content.Token}");
            return false;
        }
        
        App.Logger.Log(LogLevel.Info, "message is received, writing it...");
        await File.WriteAllTextAsync(DataPath, await response.Content.ReadAsStringAsync());

        return true;
    }


}