# WebAPICqrs_SimpleInjector , is simple project for web API 2.0 with CQRS architecture with interdependent layers and seperate data bus
for Commands i.e. queries for write/update db and Queries i.e allow only to read db .
Command and Query pattern helps to prevent from database dirty reads and phantom reads.
We are having 3 layers :
1. Sample.Domain: Having entity framework with code first approach, it involves all Entities, Mappers & DbContext
2. Sample.Infrastructure: Having references for Sample.Domain, Having Seperate command bus and query bus and seperate handlers for each and evry command and queries.
                          It invloves Events also for Post Commit functions with API according to the expected result of your API.
                          Hadlers include business logic for your API.
3. Sample : Having references for Sample.Domain & Sample.Infrastructure and involves API Controllers and configuration for Swagger 
            and Simple Injector dependency injection for IOC.
            
Logic for Architecture : API Controller -> Command Bus and QueryBus (generic methods)
                         Command Bus & QueryBus -> (flow data) -> Command Handlers or query handlers (complete logic & return result) 
                         + 
                         Commands (for command handler) / Model (for query handler)
