﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProjetLogoV1._0.Startup))]
namespace ProjetLogoV1._0
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
