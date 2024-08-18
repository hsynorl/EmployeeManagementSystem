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

// TokenHandler'�n eklenmesi
builder.Services.AddTransient<TokenHandler>();

// IUserService i�in HttpClient'� yap�land�r�n ve BaseAddress ekleyin
builder.Services.AddHttpClient<IUserService, UserService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();

// IDepartmentService i�in HttpClient'� yap�land�r�n ve BaseAddress ekleyin
builder.Services.AddHttpClient<IDepartmentService, DepartmentService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();

// IUserDepartmentService i�in HttpClient'� yap�land�r�n ve BaseAddress ekleyin
builder.Services.AddHttpClient<IUserDepartmentService, UserDepartmentService>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
})
.AddHttpMessageHandler<TokenHandler>();



// WebApiUrl i�in HttpClient tan�mlamas�
builder.Services.AddHttpClient("WebApiUrl", client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("ApiUrl"));
});

// Scoped olarak WebApiUrl HttpClient'�n� sa�lamak i�in yap�land�rma
builder.Services.AddScoped(sp =>
{
    var clientFactory = sp.GetRequiredService<IHttpClientFactory>();
    return clientFactory.CreateClient("WebApiUrl");
});


// Authentication ayarlar�
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
