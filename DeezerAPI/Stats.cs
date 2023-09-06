using Microsoft.VisualBasic.CompilerServices;

namespace DeezerAPI;

public class Stats
{
    public static IOrderedEnumerable<KeyValuePair<Artist,int>> Tracklist_Most_Popular_Artist(List<Track> tracklist)
    {
        Dictionary<Artist, int> dic = new Dictionary<Artist, int>();

        foreach (var track in tracklist)
        {
            if (dic.ContainsKey(track.Artist))
            {
                dic[track.Artist]++;
            }
            else
            {
                dic[track.Artist] = 1;
            }
        }

        
        
        IOrderedEnumerable<KeyValuePair<Artist,int>> chart = dic.OrderByDescending(Item => Item.Value);
        
        int id = 1;
        int total = 0;
        foreach (var pair in chart)
        {
            Console.WriteLine($"{id} | {pair.Key.Name} : {pair.Value}");
            total += pair.Value;
            id++;
        }
        
        return chart;
    }
}