using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ModLearn.Models
{
    public interface IRepository
    {
        void SaveChanges();

        ApplicationDbContext context { get; set; }

        Task<List<Team>> getAllTeamsAsync();

        Task<List<Player>> getAllPlayersAsync();

        Task<Team> GetTeamByNameAsync(String Name);

        void AddPlayer(Player player);
    }

    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Player> Players { get; set; }

        public virtual DbSet<Team> Teams { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class TeamRepository : IRepository, IDisposable
    {
        public ApplicationDbContext db;

        public ApplicationDbContext context
        {
            get { return db; }
            set { db = value; }
        }

        public async Task<List<Team>> getAllTeamsAsync()
        {
            return await context.Teams.Include(t => t.Players).ToListAsync();
        }

        public async Task<List<Player>> getAllPlayersAsync()
        {
            return await context.Players.Include(p => p.Team).ToListAsync();
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public async Task<Team> GetTeamByNameAsync(string Name)
        {
            return await context.Teams.Include(t => t.Players).Where(t => t.Name == Name).FirstOrDefaultAsync();
        }

        public void AddPlayer(Player player)
        {
            context.Players.Add(player);
        }
    }
}