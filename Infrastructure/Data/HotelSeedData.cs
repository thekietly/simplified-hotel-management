using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Data
{
    public static class HotelSeedData
    {
        public static IEnumerable<Hotel> GetHotels(IEnumerable<IdentityUser> hotelAdmins) 
        {
            var hotelAdminArray = hotelAdmins.ToArray();
            return new List<Hotel> {
                new Hotel
                {
                    Id = 1,
                    Name = "Best Arena Hotel",
                    Address = "1234, 5th Avenue, Adelaide",
                    Description = "Nestled in the heart of the city, the Best Arena Hotel is a luxurious haven that combines elegance, comfort, and exceptional service. Whether you're visiting for business, leisure, or a special occasion, our hotel offers an ideal location and a wide range of amenities to ensure your stay is both memorable and relaxing.\r\n\r\nThe hotel features modern, spacious rooms designed with a blend of contemporary style and classic comfort. Each room is equipped with state-of-the-art facilities, including plush bedding, a flat-screen TV, high-speed Wi-Fi, and a fully stocked minibar. Our spacious suites offer even more comfort, with separate living areas, large windows with breathtaking views, and luxury bath products that guarantee a relaxing experience after a day of exploring or working.\r\n\r\nGuests can enjoy a variety of dining options at our on-site restaurant, which offers a diverse menu featuring both local and international cuisine. Whether you're looking for a hearty breakfast, a quick snack, or an elegant dinner, the culinary team at Best Arena Hotel ensures that every meal is a delightful experience. For those who prefer dining in privacy, room service is available 24/7.\r\n\r\nThe hotel boasts an array of amenities to cater to the needs of every guest. Our fully equipped fitness center allows you to maintain your workout routine while traveling, while our spa offers a range of treatments designed to rejuvenate and relax. Take a dip in our outdoor pool or unwind in the sauna for a complete wellness experience.\r\n\r\nFor business travelers, the Best Arena Hotel offers comprehensive meeting and event facilities. Our versatile meeting rooms are equipped with the latest technology, and our professional staff is always available to assist with event planning and coordination. Whether you're hosting a small seminar or a large conference, our hotel provides a seamless and efficient environment for all your business needs.\r\n\r\nThe Best Arena Hotel also offers a range of recreational activities to make your stay even more enjoyable. Explore the vibrant city center, located just a short walk from the hotel, or take a guided tour to discover local attractions. For those who prefer a more relaxed pace, our hotel is the perfect place to unwind and enjoy quality time with loved ones.\r\n\r\nWhether you're visiting for a short stay or an extended holiday, Best Arena Hotel promises to deliver a high standard of service, a peaceful ambiance, and an unforgettable experience. We look forward to welcoming you to our hotel, where exceptional comfort and personalized attention await.",
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Size = 200,
                    LastUpdated = DateTime.Now,
                    OwnerId = hotelAdminArray[0].Id
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Adelaide Oasis Hotel",
                    Address = "1234, 5th Avenue, Adelaide",
                    Description = "Situated in the vibrant heart of Adelaide, the Adelaide Oasis Hotel offers a peaceful retreat amidst the city’s bustling atmosphere. With its modern amenities, stylish design, and exceptional service, it’s the perfect place for both business and leisure travelers seeking comfort and convenience.\r\n\r\nThe hotel features elegantly designed rooms with a focus on comfort and relaxation. Each room is equipped with premium furnishings, high-speed internet, flat-screen TVs, and minibars to ensure a comfortable stay. Whether you're staying for a few days or a longer visit, our rooms provide the perfect space to unwind after a busy day. The suites offer extra luxury, featuring expansive living areas, plush bedding, and spacious bathrooms designed with high-end finishes.\r\n\r\nDining at the Adelaide Oasis Hotel is an experience of its own. Our signature restaurant serves an extensive menu featuring fresh, locally sourced ingredients that highlight the best of Australian cuisine. From a hearty breakfast to a gourmet dinner, each dish is crafted to offer you a delightful culinary experience. For a more casual option, guests can enjoy drinks and snacks at our hotel’s lounge bar, offering a relaxing environment to socialize or unwind.\r\n\r\nFor guests seeking to stay active, the Adelaide Oasis Hotel offers a state-of-the-art fitness center with all the equipment needed to keep your exercise routine on track. After a workout, take a dip in our indoor pool or indulge in a rejuvenating spa treatment at our wellness center, designed to refresh and energize you.\r\n\r\nThe hotel also caters to business needs with fully equipped meeting rooms and event spaces. Our versatile facilities can accommodate small corporate meetings, large conferences, or private events. Our experienced event coordinators will assist you in creating a seamless experience for any gathering.\r\n\r\nJust a short walk from the hotel, you’ll find Adelaide’s cultural hubs, shopping precincts, and dining hotspots. Take time to explore the city’s top attractions, including the Adelaide Central Market, the Botanic Gardens, and the vibrant laneways filled with art, cafes, and boutiques. Whether you’re here for business or leisure, the Adelaide Oasis Hotel is perfectly positioned to help you experience all that this beautiful city has to offer.\r\n\r\nWith a focus on comfort, style, and service, Adelaide Oasis Hotel ensures that every stay is exceptional. We look forward to welcoming you to a memorable experience in the heart of Adelaide.",
                    ImageUrl = "https://images.pexels.com/photos/2957461/pexels-photo-2957461.jpeg?auto=compress&cs=tinysrgb&w=600&lazy=load",
                    Size = 200,
                    LastUpdated = DateTime.Now,
                    OwnerId = hotelAdminArray[1].Id
                }
            };
        
        }

    }
}
