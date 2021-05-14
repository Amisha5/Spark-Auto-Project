using Microsoft.EntityFrameworkCore;
using Spark.DataModel.Models;
using System;

namespace Spark.DataLayer
{
    public class SparkDbContext: DbContext
    {
        public SparkDbContext(DbContextOptions<SparkDbContext> options) : base(options)
        {

        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<ServiceShoppingCart> ServiceShoppingCarts { get; set; }
        public DbSet<CarServiceHistory> CarServiceHistories { get; set; }
        public DbSet<CarServiceDetails> CarServiceDetails { get; set; }

        public DbSet<CarServiceType> CarServiceTypes { get; set; }

    }
}
