namespace DeezerAPI;


public class Track
    {
        public long Id { get; set; }
        public bool Readable { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public int Duration { get; set; }
        public int Rank { get; set; }
        public bool ExplicitLyrics { get; set; }
        public int ExplicitContentLyrics { get; set; }
        public int ExplicitContentCover { get; set; }
        public string Md5Image { get; set; }
        public int TimeAdd { get; set; }
        public Album Album { get; set; }
        public Artist Artist { get; set; }
        public string Type { get; set; }

        public void Print()
        {
            Console.WriteLine($"Title : {this.Title} | Artist : {this.Artist.Name}  | Album : {this.Album.Title}");
        }
    }

public class Album
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Cover { get; set; }
        public string CoverSmall { get; set; }
        // ... Other album properties
    }

public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        // ... Other artist properties

        public override bool Equals(object? obj)
        {
            var a = obj as Artist;
            if (a != null)
            {
                return this.Id == a.Id || a.Name == this.Name;
            }
            
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            
            return this.Name.GetHashCode();
        }
    }

