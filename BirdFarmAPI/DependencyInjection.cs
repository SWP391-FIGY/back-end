using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder.Extensions;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BirdFarmAPI
{
    public static class DependencyInjection
    {
        public static void AddWebAPIServices(this IServiceCollection services, WebApplicationBuilder builder)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            // Add CORS Policy
            services.AddCors(options =>
            {
                options.AddPolicy(name: "_myAllowSpecificOrigins",
                                  policy =>
                                  {
                                      policy.WithOrigins(
                                          "http://localhost:3005",
                                          "http://localhost:3000")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                                  });
            });



            string jsonLocationPath = "bird-management-27cc4-firebase-adminsdk-t0xlu-58bfb8083b.json";
            string fullPath = Environment.CurrentDirectory;
            string jsonLocationFullPath = Path.Combine(fullPath, jsonLocationPath);
            FirebaseApp.Create(
            new AppOptions()
            {
                Credential = GoogleCredential.FromFile(jsonLocationFullPath),
            });
        }
    }
}
