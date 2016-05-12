using System.Collections.Generic;
using RetroGamesWeb.Data.Entities;

namespace RetroGamesWeb.Models
{
    public class PlayerGames
    {
        public Player Player { get; set; }

        public List<Game> AvailableGames { get; set; }
    }
}