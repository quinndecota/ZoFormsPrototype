﻿using GameStore.Api.DTOs;
using GameStore.Api.Entities;

using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Mapping
{
    public static class GameMapping
    {
        public static Game ToEntity(this CreateGameDTO game)
        {
            return new Game()
            {
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public static Game ToEntity(this UpdateGameDTO game, int id)
        {
            return new Game()
            {
                Id = id,
                Name = game.Name,
                GenreId = game.GenreId,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate
            };
        }

        public static GameSummaryDTO ToGameSummaryDTO(this Game game)
        {
            return new(
                game.Id,
                game.Name,
                game.Genre!.Name,
                game.Price,
                game.ReleaseDate
            );
        }

        public static GameDetailDTO ToGameDetailDTO(this Game game)
        {
            return new(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );
        }

    }
}
