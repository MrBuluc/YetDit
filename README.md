# YetDit

This is a Reddit API for YetGen. Once registered, YetGeners can share new posts and receive comments from other users. Upvotes can be given to both posts and comments. The API is designed to be a Reddit forum that we believe YetGenians will enjoy. 

## Features

- ### The Repository Pattern
    The Repository Pattern has been implemented to restrict access to the database. Database operations can be performed using specified methods to ensure database security. 
- ### Identity Mechanism
    The user management system includes common fields such as email and username, as well as methods for registering and logging in that are applicable to all users. The Identity Mechanism simplifies development and offers additional features.

## Features Details
- ### The Repository Pattern
    One such feature is the Repository Pattern, which involves creating an IRepository class in the Core layer of the Application project. This class is inherited by IReadRepository and IWriteRepository. We developed the read and write interfaces for the entities and implemented these interfaces as classes in the Persistence project of the Infrastructure layer. To avoid code repetition, we collected the read and write classes for each entity in the ReadRepository and WriteRepository. Finally, we utilized them in the API project within the Presentation layer.
- ### Identity Mechanism
    To establish an identity mechanism, we first added the Microsoft.Extensions.Identity.Stores package to the Domain project in the Core layer. Next, we defined the Role and User classes for Identity. Then, we added the Microsoft.AspNetCore.Identity.EntityFrameworkCore package to the Persistence project in the Infrastructure layer. Finally, we specified the constraints of the fields in the User class. In the Persistence project of the Infrastructure layer, we utilized the AuthService to perform login and login renewal operations via AppUserCommands. The UserService was used to retrieve the logged-in user's ID in Commands. Additionally, we verified the user's login status and account validity in the required Actions. Finally, we included the Identity Service in Program.cs.

## Task Breakdown
- ### [Hakkıcan Bülüç](https://github.com/MrBuluc)
    RepositoryPattern, Entities, Controllers, Request and Response models, AuthService
- ### [Celal Karahan](https://github.com/k-celal)
    - Controllers:
        - Contributed to the implementation of the Controllers in the project.
    - Infrastructure Layer:
        - Participated in setting up the persistence layer in the Infrastructure, focusing on database connection processes.
- ### [Tarık Emir Kaldırım](https://github.com/tarikemir)
    - Comments/Post Controllers, Queries, Authentication
