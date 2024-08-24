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

## Swagger UI
The Tunify Platform includes Swagger UI for API documentation and testing. Swagger UI provides a visual interface to interact with the API endpoints, making it easier for developers to understand and test the API.

### Accessing Swagger UI
1. Run the application using the following command: ```dotnet run```
2. Open a web browser and navigate to `http://localhost:5000/api/v1/swagger.json` to view the Swagger JSON document.
3. To access the Swagger UI, navigate to `http://localhost:5000/swagger` in your web browser.

### Using Swagger UI
- **Explore Endpoints**: The Swagger UI lists all available API endpoints. You can expand each endpoint to see details such as request parameters and response formats.
- **Try it Out**: You can test API endpoints directly from the Swagger UI by clicking the "Try it out" button, filling in the required parameters, and executing the request.
- **View Responses**: After executing a request, the Swagger UI displays the response, including status codes and response bodies.

## Identity Setup
The Tunify Platform uses ASP.NET Core Identity for user authentication and authorization. This setup allows users to register, log in, and log out securely.

### Registration
To register a new user, send a POST request to the `/api/Account/register` endpoint with the following JSON payload:
```JSON
{
  "username": "your_username",
  "password": "your_password",
  "email": "your_email@example.com"
}
```

### Login
To log in, send a POST request to the `/api/Account/login` endpoint with the following JSON payload:
```JSON
{
  "username": "your_username",
  "password": "your_password"
}
```

### Logout
To log out, send a POST request to the `/api/Account/logout` endpoint. No payload is required for this request.

## Getting Started
To get started with the Tunify Platform, follow these steps:

1. Clone the repository.
2. Set up the database connection string in the `appsettings.json` file.
3. Run the migrations to create and seed the database:
   ```dotnet ef migrations add InitialCreate``` ``` dotnet ef database update```
4. Build and run the application:
   ```dotnet run```


## Technologies Used
- .NET 7
- Entity Framework Core
- SQL Server

## License
This project is licensed under the MIT License.
