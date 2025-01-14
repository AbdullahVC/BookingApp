﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookingApp.Data.Entities
{
    public class RoomEntity : BaseEntity
    {

        public int HotelId { get; set; }
        public string RoomNumber { get; set; }

        //Relational Property

        public ICollection<ReservationEntity> Rezervations { get; set; }
        public HotelEntity Hotel { get; set; }

    }


    public class RoomConfiguration : BaseConfiguration<RoomEntity>
    {
        public override void Configure(EntityTypeBuilder<RoomEntity> builder)
        {
            base.Configure(builder);
        }
    }



}
