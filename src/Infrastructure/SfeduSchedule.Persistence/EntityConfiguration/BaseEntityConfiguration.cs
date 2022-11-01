using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SfeduSchedule.Domain.Entities;

namespace SfeduSchedule.Persistence.EntityConfiguration
{
    public abstract class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(GetTableName());
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired();

            BuildConfig(builder);
        }
        protected abstract void BuildConfig(EntityTypeBuilder<TEntity> builder);
        protected abstract string GetTableName();
    }
}
