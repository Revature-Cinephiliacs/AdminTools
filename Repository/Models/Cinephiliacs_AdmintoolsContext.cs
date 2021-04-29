using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Repository.Models
{
 
        /// <summary>
        /// Context for our database
        /// Avalible models: Topics, Resolved tickets, Tickets
        /// </summary>
    public partial class Cinephiliacs_AdmintoolsContext : DbContext
    {
        public Cinephiliacs_AdmintoolsContext()
        {
        }

        public Cinephiliacs_AdmintoolsContext(DbContextOptions<Cinephiliacs_AdmintoolsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AffectedSubject> AffectedSubjects { get; set; }
        public virtual DbSet<ResolvedTicket> ResolvedTickets { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AffectedSubject>(entity =>
            {
                entity.HasKey(e => e.AffectedSubject1)
                    .HasName("PK__Affected__602FF4E179AB8ED3");

                entity.Property(e => e.AffectedSubject1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AffectedSubject");
            });

            modelBuilder.Entity<ResolvedTicket>(entity =>
            {
                entity.HasKey(e => e.TicketId)
                    .HasName("PK__Resolved__712CC6270C1EDB74");

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

                entity.Property(e => e.TimeSubmitted).HasColumnType("datetime");
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

                entity.Property(e => e.TimeSubmitted).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
