using AuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.DataAccess.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.ToTable("Clients");
        builder.HasKey(x => x.ClientId);
        builder.Property(x => x.ClientId).IsRequired().HasMaxLength(100).HasColumnName(nameof(Client.ClientId)).HasColumnType("text");
        builder.Property(x => x.SecretKey).IsRequired().HasMaxLength(200).HasColumnName(nameof(Client.SecretKey)).HasColumnType("text");
        builder.HasMany(x => x.Audiences).WithOne(y => y.Client).HasForeignKey(y => y.ClientId);
    }
}
