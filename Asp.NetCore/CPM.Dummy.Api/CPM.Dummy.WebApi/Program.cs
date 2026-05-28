using CPM.Dummy.DataInterface;
using CPM.Dummy.DataLayer;
using CPM.Dummy.OperationalManager;
using ILogger = CPM.Dummy.OperationalManager.ILogger;
using CPM.Dummy.BussinesInterface;
using CPM.Dummy.BussinesLayer;

var builder = WebApplication.CreateBuilder(args);
var cnx = builder.Configuration.GetConnectionString("CRM");

// Registrar la cadena de conexión y el logger
builder.Services.AddSingleton(cnx);
builder.Services.AddSingleton<ApiConnection>(provider => new ApiConnection(cnx));
builder.Services.AddScoped<ICRMRepository, CRMRepository>();
builder.Services.AddScoped<ILogger, EventLogger>();
builder.Services.AddHttpClient();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IRespuestaProcessor, RespuestaProcessor>();

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

app.MapControllers();

app.MapRazorPages();

app.Run();
