using System;
using System.IO;
using System.Net.Http;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using ExtremelySimpleLogger;
using Newtonsoft.Json;
using OlimpaSolution.models;

namespace OlimpaSolution.services;

public static class NetworkService
{
    private static HttpClient _httpClient = new HttpClient();
    private const string ServerUri = "https://dt.miet.ru/ppo_it_final";
    public static readonly string DataPath = App.Path + "tmp/";
    private const string Token = "daqazfdo";

    static NetworkService()
    {
        _httpClient.DefaultRequestHeaders.Add("X-Auth-Token",Token);
    }
    
    public static async Task<bool> GetSensorsData()
    {

        HttpRequestMessage request = new HttpRequestMessage()
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri(ServerUri)
        };

        var response = await _httpClient.SendAsync(request);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            App.Logger.Log(LogLevel.Error, $"Received response with {response.StatusCode} status for token = {Token}");
            return false;
        }

        if (!Directory.Exists(DataPath)) Directory.CreateDirectory(DataPath);
        App.Logger.Log(LogLevel.Info, "message is received, writing it...");
        await File.WriteAllTextAsync(DataPath + "example.json", await response.Content.ReadAsStringAsync());

        return true;
    }


}