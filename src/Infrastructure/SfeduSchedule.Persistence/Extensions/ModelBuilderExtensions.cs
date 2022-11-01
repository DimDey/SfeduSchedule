using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SfeduSchedule.Persistence.Extensions
{
    public static class ModelBuilderExtensions 
    {
        public static ModelBuilder ApplyAllConfigurationsFromAssembly(this ModelBuilder modelBuilder, Assembly assembly)
        {
            var applyGenericMethod =
                typeof(ModelBuilder).GetMethod("ApplyConfiguration", BindingFlags.Instance | BindingFlags.Public);

            foreach (var type in assembly.GetTypes()
                         .Where(t => t.IsClass && !t.IsAbstract && !t.ContainsGenericParameters))
            {
                foreach (var item in type.GetInterfaces())
                {
                    if (item.IsConstructedGenericType &&
                        item.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    {
                        var applyConcreteMethod =
                            applyGenericMethod.MakeGenericMethod(item.GenericTypeArguments[0]);
                        applyConcreteMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(type) });
                        break;
                    }
                }
            }
            return modelBuilder;
        }

    }
}
