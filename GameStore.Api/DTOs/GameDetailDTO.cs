namespace GameStore.Api.DTOs
{
    public record class GameDetailDTO(
    
        int Id,
        string Name,
        int GenreID,
        decimal Price,
        DateOnly ReleaseDate);
    
}
