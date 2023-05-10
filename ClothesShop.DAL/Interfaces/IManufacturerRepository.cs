using ClothesShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothesShop.DAL.Interfaces
{
    public interface IManufacturerRepository
    {
        Task<List<ManufacturerEntity>> GetAllManufacturers();
        void AddManufacturer(ManufacturerEntity manufacturer);
        Task<ManufacturerEntity> GetManufacturerById(Guid id);
        void RemoveManufacturer(ManufacturerEntity manufacturer);
        public void UpdateManufacturer(ManufacturerEntity manufacturer);
    }
}
