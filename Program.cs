// WebApplication
var builder = WebApplication.CreateBuilder(args);   

// middlewares (adiciono)
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

//
builder.Services.AddTransient<IContratosData, ContratosData>();
builder.Services.AddTransient<IEnderecosData, EnderecosData>();
builder.Services.AddTransient<ILocaisData, LocaisData>();
builder.Services.AddTransient<IMotoristasData, MotoristasData>();
builder.Services.AddTransient<IOrdemData, OrdemData>();
builder.Services.AddTransient<ITransporData, TransporData>();

var app = builder.Build();

// middlewares (configuro)
app.MapControllerRoute("default", "/{controller=inicio}/{action=index}/{id?}");

app.UseStaticFiles();

app.Run();