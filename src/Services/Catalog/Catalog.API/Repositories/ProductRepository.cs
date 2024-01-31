﻿using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _context;
        public ProductRepository(ICatalogContext catalogContext)
        {
            this._context = catalogContext;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _context
                .Products
                .Find(p=> p.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByCategory(string categoryName)
        {
            FilterDefinition<Product> filters = Builders<Product>.Filter.Eq(p => p.Category, categoryName); 
            return await _context
                .Products
                .Find(filters)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductByName(string name)
        {
            FilterDefinition<Product> filters = Builders<Product>.Filter.Eq(p => p.Name, name);

            return await _context
                .Products
                .Find(filters)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await _context
                .Products
                .Find(p=> true)
                .ToListAsync();
        }

        public async Task Create(Product product)
        {
           await _context.Products.InsertOneAsync(product);
        }
        
        public async Task<bool> Update(Product product)
        {
            var updateResult = await _context
                .Products
                .ReplaceOneAsync(filter: p=> p.Id == product.Id, replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0; 
        }
        public async Task<bool> Delete(string id)
        {
            FilterDefinition<Product> filters = Builders<Product>.Filter.Eq(p => p.Id, id);
            var deleteResult = await _context
                .Products
                .DeleteOneAsync(filters);

            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }

    }
}
