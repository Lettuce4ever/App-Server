using System.ComponentModel.DataAnnotations;

namespace App_Server.DTO
{
    public class GameDTO
    {
        public int GameId { get; set; }

        public int? ActionsAmount { get; set; }

        public int? TurnsAmount { get; set; }

        public DateOnly? Date { get; set; }

        public int? PointsGained { get; set; }

        public int? PointsLost { get; set; }

        public string? Winner { get; set; }

        public string? Loser { get; set; }
    }
}
