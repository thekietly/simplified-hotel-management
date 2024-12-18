# Simplified Hotel Management
 This project folder contains only .NET Web API where I focus solely on delivering RESTful APIs. A React project will be created to consume the APIs from .NET Web API project in order to separate .NET MVC into front-end (React.js) and back-end (.NET Web API).
 In summary, different users will be able to use different components of this website: 
 1. __Website admin__ will be able to use the CMS where you modify/delete hotels/rooms/amenities/reviews.
 2. __Anonymous users__ will be able to view a list of hotels and rooms with their associated average price per night.
 3. __Registered users__ will be able to make bookings.
 4. __Hotel admin__ will be able to update their hotel/rooms details.

# Tools
Ultilise .NET v8, Boostrap v5.3 and SQL Server Management Studio v20

# Design tools
SQL Server Management Studio Database Diagram, Class diagram (Umlet) and User case diagram (Umlet)

# Tasks management
Trello board (kanban board).

# Methodologies and software designs
Layered Architecture, Restful APIs, DTO with AutoMapper, Repository patterns and Identity.

# Goals
Mimicking the features of booking.com and deploy it as a general website (including CMS).

# Features
6 core components will be Booking, Registration, Hotel, Room, Review and Amenity.
 1. __Website admin__
     - Have access to CMS where you modify/delete hotels/rooms/amenities/reviews.
     - Admin dashboard -> provides website insights such as hotel retris, revenue, users, etc
 4. __Anonymous users__
     - will be able to view a list of hotels and rooms with their associated average price per night.
 6. __Registered users__
     - Same as anonymous users
     - will also be able to make bookings.       
 8. __Hotel admin__
     - Have acess to CMS where you update your hotel/rooms details.
     - You will have a similar report insights however, you can only see your user bookings, revenue and reviews.
       
# Approach
I will try to implement the website first then design everything along the way so I don't fall into a state where I design everything but hadn't got anything completed.

# Current progress:
## Completed
CMS: Completed Hotels / Hotel rooms / Amenity

## In progress
Booking CRUD
Hotel/Room Image Gallery

## Future plans/remaning features: 
- __Users Identity__ (Anonymous, Registered, Admin, Hotel Admin)
- Reviews for Registered Users
- Provide __reports insights__ to website admin and hotel admin
- Focucs on website designs - re-design Hotels, Rooms, Amenities, Bookings
- Promotion/ Special offers system, meaning that this will affect each booking final price

  

