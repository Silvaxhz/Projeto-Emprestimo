using ProjetoEmprestimoAspCore.CarrinhoCompra;
using ProjetoEmprestimoAspCore.Cookie;
using ProjetoEmprestimoAspCore.GerenciarArquivos;
using ProjetoEmprestimoAspCore.Models;
using ProjetoEmprestimoAspCore.Repository;
using ProjetoEmprestimoAspCore.Repository.Contract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(900);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddMvc().AddSessionStateTempDataProvider();

builder.Services.AddMemoryCache();

builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
builder.Services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();
builder.Services.AddScoped<Cookie>();
builder.Services.AddScoped<GerenciadorArquivos>();
builder.Services.AddScoped<CookieCarrinhoCompra>();

builder.Services.AddScoped<ILivroRepository, LivroRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<ICategoriaRepository, Categoria>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
