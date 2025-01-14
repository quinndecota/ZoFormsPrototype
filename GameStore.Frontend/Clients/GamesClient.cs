using System;
using GameStore.Frontend.Models;

namespace GameStore.Frontend.Clients;

public class GamesClient
{
    private readonly List<GameSummary> games = 
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


    private readonly Genre[] genres = new GenresClient().GetGenres();

    public GameSummary[] GetGames() => [.. games];

    public void AddGame(GameDetails game)
    {
        Genre genre = GetGenreByID(game.GenreID);

        var gameSummary = new GameSummary
        {
            Id = games.Count + 1,
            Name = game.Name,
            Genre = genre.Name,
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };

        games.Add(gameSummary);
    }

    

    public GameDetails GetGame(int id)
    {
        GameSummary game = GetGameSummaryByID(id);

        var genre = genres.Single(genre => string.Equals(genre.Name, game.Genre, StringComparison.OrdinalIgnoreCase));

        return new GameDetails
        {
            Id = game.Id,
            Name = game.Name,
            GenreID = game.Genre.ToString(),
            Price = game.Price,
            ReleaseDate = game.ReleaseDate
        };
    }


    public void updateGame(GameDetails updatedGame)
    {
        var genre = GetGenreByID(updatedGame.GenreID);
        GameSummary existingGame = GetGameSummaryByID(updatedGame.Id);

        existingGame.Name = updatedGame.Name;
        existingGame.Genre = genre.Name;
        existingGame.Price = updatedGame.Price;
        existingGame.ReleaseDate = updatedGame.ReleaseDate;
    }

    public void DeleteGame(GameSummary game){
        var gameToRemove = games.Single(r => r.Id == game.Id);
        games.Remove(gameToRemove);
    }


    private GameSummary GetGameSummaryByID(int id)
    {
        GameSummary? game = games.Find(game => game.Id == id);
        ArgumentNullException.ThrowIfNull(game);
        return game;
    }

    private Genre GetGenreByID(string? id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(id);
        var genre = genres.Single(genre => genre.Id == int.Parse(id));
        return genre;
    }
}