<div align="center">
   <h1>FilmX</h1>
</div>

A dynamic movie application which provides information about various movies. It includes full CRUD features, enabling users to add and edit movies, actors, and producers.

## Features

- Comprehensive movie representation with all associated parameters.
- Full CRUD functionality for managing movies.
- Utilizes stored procedures in SQL Server for efficient data handling.
- Production-grade backend application built with .NET.


## Tech Stack

**Client:** Vue.Js, Vuex, Vue Router, Vuetify.

**Server:** ASP.NET, Dapper, MS-SQL.


## Installation & Setup

Install .NET 5.0 and Visual Studio. Open `Backend/Backend.csproj` and run the server.

Install frontend dependencies.

```bash
  cd Frontend
  npm install
```

After installation, open `Data.sql` file from Database folder and run the SQL-Server scripts. Maksure to have SQL-Server installed before running the scripts.

Now time to run frontend server.

```bash
  cd Frontend
  npm run serve
```

## Screenshots

*Home Page*
<img alt="Logo" src="https://github.com/adarsh-VA/FilmX/blob/main/Screenshots/homePage.jpg" />

*Add Movie*
<img alt="Logo" src="https://github.com/adarsh-VA/FilmX/blob/main/Screenshots/addMovie.png" />

*Add Producer*
<img alt="Logo" src="https://github.com/adarsh-VA/FilmX/blob/main/Screenshots/addProducer.png" />

*Edit Movie*
<img alt="Logo" src="https://github.com/adarsh-VA/FilmX/blob/main/Screenshots/editMovie.png" />

## My Portfolio
Check out my full-stack projects at [adarshvodnala.vercel.app](https://adarshvodnala.vercel.app)

