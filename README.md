# Resurant Reservation System (API)
![Build Status](https://travis-ci.org/joemccann/dillinger.svg?branch=master)

This is the API part of the system. To chech the front-end part, please check this [repository](https://github.com/RamiB1234/resturant-front)

## Live Demo

To test the app, please click on this [link](https://ramib1234.github.io/my-reads/)
Please note that the backend API is hosted in Azure as a service

## Features

- Entitiy Framework with Code-first approach
- A repository pattern with dependency injection approach
- A public endpoint for registration (POST)
- A public endpoint for logging in (POST)
- A secured endpoint to make a reservation (POST)
- A secured endpoint to fetch user reservations (GET)
- JWT Authentication
- Server side validation (i.e, prevent email duplications, reservation date in the future

## Installation

* Clone the repository
* Open the project with VS 2017 or later
* Run the app once to create an empty localDB by pressing `F5`
* Run the following CLI command at the root that contains Startup.cs file `dotnet ef database update`
* The API should now be ready to listen for requests

## Technology Used

This application was developed using **ASP.NET Core 2.1 MVC** framework

## License
The project is released under [MIT](https://github.com/RamiB1234/ResturantAPI/blob/master/LICENSE) License


