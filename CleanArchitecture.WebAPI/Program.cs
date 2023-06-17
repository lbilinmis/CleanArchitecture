using CleanArchitecture.Application;
using CleanArchitecture.Application.Services.Authentication;
using CleanArchitecture.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

{
    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();


    // a�a��daki kod yerine DependencyInjection diye tanomlad���m�z class dosyas�n� kullanmak i�in 
    //builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

    //servisini kullan�yorum
    builder.Services.
        AddApplication().
        AddInfrastructure(builder.Configuration);

}

var app = builder.Build();

{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}