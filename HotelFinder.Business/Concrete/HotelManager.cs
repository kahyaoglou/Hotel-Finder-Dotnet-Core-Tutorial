﻿using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private IHotelRepository _hotelRepository;
        //IHotelRepository interface türünden bir değişken oluşturduk.
       
        public HotelManager(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;

            /* Önceki yapımız şöyleydi:
             public HotelManager()
             {
                _hotelRepository = new HotelRepository();
                //Bu değişken, bir HotelRepository örneği olsun dedik.
             }

            * Böylelikle constructor içerisinde sürekli newlemek durumundan kurutlduk.*/
        }

        public async Task<Hotel> CreateHotel(Hotel hotel)
        {
            return await _hotelRepository.CreateHotel(hotel);
        }

        public async Task DeleteHotel(int id)
        {
            await _hotelRepository.DeleteHotel(id);
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            return await _hotelRepository.GetAllHotels();
        }

        public async Task<Hotel> GetHotelById(int id)
        {
            //Bir iş kuralı yazalım.
            if (id > 0)
            {
                return await _hotelRepository.GetHotelById(id);
            }

            throw new Exception("id can not be less than 1");
        }

        public async Task<Hotel> GetHotelByName(string name)
        {
            return await _hotelRepository.GetHotelByName(name);
        }

        public async Task<Hotel> UpdateHotel(Hotel hotel)
        {
            return await _hotelRepository.UpdateHotel(hotel);
        }
    }
}

/*
 - Bizim burada işin mantığını yönetmemiz gerekecek. Entities katmanında veritabanına yansıyan verileri
 property olarak tanımlamıştık.

 - DataAccess katmanında veritabanı üzerindeki temel işlemleri yapmamızı sağlayan yapıyı kurmuştuk.

 - Bu katmanda da basit veritabanı işlemleri için gereken iş kurallarını yapacağız. Bu katman genellikle isterlerin
 tam anlamıyla karşılanması için gerekli koşulların yazıldığı katmandır.
*/

