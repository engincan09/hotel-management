
using HotelManagement.Entity.Models.Users;
using HotelManagement.Entity.Shared;
using Microsoft.EntityFrameworkCore;
using System;

namespace HotelManagement.Dal.EfCore.Seed.Systems
{
    public static class UserRoleCreator
    {
        public static void Create(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRole>().HasData(new UserRole[] {
                    new UserRole { Id = 1,
                        RoleId = 1,
                        UserId = 1,
                        CreatedAt = new DateTime(2020, 03, 09),
                        DataStatus = DataStatus.Activated
                    }
            });
        }
    }
}
