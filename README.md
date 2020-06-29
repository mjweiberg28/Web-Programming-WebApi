# Web-Programming-WebApi
Assignment 4 for Bethel University Fall 2019's Web Programming course

In this project, I have a server hosted by Azure that tracks a list
of favorite characters from Star Wars. The server does not persist any data,
but supports the endpoints:
- GET
   Returns a JSON array of all the favorite chawracters currently stored in the server.
- GET/{index}
   - Returns a JSON object containing the favorite character and name data for the specified index (also validating that it is a valid index).
- POST
   - Accepts JSON data for FirstName, LastName, and Character and saves it on the server.
   - Validates that FirstName and Character are sent in the JSON and have length of at least 1 using entity annotations.
   - Returns the created data.
- GET/{index}/views
   - Returns a list of views for a favorite character stored on the server (simple list of strings).
- POST/{index}/views
   - Accepts JSON data for a view date (as a string). It only has a single key/value pair, "ViewDate."
   - Validate that ViewDate is sent in the JSON and has a length of at least 1 using entity annotations.
   - Return the created data.
