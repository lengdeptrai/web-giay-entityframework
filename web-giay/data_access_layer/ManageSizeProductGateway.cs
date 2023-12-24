using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageSizeProductGateway : IManageSizeProductGateway
    {
        public void addSizeProduct(SizeProduct sizeProduct)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {

                    dbContext.SizeProducts.Add(sizeProduct);
                    dbContext.SaveChanges();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public void deleteSizeProduct(int sizeProductId)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var sizeProductDelete = dbContext.SizeProducts.FirstOrDefault(sp => sp.SizeProductId == sizeProductId);
                    if (sizeProductDelete != null)
                    {
                        dbContext.SizeProducts.Remove(sizeProductDelete);
                        dbContext.SaveChanges();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        public List<SizeProduct> getAllSizeProduct()
        {
            List<SizeProduct> sizeProducts = new List<SizeProduct>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    sizeProducts = dbContext.SizeProducts.ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sizeProducts;
        }

        public SizeProduct getSizeProductById(int sizeProductId)
        {
           SizeProduct sizeProduct = new SizeProduct();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    sizeProduct = dbContext.SizeProducts.FirstOrDefault(sp => sp.SizeProductId == sizeProductId);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sizeProduct;
        }

        public List<SizeProduct> getSizeProductByProductId(int sProductId)
        {
            List<SizeProduct> sizeProducts = new List<SizeProduct>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    sizeProducts = dbContext.SizeProducts.Where(sp => sp.ProductId ==  sProductId).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sizeProducts;
        }

        public void updateSizeProduct(SizeProduct sizeProduct)
        {
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    var existingSizeProduct = dbContext.SizeProducts.FirstOrDefault(sp => sp.SizeProductId == sizeProduct.SizeProductId);
                    if (existingSizeProduct != null)
                    {
                        existingSizeProduct.ProductId = sizeProduct.ProductId;
                        existingSizeProduct.SizeId = sizeProduct.SizeId;
                        existingSizeProduct.Quantity = sizeProduct.Quantity ;
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
