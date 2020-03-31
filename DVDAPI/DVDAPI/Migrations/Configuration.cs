namespace DVDAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models.EF;
    using Models.POCOs;

    internal sealed class Configuration : DbMigrationsConfiguration<DVDAPI.Models.EF.DVDEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DVDAPI.Models.EF.DVDEntities context)
        {
            context.DVDs.AddOrUpdate(
                d => d.id,
                new DVDs { 
                    id = 1,
                    title = "Tremors",
                    director = "Ron Underwood",
                    rating = "PG-13",
                    year = 1990,
                    notes = "Worms!"
                }
            );

            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
//('Tremors', 'Ron Underwood', 'PG-13', '1990', 'Worms!'),
//('Tremors II: Aftershocks', 'S.S. Wilson', 'PG-13', '1996', 'More worms!'),
//('Tremors 3: Back to Perfection', 'S.S. Wilson', 'PG', '2001', 'Even more worms!'),
//('Tremors 4: The Legend Begins', 'S.S. Wilson', 'PG-13', '2004', 'Really old worms!'),
//('Tremors 5: Bloodlines', 'Don Michael Paul', 'PG-13', '2015', 'Flying worms!'),
//('Tremors: A Cold Day in Hell', 'Don Michael Paul', 'PG-13', '2018', 'Frozen worms!');
