using Back_Progetto_S5_L5_PoliziaMunicipale.Models.Entity;
using Back_Progetto_S5_L5_PoliziaMunicipale.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//inizializare variabile per la conessione e includere gestione errori per la connessione backend - database

string connectionString = string.Empty;

try
{
    connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new Exception("Stringa di connessione non trovata");
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Environment.Exit(1);
}

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString)
);

//registrare servizi
builder.Services.AddScoped<AnagraficaService>();
builder.Services.AddScoped<TipoViolazioneService>();
builder.Services.AddScoped<VerbaleService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
