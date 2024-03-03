using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Repository
{
    public class HotelRepository : IHotelRepository
    {
        protected readonly ITrybeHotelContext _context;
        public HotelRepository(ITrybeHotelContext context)
        {
            _context = context;
        }

        public IEnumerable<HotelDto> GetHotels()
        {
            return _context.Hotels.Select(h => new HotelDto()
			{
				HotelId = h.HotelId,
				Name = h.Name,
				Address = h.Address,
				CityId = h.CityId,
			});
        }
        
        public HotelDto AddHotel(Hotel hotel)
        {
              _context.Hotels.Add(hotel);
            _context.SaveChanges();
            return new HotelDto
            {
                HotelId = hotel.HotelId,
                Name = hotel.Name,
                Address = hotel.Address,
                CityId = hotel.CityId,
                CityName = (from c in _context.Cities
                            where c.CityId == hotel.CityId
                            select c.Name).FirstOrDefault()
            };
        }
    }
}