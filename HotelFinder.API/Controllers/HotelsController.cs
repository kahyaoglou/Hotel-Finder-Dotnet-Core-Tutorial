using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace HotelFinder.API.Controllers
{
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
        public List<Hotel> Get()
        {
            return _hotelService.GetAllHotels();
        }

        //Api'den id alan,
        //Geriye hotel döndüren,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpGet("{id}")]
        public Hotel Get(int id)
        {
            return _hotelService.GetHotelById(id);
        }

        //Geriye hotel döndüren
        //Hotel türünden bir hotel parametre alan
        //Body kısmında hotel barındıran bir controller metot.
        [HttpPost]
        public Hotel Post([FromBody] Hotel hotel)
        {
            return _hotelService.CreateHotel(hotel);
        }

        //Geriye hotel döndüren
        //Hotel türünden bir hotel parametre alan
        //Body kısmında hotel barındıran bir controller metot.
        [HttpPut]
        public Hotel Put([FromBody] Hotel hotel)
        {
            return _hotelService.UpdateHotel(hotel);
        }

        //Api'den id alan,
        //Geriye bir şey döndürmeyen,
        //Aldığı id'yi parametre kullanan bir controller metot.
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _hotelService.DeleteHotel(id);
        }
    }
}
