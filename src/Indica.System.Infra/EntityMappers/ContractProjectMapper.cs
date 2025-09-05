using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Indica.System.Infra.EntityMappers
{
    public class ContractProjectMapper : IEntityTypeConfiguration<ContractProject>
    {
        public void Configure(EntityTypeBuilder<ContractProject> builder)
        {
            builder.ToTable("contrato_projeto");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .HasColumnName("id_contrato_projeto")
                .ValueGeneratedOnAdd()
                .IsRequired();
            builder.Property(x => x.IdContract)
                .HasColumnName("id_contrato")
                .IsRequired();
            builder.Property(x => x.IdProject)
                .HasColumnName("id_projeto")
                .IsRequired();
            builder.Property(x => x.IdRegional)
                .HasColumnName("id_regional")
                .IsRequired();
            builder.Property(x => x.IdDerivation)
                .HasColumnName("id_derivacao")
                .HasDefaultValue(1)
                .IsRequired();
            builder.HasOne(x => x.Contract)
                .WithMany()
                .HasForeignKey(x => x.IdContract)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.Project)
                .WithMany()
                .HasForeignKey(x => x.IdProject)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.Regional)
                .WithMany()
                .HasForeignKey(x => x.IdRegional)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasOne(x => x.Derivation)
                .WithMany()
                .HasForeignKey(x => x.IdDerivation)
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired();
            builder.HasIndex(x => new { x.IdContract, x.IdProject, x.IdRegional, x.IdDerivation }).IsUnique();
        }
    }
}