using AuthServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuthServer.DataAccess.Configurations;

public class ClientAudienceConfiguration : IEntityTypeConfiguration<ClientAudience>
{
    public void Configure(EntityTypeBuilder<ClientAudience> builder)
    {
        builder.ToTable("ClientAudiences");
        builder.HasKey(x => new { x.ClientId, x.Audience });
        builder.Property(x => x.ClientId).IsRequired().HasMaxLength(100).HasColumnName(nameof(ClientAudience.ClientId)).HasColumnType("text");
        builder.Property(x => x.Audience).IsRequired().HasMaxLength(100).HasColumnName(nameof(ClientAudience.Audience)).HasColumnType("text");
    }
}
