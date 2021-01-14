using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL.Repository
{
    public class HotelRepository : IHotelRepository
    {

        private readonly Database.SampleMVCEntities _dbContext;

        public HotelRepository()
        {
            _dbContext = new Database.SampleMVCEntities();
        }

        public string CreateHotel(Hotel model)
        {
            try
            {
                if (model != null)
                {
                    Mapper.CreateMap<Hotel, Database.Hotel>();
                    Database.Hotel entity = Mapper.Map<Database.Hotel>(model);

                    entity.CreatedDate = DateTime.Now;
                    _dbContext.Hotels.Add(entity);
                    _dbContext.SaveChanges();

                    return "Successfully Added";
                }
                return "Model is Null;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Hotel> GetAllHotels()
        {
            var entities = _dbContext.Hotels.OrderBy(e => e.HotelName).ToList();
            List<Hotel> list = new List<Hotel>();

            if(entities != null)
            {
                Mapper.CreateMap<Database.Hotel, Hotel>();
                foreach (var item in entities)
                {
                    Hotel hotel = Mapper.Map<Hotel>(item);

                    list.Add(hotel);
                }
            }

            return list;
        }
    }
}
