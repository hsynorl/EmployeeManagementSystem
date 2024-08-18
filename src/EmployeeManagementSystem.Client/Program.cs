using EmployeeManagementSystem.Client.Services.Abstract;
using EmployeeManagementSystem.Client.Services.Concrete;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new HttpResponseExceptionFilter());
});
builder.Services.AddHttpContextAccessor();

// TokenHandler'ýn eklenmesi
builder.Services.AddTransient<TokenHandler>();

// IUserService için HttpClient'ý yapýlandýrýn ve BaseAddress ekleyin
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();

// IDepartmentService için HttpClient'ý yapýlandýrýn ve BaseAddress ekleyin
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();

// IUserDepartmentService için HttpClient'ý yapýlandýrýn ve BaseAddress ekleyin
builder.Services.AddHttpClient<IUserDepartmentService, UserDepartmentService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();



// WebApiUrl için HttpClient tanýmlamasý
builder.Services.AddHttpClient("WebApiUrl", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
});

// Scoped olarak WebApiUrl HttpClient'ýný saðlamak için yapýlandýrma
builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiUrl");
});


// Authentication ayarlarý
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/User/Login";
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
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
