namespace MoodLibrary.Api.Dtos
{
    public class AlbumDto
    {
        public required string Name { get; set; }
        public DateTime ReleaseDate { get; set; }
        public required List<SongDto> Songs { get; set; }
    }
}