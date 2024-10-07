using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App_Server.Models;

public partial class Game
{
    [Key]
    [Column("GameID")]
    public int GameId { get; set; }

    public int? ActionsAmount { get; set; }

    public int? TurnsAmount { get; set; }

    public DateOnly? Date { get; set; }

    public int? PointsGained { get; set; }

    public int? PointsLost { get; set; }

    [StringLength(16)]
    public string? Winner { get; set; }

    [StringLength(16)]
    public string? Loser { get; set; }

    [ForeignKey("Loser")]
    [InverseProperty("GameLoserNavigations")]
    public virtual User? LoserNavigation { get; set; }

    [ForeignKey("Winner")]
    [InverseProperty("GameWinnerNavigations")]
    public virtual User? WinnerNavigation { get; set; }
}
