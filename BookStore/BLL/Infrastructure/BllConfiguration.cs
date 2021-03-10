using Domain.Models;
using Core.Context;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

namespace BLL.Infrastructure
{
    public static class BllConfiguration
    {
        public static void Configuration(IServiceCollection collection, string dbConnection)
        {
            collection.AddDbContext<StoreContext>(x => x.UseSqlServer(dbConnection));
            collection.AddIdentity<User, Role>(x => x.Password.RequireLowercase = true).AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();
            //collection.AddIdentityCore<User>(x => x.Password.RequireLowercase = true).AddEntityFrameworkStores<StoreContext>();


        }
    }
}
