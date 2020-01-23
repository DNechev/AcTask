using AssecorTask.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssecorTask.Persistance.EF.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<ColorEntity>
    {
        public void Configure(EntityTypeBuilder<ColorEntity> builder)
        {
            builder.HasKey(ce => ce.Id);
            builder.Property(ce => ce.Id);
        }
    }
}
