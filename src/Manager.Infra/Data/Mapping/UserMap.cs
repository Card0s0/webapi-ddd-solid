using Manager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager.Infra.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");

            builder.HasKey(col => col.Id);

            builder.Property(col => col.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(col => col.Name)
                .HasColumnName("Name")
                .IsRequired()
                .HasMaxLength(80)
                .HasColumnType("VARCHAR(80)");

            builder.Property(col => col.Email)
                .HasColumnName("Email")
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnType("VARCHAR(180)");

            builder.Property(col => col.Password)
                .HasColumnName("Password")
                .IsRequired()
                .HasMaxLength(30)
                .HasColumnType("VARCHAR(30)");
        }
    }
}
