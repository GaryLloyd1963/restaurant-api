# restaurant-api
Demo restaurant management - WORK IN PROGRESS FOLKS!

# Design
## Component diagram (target)

<img src="https://github.com/GaryLloyd1963/restaurant-api/blob/main/images/ComponentDiagram.JPG" width="600">

## Domain model (target)

<img src="https://github.com/GaryLloyd1963/restaurant-api/blob/main/images/DomainModel.JPG" width="600">

# Tech stack
C# .NET 9.0
SQLite

# API Installation
Clone repository and build. When run the application, it will create a SQLite database file in the root directory,
and will be accessible on http://localhost:5252

# Endpoints
- GET /api/v1/restaurants

# Things to think about
1. Tests - this has not been a TDD exercise and will need a test project
2. Should the repository be a SQLite dedicated class?
3. DTO on output - the endpoint responses should have a DTO class to avoid direct return of data
