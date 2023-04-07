using ClothesShop.DAL.Entities;
using ClothesShop.DAL.Interfaces;
using ClothesShop.DAL.Migrations;

namespace ClothesShop.DAL.Repository
{
    public class ClothingRepository : IClothingRepository
    {
        private readonly InitialData _data;   
        public ClothingRepository(InitialData data) 
        {
            _data = data;
        }

        public List<ClothingEntity> GetAllClothing()
        {
            return _data.Data.OfType<ClothingEntity>().ToList();
        }

        public void AddClothing(ClothingEntity clothing)
        {
            _data.AddEntity(clothing);
            CorrectManufacturer.AddComodities(clothing, _data);
        }

        public void RemoveClothing(ClothingEntity clothing)
        {
            CorrectManufacturer.DeleteComodities(clothing, _data);
            _data.Data.Remove(clothing);
        }

        public ClothingEntity FindClothing(Guid id)
        {
            var clothing = _data.Data.OfType<ClothingEntity>().Where(c => c.Id == id).FirstOrDefault();
            return clothing;
        }
    }
}
