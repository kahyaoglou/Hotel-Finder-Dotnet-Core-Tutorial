//Bütün yapıda Dependency Injection kullanacağız.
//Bu sebeple bu katmana metotlarımızı yazarken interface tanımlamalıyız.

using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Abstract
{
    public interface IHotelRepository
    {
        Task<List<Hotel>> GetAllHotels();
        //Geriye liste türünden Hotel'leri döndürecek. Parametre almayacak.
        Task<Hotel> GetHotelById(int id);
        //Geriye Hotel döndürecek. Parametre id alacak.
        Task<Hotel> GetHotelByName(string name);
        //Geriye Hotel döndürecek. Parametre name alacak.
        Task<Hotel> CreateHotel(Hotel hotel);
        //Geriye Hotel döndürecek. Parametre Hotel alacak.
        Task<Hotel> UpdateHotel(Hotel hotel);
        //Geriye Hotel döndürecek. Parametre Hotel alacak.
        Task DeleteHotel(int id);
        //Geriye bir şey döndürmeyecek. Parametre id alacak.
    }
}

/*Projede abstract ve concrete yapıları kullanmanın temel sebebi, yazılım geliştirme sürecinde esneklik, test edilebilirlik
ve bağımlılıkların yönetimi gibi önemli avantajlar sağlamaktır. Bu yapı, yazılımın gelecekte daha kolay
genişletilebilmesi ve bakımının yapılabilmesi için önemli bir tasarım desenidir.
Bu yapıyı biraz daha detaylı inceleyelim:*/
    
/*Abstract ve Concrete Yapısı:

1. Abstract Katmanı (Örneğin:IHotelRepository):
        -Interface'ler ve Soyutlama: Bu katman, veri erişim işlemlerini soyutlar. `IHotelRepository` gibi bir interface
        tanımlayarak, hangi işlemleri gerçekleştireceğini belirtiriz ama nasıl yapılacağı hakkında bir bilgi vermez.
        - Amacı: Kodun bağımsız hale gelmesini sağlar. Yani uygulamanın diğer katmanları, veri erişim işlemlerinin
        nasıl yapıldığını bilmek zorunda kalmaz, sadece hangi işlemlerin yapıldığını bilir.
2. Concrete Katmanı (Örneğin: HotelRepository):
        -Somut Uygulama: Bu katman, interface’de belirtilen metodların gerçek uygulamasını sağlar. `HotelRepository`, 
        `IHotelRepository`'de tanımlanan metodların nasıl gerçekleştirileceğini belirler.
        - Amacı: Soyutlanan metodların(örneğin `CreateHotel`, `GetHotelById`) gerçek işleyişini sağlar.*/
    
/*Faydaları:
    
1. Bağımlılıkların Azaltılması (Loose Coupling):
        -Interface ile somut sınıf birbirinden ayrıldığı için, uygulamanın diğer bölümleri `IHotelRepository`'yi
        kullanır ve somut sınıfa bağımlı hale gelmez. Bu da değişiklik yapmayı kolaylaştırır.
2. Test Edilebilirlik:
        -Birim testlerde `HotelRepository` gibi somut sınıfları direkt test etmek yerine, `IHotelRepository`'nin bir
        mock (sahte) versiyonunu kullanarak testler yapabilirsin. Böylece veri tabanı gibi harici bağımlılıklar
        olmadan test yapabilirsin.
3. Esneklik:
        -Eğer ileride başka bir veri kaynağı (örneğin bir başka veri tabanı veya bir web servisi) kullanmak istersen,
        sadece `IHotelRepository`'yi implement eden yeni bir sınıf oluşturman yeterli olur. Diğer kodlarda herhangi
        bir değişiklik yapmana gerek kalmaz.
4. Bakım Kolaylığı:
        -Abstract - concrete yapısı, uygulamayı daha modüler hale getirir. Bir katmanda yapılan değişiklikler diğer 
        katmanları etkilemez. Bu da yazılımın bakımını kolaylaştırır.*/
    
/*Bu Yapının Tanımı:
    
        -Bu yapı genellikle Repository Pattern ve Dependency Injection ile birlikte kullanılır.
        - Repository Pattern: Veri erişim işlemlerini soyutlayarak veritabanı ile ilgili işlemleri bir merkezi noktada
        toplar. Kodun tekrarlanmamasını sağlar ve veri erişimini daha temiz bir şekilde organize eder.
        - Dependency Injection (Bağımlılık Enjeksiyonu): Uygulama içerisindeki bağımlılıkları soyutlamak ve yönetmek
        için kullanılır. `IHotelRepository` gibi bağımlılıklar, ihtiyaç duyulan yerlere dışarıdan enjekte edilir,
        böylece sınıfların bağımlılıkları kendilerinin oluşturması gerekmez.*/