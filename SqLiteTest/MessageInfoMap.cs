using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace SqLiteTest
{
    public class MessageInfoMap : EntityTypeConfiguration<MessageInfoEntity>
    {
        public MessageInfoMap(string tableName)
        {
            HasKey(e => e.EventId);
            Property(e => e.EventId)
                .HasColumnName("EventID")
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            
            Property(e => e.ChatId)
                .HasColumnName("ChatID");

            ToTable($"{tableName}");
        }
    }
}