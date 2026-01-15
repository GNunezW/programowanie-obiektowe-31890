using DomowaApteczka.Components;
using DomowaApteczka.Data;
using DomowaApteczka.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSingleton<IApteczkaRepository, ApteczkaRepositoryJson>();

var app = builder.Build();
var repo = app.Services.GetRequiredService<IApteczkaRepository>();

repo.Dodaj(new LekBezRecepty("Paracetamol", DateTime.Now.AddMonths(12)));
repo.Dodaj(new LekNaRecepte("Amoksycylina", DateTime.Now.AddMonths(-1)));

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
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
