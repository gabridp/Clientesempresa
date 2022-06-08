using ApiClientesEmpresa.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
        options.SerializerSettings.ReferenceLoopHandling
            = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddEndpointsApiExplorer();

//registrando as configurações do projeto
EntityFrameworkConfiguration.Register(builder);
CorsConfiguration.Register(builder);
SwaggerConfiguration.Register(builder);
JwtConfiguration.Register(builder);

#region Configuração do CORS

builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy", builder => {
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
}));

#endregion


var app = builder.Build();

//ativando as configurações do projeto
CorsConfiguration.Use(app);
SwaggerConfiguration.Use(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
