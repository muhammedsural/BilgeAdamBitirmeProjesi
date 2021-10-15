using System.Collections.Generic;
using System.Text;
using BitirmeProjesi.API.Infrastructor.Models.Base;
using BitirmeProjesi.Common.Service.WorkContext;
using BitirmeProjesi.Model.Context;
using BitirmeProjesi.Service.Repository.BillingAddress;
using BitirmeProjesi.Service.Repository.Brand;
using BitirmeProjesi.Service.Repository.Cart;
using BitirmeProjesi.Service.Repository.CartItem;
using BitirmeProjesi.Service.Repository.Category;
using BitirmeProjesi.Service.Repository.Country;
using BitirmeProjesi.Service.Repository.FavouritedProduct;
using BitirmeProjesi.Service.Repository.Location;
using BitirmeProjesi.Service.Repository.Maillist;
using BitirmeProjesi.Service.Repository.MaillistGroup;
using BitirmeProjesi.Service.Repository.Member;
using BitirmeProjesi.Service.Repository.MemberAddress;
using BitirmeProjesi.Service.Repository.OptionGroup;
using BitirmeProjesi.Service.Repository.Options;
using BitirmeProjesi.Service.Repository.OptionToProduct;
using BitirmeProjesi.Service.Repository.Order;
using BitirmeProjesi.Service.Repository.OrderAddress;
using BitirmeProjesi.Service.Repository.OrderItem;
using BitirmeProjesi.Service.Repository.OrderRefundRequest;
using BitirmeProjesi.Service.Repository.OrderRefundRequestItem;
using BitirmeProjesi.Service.Repository.OrderUserNote;
using BitirmeProjesi.Service.Repository.Payment;
using BitirmeProjesi.Service.Repository.PaymentGateway;
using BitirmeProjesi.Service.Repository.PaymentProvider;
using BitirmeProjesi.Service.Repository.PaymentType;
using BitirmeProjesi.Service.Repository.Product;
using BitirmeProjesi.Service.Repository.ProductComment;
using BitirmeProjesi.Service.Repository.Region;
using BitirmeProjesi.Service.Repository.ShippingAddress;
using BitirmeProjesi.Service.Repository.ShippingCompany;
using BitirmeProjesi.Service.Repository.ShippingProvider;
using BitirmeProjesi.Service.Repository.SpecGroup;
using BitirmeProjesi.Service.Repository.SpecName;
using BitirmeProjesi.Service.Repository.SpecToProduct;
using BitirmeProjesi.Service.Repository.SpecValue;
using BitirmeProjesi.Service.Repository.Town;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BitirmeProjesi.API
{
    public class Startup
    {
        public IConfigurationRoot configuration { get; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", reloadOnChange: true, optional: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", reloadOnChange: true, optional: true)
                .AddEnvironmentVariables();
            configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(configuration);

            services.AddDbContext<DataContext>(option =>
            {
                option.UseNpgsql(configuration["ConnectionStrings:Conn"],
                    b => b.MigrationsAssembly("BitirmeProjesi.API"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddAutoMapper(typeof(Startup));
            services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(option =>
                {
                    option.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = configuration["Tokens:Issuer"],
                        ValidAudience = configuration["Tokens:Audience"],
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Tokens:Key"]))
                    };
                });
            services.AddTransient<IWorkContext, ApiWorkContext>();
            services.AddTransient<IBillingAddressRepository, BillingAddressRepository>();
            services.AddTransient<IBrandRepository, BrandRepository>();
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<IFavouritedProductRepository, FavouritedProductRepository>();
            services.AddTransient<ILocationRepository, LocationRepository>();
            services.AddTransient<IMaillistRepository, MaillistRepository>();
            services.AddTransient<IMaillistGroupRepository, MaillistGroupRepository>();
            services.AddTransient<IMemberRepository, MemberRepository>();
            services.AddTransient<IMemberAddressRepository, MemberAddressRepository>();
            services.AddTransient<IOptionGroupRepository, OptionGroupRepository>();
            services.AddTransient<IOptionsRepository, OptionsRepository>();
            services.AddTransient<IOptionToProductRepository, OptionToProductRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IOrderAddressRepository, OrderAddressRepository>();
            services.AddTransient<IOrderItemRepository, OrderItemRepository>();
            services.AddTransient<IOrderRefundRequestRepository, OrderRefundRequestRepository>();
            services.AddTransient<IOrderRefundRequestItemRepository, OrderRefundRequestItemRepository>();
            services.AddTransient<IOrderUserNoteRepository, OrderUserNoteRepository>();
            services.AddTransient<IPaymentRepository, PaymentRepository>();
            services.AddTransient<IPaymentGatewayRepository, PaymentGatewayRepository>();
            services.AddTransient<IPaymentProviderRepository, PaymentProviderRepository>();
            services.AddTransient<IPaymentTypeRepository, PaymentTypeRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IProductCommentRepository, ProductCommentRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<IShippingAddressRepository, ShippingAddressRepository>();
            services.AddTransient<IShippingCompanyRepository, ShippingCompanyRepository>();
            services.AddTransient<IShippingProviderRepository, ShippingProviderRepository>();
            services.AddTransient<ISpecGroupRepository, SpecGroupRepository>();
            services.AddTransient<ISpecNameRepository, SpecNameRepository>();
            services.AddTransient<ISpecToProductRepository, SpecToProductRepository>();
            services.AddTransient<ISpecValueRepository, SpecValueRepository>();
            services.AddTransient<ITownRepository, TownRepository>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                //using Microsoft.OpenApi.Models
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Swagger on ASP.Net Core",
                    Version = "1.0.0.",
                    Description = "Bilge Adam Backend Servis Projesi(ASP.NET Core 3.1)",
                    TermsOfService = new System.Uri("http://swagger.io/terms")
                });

                c.AddSecurityDefinition("Bearer",
                    new OpenApiSecurityScheme
                    {
                        Description =
                            "Bilge Adam Core API Projesi JWT Authorization header (Bearer) kullanmaktadır. örnek: \"Authorization: Bearer {token} \"",
                        Type = SecuritySchemeType.Http,
                        Scheme = "bearer"
                    });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BitirmeProjesi.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}