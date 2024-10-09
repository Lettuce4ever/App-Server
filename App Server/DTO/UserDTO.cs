using App_Server.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace App_Server.DTO
{
    public class UserDTO
    {
        public string Username { get; set; } = null!;
        public string? Email { get; set; }
        public string? UserPassword { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Score { get; set; }
        public int? GamesPlayed { get; set; }
        public int? TypeId { get; set; }
        public virtual ICollection<Game> GameLoserNavigations { get; set; } = new List<Game>();
        public virtual ICollection<Game> GameWinnerNavigations { get; set; } = new List<Game>();

        public UserDTO() { }
        public UserDTO(Models.User useri)
        {
            this.Username = useri.Username;
            this.Email = useri.Email;
            this.FirstName = useri.FirstName;
            this.LastName = useri.LastName;
            this.UserPassword = useri.UserPassword;

        }
    }
}
