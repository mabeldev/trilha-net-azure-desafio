using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text.Json.Serialization;
using Trilha_net_azure_desafio.Domain.Interfaces;
using Trilha_net_azure_desafio.Domain.Settings;
using Trilha_net_azure_desafio.Repository;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.Converters.Add
        (new JsonStringEnumConverter()));


#region Swagger

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1",
                        new Microsoft.OpenApi.Models.OpenApiInfo
                        {
                            Title = "Trilha-Net-Azure",
                            Version = "v1",
                            Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "Alisson Silva" },
                        });
});

#endregion

#region AppSettings

var appSetting = builder.Configuration.GetSection(nameof(AppSetting)).Get<AppSetting>();
builder.Services.AddSingleton(appSetting);

#endregion

#region Mapper

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

#endregion


#region Service&Repository

builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
builder.Services.AddScoped<IFuncionarioLogRepository, FuncionarioLogRepository>();

#endregion

#region DbContext

builder.Services.AddDbContext<ApiContext>(options =>
{
    options.UseSqlServer(appSetting.SqlServerConnection);
    options.UseLazyLoadingProxies();
});

#endregion

#region AppConfiguration
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion