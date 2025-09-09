using Indica.System.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class CredentialMapper : IEntityTypeConfiguration<Credential>
{
    public void Configure(EntityTypeBuilder<Credential> builder)
    {
        builder.ToTable("credenciais");
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .HasColumnName("id_credencial")
            .ValueGeneratedOnAdd()
            .IsRequired();
        builder.Property(x => x.IdEmployer)
            .HasColumnName("id_funcionario")
            .IsRequired();
        builder.Property(x => x.PassHash)
            .HasColumnName("passwordhash")
            .HasMaxLength(32)
            .IsFixedLength()
            .IsRequired();
        builder.HasOne(x => x.Employer)
            .WithOne(y => y.Credential)
            .HasForeignKey<Credential>(x => x.IdEmployer)
            .OnDelete(DeleteBehavior.SetNull)
            .IsRequired(false);
        builder.HasIndex(x => x.IdEmployer).IsUnique();
    }
}
