 using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation;
using Kuleli.Shop.Application.Exceptions;
using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Application.Wrapper;
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

        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var result= new Result<List<CategoryDto>>();

            //var categories = await _context.Categories.ToListAsync();

            ////_mapper.Map<T1,T2> T1 tipindeki kaynak objeyi T2 tipindeki hedef objeye cevirir.
            //var categoryDtos= _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            var categoryDtos = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = categoryDtos;
            return result;
        }

        public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdViewModel getCategoryByIdViewModel)
        {
            //var categoryEntity = await _context.Categories.FindAsync(id);
            //var categoryDto = new CategoryDto

            //{
            //    Id = id,
            //    Name = categoryEntity.Name,
            //};
            var result = new Result<CategoryDto>();

            //Request model dogrulaması

            var validator = new GetCategoryByIdValidator();
            var validationResult = validator.Validate(getCategoryByIdViewModel);

            if(!validationResult.IsValid) 
            {
                throw new ValidateException(validationResult);
            }

            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == getCategoryByIdViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{getCategoryByIdViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }
            var categoryDto = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(x => x.Id == getCategoryByIdViewModel.Id);

            result.Data = categoryDto;
            return result;
        }

        public async Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {

            // Yeni bir kategori entity nesnesi
            //var categoryEntity = new Category
            //{
            //    Name = createCategoryViewModel.CategoryName
            //};

            var validator = new CreateCategoryValidator();
            var validationResult = validator.Validate(createCategoryViewModel);

            if (!validationResult.IsValid)
            {
                throw new ValidateException(validationResult);
            }

            var result = new Result<int>();

            if(string.IsNullOrEmpty(createCategoryViewModel.CategoryName)) 
            {
                throw new Exception("KATEGORI ADI BOS BIRAKILAMAZ");
            }
            if(createCategoryViewModel.CategoryName.Length >100)
            {
                throw new Exception("KATEGORI ADI 100 KARAKTERDEN BUYUK OLAMAZ");            
            }
            var categoryEntity = _mapper.Map<CreateCategoryViewModel, Category>(createCategoryViewModel);

            //uretilen entity nesnesi kategori koleksiyonuna ekleniyor
            await _context.Categories.AddAsync(categoryEntity);
            await _context.SaveChangesAsync();
            //yansıtılan kategorinin idsi oluyor ve idyi getirmemizi sağlıyor...!!!
            //Db kayıt isleminden sonra herhangi bir sıkıntı yoksa bu kategori icin atanan entity geri doner...!!!
            result.Data = categoryEntity.Id;
            return result;
        }

        public async Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {

            var result = new Result<int>();
            //sarta baglı kategori getirmek icin kullanılır fake id durumu!!!

            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == deleteCategoryViewModel.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }
            var validator = new DeleteCategoryValidator();
            var validationResult = validator.Validate(deleteCategoryViewModel);

            if (!validationResult.IsValid)
            {
                throw new ValidateException(validationResult);
            }
            // veritabaninda kayitli kategoriyi getirelim.
            var existsCategory = await _context.Categories.FindAsync(deleteCategoryViewModel.Id);
            // silindi olarak isaretleyelim.
            existsCategory.IsDeleted = true;
            //guncellemeyi veritabanına yansitalim..!!
            _context.Categories.Update(existsCategory);
            await _context.SaveChangesAsync();
            result.Data= existsCategory.Id;

            return result;

        }

        public async Task<Result<int>> UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel)
        {
            var result =new Result<int>();
            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            var categoryExists = await _context.Categories.AnyAsync(x => x.Id == updateCategoryVievModel.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{updateCategoryVievModel} NUMARALI KATEGORI BULUNAMADI!");
            }

            var validator = new UpdateCategoryValidator();
            var validationResult = validator.Validate(updateCategoryVievModel);

            if (!validationResult.IsValid)
            {
                throw new ValidateException(validationResult);
            }

            var updatedCategory = _mapper.Map<UpdateCategoryVievModel, Category>(updateCategoryVievModel);

            //// veritabaninda kayitli kategoriyi getirelim.
            //var existsCategory = await _context.Categories.FindAsync(updateCategoryVievModel.Id);
            //// silindi olarak isaretleyelim.
            //existsCategory.Name = updateCategoryVievModel.CategoryName;

            //guncellemeyi veritabanına yansitalim..!!
            _context.Categories.Update(updatedCategory);
            await _context.SaveChangesAsync();
            result.Data = updatedCategory.Id;

            return result;

        }

    }
}
