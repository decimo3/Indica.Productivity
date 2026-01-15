using Indica.Productivity.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.Productivity.Infra.EntityMappers
{
    public class DamageToProjectMapper : IEntityTypeConfiguration<DamageToProject>
    {
        public void Configure(EntityTypeBuilder<DamageToProject> builder)
        {
            builder.ToTable("dano_projeto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_dano_projeto")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.Damage)
                .HasColumnName("nome_dano_projeto")
                .HasMaxLength(4)
                .IsFixedLength()
                .IsRequired();
            builder.Property(x => x.Description)
                .HasColumnName("texto_breve_para_dano")
                .HasMaxLength(128)
                .IsRequired();
            builder.Property(x => x.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired(false);
            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.IdProject)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();
            builder.HasIndex(x => x.Damage).IsUnique();
        }
    }
}