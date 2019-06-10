using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AvaViber.Db.Entities;

namespace AvaViber.Db.SqLite.Mappings
{
    public class ChatInfoMap : EntityTypeConfiguration<ChatInfoEntity>
    {
        public ChatInfoMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("ChatID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            ToTable($"{tableName}");
        }
    }
}