using CasamentoLH_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CasamentoLH_Backend.Core.Mapping;

public class GuestGroupMapping : BaseMapping<GuestGroup>
{
    public override void Configure(EntityTypeBuilder<GuestGroup> builder)
    {
        base.Configure(builder);

        builder.ToTable("tb_guest_group");
    }
}