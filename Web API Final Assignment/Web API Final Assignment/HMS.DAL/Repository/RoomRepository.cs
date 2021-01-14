using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace HMS.DAL.Repository
{
    public class RoomRepository : IRoomRepository
    {

        private readonly Database.SampleMVCEntities _dbContext;

        public RoomRepository()
        {
            _dbContext = new Database.SampleMVCEntities();
        }

        public string CreateRoom(Room model)
        {
            try
            {
                if (model != null)
                {
                    Mapper.CreateMap<Room, Database.Room>();
                    Database.Room entity = Mapper.Map<Database.Room>(model);
                    entity.CreatedDate = DateTime.Now;
                    
                    _dbContext.Rooms.Add(entity);
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

        public string GetAvailableRoom(Booking model)
        {
            try
            {
                if (model != null)
                {
                    var entity = _dbContext.Bookings.Where(e => e.RoomID == model.RoomID && e.BookingDate == model.BookingDate && e.Status != "Deleted" && e.Status != "Cancelled").ToList();

                    if(entity.Count != 0)
                    {
                        return "False";
                    }
                    else
                    {
                        return "True";
                    }
                }
                return "Data is Null;";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public List<Room> GetRooms(Temp model)
        {
            if(model != null)
            {
                var HotelID = _dbContext.Hotels.Where(e => (model.City != null ? e.City == model.City : true)  && (model.Pincode != null ? e.Pincode == model.Pincode : true)).Select(e => e.ID).ToList();

                var entities = _dbContext.Rooms.Where(e => (HotelID.Contains((int)e.HotelID) ? true : false) && (model.Category != null ? e.RoomCategory == model.Category : true) && (model.Price != null ? (e.RoomPrice <= model.Price) : true)).OrderBy(e => e.RoomPrice).ToList();
                List<Room> list = new List<Room>();

                if (entities != null)
                {
                    Mapper.CreateMap<Database.Room, Room>();

                    foreach (var item in entities)
                    {
                        Room room = Mapper.Map<Room>(item);
                        list.Add(room);
                    }
                }
                return list;
            }
            return new List<Room>();
        }
    }
}
