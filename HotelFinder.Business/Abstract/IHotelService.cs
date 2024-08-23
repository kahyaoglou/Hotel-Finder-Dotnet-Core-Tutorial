using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Abstract
{
    public interface IHotelService
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
