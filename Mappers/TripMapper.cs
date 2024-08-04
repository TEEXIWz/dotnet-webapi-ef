using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_ef.DTOs.Trip;
using dotnet_webapi_ef.Models;

namespace dotnet_webapi_ef.Mappers
{
    public static class TripMapper
    {
        //Method to Map from Model => DTO
        //static คือ เปิดโปรแกรมมาเรียกใช้ได้เลย ไม่ต้องสร้าง object เพื่อใช้งาน
        public static TripDTO ToTripDTO(this Trip trip){
            return new TripDTO {
                Idx = trip.Idx,
                Name = trip.Name,
                Country = trip.Country,
                Destinationid = trip.Destinationid,
                Coverimage = trip.Coverimage,
                Detail = trip.Detail,
                Price = trip.Price,
                Duration = trip.Duration,
                Destination = trip.Destination.ToDestinationDTO()
            };
        }
    }
}