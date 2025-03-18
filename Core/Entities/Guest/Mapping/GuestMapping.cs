using CasamentoLH_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasamentoLH_Backend.Core.Mapping;

public class GuestMapping : BaseMapping<Guest>
{
    public override void Configure(EntityTypeBuilder<Guest> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_guest");

        builder.Property(g => g.Name)
            .HasMaxLength(255)
            .HasColumnName("name");

        builder.Property(g => g.IsConfirmed)
            .HasColumnName("is_confirmed");

        builder.HasOne(g => g.GuestGroup)
            .WithMany(g => g.Guests)
            .HasPrincipalKey(g => g.Id)
            .HasForeignKey("id_guest_group");
    }
}