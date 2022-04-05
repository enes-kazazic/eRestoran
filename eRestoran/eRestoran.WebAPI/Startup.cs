using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eRestoran.Model.Requests;
using eRestoran.WebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace eRestoran.WebAPI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddAutoMapper(typeof(Startup));

			services.AddSwaggerGen();

			services.AddDbContext<Database.eRestoranContext>(options =>
				options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

			services.AddScoped<ICRUDService<Model.Jelo, JeloSearchRequest, JeloUpsertRequest, JeloUpsertRequest>, JeloService>();
			services.AddScoped<ICRUDService<Model.Kategorija, KategorijaSearchRequest, KategorijaUpsertRequest, KategorijaUpsertRequest>, KategorijaService>();
			services.AddScoped<IBaseService<Model.StatusNarudzbe, StatusNarudzbeSearchRequest>, StatusNarudzbeService>();
			services.AddScoped<ICRUDService<Model.Narudzba,NarudzbaSearchRequest, NarudzbaUpsertRequest, NarudzbaUpsertRequest>, NarudzbaService>();
			services.AddScoped<ICRUDService<Model.StavkeNarudzbe,StavkeNarudzbeSearchRequest, StavkeNarudzbeUpsertRequest, StavkeNarudzbeUpsertRequest>, StavkeNarudzbeService>();
			services.AddScoped<ICRUDService<Model.Recenzija,object, RecenzijaUpsertRequest, RecenzijaUpsertRequest>, RecenzijaService>();
			
			services.AddControllers();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			//app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});

			app.UseSwagger();

			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
			});
		}
	}
}
