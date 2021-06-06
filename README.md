# ImageTools_Dapper


Projects in the Solution

1)	ImageTool 
2)	
         -	.Net Core project. 
         -	Update and Get data from ImagesTool DB using Dapper.
2)	SQLDataBase


         -	SQLDatabase project
         -	It is used in our project to create the ImagesTool DB in your SQL to be used in the ImageToolProject.
         
         Steps to run the ImageTool project:
         1)	Create Databasein your SQL server from SQLDataBase project.

                  a)	Publish SQLDataBase project
                       To Connect to your DB 
                  -	Click on Edit button next to Target Database connection.
                  -	Go to Browse to select the SQL server and select the connectionString

                  b)	Name the new DB you are going to create (ImagesTool).

                  c)	Click on Save Profile As. It creates the publish xml file to use in the future. 

                  d)	Click on Publish.

                  e)	ImagesTool DB will be created in your SQL server and in SQL Object Explorer.

        
         2)	Run ImageTool project.

                  - Modify the connectionString in appsettings.json file (ConnString of the new DB)
                  - Execute the project. 
                  -	Add an entity.
                  -	Add an image to the created entity 
                  -	Add multiple images to the created entity.
                  -	Get the images of an entity.

 
 





