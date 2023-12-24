using web_giay.business_logic_layer.Models;

namespace web_giay.data_access_layer
{
    public class ManageSizeGateway : IManageSizeGateway
    {
        public List<Size> getAllSizes()
        {
            List<Size> sizes = new List<Size>();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    sizes = dbContext.Sizes.ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return sizes;
        }

        public Size getSizeById(int id)
        {
            Size size = new Size();
            using (DatabaseContext dbContext = new DatabaseContext())
            {
                try
                {
                    size = dbContext.Sizes.FirstOrDefault(s => s.SizeId == id);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
            return size;
        }
    }
}
