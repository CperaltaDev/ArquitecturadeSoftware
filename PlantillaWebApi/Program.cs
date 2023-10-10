using Microsoft.OpenApi.Models;
using NLog;
using NLog.Web;
using Proyecto.Business;
using Proyecto.Business.Interfaces;
using Proyecto.Middleware;
using Proyecto.Model;
using Proyecto.Model.Interfaces;
using Proyecto.Model.Repository;
using Swashbuckle.AspNetCore.Filters;
using System.Reflection;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();

try
{
    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
#pragma warning disable S1075 // URIs should not be hardcoded
    string uriString = "https://github.com/CperaltaDev/ApiIntegracionContinuaCoreBanca_CAPA";
#pragma warning restore S1075 // URIs should not be hardcoded
    builder.Services.AddSwaggerGen(options =>
    {
        options.ExampleFilters();

        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Version = "v1",
            Title = "Api Integracion Core Bancario",
            Description = "Api que permite la integracion de documentos para la Banca" + " " +
                          "\n\n### Politecnico Grancolombiano\n### Interacion Continua" +
                          "\n Entrega proyecto 2 Escenario 5",
            TermsOfService = new Uri(uriString),
            Contact = new OpenApiContact
            {
                Name = "Contact the developer",
                Url = new Uri(uriString)
            },
            License = new OpenApiLicense
            {
                Name = "License",
                Url = new Uri(uriString)
            }
        });

        options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter a valid token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "Bearer"
        });
        options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            new string[]{}
            }
        });

        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });

    builder.Services.AddSwaggerExamplesFromAssemblies(Assembly.GetEntryAssembly());

    builder.Logging.ClearProviders();
    builder.Host.UseNLog();
    
    builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

    builder.Services.AddSqlServer<CoreBancaContext>(builder.Configuration.GetConnectionString("CoreBanca"));


    builder.Services.AddScoped<IProductos, ProductoDB>(); 
    builder.Services.AddScoped<IProducto, ProductoServices>();
    builder.Services.AddScoped<ITipodocumentos, TipoDocumentoDB>();
    builder.Services.AddScoped<ITipodocumento, TDocumentoServices>(); 



    var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();

    app.UseAuthorization();
    app.UseMiddleware<JwtMiddleware>();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    logger.Error(ex, "Error inicializando program.cs");
    throw;
}
finally 
{
    LogManager.Shutdown();
}










