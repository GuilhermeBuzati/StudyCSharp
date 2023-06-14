<h1 align="center" id="installEntityFramework"> Summary </h1>
<ol>
    <li> <a href="#installEntityFramework"> How to install Entity Framework </a></li>
    <li> <a href="#useEntityFramework"> Entity Framework </a></li>
        <ul>
            <li> <a href="#crudEntityFramework"> C.R.U.D </a></li>
            <li> <a href="#changeTrackerEntityFramework"> ChangeTracker and States </a></li>
        </ul>

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
        
<h3 align="center" id="crudEntityFramework"> C.R.U.D </h3>

<h4> Branch: EntityFramework - Commit 23a56900da9f4406772b267df5fe12d63a27d048 </h4>

- <p> Now, you can do the CRUD with EntityFramework. </p>

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


<h3 align="center" id="changeTrackerEntityFramework"> ChangeTracker and States </h3>
    

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
