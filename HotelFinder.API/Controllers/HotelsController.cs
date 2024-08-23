using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelFinder.API.Controllers
{
    /*
     * Biz şu ana kadar yaptığımız testlerimizi sürekli pozitif senaryolar üzerinden test ettik.
     * Mesela Get endpointindeki GetById metodunu kullanırken biz sürekli db’de olduğunu bildiğimiz
     verileri db’den sorguladık.
     * Peki bu senaryoda db’de olmayan bir hoteli sorgulasaydık ne olacaktı? 404 response code dönmesi
     gerekecekti. Ama şu anda negatif bir senaryoda sorgu yaptığımızda 204 No Content hatası dömekte.
     * Bizim bütün bu senaryoda 404 Not Found döndürmeyi sağlamamız gerekir.
     * Bunu da IActionResult interfacei ile sağlarız 
     */

    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        /*Controllerdan HotelManager’a ulaşabilmek için bir IHotelService interface’i
         üzerinden HotelManager örneği oluşturmamız lazım.*/

        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }

        //Geriye liste türünden hotel döndüren bir controller metot
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllHotels() //api/hotels/getallhotels
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }

        //Api'den id alan,
        //Geriye hotel döndüren,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpGet]
        [Route("[action]/{id}")] //api/hotels/gethotelbyid/2
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound(); //404
        }

        //Mevcut geliştirmede parametre alan iki adet Get endpointi var.
        //Bunlar birbirini overload etmektedirler.
        //Eğer bu endpointlere istek atarsak hata alırız.
        //Çünkü hangi endpointi seçeceğini bilemez.
        //Göndereceğimiz int 2 ya da string titanic değerlerinin hangi endpointe düşeceği belli değildir.
        //Bizim bu durumda bu endpointlere Route vermemiz gerekir
        [HttpGet]
        [Route("[action]/{name}")] //api/hotels/gethotelbyname/titanic
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel); //200 + data
            }
            return NotFound(); //404
        }

        //Geriye hotel döndüren
        //Hotel türünden bir hotel parametre alan
        //Body kısmında hotel barındıran bir controller metot.
        [HttpPost]
        [Route("[action]")] //api/hotels/createhotel
        public IActionResult CreateHotel([FromBody] Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201 + Data
            //Required olarak etiketlediğimiz verilerle yapalım geliştirmeyi.
        }

        //Geriye hotel döndüren
        //Hotel türünden bir hotel parametre alan
        //Body kısmında hotel barındıran bir controller metot.
        [HttpPut]
        [Route("[action]")] //api/hotels/updatehotel
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 + Data
            }
            return NotFound();
        }

        //Api'den id alan,
        //Geriye bir şey döndürmeyen,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpDelete]
        [Route("[action]/{id}")] //api/hotels/deletehotel/2
        public IActionResult DeleteHotel(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound();
        }
    }
}
