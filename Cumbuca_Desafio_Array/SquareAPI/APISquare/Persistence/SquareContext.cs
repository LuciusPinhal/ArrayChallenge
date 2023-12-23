using Microsoft.EntityFrameworkCore;
using APISquare.Models;

namespace APISquare.Persistence;

public class SquareContext : DbContext
{
    public SquareContext(
    DbContextOptions<SquareContext> options
    ) : base(options)
    {

    }
    public DbSet<Amount> Amounts { get; set; }
    public DbSet<Square> Squares { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Amount>(tabela =>
        {
            tabela.HasKey(e => e.id);
            tabela
                .HasMany(e => e.squares)
                .WithOne()
                .HasForeignKey(a => a.amountId);
        });

        builder.Entity<Square>(tabela =>
        {
            tabela.HasKey(e => e.id);

        });


    }
}