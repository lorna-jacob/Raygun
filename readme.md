# README #

This is an ASP.NET MVC5 application that integrates Trello authentication and allows user to do basic tasks such as view boards, cards, and adding comments using Trello APIs.

I used the AuthorizeRoute from Trello Api to get authorize user and get the auth token. The token is then saved in the user session (instead of database).
The default timeout for the session is 5mins; so after that period of inactivity, the user needs to login again with Trello.
I didn't create Logout mechanism anymore. You may change the timeout session in web.config by changing the timeout value of sessionState node.
	<sessionState timeout="5"></sessionState>  	

Patterns:
I used Unit of Work and Repository Pattern to abstract all the HttpClient calls to Trello APIs from my controllers.
The UnitOfWork class ensures only one instance of TrelloRepository is alive.
The TrelloRepository provides the async calls to Trello WebApis, and makes use of a single abstract HttpClient instance. 
Every async method returns the deserialized JSON in form of the domain models.
I also used Dependency Injection (Ninject nuget) for contructor injection of ITrelloRepository in my Controllers.

Unit Test:
I haven't had enough time and knowledge as of writing for testing async APIs, so I wasn't able to include a decent unit test.

### How do I get set up? ###

Simply get the source from this repository, open the solution in Visual Studio (I used VS2015 for development) and hit Run to start the application.
