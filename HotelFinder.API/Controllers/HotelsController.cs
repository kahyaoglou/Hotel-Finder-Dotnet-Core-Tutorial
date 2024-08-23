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
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels); //200 + data
        }

        //Api'den id alan,
        //Geriye hotel döndüren,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
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
        public IActionResult Post([FromBody] Hotel hotel)
        {
            var createdHotel = _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel); //201 + Data
            //Required olarak etiketlediğimiz verilerle yapalım geliştirmeyi.
        }

        //Geriye hotel döndüren
        //Hotel türünden bir hotel parametre alan
        //Body kısmında hotel barındıran bir controller metot.
        [HttpPut]
        public IActionResult Put([FromBody] Hotel hotel)
        {
            if (_hotelService.GetHotelById(hotel.Id) != null)
            {
                return Ok(_hotelService.UpdateHotel(hotel)); //200 + Data
            }
            return NotFound(); //404
        }

        //Api'den id alan,
        //Geriye bir şey döndürmeyen,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok(); //200
            }
            return NotFound(); //404
        }
    }
}
