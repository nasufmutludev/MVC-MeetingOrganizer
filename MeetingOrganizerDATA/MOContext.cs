using System.Data.Entity;
using MOEntities;
namespace MeetingOrganizerDATA
{
    public class MOContext:DbContext
    {
        public MOContext() : base(GetApp())
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<MOContext>());
        }

        private static string GetApp()
        {
            return "Data Source=.;Integrated Security=True;Initial Catalog=MODB;MultipleActiveResultSets=true;";
        }

        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Meetings> Meetings { get; set; }        
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }        
    }
}
