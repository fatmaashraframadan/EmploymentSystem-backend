# Employment System

A prototype for a Employment system with basic implementation for SignUp/signIn users and CRUD operations for Vacations.

---

## Entities

- **Applicant**
- **Employer** 
- **Vacancy**
- **Application**

---

## Database

- **Microsoft SQL Server**: Relational database used for storing user data, vacancies and applications.

## Caching
- **Redis**

---

## Design Patterns Used

- **Mediator Pattern**: Used to reduce dependencies between objects by centralizing communication.
- **CQRS (Command Query Responsibility Segregation)**: Segregates reading and writing operations for better scalability.
- **Repository Pattern**: Abstracts the data access layer for easier maintenance and testing.

---

## Features

You can try out the following scenarios with this app:

- **Register (Employer & Applicant)**
- **Login (Employer & Applicant)**
- **Create Vacancy(Employer)**
- **Edit Vacancy**
- **Deactivate Vacancy**
- **Get All Vacancies**

---

## Postman Collection
- **[View Postman Documentation](https://documenter.getpostman.com/view/10825556/2sAYJ7gKBH)**: View API documentation for detailed requests and responses.
- **[Download Postman Collection](Employment-System.postman_collection.json)**: Download postman collection.

---

## Getting Started

1. **Clone the repository**:
   ```bash
   git clone https://github.com/fatmaashraframadan/EmploymentSystem-backend.git
2. Download .net 8.0
3. Download Ms sql server (using docker)
