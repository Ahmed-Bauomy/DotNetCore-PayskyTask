# DotNetCore-Employment System
Employment System is a basic project that provide CURD operations for Vacancies.
There are two user types (Employer and Applicant).
- System have below shared functions:
   - Self-registration for both user types.
   - Login.
- Each user role have specific functions.
- Employer user:
  - CRUD functions for vacancies.
  - Vacancy should have max number of allowed applications.
  - Post and deactivate vacancy.
  - Vacancies should have an expiry date.
- Applicant user:
  - Apply for vacancy. 

## Technologies
I used .Net Core 6 with microsoft sql server database and web API as a backend
also used Angular as a frontend interface

## Archtictures
I used Clean architecture with CQRS
I also used these packages Mediator, FluentValidation, AutoMapper.

## Contributing

Pull requests are welcome. For major changes, please open an issue first
to discuss what you would like to change.

Please make sure to update tests as appropriate.
