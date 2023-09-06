using System.Diagnostics;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace DeezerAPI;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class Client
{
    private const string BaseApiUrl = "https://api.deezer.com";
    private const string AppId = "623224";
    private const string RedirectUri = "https://playlistroulette.com";
    private const string Permissions = "offline_access";
    private const string AppSecret = "f76d865f326296a234582de9e661ef6b";
    private const string authorizationCode = "fr8feb02ff59421710d4217973efac9a";
    private const string accessToken = "frvywS9nGeZePkOLlyBktV1DitIYEhjwcIyI48gCAvaek8OvZz";


    public static void StartLogin()
    {
        string loginUrl = $"https://connect.deezer.com/oauth/auth.php?app_id={AppId}&redirect_uri={RedirectUri}&perms={Permissions}";
        Process.Start(new ProcessStartInfo { FileName = loginUrl, UseShellExecute = true });
    }
    
    public static async Task<string> GetAccessToken()
    {
        using (var httpClient = new HttpClient())
        {
            // Create the access token request URL
            string tokenUrl = $"https://connect.deezer.com/oauth/access_token.php?app_id={AppId}&secret={AppSecret}&code={authorizationCode}";

            // Send a GET request to Deezer's API to get the access token
            var response = await httpClient.GetStringAsync(tokenUrl);

            // Parse the response to extract the access token

            return response;
        }
    }
    
    public class DeezerResponse
    {
        public List<Track> Data { get; set; }
        public int Total { get; set; }
    }
    
    public static (List<Track>,int?) ConvertJsonToTrackList(string json)
    {
        var res = JsonConvert.DeserializeObject<DeezerResponse>(json);
        // Console.Write(res.Data[4].Id);
        // res.Data[4].Print();
        var trackList = res?.Data; ;
        return (trackList,res?.Total);
    }

    public static async Task<string> GetUserTracklist(int index)
    {
        // Create an instance of HttpClient
        using (var httpClient = new HttpClient())
        {
            // Compose the API endpoint URL with the access_token parameter
            string apiUrl = $"{BaseApiUrl}/user/me/tracks?index={index}&limit=100&access_token={accessToken}";

            // Make the GET request to the API endpoint URL
            var response = await httpClient.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            else
            {
                Console.WriteLine($"La requête a échoué avec le code d'état : {response.StatusCode}");
                return null;
            }
        }
    }
}   