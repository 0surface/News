

# About
A simple Asp.Net Core 2.0 Demo Web Application.

The page gets Live news headlines from the selected News Website and displays
(currently) 12 of them in no particualr order as a D3 tree diagram.  You can click on 
the root node and observe the nodes retract/expand.

The typescript and transpiled javaScript files are in : News/News/wwwroot/ts/

# Live Deployment
http://justheadlines.azurewebsites.net/

# Main Dependencies 
- Jquery, Bootstrap
- D3 library (3.4.5 )
- Html Agility Pack (1.11.2)

# Author
SEIFU TOLOSA aka 0surface

# Next Phase
In the next iteration(s)

1. Each website can be extracted for headlines by Category (e.g. Politics, Sports etc)
   where each category node will feature its own headlines.
   
2. For each url/news category in extract the Healdine hyperlink, Author, Published date and extracted date.

3. Each extracted headline, introduce can be given a computed numerical values / 'weights' derived from factors such as      Freshness/staleness of the headline, site ranking etc

4. Create an API

5. Refactor and develop the utility methods as nuget packages

6. Refactor the Scraping service as an independent microservice (e.g. Azure Function) that responds to API requests

7. Add Logging and monitoring

8. Add Users, Authentication and Authorisation (LogIn, Sign up, 2FA)
