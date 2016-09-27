using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using TodoAPI.Models;


[assembly: OwinStartup(typeof(TodoAPI.Startup))]

namespace TodoAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddMvc();

            services.AddSingleton<ITodoRepository, TodoRepository>();
        }


    }
}
