namespace RhythmsGonnaGetYou
{
    public class Song
    {
        public int Id { get; set; }
        public int TrackNumber { get; set; }
        public string Title { get; set; }
        public string Duration { get; set; }
        public int AlbumsId { get; set; }

        public Album Album { get; set; }
    }
}