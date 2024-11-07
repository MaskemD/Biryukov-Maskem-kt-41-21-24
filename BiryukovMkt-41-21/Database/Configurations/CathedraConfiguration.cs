using BiryukovMkt_41_21.Database.Helpers;
using BiryukovMkt_41_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BiryukovMkt_41_21.Database.Configurations
{
    public class CathedraConfiguration : IEntityTypeConfiguration<Cathedra>
    {
        private const string TableName = "cathedras";

        public void Configure(EntityTypeBuilder<Cathedra> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(p => p.CathedraId);

            builder.Property(p => p.CathedraId)
                .ValueGeneratedOnAdd()
                .HasColumnName("cathedra_id")
                .HasComment("Идентификатор записи кафедры");

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnName("cathedra_name")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Название кафедры");

            builder.Property(p => p.HeadTeacherId)
                .HasColumnName("f_head_teacher_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор заведующего кафедрой");

            builder.ToTable(TableName)
                .HasOne(p => p.HeadTeacher)
                .WithOne()
                .HasForeignKey<Cathedra>(p => p.HeadTeacherId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
