# to-do-list
Simple DDD example based on ASP.NET Core + React.

The Application has two Bounded Context:
 - Issue. This BC is responsible for task creation and has many DDD patterns;
 - Security. This BC is responsible for authorization and it's a classic 3-layer arcitecture.
 
 

## List of technologies:
 - ASP.NET Core
 - Automapper
 - Autofac
 - Fluent Validation
 - React + Redux
 - Material UI
 
## To Run App:
 1) open cmd
 2) cd src/ToDoList.ReactClient
 3) npm install
 4) npm run build
 4) open solution using Visual Studio
 5) set ToDoList.Web as startup project
 7) run (f5)
 6) open http://localhost:9090/
