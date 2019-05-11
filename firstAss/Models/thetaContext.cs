using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace firstAss.Models
{
    public partial class thetaContext : DbContext
    {
        public thetaContext()
        {
        }

        public thetaContext(DbContextOptions<thetaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Student { get; set; }

//        protected override void onconfiguring(dbcontextoptionsbuilder optionsbuilder)
//        {
//            if (!optionsbuilder.isconfigured)
//            {
//#warning to protect potentially sensitive information in your connection string, you should move it out of source code. see http://go.microsoft.com/fwlink/?linkid=723263 for guidance on storing connection strings.
//                optionsbuilder.usesqlserver("server= desktop-l1b40q8\\sqlexpress;database=theta;trusted_connection=true;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Student>(entity =>
            {
                entity.ToTable("student");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddedDate)
                    .HasColumnName("added_date")
                    .HasMaxLength(50);

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Username)
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });
        }
    }
}
