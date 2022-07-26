﻿using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace Infrastructure.Identity
{
   public class AppIdentityDbContext: IdentityDbContext<AppUser>
    
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<AppUser>()
            //.HasOne(a => a.Address)
            //.WithOne(a => a.AppUser)
            //.HasForeignKey<Address>(c => c.AppUserId);

        }
    }
}
