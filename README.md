# CustomSearchEngine

This is a sample application implemented usind React for front-end, .net Core for back-end and Docker as container. To run this application, you need to follow the instructions below:

 - Check out the source code
 - Go to the root directory of the application
 - Run `docker-compose build`
 - Run `docker-compose up`
 
The Swagger for WebApi is configured on port 8090, so you can open it using http://localhost:8090/swagger. It includes one simple endpoints to get the search results. The react application is also accessible using http://localhost:3001. You need to enter the query and the link to search to be able to send the request.
The project includes some unit tests for back-end part, and some tests for the reducer on front-end. To make the application robust, we can add more front-end and back-end tests to the applications.
To increase the performance, the application sends the search requests in parallel. We can improve it even more if we implement object pools for WebClient objects (Which is a good improvement if we want the application to handle a huge amount of requests). The results get cached based on the engine, query and the link for a default value of one hour.
Currently, the application supports only one search engine (*Google*). The solution for processing the response from Google might not be the best possible solution, and it would be more accurate if we could use search APIs. To support other search engines like *Bing*, we only need to implement an instance of ISearchEngineHandler for it, then as front-end passes the request and the `Bing Handler` will process the request.
To add more parameters to the search result, we need to modify `SearchResultItem` class and add the new properties.
