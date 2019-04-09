

# About
A simple sp.Net Core 2.0 Demo Web Application.

The page gets Live news headlines from the selected News Website and displays
(currently) 12 of them in no particualr order as a D3 tree diagram.  You can click on 
the root node and observe the nodes retract/expand.

The typescript and transpiled javaScript files are in : News/News/wwwroot/ts/

# Next Phase
In the next iteration(s)

1. Each website can be extracted for headlines by Category (e.g. Politics, Sports etc)
   where each category node will feature its own headlines.
   
2. For each url/news category in extract the Healdine hyperlink, Author, Published date and extracted date.

3. Each extracted headline, introduce can be given a computed numerical values / 'weights' derived from factors such as      Freshness/staleness of the headline, site ranking etc


# Main Dependencies 
- Jquery
- D3 library (3.4.5 )
- Html Agility Pack (1.11.2)

# Live Deployment
http://justheadlines.azurewebsites.net/

# Author
SEIFU TOLOSA aka 0surface
