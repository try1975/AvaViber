using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using AvaViber.Db.Entities;

namespace AvaViber.Db.SqLite.Mappings
{
    public class MessageInfoMap : EntityTypeConfiguration<MessageInfoEntity>
    {
        public MessageInfoMap(string tableName)
        {
            HasKey(e => e.Id);
            Property(e => e.Id)
                .HasColumnName("EventID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(e => e.ChatId)
                .HasColumnName("ChatID");

            ToTable($"{tableName}");
        }
    }
}