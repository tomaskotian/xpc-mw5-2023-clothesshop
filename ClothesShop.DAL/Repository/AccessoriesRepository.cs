using ClothesShop.Common.Enums;
using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class AccessoriesRepository : IAccessoriesRepository
    {
        private readonly InitialData _data;

        public AccessoriesRepository(InitialData data) 
        {
            _data = data;
        }

        public List<AccessoriesEntity> GetAllAccessories()
        {
            return _data.Data.OfType<AccessoriesEntity>().ToList();
        }

        public void AddAccessory(AccessoriesEntity accessories)
        {
            _data.AddEntity(accessories);
            CorrectManufacturer.AddComodities(accessories, _data);
        }

        public void RemoveAccessory(AccessoriesEntity accessories)
        {
            CorrectManufacturer.DeleteComodities(accessories, _data);
            _data.Data.Remove(accessories);
        }

        public AccessoriesEntity GetAccessoryById(Guid id)
        {
            var accessories = _data.Data.OfType<AccessoriesEntity>().Where(c => c.Id == id).FirstOrDefault();
            return accessories;
        }

        public List<AccessoriesEntity> GetAccessoriesFiltered(string manufacturer_name, Sex sex, string sort)
        {
            var accessories = _data.Data.OfType<AccessoriesEntity>();
            if (manufacturer_name != default)
                accessories = accessories.Where(s => s.Manufacturer.Name == manufacturer_name);
            if (sex != default)
                accessories = accessories.Where(s => s.Sex == sex);
            if (sort == "ByPrice")
                accessories = accessories.OrderBy(s => s.Price);

            return accessories.ToList();
        }
    }
}
