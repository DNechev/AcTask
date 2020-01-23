using AssecorTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssecorTask.Persistance.EF.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.HasKey(pe => pe.Id);
            builder.Property(pe => pe.Id);

            builder.HasOne<ColorEntity>()
                .WithMany()
                .HasForeignKey(pe => pe.ColorId)
                .IsRequired();
        }
    }
}
