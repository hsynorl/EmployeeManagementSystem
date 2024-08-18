using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Client.Services.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new HttpResponseExceptionFilter());
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<TokenHandler>();


builder.Services.AddHttpClient("WebApiUrl", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();

builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiUrl");
});


builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IDepartmentService, DepartmentService>();
builder.Services.AddScoped<IUserDepartmentService,UserDepartmentService>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
    });
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=GetDepartments}/{id?}");

app.Run();
