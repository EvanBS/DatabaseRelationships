using System.Collections.Generic;
using System.Data.Entity;

namespace ModLearn.Models
{
    public class AppDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            List<Team> defTeams = new List<Team>
            {
                new Team {Id = 1, Name = "Реал Мадрид", Coach = "Анчелотти" },
                new Team {Id = 2, Name = "Барселона", Coach = "Мартино" },
                new Team {Id = 3, Name = "Бавария", Coach = "Гуардиола" },
                new Team {Id = 4, Name = "Боруссия", Coach = "Клопп" }
            };

            context.Teams.AddRange(defTeams);
            context.SaveChanges();

            List<Player> defPlayers = new List<Player>
            {
                new Player {Id = 1, Name = "Месси", Age = 26, Position = "Нападающий", TeamId = 2 },
                new Player {Id = 2, Name = "Роналду", Age = 29, Position = "Нападающий", TeamId = 1 },
                new Player {Id = 3, Name = "Бейл", Age = 24, Position = "Полузащитник", TeamId = 1 },
                new Player {Id = 4, Name = "Неймар", Age = 22, Position = "Нападающий", TeamId = 2 },
                new Player {Id = 5, Name = "Иньеста", Age = 29, Position = "Полузащитник", TeamId = 3 }
            };

            context.Players.AddRange(defPlayers);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}