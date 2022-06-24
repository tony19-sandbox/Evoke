using Evoke_Web.Architecture.Application_Layer.Extensions;
using Microsoft.AspNetCore.SpaServices;
using VueCliMiddleware;

var requisition = WebApplication.CreateBuilder(args);
requisition.Host.RegisterLogger($@"{Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData)}\Arrigotti Consulting\Evoke\Web\Logs");
requisition.Configuration.Build("web-application-settings.json");
requisition.Services.RegisterDependencies();

/* Important:
 * You can inject particular services; or use the extension method, example:
 * requisition.Services.AddRazorPages(); */

var application = requisition.Build();
//application.UseExceptionHandler("/Error");
application.UseDeveloperExceptionPage();
application.UseHsts();
application.UseHttpsRedirection();
application.UseStaticFiles();
application.UseSpaStaticFiles();
application.UseRouting();

application.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(default, "{controller}/{action=Index}/{id?}");
    if (System.Diagnostics.Debugger.IsAttached)
        endpoints.MapToVueCliProxy(
            "{*path}",
            new SpaOptions { SourcePath = "Architecture/Application Layer/client" },
            npmScript: "serve",
            regex: "Compiled successfully",
            forceKill: true,
            wsl: false);
});

if (!System.Diagnostics.Debugger.IsAttached)
    application.UseSpa(spa => { spa.Options.SourcePath = "Architecture/Application Layer/Client/dist"; });

/* Important:
 * You can add additional pipeline items into the application hiearchy, for example: 
 * application.UseAuthorization();
 * application.MapRazorPages(); */

application.Run();
