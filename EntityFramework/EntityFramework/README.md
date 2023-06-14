<h1 align="center" id="installEntityFramework"> Summary </h1>
<ol>
    <li> <a href="#installEntityFramework"> How to install Entity Framework </a></li>
    <li> <a href="#useEntityFramework"> Entity Framework </a></li>
        <ul>
            <li> <a href="#crudEntityFramework"> C.R.U.D </a></li>
            <li> <a href="#changeTrackerEntityFramework"> ChangeTracker</a></li>
            <li> <a href="#statesEntityFramework"> States </a></li>
        </ul>
        
<li> <a href="#userToolsEntityFramework"> Tools Entity Framework </a></li>
</ol>



<h1 align="center" id="installEntityFramework"> How to install Entity FrameWork</h1>
	
<p> Open Terminal in </p>

- Tools -> NuGet Package Manager -> Package Manager Console


<p> Type the command </p>

    - Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.7

<p> In case, we are installing provider for SqlServer, but you can see all providers <a href="https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli"> here </a> </p>


<h1 align="center" id="useEntityFramework"> EntityFramework </h1>

<p> Configure application to accept Entity Framework </p>

- <p> First of all, you must create a context, in this project is "StoreContext". </p>

        //Import EntityFramework
        using Microsoft.EntityFrameworkCore;

        namespace EntityFramework
        {
            //Implement from DbContext
            internal class StoreContext : DbContext
            {
                //Products are attributes in context, remember, name must be identical to database column!
                public DbSet<Product> Products { get; set; }

                //Configure access to db with method "OnConfiguring", like this:
                protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
                {
                    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=StoreDB;Trusted_Connection=true;");
                }

            }
        }
        
- <h2 id="crudEntityFramework">  C.R.U.D </h2>

<h4> Branch: EntityFramework - Commit 23a56900da9f4406772b267df5fe12d63a27d048 </h4>

- <p> Create a object:</p>

        private static void RecordUsingEntity()
        {
            //Creating a object
            Product p = new Product();
            p.Name = "Harry Potter e a Ordem da Fênix";
            p.Category = "Livros";
            p.Value = 19.89;

            //Using the context "StoreContext()"
            using (var context = new StoreContext())
            {
                //With context open, we added a object in "Products"
                context.Products.Add(p);
                //After, we must save the changes (commit)
                context.SaveChanges();
            }

            Console.WriteLine("Saved!");
        }


- <p> Reading a object </p>

        private static void GetListProduct()
        {   
            //Using context
            using (var context = new StoreContext())
            {
                //Getting list of products from context
                IList<Product> products = context.Products.ToList();
                Console.WriteLine("It was found {0} product(s).", products.Count);

                //Listing object with foreach
                foreach (var item in products)
                {
                    Console.WriteLine(item.Name);
                }
            }
        }


- <p> Update a object </p>
    
        private static void UpdateProduct()
        {
            //Using context
            using (var context = new StoreContext())
            {
                //We are updating first object was found in db
                Product product = context.Products.First();
                product.Name = "Product updated!";

                //Update "Products" with object
                context.Products.Update(product);
                //commit
                context.SaveChanges();
            }
        }
    

- <p> Deleting a object </p>
        
        private static void RemoveProduct()
        {   
            //Using context
            using (var context = new StoreContext())
            {
                //Listing all products in context
                IList<Product> products = context.Products.ToList();

                //We are removing each product was found in database
                foreach(Product product in products)
                {
                    context.Products.Remove(product);                    
                }
                //commit
                context.SaveChanges();
            }
        }


- <h2 id="changeTrackerEntityFramework" > ChangeTracker</h2>

    <h4> Branch: EntityFramework - Commit 442b0e8bb6059b7b392e024d29940bc0317138da </h4>

        static void Main(string[] args)
            {
                using(var context = new StoreContext())
                {
                    var products = context.Products.ToList();

                    foreach(var product in products)
                    {
                        Console.WriteLine(product);
                    }

                    //ChangeTrack is responsible for verify every changes in context, and have a method called Entries than list all entities managed by context
                    foreach(var e in context.ChangeTracker.Entries())
                    {
                        //Every element in entities (context)
                        Console.WriteLine(e.State);
                        //Will return "unchanged"
                    }

                    var product1 = products.Last();
                    product1.Name = "Teste de Livros";  

                    //After we update attribute from element
                    foreach (var e in context.ChangeTracker.Entries())
                    {
                        Console.WriteLine(e.State);
                        //The last element, will return "modified"
                    }

                    //Then, entity can manage state of each entity
                }
            }    


