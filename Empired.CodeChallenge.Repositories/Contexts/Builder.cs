using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Empired.CodeChallenge.Repositories.Models;

namespace Empired.CodeChallenge.Repositories.Contexts
{
    public static class Builder
    {
        public static void Create(this EntityTypeConfiguration<Animal> builder)
        {
            builder.ToTable("Animal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Behaviour).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Colour).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Uniqueness).IsRequired().HasMaxLength(255);
        }
    }
}
