using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BitirmeProjesi.Web.UI.APIs;
using BitirmeProjesi.Web.UI.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Polly;
using Refit;

namespace BitirmeProjesi.Web.UI
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(Configuration);

            //Http Context'i S�recimize ekliyoruz.
            services.AddHttpContextAccessor();

            //Register Refit Interfaces
            //Refit.HttpClientFactory
            RegisterClients(services);

            //Add AutoMapper
            //AutoMapper.Extensions.Microsoft.DependencyInjection
            services.AddAutoMapper(typeof(Startup));

            //MVC mod�l�n� s�recimize ekliyoruz.
            services.AddControllersWithViews()
                //Microsoft.AspNetCore.Mvc.Razor.RuntimeCompilation
                .AddRazorRuntimeCompilation();

            //Microsoft.AspNetCore.Authentication.Cookies
            //Asp.NEt Core MVC'de Oturum Y�netimini Core Identity ile ger�ekle�tiriyoruz. Core Identity'de Cookie y�netimini kullan�yoruz.
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => { options.LoginPath = "/Account/Login"; });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Core Identity Servisimizi aktifle�tiriyoruz.
            app.UseAuthentication();

            //wwwroot klas�r�ne ri�im izni veriyoruz.
            app.UseStaticFiles();

            //Durum kodlar� ile ilgili sayfalar� kullanma izni veriyoruz...
            app.UseStatusCodePages();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
            });
        }

        private void RegisterClients(IServiceCollection services)
        {
            //RegisterHttpHandler
            services.AddScoped<AuthTokenHandler>();

            var baseUrl = Configuration
                .GetSection("Settings")
                .GetSection("Host")["CoreAPIServer"];
            var baseUri = new Uri(baseUrl);

            //Account
            services.AddRefitClient<IAccountApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3));

            //Category
            services.AddRefitClient<ICategoryApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());

            //Brand
            services.AddRefitClient<IBrandApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());

            //Product
            services.AddRefitClient<IProductApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());

            //Member
            services.AddRefitClient<IMemberApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());

            //ConfirmedOrder
            services.AddRefitClient<IConfirmedOrderApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());

            //PendingOrder
            services.AddRefitClient<IPendingOrderApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());
            //CartApi
            services.AddRefitClient<ICartApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());
            
            services.AddRefitClient<ICountryApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());
            
            services.AddRefitClient<ILocationApi>()
                .ConfigureHttpClient(client => { client.BaseAddress = baseUri; })
                .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(TimeSpan.FromSeconds(60)))
                .AddTransientHttpErrorPolicy(p => p.RetryAsync(3))
                .AddHttpMessageHandler((s) => s.GetService<AuthTokenHandler>());
        }
    }
}