- <h2 id="statesEntityFramework"> States</h2>

    <h4> Branch: EntityFramework - Commit 442b0e8bb6059b7b392e024d29940bc0317138da </h4>

    <ul>
    <li> <b> Added </b>: Element added in context </li>
        - Example: context.Products.Add(newProduct);<br>

    <br>
    <li> <b> Unchanged </b>: Element was return from database </li>
        - Example: context.Products.ToList();<br>

    <br>
    <li> <b> Modified </b>: Element was update from context</li>
            - Example: <br>
                  var product1 = products.Last();<br>
                  product1.Name = "Product tested";<br>
        
    <br>
    <li> <b> Deleted </b>: Element was remove from context </li>
        - Example: context.Products.Remove(product);<br>

    <br>
    <li> <b> Detached </b>: Element not being monitored in context </li>
        - Example: </br>
                 context.Products.Add(newProduct);</br>
                  - Then, before the commit, it is removed </br>
                 context.Products.Remove(newProduct);</br>
                 
    </ul>


<h1 align="center" id="userToolsEntityFramework"> How to use Tools Entity FrameWork</h1>

<p> Tools Entity FrameWork will syncronize the class with table in database. So, we do not need update script directly in database, the Tools will do
this for us </p>

<p> The Class before update </p>

    internal class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double Value { get; internal set; }

        public override string ToString()
        {
            return $"Product: {this.Id}, {this.Name}, {this.Category}, {this.Value}";
        }
    }

<p> The class conform we want to update </p>

    internal class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }

        //It was updated this attribute
        public double CostUnit { get; internal set; }

        //It was added this attribute
        public string Unit{ get; internal set; }

        public override string ToString()
        {
            return $"Product: {this.Id}, {this.Name}, {this.Category}, {this.CostUnit}";
        }
    }

<p> Now, to update the table without database, you need follow the topics below </p> 

<p> Open Terminal PMC in </p>

- Tools -> NuGet Package Manager -> Package Manager Console

<p> Type the command </p>

    - Install-Package Microsoft.EntityFrameworkCore.Tools -version 7.0.7

<p> Then, type to create the miggration: </p>

    - Add-Migration "NAME"

<p> To update database with class: </p>

    - Update-Database -Verbose

<p> If returns this error:</p>

    - There is already an object named 'Products' in the database.

<p> You will need follow steps below </p>

<ul> 
<li> Delete folder migration created in project </li>
<li> Delete table migration created in database </li>
<li> Let's go back to the beginning of the class of what we updated </li>

    internal class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }
        public double Value { get; internal set; }

        public override string ToString()
        {
            return $"Product: {this.Id}, {this.Name}, {this.Category}, {this.Value}";
        }
    }

<li> Open Terminal PMC and type: </li>

    - Add-Migration Init

<li> Update class </li>

    internal class Product
    {
        public int Id { get; internal set; }
        public string Name { get; internal set; }
        public string Category { get; internal set; }

        //It was updated this attribute
        public double CostUnit { get; internal set; }

        //It was added this attribute
        public string Unit{ get; internal set; }

        public override string ToString()
        {
            return $"Product: {this.Id}, {this.Name}, {this.Category}, {this.CostUnit}";
        }
    }

<li> Open Terminal PMC and type:</li>

    - Add-Migration "Name" (ex: Add-Migration Unit)
   

<li> Comment the code in file "Migration > ..._Init.cs" </li>
        

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Value = table.Column<double>(type: "float", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //    });
        }

<li> Open Terminal PMC and type: </li>

    - Update-Database Init -Verbose


<li> Remove comment in file (Migration > "..._Init.cs) </li>

<li> Open Terminal PMC and type: </li>

    - Update-Database -Verbose


<li> Now your table in database will be updated with base in Class Product </li>

</ul>
