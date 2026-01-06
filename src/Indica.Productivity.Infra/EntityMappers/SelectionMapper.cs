using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class SelectionMapper : IEntityTypeConfiguration<Selection>
{
    public void Configure(EntityTypeBuilder<Selection> builder)
    {
        builder.ToTable("selecao");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id_selecao")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(x => x.SelectionPattern)
            .HasColumnName("padrao_selecao")
            .HasMaxLength(16)
            .IsRequired();
        builder.Property(x => x.IdDerivation)
            .HasColumnName("id_derivacao")
            .IsRequired();
        builder.HasOne(x => x.Derivation)
            .WithMany(y => y.Selections)
            .HasForeignKey(x => x.IdDerivation)
            .OnDelete(DeleteBehavior.Cascade)
            .IsRequired();
        builder.HasIndex(x => x.SelectionPattern).IsUnique();
        builder.HasData([
new Selection() { Id = 1, SelectionPattern = "INICIATIVA", IdDerivation = 3 },
new Selection() { Id = 2, SelectionPattern = "SELMANUTBT", IdDerivation = 4 },
new Selection() { Id = 3, SelectionPattern = "ESTOQCORT", IdDerivation = 10 },
new Selection() { Id = 4, SelectionPattern = "SELEXTMED", IdDerivation = 5 },
new Selection() { Id = 5, SelectionPattern = "SELEXTMDNI", IdDerivation = 5 },
new Selection() { Id = 6, SelectionPattern = "MODYMYMFT", IdDerivation = 6 },
new Selection() { Id = 7, SelectionPattern = "MODMYMFT", IdDerivation = 6 },
new Selection() { Id = 8, SelectionPattern = "PROJTURIA", IdDerivation = 7 },
new Selection() { Id = 9, SelectionPattern = "PROJTUIA", IdDerivation = 7 },
        ]);
    }
}
