 using AutoMapper;
using AutoMapper.QueryableExtensions;
using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Domain.Entities;
using Kuleli.Shop.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class CategoryService : ICategoryServices
    {
        private readonly KuleliGalleryContext _context;
        private readonly IMapper _mapper;

        public CategoryService(KuleliGalleryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        //Automapper : Bir modeli baska bir modele cevirmek icin kullanılıyor.

        public async Task<List<CategoryDto>> GetAllCategories()
        {
            //var categories = await _context.Categories.ToListAsync();

            ////_mapper.Map<T1,T2> T1 tipindeki kaynak objeyi T2 tipindeki hedef objeye cevirir.
            //var categoryDtos= _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            var categoryDtos = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync();

            return categoryDtos;
        }

        public async Task<CategoryDto> GetCategoryById(GetCategoryByIdViewModel getCategoryByIdViewModel)
        {
            //var categoryEntity = await _context.Categories.FindAsync(id);
            //var categoryDto = new CategoryDto

            //{
            //    Id = id,
            //    Name = categoryEntity.Name,
            //};

            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == getCategoryByIdViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{getCategoryByIdViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }
            var categoryDto = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == getCategoryByIdViewModel.Id);
            return categoryDto;
        }

        public async Task<int> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {

            // Yeni bir kategori entity nesnesi
            //var categoryEntity = new Category
            //{
            //    Name = createCategoryViewModel.CategoryName
            //};

            var categoryEntity = _mapper.Map<CreateCategoryViewModel, Category>(createCategoryViewModel);

            //uretilen entity nesnesi kategori koleksiyonuna ekleniyor
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            //yansıtılan kategorinin idsi oluyor ve idyi getirmemizi sağlıyor...!!!
            //Db kayıt isleminden sonra herhangi bir sıkıntı yoksa bu kategori icin atanan entity geri doner...!!!
            return categoryEntity.Id;
        }

        public async Task<int> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {
            //sarta baglı kategori getirmek icin kullanılır fake id durumu!!!

            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == deleteCategoryViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{deleteCategoryViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }

            // veritabaninda kayitli kategoriyi getirelim.
            var existsCategory = await _context.Categories.FindAsync(deleteCategoryViewModel.Id);
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

            var updatedCategory = _mapper.Map<UpdateCategoryVievModel, Category>(updateCategoryVievModel);

            //// veritabaninda kayitli kategoriyi getirelim.
            //var existsCategory = await _context.Categories.FindAsync(updateCategoryVievModel.Id);
            //// silindi olarak isaretleyelim.
            //existsCategory.Name = updateCategoryVievModel.CategoryName;

            //guncellemeyi veritabanına yansitalim..!!
            _context.Categories.Update(updatedCategory);
            await _context.SaveChangesAsync();

            return updatedCategory.Id;

        }

    }
}
