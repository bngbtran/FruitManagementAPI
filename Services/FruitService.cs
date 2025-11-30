using FruitManagementAPI.Data;
using FruitManagementAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FruitManagementAPI.Services
{
    public class FruitService
    {
        private readonly AppDbContext _context;

        public FruitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Fruit>> GetAllAsync() => await _context.Fruits.ToListAsync();

        public async Task<Fruit> GetByIdAsync(int id) => await _context.Fruits.FindAsync(id);

        public async Task<Fruit> CreateAsync(Fruit fruit)
        {
            _context.Fruits.Add(fruit);
            await _context.SaveChangesAsync();
            return fruit;
        }

        public async Task<bool> UpdateAsync(Fruit fruit)
        {
            var existing = await _context.Fruits.FindAsync(fruit.Id);
            if (existing == null) return false;

            existing.Name = fruit.Name;
            existing.Price = fruit.Price;
            existing.Quantity = fruit.Quantity;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var fruit = await _context.Fruits.FindAsync(id);
            if (fruit == null) return false;

            _context.Fruits.Remove(fruit);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
