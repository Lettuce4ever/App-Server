using App_Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace App_Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();


            //Add Database to dependency injection
            builder.Services.AddDbContext<GameDbContext>(
                    options => options.UseSqlServer("Server = (localdb)\\MSSQLLocalDB;Initial Catalog=Game_DB;User ID=TaskAdminLogin;Password=DBGalPass; Trusted_Connection=True; MultipleActiveResultSets = true"));
           
            
            #region Add Session
            builder.Services.AddDistributedMemoryCache();
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
                options.Cookie.HttpOnly = false;
                options.Cookie.IsEssential = true;
            });
            #endregion
            
            #region for debugginh UI
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
/*            builder.Services.AddSwaggerGen();*/
            #endregion

            var app = builder.Build();

            #region for debugginh UI
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                //app.UseSwagger();
                //app.UseSwaggerUI();
            }
            #endregion


            #region Add Session
            app.UseSession(); //In order to enable session management
            #endregion 

            // Configure the HTTP request pipeline.

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }

        private static void connectionString(SqlServerDbContextOptionsBuilder builder)
        {
            throw new NotImplementedException();
        }
    }
}
