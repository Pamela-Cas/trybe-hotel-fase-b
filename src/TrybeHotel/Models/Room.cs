namespace TrybeHotel.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// 1. Implemente as models da aplicação
public class Room
{
  public int RoomId { get; set; }
  public string? Name { get; set; }
  public int HotelId { get; set; }
  public int Image { get; set; }
  public Hotel? Hotel { get; set; }
  public List<Booking>? Bookings { get; set; }
  public int Capacity { get; set; }

}