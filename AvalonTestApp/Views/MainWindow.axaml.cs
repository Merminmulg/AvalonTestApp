using Avalonia.Controls;
using System.Collections.ObjectModel;
using AvalonTestApp.Models;
using AvalonTestApp.DataSetter;

namespace AvalonTestApp.Views
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Song> Songs { get; set; }
        public ObservableCollection<AlbumTitle> albumTitleCollection { get; set; }
        public AlbumTitle albumTitle { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            albumTitleCollection = new ObservableCollection<AlbumTitle>();
            albumTitleCollection.Add(AlbumTitleParser.Parser("https://music.amazon.com/playlists/B08BWK8W15"));
            Songs = new ObservableCollection<Song>(SongParser.Parser("https://music.amazon.com/playlists/B08BWK8W15")); 
            albumTitleView.Items = albumTitleCollection;
            
            songList.Items = Songs;
        }
    }
}
