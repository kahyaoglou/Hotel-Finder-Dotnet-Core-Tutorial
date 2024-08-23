using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Controller kullanmak i�ingerekli.

builder.Services.AddEndpointsApiExplorer(); //Swagger'�n API'mizdeki t�m endpoint'leri otomatik olarak ke�fetmesini sa�lar. 
builder.Services.AddSwaggerGen(); //Swagger dok�mantasyonu ve UI'sini olu�turmak i�in kullan�lan servisi kaydeder.

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
//Swagger dok�mantasyonu eklemek i�in kullan�lan NSwag k�t�phanesine ait bir yap�land�rmad�r.

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseSwagger(); //uygulaman�z�n API dok�mantasyonunu JSON format�nda sunan bir endpoint olu�turur.
                      //Bu JSON dok�man�, Swagger UI gibi ara�lar taraf�ndan API'nizi g�rselle�tirmek ve test etmek i�in kullan�l�r.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List); // T�m endpointleri default olarak listeler.
    });
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
