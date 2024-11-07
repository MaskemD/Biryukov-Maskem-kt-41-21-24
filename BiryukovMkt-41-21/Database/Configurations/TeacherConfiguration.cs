using BiryukovMkt_41_21.Database.Helpers;
using BiryukovMkt_41_21.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BiryukovMkt_41_21.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        private const string TableName = "teachers";

        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder
                .ToTable(TableName)
                .HasKey(p => p.TeacherId);

            builder.Property(p => p.TeacherId)
                .ValueGeneratedOnAdd()
                .HasColumnName("teacher_id")
                .HasComment("Идентификатор записи преподавателя");

            builder.Property(p => p.FirstName)
                .IsRequired()
                .HasColumnName("teacher_firstname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Имя преподавателя");

            builder.Property(p => p.LastName)
                .IsRequired()
                .HasColumnName("teacher_lastname")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Фамилия преподавателя");

            builder.Property(p => p.MiddleName)
                .IsRequired()
                .HasColumnName("teacher_middlename")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Отчество преподавателя");

            builder.Property(p => p.Position)
                .IsRequired()
                .HasColumnName("teacher_position")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Должность преподавателя");
            builder.Property(p => p.Degree)
                .HasColumnName("teacher_degree")
                .HasColumnType(ColumnType.String).HasMaxLength(100)
                .HasComment("Ученая степень преподавателя");

            builder.Property(p => p.CathedraId)
                .IsRequired()
                .HasColumnName("f_cathedra_id")
                .HasColumnType(ColumnType.Int)
                .HasComment("Идентификатор кафедры");

            builder.ToTable(TableName)
                .HasOne(p => p.Cathedra)
                .WithMany()
                .HasForeignKey(p => p.CathedraId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}

