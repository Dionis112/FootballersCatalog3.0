using System;
using System.Linq;
using Каталог_футболистов_3._0.Models.Context;

namespace Каталог_футболистов_3._0
{
    public class StartData
    {
        public static void Initialize(FootballersContext context)
        {
            if (!context.Footballers.Any())
            {
                context.Footballers.Add(new Models.Footballers
                {
                    FirstName = "Эдуард",
                    LastName = "Стрельцов",
                    Gender = "Мужской",
                    BirthDate = Convert.ToDateTime("21.07.1937").Date,
                    NameTeam = "Торпедо",
                    Country = "Россия"
                });

                context.Footballers.Add(new Models.Footballers
                {
                    FirstName = "Эбби",
                    LastName = "Уомбак",
                    Gender = "Женский",
                    BirthDate = Convert.ToDateTime("02.06.1980").Date,
                    NameTeam = "Washington Freedom",
                    Country = "США"
                });

                context.SaveChanges();
            }
        }
    }
}
