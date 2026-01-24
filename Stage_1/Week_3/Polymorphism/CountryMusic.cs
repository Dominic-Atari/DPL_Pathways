using System;

namespace MusicApp
{
    public class CountryMusic : MusicBase
    {
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string Views { get; set; }

        public CountryMusic(string songName, string artist, string views, string type, string origin) : base(type, origin)
        {
            SongName = songName;
            Artist = artist;
            Views = views;
        }

        // Unique chatacteristics
        public override string Description()
        {
            return "Description\na genre of American music rooted in folk, blues, and Appalachian traditions, known for storytelling lyrics about everyday life...";
        }

        public override string ToString()
        {
            return $"\nArtist: {Artist}\nSong Name: {SongName}\nViews: {Views}\nType: {Type}\nOrigin: {Origin}";
        }
    }
}