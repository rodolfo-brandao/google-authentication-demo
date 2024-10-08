using GoogleAuth.Api.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddScoped<IGoogleAuthenticationService, GoogleAuthenticationService>();
}

var app = builder.Build();

{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
