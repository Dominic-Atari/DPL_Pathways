using System;

namespace MusicApp
{
    public class AfroBeats : MusicBase
    {
        public string SongName { get; set; }
        public string Artist { get; set; }
        public string Views { get; set; }

        public AfroBeats(string songName, string artist, string views, string type, string origin) : base(type, origin)
        {
            SongName = songName;
            Artist = artist;
            Views = views;
        }

        // Unique chatacteristics
        public override string Description()
        {
            return "Description\nAfro-Caribbean, Afro-R&B, and local styles such as Highlife, Fuji, and Amapiano, characterized by African rhythms, slang, and...";

        }
        public override string ToString()
        {
            return $"\nArtist: {Artist}\nSong Name: {SongName}\nViews: {Views}\nType: {Type}\nOrigin: {Origin}";
        }
    }
}