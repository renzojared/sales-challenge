var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(
    dbOptions
        => builder.Configuration.GetSection(Sales.Domain.Options.DbOptions.SectionKey).Bind(dbOptions),
    jwtOptions
        => builder.Configuration.GetSection(Sales.Domain.Options.JwtOptions.SectionKey).Bind(jwtOptions),
    claimOptions
        => builder.Configuration.GetSection(Sales.Domain.Options.ClaimOptions.SectionKey).Bind(claimOptions));
builder.Services.AddWebApiServices();
builder.Services.AddJwtServices(
    builder.Configuration[$"{nameof(Sales.Domain.Options.JwtOptions)}:{nameof(Sales.Domain.Options.JwtOptions.Key)}"]);
builder.Services.AddSwaggerServices();

builder.Services.AddCors(options => options.AddDefaultPolicy(config =>
{
    config.AllowAnyMethod();
    config.AllowAnyHeader();
    config.AllowAnyOrigin();
}));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapSwagger().RequireAuthorization();
app.UseAuthorization();
app.MapControllers();

app.Run();