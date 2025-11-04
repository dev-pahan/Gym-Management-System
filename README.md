# Gym Management System

Gym Management System is a Windows Forms application built with C# and .NET that provides basic gym management features: user authentication, trainers and members management, classes, attendance and billing. The application uses SQLite as its persistence layer and exposes grid-based forms for data input and editing. The GUI follows a minimalist design and includes robust error handling on both front-end (forms/validation) and back-end (controllers/DB operations).

## Table of Contents
- [Features](#features)
- [Tech Stack](#tech-stack)
- [Getting Started](#getting-started)
  - [Prerequisites](#prerequisites)
  - [Setup](#setup)
  - [Database](#database)
- [Usage](#usage)
- [Project Structure & Key Components](#project-structure--key-components)
- [Error Handling](#error-handling)
- [Contributing](#contributing)
- [Contributors & Highlights](#contributors--highlights)
- [License](#license)

## Features
- User registration and login (credentials checked against UsersTbl)
- Password hashing for stored credentials
- CRUD for Trainers (add, view, edit, delete)
- Member management (dashboards and navigation)
- Class management (TrainerClassesForm and related components)
- Attendance tracking
- Memberships and Billing tables
- Minimalist desktop GUI with grid-based forms for input and edit
- Front-end and back-end input validation and exception handling
- Pagination for lists where applicable

## Tech Stack
- Language: C#
- Framework: .NET (Windows Forms)
- Database: SQLite (gms.db)
- Development: Visual Studio (recommended) or compatible .NET IDE

## Getting Started

### Prerequisites
- Windows OS (Windows Forms target)
- .NET SDK / .NET Framework compatible with the project (open the .sln to see exact target)
- Visual Studio (recommended) or another C#/.NET IDE
- SQLite (or NuGet packages for System.Data.SQLite / Microsoft.Data.Sqlite)

### Setup
1. Clone the repository:
   git clone https://github.com/dev-pahan/Gym-Management-System.git

2. Open the solution (.sln) in Visual Studio.

3. Restore NuGet packages (Visual Studio should prompt to restore).

4. Ensure the SQLite DB file (gms.db) is present in the project or update the connection string to point to your copy.

5. Build the solution and run.

### Database
- The project uses an SQLite database file (gms.db). Expected tables (created during early commits) include:
  - Trainers
  - Members
  - Memberships
  - Billing
  - UsersTbl (for authentication)
  - Attendance
  - Classes / Sessions (TrainerClassesForm)
- If gms.db is included in the repository, confirm its location relative to the compiled binary and the connection string used by the app.

Configuration tip:
- Connection strings for SQLite are typically in a central class or configuration file. If relative path is used, confirm that gms.db is copied to the output folder or adjust the path.

## Usage
- Launch the application (Debug/Release mode from Visual Studio).
- Register a user (Registration form) or use existing credentials stored in UsersTbl.
- Login to reach the dashboard.
- Navigate to Trainers, Members, Classes, Attendance, Memberships and Billing dashboards using the app navigation.
- Use the provided grid forms to add/edit/delete rows. Selected row values populate input fields for editing (TrainersList behavior implemented).

## Project Structure & Key Components
- Forms for: Login, Register, Dashboard, TrainersList, Members dashboard, Memberships GUI, Attendance, TrainerClassesForm
- Controller classes for DB operations (ClassController, TrainerController, etc.)
- gms.db SQLite database file (used for persistence)
- Exception handling and validation utilities (present across multiple commits)

## Error Handling
- Front-end: Form validation for phone numbers, birth dates, addresses, required fields, null checks.
- Back-end: Refined exception handling in controllers, error handling for DB operations and class controllers.
- Typical fixes recorded: resolving null errors in attendance form, register form fixes, refined exception handling code.

## Contributing
- Fork the repo and create a feature branch per change.
- Follow naming for branches (e.g., feature/<name>, fix/<name>).
- Commit small, focused changes and open pull requests for review.
- Include tests or manual instructions for QA steps where applicable.
- Keep DB migrations or schema changes documented (or include SQL files) so teammates can reproduce local DB.

## Contributors & Highlights
This project has collaborative contributions from multiple authors. Below are contributors and notable contributions from the commit history:

- UmaimaFahim (26 commits)
  - Implemented authentication and registration flow
  - Added and refined error handling across registration, trainers (address/phone/DOB), and registration GUI
  - Implemented login checks against UsersTbl and password hashing on register/login
  - Fixed register GUI and resolved merge conflicts
  - Worked on fonts and dashboard error handling
  - Authored Merge PRs for Authentication and error-handling features

- dev-pahan (20 commits)
  - Base commit and repository maintainer tasks
  - Implemented trainers CRUD (add/view/edit/delete) and populated input fields from selected rows
  - Created database tables (Trainers, Members, Memberships, Billing)
  - Changed DB to SQLite and enabled DB connection
  - Implemented attendance GUI and related fixes
  - Added pagination and refactoring of forms and user management
  - Resolved various merge conflicts and added comments for clarity

- deluluu-me (10 commits)
  - Built multiple GUI screens: Members GUI, Trainers GUI, Login GUI, Memberships GUI
  - Added TrainerClassesForm and updated related components
  - Implemented exception handling for class controllers and refined fonts/renames
  - Contributed to adding classes GUI, functionality and SQL connections

Commit highlights/timeframe (selection):
- Dec 21, 2024: Major GUI screens added (Members, Trainers, Login, Memberships), DB tables created, trainers functionality implemented.
- Dec 30, 2024: DB changed to SQLite.
- Jan 2–31, 2025: Authentication, registration, login, and error handling improvements including password hashing.
- Feb 1–3, 2025: Finalizing error handling, register form fixes, merge conflict resolutions, attendance fixes.

(You can expand this section with full commit/PR links or a CHANGELOG if desired.)

## Troubleshooting
- If database connection fails: confirm gms.db path and check that the app has read/write permissions to the file location.
- If login fails: verify UsersTbl content and that password hashing algorithm matches both register and login paths.
- If UI elements are missing or fonts look wrong: confirm required assets are included and the correct font family is available.
- For null reference exceptions: check that the calling code verifies selection of rows and that forms initialize all expected fields.

## Tests
- There are no automated tests included in the repository by default. Add unit tests for controller/database logic and integration tests for critical flows (authentication, CRUD).
