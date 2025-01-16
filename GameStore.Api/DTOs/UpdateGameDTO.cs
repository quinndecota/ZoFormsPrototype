namespace GameStore.Api.DTOs
{
    public record class UpdateGameDTO(
        string Name,
        int GenreId,
        decimal Price,
        DateOnly ReleaseDate
    );
}
