﻿using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VidllyApp.Startup))]
namespace VidllyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //app.MapSignalR();
            ConfigureAuth(app);
        }
    }
}
