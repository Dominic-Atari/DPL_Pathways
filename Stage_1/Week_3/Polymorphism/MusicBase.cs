using System;

namespace MusicApp
{
    public abstract class MusicBase
    {
        public string Type { get; set; }

        public string Origin { get; set; }

        public MusicBase(string type, string origin)
        {
            Type = type;
            Origin = origin;
        }

        // Unique chatacteristics
        public virtual string Description()
        {
            return "";
        }
        //public abstract long SongViews();
    }
}