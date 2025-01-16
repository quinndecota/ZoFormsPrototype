using System.Reflection.Metadata.Ecma335;

using GameStore.Api.Data;
using GameStore.Api.DTOs;
using GameStore.Api.Entities;
using GameStore.Api.Mapping;

using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints
{


    public static class GameEndpoints
    {

        const string GetGameEndpointName = "GetGame";

        private static readonly List<GameSummaryDTO> games = [

            new(
                1,
                "Pokemon Go",
                "Adventure",
                0.0M,
                new DateOnly(2015, 1, 15)
            ),
            new(
                2,
                "Elden Ring",
                "RPG",
                40.00M,
                new DateOnly(2017, 4, 15)
            ),
            new(
                3,
                "Sword Art Online",
                "RPG",
                99.00M,
                new DateOnly(2022, 9, 1)
            )

        ];

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games");


//GET /games
            group.MapGet("/", (GameStoreContext dbContext) =>
                dbContext.Games.Include(Game => Game.Genre)
                .Select(game => game.ToGameSummaryDTO()).AsNoTracking());

//GET /games/1
            group.MapGet("/{id}", (int id, GameStoreContext dbContext) => {

                Game? game = dbContext.Games.Find(id);

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailDTO());

            }).WithName(GetGameEndpointName);


// POST /games
            group.MapPost("/", (CreateGameDTO newGame, GameStoreContext dbContext) =>
            {


                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                dbContext.SaveChanges();

                return Results.CreatedAtRoute(GetGameEndpointName,
                    new { id = game.Id },
                    game.ToGameDetailDTO());
            });

//PUT 
            group.MapPut("/{id}", (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = dbContext.Games.Find(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
                dbContext.SaveChanges();

                return Results.NoContent();

            });

//DELETE
            group.MapDelete("/{id}", (int id, GameStoreContext dbContext) =>
            {

                Game? game = dbContext.Games.Find(id);

                if (game is null)
                {
                    return Results.NotFound();
                }

                dbContext.Games.Remove(game);
                dbContext.SaveChanges();

                return Results.NoContent();
            });

            return group;
        }


        
    }
}
