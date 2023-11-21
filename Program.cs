// WebApplication
var builder = WebApplication.CreateBuilder(args);   

// middlewares (adiciono)
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//
builder.Services.AddTransient<IConjuntosData, ConjuntosData>();
builder.Services.AddTransient<IContratosData, ContratosData>();
builder.Services.AddTransient<ILocaisData, LocaisData>();
builder.Services.AddTransient<IMotoristasData, MotoristasData>();
builder.Services.AddTransient<IOrdemData, OrdemData>();
builder.Services.AddTransient<INotaFiscalData, NotaFiscalData>();

var app = builder.Build();

// middlewares (configuro)
app.MapControllerRoute("default", "/{controller=home}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();