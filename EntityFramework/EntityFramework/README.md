<h1 align="center" id="installEntityFramework"> Summary </h1>
<ol>
    <li> <a href="#installEntityFramework"> How to install Entity Framework </a></li>
    <li> <a href="#useEntityFramework"> How to use Entity Framework </a></li>
</ol>



<h1 align="center" id="installEntityFramework"> How to install Entity FrameWork</h1>
	
<p> Open Terminal in </p>

- Tools -> NuGet Package Manager -> Package Manager Console


<p> Type the command </p>

- Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 7.0.7

	<p> In case, we are installing provider for SqlServer, but you can see all providers <a href="https://learn.microsoft.com/en-us/ef/core/providers/?tabs=dotnet-core-cli"> here </a> </p>


<h1 align="center" id="useEntityFramework"> Methods with EntityFramework</h1>

<h4> Branch: EntityFramework - Commit 23a56900da9f4406772b267df5fe12d63a27d048 </h4>

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
