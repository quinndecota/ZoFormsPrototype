using System;

using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient(HttpClient httpClient)
{
    /*private readonly List<GameSummary> games = 
    [
        new(){
            Id=1,
            Name="Pokemon Go",
            Genre="Adventure",
            Price=0.0M,
            ReleaseDate = new DateOnly(2015, 1, 15)
        },
        new(){
            Id=2,
            Name="Elden Ring",
            Genre="RPG",
            Price=40.00M,
            ReleaseDate = new DateOnly(2017, 4, 15)
        },
        new(){
            Id=3,
            Name="UFC 4",
            Genre="Sports",
            Price=60.00M,
            ReleaseDate = new DateOnly(2020, 9, 1)
        }
    ];

    //private int IdCount { get; set; } = 3;
    //private readonly Genre[] genres = new GenresClient(httpClient).GetGenresAsync();
    */
    public async Task<GameSummary[]> GetGamesAsync() =>
        await httpClient.GetFromJsonAsync<GameSummary[]>("games") ?? [];

    public async Task AddGameAsync(GameDetails game) =>
        await httpClient.PostAsJsonAsync("games", game);


    public async Task<GameDetails> GetGameAsync(int id) =>
        await httpClient.GetFromJsonAsync<GameDetails>($"games/{id}") ?? throw new Exception("Game Not Found");


    public async Task updateGameAsync(GameDetails updatedGame) =>
        await httpClient.PutAsJsonAsync($"games/{updatedGame.Id}", updatedGame);


    public async Task DeleteGameAsync(GameSummary game) =>
        await httpClient.DeleteAsync($"games/{game.Id}");



    //private GameSummary GetGameSummaryByID(int id)
    //{
    //    GameSummary? game = games.Find(game => game.Id == id);
    //    ArgumentNullException.ThrowIfNull(game);
    //    return game;
    //}

    //private Genre GetGenreByID(string? id)
    //{
    //    ArgumentException.ThrowIfNullOrWhiteSpace(id);
    //    var genre = genres.Single(genre => genre.Id == int.Parse(id));
    //    return genre;
    //}
}