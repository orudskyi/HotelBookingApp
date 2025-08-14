using HotelBooking.Domain.Entities;
using HotelBooking.Infrastructure.Data.Seeding;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Amenity> Amenities { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Configure relationships and other settings here if needed
            //builder.Entity<Hotel>().OwnsOne(h => h.Address);

            var hotelsToSeed = DbSeeder.GetHotels();


            builder.Entity<Hotel>().HasData(
                hotelsToSeed.Select(h => new Hotel
                {
                    Id = h.Id,
                    Name = h.Name,
                    Rating = h.Rating
                })
            );

            builder.Entity<Hotel>().OwnsOne(
                h => h.Address,
                addressBuilder =>
                {
                    addressBuilder.HasData(
                        hotelsToSeed.Select(h => new
                        {
                            HotelId = h.Id,
                            Country = h.Address!.Country,
                            City = h.Address.City,
                            Street = h.Address.Street,
                            PostalCode = h.Address.PostalCode
                        })
                    );
                });

        }
    }
}