var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

var app = builder.Build();

app.MapControllerRoute(
    name : "default",
    pattern : "{controller=Home}/{action=Index}/{Id?}"
);

app.UseStaticFiles();

app.Run();
