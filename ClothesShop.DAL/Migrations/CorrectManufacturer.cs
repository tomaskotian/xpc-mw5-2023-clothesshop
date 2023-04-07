using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Migrations
{
    public static class CorrectManufacturer
    {
        public static void GetCorrectManufacturerBogus(InitialData data) 
        {
            List<string> manufacturers = new List<string>();

            //find all manufacturer names
            foreach(ClothingEntity comodity in data.Data.OfType<ClothingEntity>())
            {
                manufacturers.Add(comodity.Manufacturer.Name);     
            }
            manufacturers = manufacturers.Distinct().ToList();

            UpadteCommodities<ClothingEntity>(manufacturers, data);
            UpadteCommodities<ShoesEntity>(manufacturers, data);
            UpadteCommodities<AccessoriesEntity>(manufacturers, data);

        }  
        private static void UpadteCommodities<T>(List<string> manufacturers, InitialData data) where T : IClothes
        {   
            foreach (string manufacturer in manufacturers)
            {
                List<object> clothings = new List<object>();
                foreach (T comodity in data.Data.OfType<T>().Where(c => c.Manufacturer.Name == manufacturer))
                {
                    clothings.Add(comodity);
                }
                var ManufacturerObject = data.Data.OfType<T>().Where(c => c.Manufacturer.Name == manufacturer).FirstOrDefault();
                foreach (object clothing in clothings)
                {
                    ManufacturerObject.Manufacturer.Commodities.Add(clothing);
                }
            }
        }
    }
}
