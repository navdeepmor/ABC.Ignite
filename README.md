# ABC Ignite

ABC Ignite is a .NET project that provides APIs for managing classes and bookings. It features a DatabaseContext and CacheService implemented for in-memory operations, enabling quick testing and experimentation with class creation, booking management, and filtering without relying on an external database or cache system.

---

## Features

### Bookings API
The `BookingsController` manages API endpoints for handling bookings.

- **Create a Booking** (`POST /api/bookings`):
  - Create a new booking for a class.
  - Returns the created booking details with a `201 Created` status.
- **Get Bookings** (`GET /api/bookings`):
  - Retrieve a list of bookings with optional filters:
    - `SearchTerm`: Filter by search string.
    - `StartDate` & `EndDate`: Filter by date range.

### Classes API
The `ClassesController` provides API endpoints for managing classes.

- **Create a Class** (`POST /api/classes`):
  - Add a new class with details like title, description, start time, and duration.
  - Returns the created class details with a `201 Created` status.

- **In-Memory DatabaseContext**: A dummy `DatabaseContext` for testing and experimentation purposes.
- **In-Memory Cache Service**: A simple cache service for caching data during runtime.

---

## Prerequisites

Before setting up the project, ensure you have the following installed:

1. **.NET SDK**: Version 6.0 or later. You can download it from [here](https://dotnet.microsoft.com/download).
2. **IDE**: Visual Studio 2022, Visual Studio Code, or any other editor of your choice.
3. **Git**: Version control system. Install it from [here](https://git-scm.com/).

---

## Setup Instructions

Follow these steps to set up and run the project locally:

### 1. Clone the Repository
```bash
git clone https://github.com/navdeepmor/ABC.Ignite.git
cd ABC.Ignite
