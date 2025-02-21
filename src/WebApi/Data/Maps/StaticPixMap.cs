using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi.Models;

namespace WebApi.Data.Maps
{
    public class StaticPixMap : IEntityTypeConfiguration<StaticPix>
    {
        public void Configure(EntityTypeBuilder<StaticPix> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Key)
                .HasColumnType("varchar")
                .HasMaxLength(300)
                .IsRequired();

            builder.Property(x => x.Total)
                .HasColumnType("decimal")
                .IsRequired();

            builder.Property(x => x.MerchantName)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.MerchantCity)
                .HasColumnType("varchar")
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}