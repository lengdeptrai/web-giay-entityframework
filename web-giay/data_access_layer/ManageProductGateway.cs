using Microsoft.EntityFrameworkCore;
using System;
using web_giay.business_logic_layer.Models;
namespace web_giay.data_access_layer
{
    public class ManageProductGateway : AManageProductGateway
    {
        public override void addProduct(Product p)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {

                    dbContext.Products.Add(p);
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public override void deleteProduct(int ProductId)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var productToDelete = dbContext.Products.FirstOrDefault(p => p.ProductId == ProductId);
                    if (productToDelete != null)
                    {
                        dbContext.Products.Remove(productToDelete);
                        dbContext.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }


        public override List<Product> getAllProducts()
        {
            List<Product> products = new List<Product>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    products = dbContext.Products.ToList();
                    
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            }
            return products;
        }

        public override List<Product> getAllCategoryProducts(int CategoryId)
        {
            List<Product> products = new List<Product>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    products = dbContext.Products.Where(p => p.CategoryId == CategoryId).ToList();
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return products;
        }

        public override Product getProductById(int ProductId)
        {
            Product product = new Product();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    product = dbContext.Products.FirstOrDefault(p => p.ProductId == ProductId );
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return product;
        }

        public override List<Product> getProductByName(string ProductName)
        {
            List<Product> products = new List<Product>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    products = dbContext.Products.Where(p => EF.Functions.Like(p.ProductName, $"%{ProductName}%")).ToList();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return products;
        }

        public override void updateProduct(Product p)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var existingProduct = dbContext.Products.FirstOrDefault(p => p.ProductId == p.ProductId);
                    if (existingProduct != null)
                    {
                        existingProduct.ProductName = p.ProductName;
                        existingProduct.ProductPrice = p.ProductPrice;
                        existingProduct.ProductDescription = p.ProductDescription;
                        existingProduct.ProductImgURL = p.ProductImgURL;
                        existingProduct.CategoryId = p.CategoryId;
                        existingProduct.SupplierId = p.SupplierId;

                        dbContext.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("ko thấy");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
    }
}
