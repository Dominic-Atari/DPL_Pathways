using System;

namespace MusicApp
{
    public class AfroBeats : MusicBase
    {
        public string SongName { get; set; }
        public string Artist { get; set; }
        public long Views { get; set; }

        public AfroBeats(string songName, string artist, long views, string type, string origin) : base(type, origin)
        {
            SongName = songName;
            Artist = artist;
            Views = views;
        }

        //public override int SongViews()
        // public override long SongViews()
        // {
        //     Random random = new Random();
        //     random.NextInt64(5000000000, long.MaxValue);
        //     if (random.NextInt64(500000000, long.MaxValue) < 900000)
        //     {
        //         //return number K example 1K
        //         return random.DecimalPlaces(3);
        //     }
        //     if (random.NextInt64(500000000, long.MaxValue) > 9000000)
        //     {
        //         //return number K example 1K
        //         return random.DecimalPlaces(4);
        //     }
        //     else
        //     {
        //         return random.DecimalPlaces(6);
        //     }
        //}

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