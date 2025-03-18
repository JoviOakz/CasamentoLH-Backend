using CasamentoLH_Backend.Core.Mapping;
using CasamentoLH_Backend.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CasamentoLH_Backend.Config;

public partial class CasamentoLHContext(DbContextOptions<CasamentoLHContext> options) : DbContext(options)
{
    public virtual DbSet<Guest> Guests { get; set; }
    public virtual DbSet<GuestGroup> GuestGroups { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GuestMapping());
        modelBuilder.ApplyConfiguration(new GuestGroupMapping());

        OnModelCreatingPartial(modelBuilder);
    }
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}