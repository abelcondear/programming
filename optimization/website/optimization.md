## Optimization

At the moment, we need to optimize our web site, we should be aware of performing the following steps:

- Obfuscate JavaScript and CSS files in order to reduce the file size
- Use one image and make slices from that image using CSS in order to reduce the amount of requests
- Use CDN (Content Delivery Network) in order to have cached website resources
- Load only elements which user needs to see
- Load elements dynamically depending on scrolling movement or what the user needs to see
- Analyze the time execution of each server request. At this particular item, we need to take into account the following matters:

	- If we are trying to get a huge set of data at once then we need to take only the part that the user needs to consume or we need to paginate the data into several pages and showing that data by chunks
	- If we try to get a particular unique data and that action takes more than 0.5 seconds then we should tune the database query
Tuning a query:

	- Use only tables needed
	- Use primary and foreign keys to join field' tables
	- Use only fields needed
	- Use another similar data or field in case we need to read some specific data and we have to use many resources or objects from database
	- Use easy data types for reading like “int” data type. Because, if we use data types like “string” then we can carry low performance' issues
	- Use primary and foreign keys in order to create an Entity Relation diagram and rewrite those queries which run slowly
Rewriting queries:

		- Find and remove unnecessary fields and tables
		- Match indexed fields when joining tables
		- Use tables which do not contain many fields
		- Use Sub-Queries which simplify the fields' list
		- Create views for those queries which always use the same fields and/or
tables
