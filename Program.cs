using ExpenseApp.Config;
using ExpenseApp.Contracts;
using ExpenseApp.Data;
using ExpenseApp.Data.Contracts;
using ExpenseApp.Services;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);




{
    // Add services to the container.
    // Dependency Injections.
    builder.Services.AddControllers();

    // Making sure only of instance of our expense service interface is created.
    // Prevents reinstantiation per request.
    // Created for entire lifetime of the application.
    var dbSettings = builder.Configuration.GetSection(nameof(ExpenseStoreDatabaseSettings)).Get<ExpenseStoreDatabaseSettings>();
    builder.Services.AddSingleton<IMongoClient>(s => new MongoClient(dbSettings.ConnectionString));
    builder.Services.AddSingleton<IExpenseService, ExpenseService>();
    builder.Services.AddSingleton<IDataProvider, MongoDataProvider>();
    builder.Services.AddSingleton(dbSettings);

    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
}



var app = builder.Build();
{

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
}