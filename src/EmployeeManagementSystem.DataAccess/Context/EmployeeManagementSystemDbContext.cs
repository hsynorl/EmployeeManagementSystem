using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EmployeeManagementSystem.Entities.Entities;
using Microsoft.Extensions.Configuration;
using EmployeeManagementSystem.Common.Enums;

namespace EmployeeManagementSystem.DataAccess.Context
{
    public class EmployeeManagementSystemDbContext : DbContext
    {
        public EmployeeManagementSystemDbContext(DbContextOptions<EmployeeManagementSystemDbContext> options)
          : base(options)
        {
            Database.Migrate();
        }


        public DbSet<Department> Departments { get; set; }
        public DbSet<UserDepartment> UserDepartments{ get; set; }
        public DbSet<User> Users { get; set; }
   
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User()
            {
                EmailAddress = "admin@gmail.com",
                FirstName = "Hüseyin",
                LastName = "ORAL",
                Password = "admin",
                UserType = UserType.Admin,
                PhoneNumber = "05360596086",
                Id = Guid.NewGuid(),
                CreatedDate = DateTime.Now,

            });

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.Entity<User>()
                .HasOne(u => u.UserDepartment)
                .WithOne(du => du.User)
                .HasForeignKey<UserDepartment>(du => du.Id);

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            OnBeforeForUpdateSave();
            OnBeforeSave();
            return base.SaveChanges();
        }

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            OnBeforeForUpdateSave();
            OnBeforeSave();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
        {
            OnBeforeForUpdateSave();
            OnBeforeSave();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            OnBeforeForUpdateSave();
            OnBeforeSave();
            return base.SaveChangesAsync(cancellationToken);
        }
        private void OnBeforeSave()
        {
            var addedEntites = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Added)
                                    .Select(i => (BaseEntity)i.Entity);

            PrepareAddedEntities(addedEntites);
        }
        private void PrepareAddedEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.CreatedDate == DateTime.MinValue)
                    entity.CreatedDate = DateTime.Now;
            }
        }
        private void OnBeforeForUpdateSave()
        {
            var updatedEntites = ChangeTracker.Entries()
                                    .Where(i => i.State == EntityState.Modified)
                                    .Select(i => (BaseEntity)i.Entity);

            PrepareUpdateEntities(updatedEntites);
        }
        private void PrepareUpdateEntities(IEnumerable<BaseEntity> entities)
        {
            foreach (var entity in entities)
            {
                if (entity.UpdatedDate == DateTime.MinValue)
                    entity.UpdatedDate = DateTime.Now;
            }
        }
    }
}