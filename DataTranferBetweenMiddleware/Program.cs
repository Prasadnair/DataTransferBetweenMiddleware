using DataTranferBetweenMiddleware.MWare.Features;
using DataTranferBetweenMiddleware.MWare.Header;
using DataTranferBetweenMiddleware.MWare.Items;
using DataTranferBetweenMiddleware.MWare.QString;
using DataTranferBetweenMiddleware.MWare.ScopedService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IScopedService, ScopedService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //Items Approach
    //app.UseIMiddlewareOne();
    //app.UseIMiddlewareTwo();

    //Scoped Service
    app.UseSMiddlewareOne();
    app.UseSMiddlewareTwo();

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
//QueryString Approach
//app.UseQStringMiddlewareOne();
//app.UseQStringMiddlewareTwo();
//Header Approach
//app.UseHMiddlewareOne();
//app.UseHMiddlewareTwo();

//Features Approach
//app.UseFMiddlewareOne();
//app.UseFMiddlewareTwo();


app.MapControllers();

app.Run();
