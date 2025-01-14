using System;

namespace GameStore.Frontend.Models;

public class Genre
{
    public int Id { get; set; }

    public required string Name { get; set; }

    public static implicit operator string(Genre v)
    {
        throw new NotImplementedException();
    }
}
