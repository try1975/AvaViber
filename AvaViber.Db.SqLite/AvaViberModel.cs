using System.Data.Entity;
using AvaViber.Db.Entities;
using AvaViber.Db.SqLite.Mappings;

namespace AvaViber.Db.SqLite
{
    public class AvaViberModel : DbContext
    {
        // Your context has been configured to use a 'AvaViberModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WindowsFormsApp1.AvaViberModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'AvaViberModel' 
        // connection string in the application configuration file.
        public AvaViberModel() : base("name=AvaViberModel")
        {
            Database.SetInitializer<AvaViberModel>(null);
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<MessageInfoEntity> MessageInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            const string prefix = "";
            modelBuilder.Configurations.Add(new MessageInfoMap($"{prefix}{nameof(MessageInfo)}"));
        }
    }
}