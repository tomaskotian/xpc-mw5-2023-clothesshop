using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Interfaces
{
    public interface IFakeDatabase
    {
        Task<List<ClothingEntity>> GetAllClothing();
        Task<List<ShoesEntity>> GetAllShoes();
        Task<List<AccessoriesEntity>> GetAllAccessories();
        Task AddClothing(ClothingEntity clothing);
        Task AddShoes(ShoesEntity shoes);
        Task AddAccessories(AccessoriesEntity accessories);
        Task RemoveClothing(ClothingEntity clothing);
        Task RemoveShoes(ShoesEntity shoes);
        Task RemoveAccessories(AccessoriesEntity accessories);
        ClothingEntity GetClothingById(Guid id);
        ShoesEntity GetShoesById(Guid id);
        AccessoriesEntity GetAccessoriesById(Guid id);
    }
}
