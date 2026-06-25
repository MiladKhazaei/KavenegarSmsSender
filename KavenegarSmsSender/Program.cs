using KavenegarSmsSender.Controllers;
using KavenegarSmsSender.Interface;
using KavenegarSmsSender.Models;
using KavenegarSmsSender.Service;

var builder = WebApplication.CreateBuilder(args);
//var rngName = SendSmsController.RandomNumberGenerate();
// Add services to the container.
builder.Services.AddControllersWithViews();

// Config our service
builder.Services.Configure<KavenegarSettings>(builder.Configuration.GetSection("KavenegarApi"));
builder.Services.AddScoped<ISMSSender, SMSSender>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=SendSms}/{action=MainView}/{id?}")
    .WithStaticAssets();


app.Run();
