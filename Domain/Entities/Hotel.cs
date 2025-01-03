﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your hotel name")]
        [StringLength(50, ErrorMessage = "Please do not enter values over 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the address of this hotel")]
        [StringLength(100, ErrorMessage = "Please do not enter values over 100 characters")]
        public string Address { get; set; }

        public string? Description{ get; set; }
        public string? ImageUrl { get; set; }
        [Required]
        [Range(50, 30000, ErrorMessage = "Please enter the correct value from 50 to 30000")]
        public double Size { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdated { get; set; }

        public virtual ICollection<HotelRoom>? HotelRooms { get; set; }
        public virtual ICollection<HotelAmenity>? HotelAmenities { get; set; }
        public virtual ICollection<HotelImageGallery>? HotelImageGalleries { get; set; }
        public virtual ICollection<Review>? Reviews { get; set; }
    }
}
