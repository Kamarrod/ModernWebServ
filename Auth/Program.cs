using Microsoft.AspNetCore.HttpOverrides;
using Auth.Extensions;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Options;
using Auth.ActionFilters;

var builder = WebApplication.CreateBuilder(args);




builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureRepositoryManager();
builder.Services.AddScoped<ValidationFilterAttribute>();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);



builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});


//builder.Services
//    .AddControllers()
//    .AddApplicationPart(typeof(WebApp.Presentation.AssemblyReference).Assembly);

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;
    config.ReturnHttpNotAcceptable = true;
    //config.InputFormatters.Insert(0, GetJsonPatchInputFormatter());
}).AddXmlDataContractSerializerFormatters();

var app = builder.Build();


if (app.Environment.IsProduction())
    app.UseHsts();

//if (app.Environment.IsDevelopment())
//    app.UseDeveloperExceptionPage();
//else
//    app.UseHsts();

//NewtonsoftJsonPatchInputFormatter GetJsonPatchInputFormatter() =>
//    new ServiceCollection()
//    .AddLogging()
//    .AddMvc()
//    .AddNewtonsoftJson()
//    .Services.BuildServiceProvider()
//    .GetRequiredService<IOptions<MvcOptions>>().Value.InputFormatters
//    .OfType<NewtonsoftJsonPatchInputFormatter>()
//    .First();


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
