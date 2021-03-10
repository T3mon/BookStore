﻿using Domain.Models;
using Core.Context;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Infrastructure
{
    public static class BllConfiguration
    {
        public static void Configuration(IServiceCollection collection, string dbConnection)
        {
            //collection.AddIdentity<User, Role>(x => x.Password.RequireLowercase = true).AddEntityFrameworkStores<StoreContext>().AddDefaultTokenProviders();
            collection.AddIdentityCore<User>(x => x.Password.RequireLowercase = true).AddEntityFrameworkStores<StoreContext>();

        }
    }
}
