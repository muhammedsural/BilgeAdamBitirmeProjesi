using BitirmeProjesi.Core.Map;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using BitirmeProjesi.Model.SeedData;
using Microsoft.AspNetCore.Http;

namespace BitirmeProjesi.Model.Context
{
    public class DataContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DataContext(DbContextOptions options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RegisterMapping(modelBuilder);

            //Seed Dataları Tetikle
            modelBuilder.ApplyConfiguration(new BrandSeedData());
            modelBuilder.ApplyConfiguration(new CategorySeedData());
            modelBuilder.ApplyConfiguration(new ProductSeedData());
            modelBuilder.ApplyConfiguration(new OrderSeedData());
            modelBuilder.ApplyConfiguration(new OrderItemSeedData());
            modelBuilder.ApplyConfiguration(new MemberSeedData());
            modelBuilder.ApplyConfiguration(new RegionSeedData());
            modelBuilder.ApplyConfiguration(new CountrySeedData());
            modelBuilder.ApplyConfiguration(new LocationSeedData());
            modelBuilder.ApplyConfiguration(new ShippingAddressSeedData());
            modelBuilder.ApplyConfiguration(new BillingAddressSeedData());
        }

        private void RegisterMapping(ModelBuilder modelBuilder)
        {
            var typeToRegister = new List<Type>();
            var dataAssembly = Assembly.GetExecutingAssembly();

            typeToRegister.AddRange(dataAssembly.DefinedTypes.Select(x => x.AsType()));
            foreach (var builderType in typeToRegister.Where(x => typeof(IEntityBuilder).IsAssignableFrom(x)))
            {
                if (builderType != null && builderType != typeof(IEntityBuilder))
                {
                    var builder = (IEntityBuilder) Activator.CreateInstance(builderType);
                    builder.Build(modelBuilder);
                }
            }
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var modifiedEntities = ChangeTracker.Entries()
                .Where(x => x.State == EntityState.Modified || x.State == EntityState.Added).ToList();

            string computerName = Environment.MachineName;
            string IPAddress = "127.0.0.1";

            foreach (var item in modifiedEntities)
            {
                //CoreEntity entity = item.Entity as CoreEntity;
                //if (item != null)
                //{
                //  switch (item.State)
                //   {
                //      case EntityState.Added:
                //           entity.CreatedComputerName = computerName;
                //           entity.CreatedIP = IPAddress;
                //           entity.CreatedDate = DateTime.Now;
                //           entity.CreatedUserId = GetUserId();
                //            break;
                //        case EntityState.Modified:
                //            entity.ModifiedComputerName = computerName;
                //            entity.ModifiedIP = IPAddress;
                //            entity.ModifiedDate = DateTime.Now;
                //            entity.ModifiedUserId = GetUserId();
                //            break;
                //    }
                // }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        private Guid? GetUserId()
        {
            string userId = "";
            if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
            {
                var claims = _httpContextAccessor.HttpContext.User.Claims.ToList();
                userId = claims?.FirstOrDefault(x => x.Type.Equals("jti", StringComparison.OrdinalIgnoreCase))?.Value;
            }

            if (userId != null)
                return Guid.Parse(userId);
            else
                return Guid.Empty;
        }
    }
}