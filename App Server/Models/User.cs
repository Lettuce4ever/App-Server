using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace App_Server.Models;

[Index("Email", Name = "UQ__Users__A9D10534FAD91414", IsUnique = true)]
public partial class User
{
    [Key]
    [StringLength(16)]
    public string Username { get; set; } = null!;

    [StringLength(60)]
    public string? Email { get; set; }

    [StringLength(16)]
    public string? UserPassword { get; set; }

    [StringLength(30)]
    public string? FirstName { get; set; }

    [StringLength(30)]
    public string? LastName { get; set; }

    public int? Score { get; set; }

    public int? GamesPlayed { get; set; }

    [Column("TypeID")]
    public int? TypeId { get; set; }

    [InverseProperty("LoserNavigation")]
    public virtual ICollection<Game> GameLoserNavigations { get; set; } = new List<Game>();

    [InverseProperty("WinnerNavigation")]
    public virtual ICollection<Game> GameWinnerNavigations { get; set; } = new List<Game>();

    [ForeignKey("TypeId")]
    [InverseProperty("Users")]
    public virtual UserType? Type { get; set; }
}
