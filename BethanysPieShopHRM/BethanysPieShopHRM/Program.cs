using BethanysPieShopHRM.Client;
using BethanysPieShopHRM.Components;
using BethanysPieShopHRM.Contracts.Repositories;
using BethanysPieShopHRM.Contracts.Services;
using BethanysPieShopHRM.Data;
using BethanysPieShopHRM.Repositories;
using BethanysPieShopHRM.Services;
using BethanysPieShopHRM.Shared.Domain;
using BethanysPieShopHRM.State;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContextFactory<AppDbContext>(
    options => options.UseSqlite(builder.Configuration["ConnectionStrings:DefaultConnection"]));

builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();  // Register the EmployeeRepository as a scoped service, this step I tend to forget
builder.Services.AddScoped<IEmployeeDataService, EmployeeDataService>(); // Register the EmployeeDataService as a scoped service, this step I tend to forget

builder.Services.AddScoped<ApplicationState>(); // Register the ApplicationState as a scoped service

builder.Services.AddScoped<ITimeRegistrationRepository, TimeRegistrationRepository>();  // Register the TimeRegistrationRepository as a scoped service

builder.Services.AddScoped<ITimeRegistrationDataService, TimeRegistrationDataService>(); // Register the TimeRegistrationDataService as a scoped service

builder.Services.AddScoped<ICountryDataService, CountryDataService>(); // Register the CountryDataService as a scoped service, this step I tend to forget
builder.Services.AddScoped<IJobCategoryDataService, JobCategoryDataService>(); // Register the JobCategoryDataService as a scoped service, this step I tend to forget

builder.Services.AddScoped<ICountryRepository, CountryRepository>();  // Register the CountryRepository as a scoped service, this step I tend to forget
builder.Services.AddScoped<IJobCategoryRepository, JobCategoryRepository>();  // Register the JobCategoryRepository as a scoped service, this step I tend to forget
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Register the IHttpContextAccessor as a singleton service, this step I tend to forget>

builder.Services.AddCascadingAuthenticationState();
builder.Services.AddScoped<IdentityRedirectManager>();
builder.Services.AddScoped<AuthenticationStateProvider, IdentityRevalidatingAuthenticationStateProvider>();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddIdentityCore<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Stores.SchemaVersion = IdentitySchemaVersions.Version3;
})
    .AddEntityFrameworkStores<AppDbContext>()
    .AddSignInManager()
    .AddDefaultTokenProviders();


builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
    options.DefaultSignInScheme = IdentityConstants.ExternalScheme;
})
    .AddIdentityCookies();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapGet("/api/employee", async (IEmployeeDataService employeeDataService) =>
{
    var employees = await employeeDataService.GetAllEmployeesAsync();
    return Results.Ok(employees);
});

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(BethanysPieShopHRM.Client._Imports).Assembly)   ;

app.Run();
