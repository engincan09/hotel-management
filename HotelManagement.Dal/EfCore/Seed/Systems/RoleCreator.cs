using HotelManagement.Entity.Models.Users;
using HotelManagement.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.Dal.EfCore.Seed.Systems
{
    public static class RoleCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[] {
                    new Role {
                        Id = 1,
                        Name = "Admin",
                        CreatedAt = new DateTime(2020, 03, 09),
                        DataStatus = DataStatus.Activated
                    }
            });
        }
    }
}
