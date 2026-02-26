# 🏨 RoomBooker

A hotel room reservation management web application built with **ASP.NET Core MVC** and **.NET 10**.

---

## 🚀 Tech Stack

| Layer      | Technology                  |
|------------|-----------------------------|
| Framework  | ASP.NET Core MVC (.NET 10)  |
| ORM        | Entity Framework Core       |
| Database   | PostgreSQL (via Npgsql)     |
| Frontend   | Razor Views + Bootstrap 5   |

---

## ✨ Features

- **Customers** — Create, view, edit and delete hotel customers
- **Rooms** — Manage room catalog with type and price per night
- **Bookings** — Reserve rooms for customers with check-in/check-out dates
- **Booking Details** — Automatic calculation of stay duration and total cost
- Anti-forgery token protection on all forms (CSRF prevention)
- Relational data with EF Core navigation properties

---

## 🗂️ Data Model

```
ERD Diagram
    Customer {
        int Id PK
        string Name
        string Email
        string Phone
    }
    Room {
        int ID PK
        string RoomNumber
        string Type
        decimal PricePerNight
    }
    Booking {
        int Id PK
        DateOnly DateFrom
        DateOnly DateTo
        int CustomerId FK
        int RoomId FK
    }

    Customer OneToMany Booking
    Room OneToMany Booking
```

---

## ⚙️ Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)

### Setup

1. **Clone the repository**
```sh
   git clone https://github.com/Mi1y/RoomBooker.git
   cd RoomBooker
```

2. **Configure the database connection** in `appsettings.json`:
```json
   "ConnectionStrings": {
     "DefaultConnection": "Host=localhost;Port=5432;Database=RoomBookerDB;Username=postgres;Password=YOUR_PASSWORD"
   }
```

3. **Apply migrations**
```sh
   dotnet ef database update
```

4. **Run the application**
```sh
   dotnet run
```

The app will be available at `https://localhost:7186` or `http://localhost:5111`

---

## 📁 Project Structure

```
RoomBooker/
├── Controllers/        # MVC Controllers (Customers, Rooms, Bookings)
├── Models/             # Entity models (Customer, Room, Booking)
├── Data/               # AppDbContext (EF Core)
├── Views/              # Razor Views per controller
│   ├── Customers/
│   ├── Rooms/
│   ├── Bookings/
│   └── Shared/
└── Program.cs          # App entry point & service configuration
```

---

## 📌 Notes

This project was built as a **first hands-on project** with the .NET framework, focusing on:
- MVC architecture pattern
- Entity Framework Core with PostgreSQL
- Razor view engine and form handling
- Model validation and CSRF protection
- Relational data modeling with navigation properties
