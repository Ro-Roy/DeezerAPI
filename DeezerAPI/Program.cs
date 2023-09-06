using DeezerAPI;

Console.WriteLine("Start");

// Client.StartLogin();

//string token = await Client.GetAccessToken();

//Console.WriteLine(token);

//frvywS9nGeZePkOLlyBktV1DitIYEhjwcIyI48gCAvaek8OvZz

string content = await Client.GetUserTracklist(0);

(List<Track> tracklist, int? total) = Client.ConvertJsonToTrackList(content);

Console.WriteLine($"Total {total}");

Console.WriteLine("\nPage 1");
int id = 100;
while (id < total)
{
    Console.WriteLine($"Page {(id+100)/100}");
    content = await Client.GetUserTracklist(id);
    tracklist.AddRange(Client.ConvertJsonToTrackList(content).Item1);
    id += 100;
}

int i = 0;
foreach (var track in tracklist)
{
    i++;
    Console.Write($"n°{i} | ");
    track.Print();
}

Console.WriteLine("------ FAVORITE ARTISTS -------\n");

Stats.Tracklist_Most_Popular_Artist(tracklist);

