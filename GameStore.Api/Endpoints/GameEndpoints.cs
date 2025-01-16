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

        public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
        {

            var group = app.MapGroup("games");


//GET /games
            group.MapGet("/", async (GameStoreContext dbContext) => {

                return await dbContext.Games.Include(Game => Game.Genre)
                    .Select(game => game.ToGameSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync();
            });

//GET /games/xxx
            group.MapGet("/{id}", async (int id, GameStoreContext dbContext) => {

                Game? game = await dbContext.Games.FindAsync(id);

                return game is null ? Results.NotFound() : Results.Ok(game.ToGameDetailDTO());

            }).WithName(GetGameEndpointName);


// POST /games
            group.MapPost("/", async (CreateGameDTO newGame, GameStoreContext dbContext) =>
            {


                Game game = newGame.ToEntity();

                dbContext.Games.Add(game);
                await dbContext.SaveChangesAsync();

                return Results.CreatedAtRoute(GetGameEndpointName,
                    new { id = game.Id },
                    game.ToGameDetailDTO());
            });

//PUT 
            group.MapPut("/{id}", async (int id, UpdateGameDTO updatedGame, GameStoreContext dbContext) =>
            {
                var existingGame = await dbContext.Games.FindAsync(id);

                if (existingGame is null)
                {
                    return Results.NotFound();
                }

                dbContext.Entry(existingGame).CurrentValues.SetValues(updatedGame.ToEntity(id));
                await dbContext.SaveChangesAsync();

                return Results.NoContent();

            });

//DELETE
            group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
            {

                Game? gameToRemove = await dbContext.Games.FindAsync(id);

                if (gameToRemove is null)
                {
                    return Results.NotFound();
                }

                dbContext.Games.Remove(gameToRemove);
                await dbContext.SaveChangesAsync();

                return Results.NoContent();
            });

            return group;
        }


        
    }
}
