using InsuranceAdvisor.IoC;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace InsuranceAdvisor.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers()
                    .AddJsonOptions(options =>
                    {
                        options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                        options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

                        var enumConverter = new JsonStringEnumConverter(JsonNamingPolicy.CamelCase);
                        options.JsonSerializerOptions.Converters.Add(enumConverter);
                    });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddInternalServices();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
