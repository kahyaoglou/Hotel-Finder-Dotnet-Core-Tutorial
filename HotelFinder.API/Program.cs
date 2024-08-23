using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Controller kullanmak içingerekli.

builder.Services.AddEndpointsApiExplorer(); //Swagger'ýn API'mizdeki tüm endpoint'leri otomatik olarak keþfetmesini saðlar. 
builder.Services.AddSwaggerGen(); //Swagger dokümantasyonu ve UI'sini oluþturmak için kullanýlan servisi kaydeder.

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
//Swagger dokümantasyonu eklemek için kullanýlan NSwag kütüphanesine ait bir yapýlandýrmadýr.

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || !app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    app.UseSwagger(); //uygulamanýzýn API dokümantasyonunu JSON formatýnda sunan bir endpoint oluþturur.
                      //Bu JSON dokümaný, Swagger UI gibi araçlar tarafýndan API'nizi görselleþtirmek ve test etmek için kullanýlýr.
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.DocExpansion(Swashbuckle.AspNetCore.SwaggerUI.DocExpansion.List); // Tüm endpointleri default olarak listeler.
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseOpenApi(); //Swagger için gerekli.
app.UseSwaggerUi(); //Swagger için gerekli.

app.UseEndpoints(endpoints => { endpoints.MapControllers(); }); //Controller kullanmak için gerekli

app.MapRazorPages();

app.Run();
