Previous requirements:

THE .NET 6 FRAMEWORK MUST BE INSTALLED.
INTERNET BROWSER BY DEFAULT: GOOGLE CHROME.
Visual Studio 2022.
Visual Studio Code 2022.
SQL Server 2014 or higher.
SQL Management Studio v17.8.1.
NodeJS for windows 10.
ReactJS 18.
POSTMAN for Windows 10.

--------------------------------------------------

WHAT'S THIS APPLICATION ABOUT?

This is a demo of SQL Server Full-Text Search implementation for a Movie Finder application.
The implementation of Full-Text Search is applied on both Database and Domain level through 
Entity Framework Core.

--------------------------------------------------

How to run this application locally?

1- OPEN AND RESTORE THE DATABASE "MoviesDB"

    \\R18_EFCORE6_FTS\DB\R18FTSNC6.bak, 

        ON THE SELECTED LOCAL SQL SERVER.

2- OPEN THE VISUAL STUDIO SOLUTION 

    \\R18_EFCORE6_FTS\R18FullTextS_Core6\ReactNC6FTS_Full.sln


3- RUN THE SOLUTION.

4- In case you run into a problem with the Web Api you can recreate the Context and the Model classes by proceeding to:

    4.1- Comment the lines:
    
        using R18FullTextS_Core6.Models;
        AND
        builder.Services.AddDbContext<MoviesDBContext>();

        in the Program.cs file.

    4.2- Delete all the files within the Models folder.

    4.3- Backup all the contents of the folder "Controllers" 
         into another folder.

    4.4- Delete the file MovieController.cs

    4.5- Go to Tools Nuget Package Manager-->Package Manager Console. This will
         open a console like window.

    4.6- Copy the following command into another text file:

         Scaffold-DbContext "Server=LAPTOP-LKBBPMQJ\SQLEXPRESS; DataBase=MoviesDB;Integrated Security=true" Microsoft.EntityFrameworkCore.SqlServer -OutPutDir Models 

    4.7- Modify the previous command to point to your local SQL Server 
         installation.

    4.8- Inside the console opened in step 4.5, type in or paste the following
         command modified in step 4.7, THEN HIT ENTER.

    4.9- You should not be seeing errors in the console.

    4.10- Verify the new files created in the Models folder.

    4.11- Create a new Empty API Controller in the Controllers folder and name it
         "MovieController".

    4.12- In the new Controller file, delete the entire class ONLY, leave the rest
          as it is.

    4.13- Copy the entire class from the previous Controller you backed up on
          a text file, then paste it into the new Controller file.

    4.14- Save the changes.

    4.15- Uncomment the lines you commented in step 4.1.

    4.16- Rebuild the whole solution. You should not get any errors.

    4.17- Now you can run the solution again.

    4.18- Check if the screens you see are similar to the ones in the Screen Captures folder.




--------------------------------------------------

HIGHLIGHTS FOR THIS APPLICATION:

     - Implements SQL Server FULL-TEXT SEARCH on the tables Movie and Cast.

     - Implements Entity Framework Core FULL-TEXT SEARCH.

     - You can try out the SQL Query QueryLab.sql already included in this DEMO in the folder
          \\R18_EFCORE6_FTS\DB

     - The Context and Model classes implement the "Database First" approach.

     - Implements Entity Framework Core to handle table relationships within a database.
 
     - Implements data transformation through JSON and ViewModels for the UI.
	     See FindMoviesFullTextSearch() method in the MovieController.cs file.

     - Implements live search results for Reactjs 18 applications and it's easy to maintain.


