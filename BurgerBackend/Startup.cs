using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Owin;
using Owin;
using BurgerBackend.DB;

[assembly: OwinStartup(typeof(BurgerBackend.Startup))]

namespace BurgerBackend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext(BBDBContext.Create);
        }
    }
}
