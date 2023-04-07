using ClothesShop.DAL.Entities;

namespace ClothesShop.DAL.Migrations
{
    public static class CorrectManufacturer
    {
        public static void AddComodities(IClothes comodity, InitialData data) 
        {
            var OriginalComodity = data.Data.OfType<IClothes>().Where(c => ((c.Manufacturer.Name == comodity.Manufacturer.Name) && (c.Name != comodity.Name))).FirstOrDefault();
            if (OriginalComodity == null)
            {
                var manufacturer = new ManufacturerEntity()
                {
                    Id = Guid.NewGuid(),
                    Name = comodity.Manufacturer.Name,
                    Description = comodity.Manufacturer.Description,
                    Logo = comodity.Manufacturer.Logo,
                    Origin = comodity.Manufacturer.Origin,
                    Commodities = new List<object>{comodity}
                };
                comodity.Manufacturer = manufacturer;   
            }
            else
            {
                OriginalComodity.Manufacturer.Commodities.Add(comodity);
                comodity.Manufacturer = OriginalComodity.Manufacturer;
            }
        }

        public static void GetCorrectManufacturerBogus(List<object> data) 
        {
            var manufacturers = FindManufacturers(data);

            UpadteCommodities<IClothes>(manufacturers, data);

        }  

        private static void UpadteCommodities<T>(List<string> manufacturers, List<object> data) where T : IClothes
        {   
            foreach (string manufacturer in manufacturers)
            {
                List<object> clothings = new List<object>();
                foreach (T comodity in data.OfType<T>().Where(c => c.Manufacturer.Name == manufacturer))
                {
                    clothings.Add(comodity);
                }
                var ManufacturerObject = data.OfType<T>().Where(c => c.Manufacturer.Name == manufacturer).FirstOrDefault();
                foreach (object clothing in clothings)
                {
                    ManufacturerObject.Manufacturer.Commodities.Add(clothing);
                }
            }
        }

        private static List<string> FindManufacturers(List<object> data) 
        {
            List<string> manufacturers = new List<string>();

            foreach (IClothes comodity in data)
            {
                manufacturers.Add(comodity.Manufacturer.Name);
            }
            manufacturers = manufacturers.Distinct().ToList();
            return manufacturers;
        }
    }
}
