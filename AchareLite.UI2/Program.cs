using App.Domain.AppServices;
using App.Domain.Core.CategoryService.AppServices;
using App.Domain.Core.CategoryService.Data.Repositories;
using App.Domain.Core.CategoryService.Services;
using App.Domain.Core.Configs.Entities;
using App.Domain.Core.Member.AppServices;
using App.Domain.Core.Member.Entities;
using App.Domain.Core.OrderAgg.AppServices;
using App.Domain.Core.OrderAgg.Data.Repositories;
using App.Domain.Core.OrderAgg.Services;
using App.Domain.Services;
using App.Infra.DataAccess.Repo.Ef;
using App.Infra.DB.SqlServer.EF.DB_Achare.Ef;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IMainCategoryRepository, MainCategoryRepository>();
builder.Services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IMainCategoryService, MainCategoryService>();
builder.Services.AddScoped<ISubCategoryService, SubCategoryService>();
builder.Services.AddScoped<IServiceService, ServiceService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IMainCategoryAppService, MainCategoryAppService>();
builder.Services.AddScoped<ISubCategoryAppService, SubCategoryAppService>();
builder.Services.AddScoped<IServiceAppService, ServiceAppService>();
builder.Services.AddScoped<IAccountAppService, AccountAppService>();
builder.Services.AddScoped<IOrderAppService, OrderAppService>();

//builder.Services.AddDbContext<AchareDbContext>(options
//    => options.UseSqlServer("Data Source =.; Initial Catalog = AchareCodefirst; Integrated Security = True; TrustServerCertificate = True"));
#region Configuration


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var siteSettings = configuration.GetSection(nameof(SiteSettings)).Get<SiteSettings>();

builder.Services.AddSingleton(siteSettings);

#endregion
#region EfConfiguration

builder.Services.AddDbContext<AchareDbContext>(options
    => options.UseSqlServer(siteSettings.SqlConfiguration.ConnectionsString));

#endregion
#region IdentityConfiguration

builder.Services.AddIdentity<ApplicationUser, IdentityRole<int>>
    (options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
    })
    .AddRoles<IdentityRole<int>>()
    .AddEntityFrameworkStores<AchareDbContext>();
//.AddErrorDescriber<PersianIdentityErrorDescriber>();

#endregion
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=ShowMainPage}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=ShowMainPage}/{id?}"
    );
});

app.Run();
//{area:exists}/