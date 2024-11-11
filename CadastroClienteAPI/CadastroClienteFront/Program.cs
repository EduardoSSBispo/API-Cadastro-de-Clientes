using CadastroClienteWeb.Integration;
using CadastroClienteWeb.Integration.Interfaces;
using CadastroClienteWeb.Integration.Refit;
using Refit;
using System.Net.Http.Headers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages().AddRazorPagesOptions(options =>
{
    options.RootDirectory = "/Views";
});

builder.Services.AddSingleton<IClienteIntegration, ClienteIntegration>();
builder.Services.AddSingleton<ILogradouroIntegration, LogradouroIntegration>();
builder.Services.AddSingleton<IUsuarioIntegration, UsuarioIntegration>();

var httpClientHandler = new HttpClientHandler
{
    ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => true
};

builder.Services.AddRefitClient<IClienteIntegrationRefit>()
    .ConfigureHttpClient((provider, client) =>
    {
        var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var token = httpContext.Session.GetString("JwtToken");

        client.BaseAddress = new Uri("https://localhost:44352");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }).ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);


builder.Services.AddRefitClient<ILogradouroIntegrationRefit>()
    .ConfigureHttpClient((provider, client) =>
    {
        var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var token = httpContext.Session.GetString("JwtToken");

        client.BaseAddress = new Uri("https://localhost:44352");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }).ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);


builder.Services.AddRefitClient<IUsuarioIntegrationRefit>()
    .ConfigureHttpClient((provider, client) =>
    {
        var httpContext = provider.GetRequiredService<IHttpContextAccessor>().HttpContext;
        var token = httpContext.Session.GetString("JwtToken");

        client.BaseAddress = new Uri("https://localhost:44352");
        if (!string.IsNullOrEmpty(token))
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
    }).ConfigurePrimaryHttpMessageHandler(() => httpClientHandler);

builder.Services.AddHttpContextAccessor();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Tempo de expiração da sessão
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.UseSession();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
