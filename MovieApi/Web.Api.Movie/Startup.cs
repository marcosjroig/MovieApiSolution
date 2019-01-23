using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web.Api.Movie.Data.Data;
using Web.Api.Movie.Data.Service.Movie;
using Web.Api.Movie.Data.Service.Rating;
using Web.Api.Movie.Data.Service.Search;
using Web.Api.Movie.Data.Service.User;
using Web.Api.Movie.Utils.Formatters;

namespace Web.Api.Movie
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MovieDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("MovieDbContext")));

            //Repositories
            services.AddScoped<IMovieRatingRepository, MovieRatingRepository>();
            services.AddScoped<ISearchRepository, SearchRepository>();
            services.AddScoped<IUserRatingRepository, UserRatingRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped<IDecimalFormatter, DecimalFormatterClosestHalf>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, MovieDbContext moviesDbContext)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            moviesDbContext.Database.EnsureCreated();
        }
    }
}
