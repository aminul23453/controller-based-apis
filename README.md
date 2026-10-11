# Controller-Based APIs (ASP.NET Core)

Assignment: Controller-based APIs, following the Microsoft Learn tutorial
[Create a controller-based web API with ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-web-api).

The solution contains two projects (.NET 9, Visual Studio):

| Project | Tutorial section | Description |
|---|---|---|
| `PetApi` | Create a controller-based web API, and Web API with JavaScript | CRUD API for pets, using Entity Framework Core with an in-memory database, plus a JavaScript page that calls it |
| `MovieStoreApi` | Create a Web API with MongoDB | CRUD API for movies, stored in MongoDB |

I used pets and movies instead of the tutorial's to-do items and books.

## Requirements

- .NET 9 SDK
- Visual Studio with the **ASP.NET and web development** workload
- MongoDB Community Server (running locally on port 27017), only for `MovieStoreApi`

## PetApi

Features:
- `PetsController` with GET (all and by id), POST, PUT and DELETE
- `PetDTO` hides the `Secret` field of the `Pet` model (prevents over-posting)
- JavaScript front-end in `wwwroot` (`index.html` and `js/site.js`) using `fetch`

Endpoints:

| Method | URL | Description |
|---|---|---|
| GET | `/api/pets` | Get all pets |
| GET | `/api/pets/{id}` | Get a pet by id |
| POST | `/api/pets` | Add a pet |
| PUT | `/api/pets/{id}` | Update a pet |
| DELETE | `/api/pets/{id}` | Delete a pet |

How to run:
1. Right-click `PetApi` and choose **Set as Startup Project**.
2. Press `Ctrl+F5`.
3. Open `https://localhost:<port>/` for the web page, or use `PetApi/PetApi.http` to test the API.

The data is stored in memory, so it is lost when the app stops.

## MovieStoreApi

Features:
- `MoviesController` with GET (all and by id), POST, PUT and DELETE
- `MoviesService` uses the official `MongoDB.Driver`
- Connection settings in `appsettings.json` (`MovieStoreDatabase` section)

Endpoints:

| Method | URL | Description |
|---|---|---|
| GET | `/api/movies` | Get all movies |
| GET | `/api/movies/{id}` | Get a movie by id (24-character ObjectId) |
| POST | `/api/movies` | Add a movie |
| PUT | `/api/movies/{id}` | Update a movie |
| DELETE | `/api/movies/{id}` | Delete a movie |

How to run:
1. Start the MongoDB service.
2. Create the database and sample data in `mongosh`:
```js
   use MovieStore
   db.createCollection('Movies')
   db.Movies.insertMany([
     { "Title": "Inception", "Price": 12.99, "Genre": "Sci-Fi", "Director": "Christopher Nolan" },
     { "Title": "The Matrix", "Price": 9.99, "Genre": "Sci-Fi", "Director": "Lana Wachowski" }
   ])
```
3. Right-click `MovieStoreApi` and choose **Set as Startup Project**.
4. Press `Ctrl+F5`.
5. Use `MovieStoreApi/MovieStoreApi.http` to test the API.

## Author

aminul23453