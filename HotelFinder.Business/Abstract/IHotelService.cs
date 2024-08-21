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
        List<Hotel> GetAllHotels();
        //Geriye liste türünden Hotel'leri döndürecek. Parametre almayacak.
        Hotel GetHotelById(int id);
        //Geriye Hotel döndürecek. Parametre id alacak.
        Hotel CreateHotel(Hotel hotel);
        //Geriye Hotel döndürecek. Parametre Hotel alacak.
        Hotel UpdateHotel(Hotel hotel);
        //Geriye Hotel döndürecek. Parametre Hotel alacak.
        void DeleteHotel(int id);
        //Geriye bir şey döndürmeyecek. Parametre id alacak.
    }
}
