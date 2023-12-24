using Azure.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using web_giay.business_logic_layer.Models;

namespace web_giay.presentation_layer.Controllers
{
    public class ManageProductController : Controller
    {
        private AddProductController addProductController;
        private DeleteProductController deleteProductController;
        private UpdateProductController updateProductController;
        private SearchProductController searchProductController;
        private IManageProduct manageProduct;

        private readonly IWebHostEnvironment _webHostEnvironment;

        public ManageProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            this.addProductController = new AddProductController(); 
            this.deleteProductController = new DeleteProductController();
            this.updateProductController = new UpdateProductController();
            this.searchProductController = new SearchProductController();
            this.manageProduct = new ManageProduct();
        }

        public IActionResult Index(string fullName)
        {
            ViewBag.Name = fullName;
            ViewBag.IsManageProduct = "true";
            List<Product> products =  manageProduct.getAllProducts();
            return View("~/presentation_layer/Views/ManageProduct/Index.cshtml", products);
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(IFormFile productImage) {
            string productName = Request.Form["ProductName"];
            string productDescription = Request.Form["ProductDescription"];
            int categoryId = Int32.Parse(Request.Form["CategoryId"]);
            int supplierId = Int32.Parse(Request.Form["supplierId"]);
            double productPrice = Double.Parse(Request.Form["ProductPrice"]);
                try
                {
                    if (productImage != null && productImage.Length > 0)
                    {

                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imgs");


                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + productImage.FileName;


                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await productImage.CopyToAsync(fileStream);
                        }


                        Product product = new Product{
                            ProductName = productName,
                            ProductDescription = productDescription,
                            CategoryId = categoryId,
                            SupplierId = supplierId,
                            ProductPrice = productPrice,
                            ProductImgURL = "~/imgs/" + uniqueFileName
                        };
                        addProductController.AddProuct(product);
                    }
                    else
                    {
                        Product product = new Product
                        {
                            ProductName = productName,
                            ProductDescription = productDescription,
                            CategoryId = categoryId,
                            SupplierId = supplierId,
                            ProductPrice = productPrice,
                            ProductImgURL = "~/imgs/noimg.png"
                        };
                        addProductController.AddProuct(product);
                    }


                    return RedirectToAction("Index", "ManageProduct");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            return RedirectToAction("Index", "ManageProduct");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(IFormFile productImageUpdate)
        {
            int productId = Int32.Parse(Request.Form["ProductIdUpdate"]);
            string productName = Request.Form["ProductNameUpdate"];
            string productUrl = Request.Form["ProductImageUpdate"];
            string productDescription = Request.Form["ProductDescriptionUpdate"];
            int categoryId = Int32.Parse(Request.Form["CategoryIdUpdate"]);
            int supplierId = Int32.Parse(Request.Form["supplierIdUpdate"]);
            double productPrice = Double.Parse(Request.Form["ProductPriceUpdate"]);
            Console.WriteLine(productId);
                try
                {
                    if (productImageUpdate != null && productImageUpdate.Length > 0)
                    {

                        string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "imgs");


                        string uniqueFileName = Guid.NewGuid().ToString() + "_" + productImageUpdate.FileName;


                        string filePath = Path.Combine(uploadsFolder, uniqueFileName);


                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await productImageUpdate.CopyToAsync(fileStream);
                        }


                        Product product = new Product
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductDescription = productDescription,
                            CategoryId = categoryId,
                            SupplierId = supplierId,
                            ProductPrice = productPrice,
                            ProductImgURL = "~/imgs/" + uniqueFileName
                        };
                        updateProductController.UpdateProduct(product);
                    }
                    else
                    {
                        Product product = new Product
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductDescription = productDescription,
                            CategoryId = categoryId,
                            SupplierId = supplierId,
                            ProductPrice = productPrice,
                            ProductImgURL = productUrl
                        };
                    Console.WriteLine("khong chon hinh");
                        updateProductController.UpdateProduct(product);
                    }
                    return RedirectToAction("Index", "ManageProduct");
                }
                catch (Exception ex)
                {
                    return RedirectToAction("Index", "ManageProduct");
                }

        }

        [HttpPost]
        public IActionResult SearchProduct(string searchProduct)
        {
            Console.WriteLine(searchProduct);
            List<Product> products =  searchProductController.SearchProduct(searchProduct);
            return View("~/presentation_layer/Views/ManageProduct/Index.cshtml", products);
        }

        public IActionResult DeleteProduct(int productId)
        {
            deleteProductController.DeleteProduct(productId);
            return RedirectToAction("Index", "ManageProduct");
        }
    }
}
