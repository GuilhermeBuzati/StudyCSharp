<h1 align="center" id="installEntityFramework"> ASP.NET - Development </h1>

<h2 id="files" align="center"> <i> Resume </i></h2>

<ol>
<li><a href="#init"> Init ASPNET </a></li>
<li><a href="#setting"> Setting of Project </a></li>
<li><a href="#controller"> Controllers </a></li>
<li><a href="#routes"> Routes and Methods </a></li>
<li><a href="#annotationAttributes"> Annotations Attribute's </a></li>
<li><a href="#pagination"> Pagination </a></li>
<li><a href="#exception"> Test with Exception </a></li>
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

  -   Example: Skip 3 element and take 2


        ![Alt text](image-14.png)

        ![Alt text](image-15.png)