using BirdFarmAPI;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Infracstructures;
using Microsoft.OpenApi.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.OData;
using Domain.Models.Base;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddInfractstructure(builder.Configuration);
builder.Services.AddWebAPIServices(builder);
builder.Services
           .AddControllers()
           .AddOData(options => options
               .AddRouteComponents("odata", GetEdmModel())
               .Select()
               .Filter()
               .OrderBy()
               .SetMaxTop(20)
               .Count()
               .Expand()
           )
           .AddJsonOptions(c => c.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
 {
     {
           new OpenApiSecurityScheme
             {
                 Reference = new OpenApiReference
                 {
                     Type = ReferenceType.SecurityScheme,
                     Id = "Bearer"
                 }
             },
             new string[] {}
     }
 });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("_myAllowSpecificOrigins");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new();
    builder.EntitySet<Bird>("Birds");
    builder.EntitySet<Cage>("Cages");
    builder.EntitySet<FeedingPlan>("FeedingPlans");
    builder.EntitySet<Food>("Foods");
    builder.EntitySet<Log>("Logs");
    builder.EntitySet<MealMenu>("MealMenus");
    builder.EntitySet<MenuDetail>("MenuDetails");
    builder.EntitySet<PurchaseOrder>("PurchaseOrders");
    builder.EntitySet<PurchaseOrderDetail>("PurchaseOrderDetails");
    builder.EntitySet<PurchaseRequest>("PurchaseRequests");
    builder.EntitySet<PurchaseRequestDetail>("PurchaseRequestDetails");
    builder.EntitySet<Species>("Species");
    builder.EntitySet<Tasks>("Tasks");
    builder.EntitySet<User>("Users");
    return builder.GetEdmModel();
}