<h1 align="center" id="installEntityFramework"> ASP.NET - Development </h1>

<h2 id="files" align="center"> <i> Resume </i></h2>

<ol>
<li><a href="#init"> Init ASPNET </a></li>
<li><a href="#setting"> Setting of Project </a></li>
<li><a href="#controller"> Controllers </a></li>
<li><a href="#routes"> Routes and Methods </a></li>
<li><a href="#annotationAttributes"> Annotations Attribute's </a></li>
<li><a href="#pagination"> Pagination </a></li>
<li><a href="#statusCode"> Status Code </a></li>
<li><a href="#databaseConnection"> Database Connection </a></li>
</ol>

</br>
<h2 id="testUnit"> Init AspNET </h2>
<hr>

- <p> Create a project as ASP.NET Core Wen App </p>
        
    ![Alt text](image.png)

</p> 

</br>
<h2 id="setting"> Setting of Project </h2>
<hr>

- <p> In "Properties > launchSetting.json", we can see localhost and port of application. </p>

    ![Alt text](image-1.png)

    ![Alt text](image-2.png)

</br>
<h2 id="controller"> Controllers </h2>
<hr>

- <p> The Controller will be responsible to manager the request created by user. The example below: </p>

    ![Alt text](image-4.png)


</br>
<h2 id="routes"> Routes and Methods </h2>
<hr>

- <p> Example Method <b> GET </b> </p>

    ![Alt text](image-5.png)

- <p> Example Method <b> POST </b> receiving parameter. </p>

    ![Alt text](image-6.png)

- <p> Returning data </p>

    ![Alt text](image-8.png)

- <p> Example <b> [FromQuery] </b> receiving values by URL

    ![Alt text](image-9.png)

    ![Alt text](image-10.png)
    
- <p> Example <b> [FromBody] </b> receiving values by body request

    ![Alt text](image-11.png)
    
    ![Alt text](image-13.png)


</br>
<h2 id="annotationAttributes"> Annotations Attribute's </h2>
<hr>

- <p> <b> [Required]</b>: Attribute can not be null</p>
- <p> <b> [MaxLength()]</b>: Max caracters allowed</p>
- <p> <b> [Range (init, end)]</b>: Value must be between these values </p>
- <p> <b> ErrorMessage</b>: You can define a custom message for that error</p>

    ![Alt text](image-7.png)


</br>
<h2 id="pagination"> Pagination </h2>
<hr>

- <p> <b> Skip(int N)</b>: Jump N elements
- <p> <b> Take(int N)</b>: Get N elements to return

  -   Example: Skip 3 element and take 2. In this case, take contains default value (10)

        ![Alt text](image-20.png)

        ![Alt text](image-14.png)

        ![Alt text](image-15.png)

    
</br>
<h2 id="statusCode"> Status Code </h2>
<hr>

- <p> When element not found, will return: <b>"Not Found()"</b> </p>

    ![Alt text](image-16.png)

    If filme is null, return method <b>"Not Found()"</b> - Status 404

    ![Alt text](image-17.png)

- <p> When element was created, will return: <b>"Created()"</b> </p>

    ![Alt text](image-19.png)

    return method "CreatedAtAction()" and path from element created - Status - 201

    ![Alt text](image-18.png)
    
    
</br>
<h2 id="databaseConnection"> Database Connection </h2>
<hr>

-   <p> In "appsetting.json": </p>

    ![Alt text](image-21.png)

-   <p> Add the command with the credentials of database. Example: </p>

        "ConnectionStrings": {
            "FilmeConnection" : "server=localhost;database=filme;user=root;password=root"
        }

    ![Alt text](image-22.png)

-   <p> Now, we must define the connection of database for DBContext in "program.cs". </p>

        //String of connection database
        var connectionString = builder.Configuration.GetConnectionString("FilmeConnection");
                
        //Connect to datase
        builder.Services.AddDbContext<FilmeContext>(opts => opts.UseMySql(connectionString, serverVersion: ServerVersion.AutoDetect(connectionString)));

    ![Alt text](image-23.png)
        
    
</br>
<h2 id="migration"> Creating Table from Classe (Migration) </h2>
<hr>


-   <p> Add a <b> [Key] </b> to identify "Id" as primary key and <b>[Required]</b> (not null) </p>

    ![Alt text](image-24.png)

-   <p> Open <b>"Package Manager Console"</b> and type:

        Add-Migration NameOfMigration
    
    ![Alt text](image-25.png)

    ![Alt text](image-27.png)

-   <p> Will be added the folder <b>"Migrations"</b> </p>

    ![Alt text](image-28.png)


-   <p> To update in database, type: </p>

        Update-Database

-   <p> Done! </p>

    ![Alt text](image-29.png)