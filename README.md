# Tunify-Platform

## Description
Tunify Platform is a music streaming service that allows users to create and manage playlists, listen to songs, and follow their favorite artists. The platform supports different subscription plans, including free and premium tiers.

## ERD Diagram
![Tunify ERD Diagram](Tunify.png)

## Entity Relationships Overview
The Tunify Platform consists of several entities that are related to each other in various ways. Below is an overview of these relationships:

1. **User**
   - A user can have one subscription.
   - A user can create multiple playlists.

2. **Subscription**
   - A subscription can be associated with multiple users.

3. **Playlist**
   - A playlist belongs to one user.
   - A playlist can contain multiple songs through the `PlaylistSongs` join table.

4. **PlaylistSongs**
   - This is a join table that establishes a many-to-many relationship between playlists and songs.
   - Each entry in `PlaylistSongs` references one playlist and one song.

5. **Song**
   - A song belongs to one album.
   - A song is performed by one artist.
   - A song can be part of multiple playlists through the `PlaylistSongs` join table.

6. **Album**
   - An album is created by one artist.
   - An album can contain multiple songs.

7. **Artist**
   - An artist can create multiple albums.
   - An artist can perform multiple songs.

## Navigation and Routing Functionalities
The Tunify Platform includes new navigation and routing functionalities to enhance user experience. These functionalities allow users to easily navigate through different sections of the platform, such as viewing playlists, songs, and artists. The routing system ensures that users can access specific resources directly via URLs, making the platform more intuitive and user-friendly.

### Example Routes:
- **Playlists**: `/api/Playlists/{playlistId}/Songs/{songId}` - Add a song to a playlist.
- **Artists**: `/api/Artists/{artistId}/songs/{songId}` - Add a song to an artist.

## Repository Design Pattern
The Tunify Platform utilizes the Repository Design Pattern to manage data access. This pattern provides a way to encapsulate the logic required to access data sources, making the code more modular and easier to maintain.

### Benefits:
- **Separation of Concerns**: The data access logic is separated from the business logic, making the codebase cleaner and more organized.
- **Testability**: Repositories can be easily mocked, which simplifies unit testing.
- **Flexibility**: Changes to the data access logic (e.g., switching from one database to another) can be made with minimal impact on the rest of the application.
- **Reusability**: Common data access logic can be reused across different parts of the application.

## Example Data Seeding
The platform seeds initial data for all entities to ensure that the database is populated with some default entries. This includes users, subscriptions, artists, albums, songs, playlists, and the relationships between them.

## Getting Started
To get started with the Tunify Platform, follow these steps:

1. Clone the repository.
2. Set up the database connection string in the `appsettings.json` file.
3. Run the migrations to create and seed the database:
   dotnet ef migrations add InitialCreate dotnet ef database update
4. Build and run the application:
   dotnet run


## Technologies Used
- .NET 7
- Entity Framework Core
- SQL Server

## License
This project is licensed under the MIT License.
