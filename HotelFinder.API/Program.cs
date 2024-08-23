using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Controller kullanmak i�ingerekli.
builder.Services.AddSingleton<IHotelService, HotelManager>();
//Senden cotr'da IHotelService istiyorsam bana HotelManager ver.
builder.Services.AddSingleton<IHotelRepository, HotelRepository>();
//Senden cotr'da IHotelRepositroy istiyorsam bana HotelRepository ver.
builder.Services.AddSwaggerDocument(config =>
{
    config.PostProcess = (doc =>
    {
        doc.Info.Title = "HotelFinder API";
        doc.Info.Version = "1.0.12";
    });
});
//Swagger i�in gerekli.

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseOpenApi(); //Swagger i�in gerekli.
app.UseSwaggerUi(); //Swagger i�in gerekli.

app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); //Controller kullanmak i�in gerekli

app.MapRazorPages();

app.Run();
