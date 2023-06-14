using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace EntityFramework
{
    internal class ProductDAO : IDisposable
    {
        private SqlConnection connection;

        public ProductDAO()
        {
            this.connection = new SqlConnection("Server=(localdb)\\mssqllocaldb;Database=LojaDB;Trusted_Connection=true;");
            this.connection.Open();
        }

        public void Dispose()
        {
            this.connection.Close();
        }

        internal void Adicionar(Product p)
        {
            try
            {
                var insertCmd = connection.CreateCommand();
                insertCmd.CommandText = "INSERT INTO Products (Name, Category, Value) VALUES (@Name, @Category, @Value)";

                var paramName = new SqlParameter("Name", p.Name);
                insertCmd.Parameters.Add(paramName);

                var paramCategory = new SqlParameter("Category", p.Category);
                insertCmd.Parameters.Add(paramCategory);

                var paramValue = new SqlParameter("Value", p.Value);
                insertCmd.Parameters.Add(paramValue);

                insertCmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal void Atualizar(Product p)
        {
            try
            {
                var updateCmd = connection.CreateCommand();
                updateCmd.CommandText = "UPDATE Products SET Name = @Name, Category = @Category, Value = @Value WHERE Id = @id";

                var paramName = new SqlParameter("Name", p.Name);
                var paramCategory = new SqlParameter("Category", p.Category);
                var paramValue = new SqlParameter("Value", p.Value);
                var paramId = new SqlParameter("id", p.Id);
                updateCmd.Parameters.Add(paramName);
                updateCmd.Parameters.Add(paramCategory);
                updateCmd.Parameters.Add(paramValue);
                updateCmd.Parameters.Add(paramId);

                updateCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal void Remover(Product p)
        {
            try
            {
                var deleteCmd = connection.CreateCommand();
                deleteCmd.CommandText = "DELETE FROM Products WHERE Id = @id";

                var paramId = new SqlParameter("id", p.Id);
                deleteCmd.Parameters.Add(paramId);

                deleteCmd.ExecuteNonQuery();

            }
            catch (SqlException e)
            {
                throw new SystemException(e.Message, e);
            }
        }

        internal IList<Product> Products()
        {
            var lista = new List<Product>();

            var selectCmd = connection.CreateCommand();
            selectCmd.CommandText = "SELECT * FROM Products";

            var resultado = selectCmd.ExecuteReader();
            while (resultado.Read())
            {
                Product p = new Product();
                p.Id = Convert.ToInt32(resultado["Id"]);
                p.Name = Convert.ToString(resultado["Name"]);
                p.Category = Convert.ToString(resultado["Category"]);
                p.Value = Convert.ToDouble(resultado["Value"]);
                lista.Add(p);
            }
            resultado.Close();

            return lista;
        }
    }
}
