namespace MoodLibrary.Api.Dtos
{
    public class SongDto
    {
        public required string Name { get; set; }
        public TimeSpan Duration { get; set; }
    }
}