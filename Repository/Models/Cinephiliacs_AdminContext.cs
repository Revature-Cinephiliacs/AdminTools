using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Models
{
    public partial class Cinephiliacs_AdminContext : DbContext
    {
        public Cinephiliacs_AdminContext()
        {
        }

        public Cinephiliacs_AdminContext(DbContextOptions<Cinephiliacs_AdminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ResolvedTicket> ResolvedTickets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=tcp:cinephiliacs.database.windows.net,1433;Initial Catalog=Cinephiliacs_Admin;Persist Security Info=False;User ID=kugelsicher;Password=F36UWevqvcDxEmt;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ResolvedTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Resolved__712CC627A0E0A678");

                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("TicketID");

                entity.Property(e => e.AffectedService)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descript)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .IsUnicode(false)
                    .HasColumnName("ItemID");
            });

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.TicketId)
                    .ValueGeneratedNever()
                    .HasColumnName("TicketID");

                entity.Property(e => e.AffectedService)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Descript)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ItemId)
                    .IsUnicode(false)
                    .HasColumnName("ItemID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
