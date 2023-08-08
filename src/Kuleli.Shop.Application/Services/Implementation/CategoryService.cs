using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class CategoryService : ICategoryServices
    {
        private readonly KuleliGalleryContext _context;

        public CategoryService(KuleliGalleryContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            var categories = await _context.Categories.Select(x =>
            new CategoryDto
            {
                Id = x.Id,
                Name = x.Name
            }).ToListAsync();
            return categories;
        }

        public async Task<CategoryDto> GetCategoryById(int id)
        {
            var categoryEntity = await _context.Categories.FindAsync(id);
            var categoryDto = new CategoryDto

            {
                Id = id,
                Name = categoryEntity.Name,
            };

            return categoryDto;
        }

        public async Task<int> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {

            // Yeni bir kategori entity nesnesi
            var categoryEntity = new Category
            {
                Name = createCategoryViewModel.CategoryName
            };

            //uretilen entity nesnesi kategori koleksiyonuna ekleniyor
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            //yansıtılan kategorinin idsi oluyor ve idyi getirmemizi sağlıyor...!!!
            //Db kayıt isleminden sonra herhangi bir sıkıntı yoksa bu kategori icin atanan entity geri doner...!!!
            return categoryEntity.Id;
        }

        public async Task<int> DeleteCategory(int id)
        {
            //sarta baglı kategori getirmek icin kullanılır fake id durumu!!!

            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == id);
            if (!categoryExists)
            {
                throw new Exception($"{id} NUMARALI KATEGORI BULUNAMADI!");
            }

            // veritabaninda kayitli kategoriyi getirelim.
            var existsCategory = await _context.Categories.FindAsync(id);
            // silindi olarak isaretleyelim.
            existsCategory.IsDeleted = true;
            //guncellemeyi veritabanına yansitalim..!!
            _context.Categories.Update(existsCategory);
            await _context.SaveChangesAsync();

            return existsCategory.Id;

        }

        public async Task<int> UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel)
        {
            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == updateCategoryVievModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{updateCategoryVievModel} NUMARALI KATEGORI BULUNAMADI!");
            }

            // veritabaninda kayitli kategoriyi getirelim.
            var existsCategory = await _context.Categories.FindAsync(updateCategoryVievModel.Id);
            // silindi olarak isaretleyelim.
            existsCategory.Name = updateCategoryVievModel.CategoryName;
            //guncellemeyi veritabanına yansitalim..!!
            _context.Categories.Update(existsCategory);
            await _context.SaveChangesAsync();

            return existsCategory.Id;

        }
               
    }
}
