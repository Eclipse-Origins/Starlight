using Microsoft.EntityFrameworkCore;
using Starlight.Models;
using Starlight.Models.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Starlight.Server.Data
{
    public static class ModelBuilderExtensions
    {
        public static void AddStarlightEntity<TEntity>(this ModelBuilder modelBuilder) where TEntity : class {
            modelBuilder.Entity<TEntity>(entity => {
                if (typeof(TEntity).IsSubclassOf(typeof(CoreDataModel))) {
                    entity.HasKey(nameof(CoreDataModel.Id));
                }

                if (typeof(TEntity).IsDerivedFromGenericParent(typeof(IDynamicStateModel<>))) {
                    entity.Ignore(nameof(IDynamicStateModel<object>.State));
                }
            });
        }
    }
}
