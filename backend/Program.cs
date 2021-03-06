using System.Globalization;
using System.Reflection;
using System.Text;
using BoleteriaOnline.Core.Services;
using BoleteriaOnline.Core.Utils;
using BoleteriaOnline.Web.Data;
using BoleteriaOnline.Web.Data.Seeders;
using BoleteriaOnline.Web.Filters;
using BoleteriaOnline.Web.Localization;
using BoleteriaOnline.Web.Middlewares;
using BoleteriaOnline.Web.Repositories;
using BoleteriaOnline.Web.Repository;
using BoleteriaOnline.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using XLocalizer;
using XLocalizer.Routing;
using XLocalizer.Xml;

var builder = WebApplication.CreateBuilder(args);

string[] supportedCultures = new string[] { "es-ES", "en-US" };

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("SecretKey"));

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

/* INYECCION DE REPOSITORIOS */

builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IClienteRepository, ClienteRepository>();
builder.Services.AddScoped<IParadaRepository, ParadaRepository>();
builder.Services.AddScoped<IViajeRepository, ViajeRepository>();
builder.Services.AddScoped<INodoRepository, NodoRepository>();
builder.Services.AddScoped<IDistribucionRepository, DistribucionRepository>();
builder.Services.AddScoped<IPaisRepository, PaisRepository>();
builder.Services.AddScoped<IProvinciaRepository, ProvinciaRepository>();
builder.Services.AddScoped<IViajeClienteRepository, ViajeClienteRepository>();

/* INYECCION DE SERVICIOS */
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<IClienteService, ClienteService>();
builder.Services.AddScoped<IParadaService, ParadaService>();
builder.Services.AddScoped<IViajeService, ViajeService>();
builder.Services.AddScoped<INodoService, NodoService>();
builder.Services.AddScoped<IDistribucionService, DistribucionService>();
builder.Services.AddScoped<IPaisService, PaisService>();
builder.Services.AddScoped<IProvinciaService, ProvinciaService>();
builder.Services.AddScoped<IViajeClienteService, ViajeClienteService>();

builder.Services.AddCors();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false,
    };
});

builder.Services.AddControllers(options => options.Filters.Add<HttpResponseExceptionFilter>())
    .AddBadRequestServices()
    .AddJsonOptions(pptions =>
    {
        pptions.JsonSerializerOptions.PropertyNamingPolicy = new SnakeCaseNamingPolicy();
        pptions.JsonSerializerOptions.Converters.Add(new BobbyUtcDateTimeConverter());
    });

builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = Environment.GetEnvironmentVariable("MYSQLCONNSTR_localdb");

    options.UseInMemoryDatabase("Boleteria");
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
    options.UseSnakeCaseNamingConvention();
});
builder.Services.Configure<RequestLocalizationOptions>(ops =>
{
    var cultures = new CultureInfo[] { new CultureInfo("en"), new CultureInfo("es"), new CultureInfo("ar") };
    ops.SupportedCultures = cultures;
    ops.SupportedUICultures = cultures;
    ops.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture("en");

    ops.RequestCultureProviders.Insert(0, new RouteSegmentRequestCultureProvider(cultures));
});
builder.Services.AddSingleton<IXResourceProvider, XmlResourceProvider>();

builder.Services.TryAddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddMvc()
    .AddDataAnnotationsLocalization()
    .AddXLocalizer<LocalizationSource>(ops => builder.Configuration.GetSection("XLocalizerOptions").Bind(ops));
builder.Services.AddSwaggerDocument(options =>
{
    options.Description = "Colleci??n de API's correspondientes al sistema de Pasajes Online.";
    options.Title = "Boleteria Online";
});
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Boleteria Online",
        Version = "v1",
        Description = "Colleci??n de API's correspondientes al sistema de Pasajes Online.",
        Contact = new OpenApiContact() { Email = "admin@boleteriasystem.com", Name = "Agustin Iba??ez" }

    });
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});
builder.Services.AddResponseCompression(opts =>
{
    opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
        new[] { "application/octet-stream" });
});


var app = builder.Build();

app.UseResponseCompression();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();

    DataGenerator.Initialize(services);
}


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    //app.UseBlazorDebugging();
}

app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .WithExposedHeaders(new string[] { "cantidadTotalRegistros" })
);
/*
app.UseDefaultFiles();
app.UseStaticFiles();
*/
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);

app.UseRequestLocalization(localizationOptions);

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//Console.WriteLine(JsonSerializer.Serialize(ClienteSeeder.Seed(50), new JsonSerializerOptions() { WriteIndented = true }));


app.UseOpenApi();
app.UseSwaggerUi3(options =>
{
    options.DocumentTitle = "Boletaria Online";
});


app.Run();
