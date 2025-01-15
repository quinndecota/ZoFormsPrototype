using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.DTOs



{
    public record class CreateGameDTO(
        [Required][StringLength(50)] string Name,
        [Required][StringLength(25)] string Genre,
        [Range(0,100)] decimal Price,
        [Required] DateOnly ReleaseDate);
}
