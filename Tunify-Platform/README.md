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
