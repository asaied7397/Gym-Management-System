Gym Management System

A Gym Management System built using C#, .NET 10, Entity Framework Core, SQL Server, and ASP.NET Core MVC.

The project is designed to manage gym members, trainers, membership plans, subscriptions, and training sessions using a structured, maintainable architecture.

Project Status: In Development
Current Phase: Data Access Layer and Database Setup
Next Phase: ASP.NET Core MVC Application

⸻

Technologies

Technology Purpose
C# Application development
.NET 10 Application framework
ASP.NET Core MVC Web application (planned)
Entity Framework Core 10 Object-Relational Mapping
SQL Server Relational database
Fluent API Entity and relationship configuration
LINQ Database querying
Git & GitHub Version control

⸻

Project Structure

Gym-Management-System/
│
├── GymManagementSystem.slnx
│
├── GymManagementSystem.Data/
│ │
│ ├── Entities/
│ │ ├── BaseEntity.cs
│ │ ├── GymUser.cs
│ │ ├── Member.cs
│ │ ├── Trainer.cs
│ │ ├── Plan.cs
│ │ ├── Session.cs
│ │ └── Membership.cs
│ │
│ ├── Enums/
│ │ ├── Gender.cs
│ │ └── Specialties.cs
│ │
│ ├── ComplexTypes/
│ │ └── Address.cs
│ │
│ ├── Configurations/
│ │ ├── GymUserConfiguration.cs
│ │ ├── MemberConfiguration.cs
│ │ ├── TrainerConfiguration.cs
│ │ ├── PlanConfiguration.cs
│ │ ├── SessionConfiguration.cs
│ │ └── MembershipConfiguration.cs
│ │
│ ├── Context/
│ │ ├── GymDbContext.cs
│ │ └── GymDbContextFactory.cs
│ │
│ ├── Migrations/
│ │
│ └── GymManagementSystem.Data.csproj
│
├── .gitignore
└── README.md

⸻

Database Entities

Member

Represents a registered gym member.

Properties:

- Id
- Name
- Email
- Phone
- DateOfBirth
- Gender
- Address
- Photo
- CreatedAt (mapped to JoinDate)
- UpdatedAt

A member can have multiple memberships.

Trainer

Represents a gym trainer responsible for training sessions.

Properties:

- Id
- Name
- Email
- Phone
- DateOfBirth
- Gender
- Address
- HireDate
- Specialties

A trainer can manage multiple training sessions.

Plan

Represents a membership plan offered by the gym.

Properties:

- Id
- Name
- Description
- DurationDays
- Price
- IsActive

Plan duration must be between 1 and 365 days.

Membership

Represents a member’s subscription to a specific plan.

Properties:

- Id
- MemberId
- PlanId
- StartDate
- EndDate
- Status (computed)
- IsActive (computed)

Membership IDs are generated using a SQL Server sequence.

Members can subscribe to the same plan multiple times.

Session

Represents a training session managed by a trainer.

Properties:

- Id
- Description
- Capacity
- StartDate
- EndDate
- TrainerId

Session capacity must be between 1 and 25 participants.

⸻

Database Relationships

The system uses the following relationships:

Relationship Type Delete Behavior
Member → Membership One-to-Many Cascade
Plan → Membership One-to-Many Restrict
Trainer → Session One-to-Many Cascade

Membership acts as an explicit junction entity between Members and Plans.

⸻

Entity Framework Core Features

The project demonstrates several EF Core concepts:

Code-First Approach

Database tables and relationships are generated from C# entities and Fluent API configurations.

Fluent API

Entity configurations are organized into separate classes using:

IEntityTypeConfiguration<TEntity>

Inheritance Mapping

The system uses Table Per Concrete Type (TPC) inheritance mapping for Member and Trainer entities.

Complex Types

The Address object is configured as an EF Core complex type.

Its properties are stored within the owning entity’s table.

Database Constraints

SQL Server check constraints enforce:

- Valid email structure.
- Egyptian mobile phone number format.
- Membership plan duration limits.
- Training session capacity limits.
- Valid session start and end dates.

Unique Indexes

Unique email indexes are configured for the Member and Trainer tables individually.

SQL Sequences

Membership primary keys are generated using:

dbo.MembershipSequence

Migrations

EF Core migrations are used to create and maintain the database schema.

⸻

Getting Started

Prerequisites

Before running the project, ensure you have:

- .NET SDK 10
- SQL Server
- EF Core CLI Tools
- Git

1. Clone the Repository

git clone https://github.com/YOUR_USERNAME/Gym-Management-System.git
cd Gym-Management-System

Replace YOUR_USERNAME with your GitHub username.

2. Restore Dependencies

dotnet restore

3. Configure the Database Connection

Set the following environment variable:

export GYM_DB_CONNECTION='Server=localhost,1433;Database=GymManagementDB;User Id=sa;Password=YOUR_PASSWORD;Encrypt=True;TrustServerCertificate=True;'

Replace the server details and password with your SQL Server configuration.

Security: Never commit database passwords or connection strings containing credentials to GitHub.

The certificate trust setting shown above is intended for local development only.

4. Apply Database Migrations

dotnet ef database update \
 --project GymManagementSystem.Data \
 --context GymDbContext

This command creates or updates the database schema.

5. Build the Solution

dotnet build

The current solution contains the Data Access Layer. The MVC application will be added in a later development phase.

⸻

Development Progress

Completed

- Solution and Class Library setup
- Entity modeling
- Inheritance implementation
- Enum definitions
- Complex type configuration
- Fluent API configurations
- Entity relationships
- Database check constraints
- Unique indexes
- SQL sequence configuration
- DbContext implementation
- Initial EF Core migration
- Database creation

Planned

- ASP.NET Core MVC project
- Dependency injection configuration
- Member management (CRUD)
- Trainer management (CRUD)
- Membership plan management
- Membership registration and renewal
- Training session management
- Server-side validation
- User interface implementation
- Testing and final improvements

⸻

Architecture

The project is being developed with separation of concerns in mind.

Data Access Layer

Responsible for:

- Entity definitions
- Database mappings
- Relationships
- Database context
- Schema migrations

Presentation Layer (Planned)

The ASP.NET Core MVC application will provide the user interface and handle HTTP requests.

Additional application services may be introduced as the project develops.

⸻

Author

Developed as a practical project to apply C#, Object-Oriented Programming, Entity Framework Core, SQL Server, and ASP.NET Core MVC concepts.

⸻

License

This project is intended for educational purposes. No open-source license has been assigned.
