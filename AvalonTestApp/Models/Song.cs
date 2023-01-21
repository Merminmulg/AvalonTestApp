using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonTestApp.Models
{
    public class Song:IEquatable<Song>, INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string AlbumName { get; set; }
        public string Duration { get; set; }
        public string Singer { get; set; }
        public Song(string name, string albumName, string duration, string singer)
        {
            Name = name;
            AlbumName = albumName;
            Duration = duration;
            Singer = singer;
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public bool Equals(Song? other)
        {
            if (other.Singer != this.Singer || other.Name != this.Name || other.Duration != this.Duration || other.AlbumName != this.AlbumName)
            {
                return false;
            }
            return true;
        }
    }
}
