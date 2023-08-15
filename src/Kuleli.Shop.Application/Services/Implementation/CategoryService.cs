using AutoMapper;
using Kuleli.Shop.Application.Behaviors;
using Kuleli.Shop.Application.Exceptions;
using Kuleli.Shop.Application.Model.Dtos;
using Kuleli.Shop.Application.Model.RequestModels;
using Kuleli.Shop.Application.Repostories;
using Kuleli.Shop.Application.Services.Absraction;
using Kuleli.Shop.Application.Validators.Categories;
using Kuleli.Shop.Application.Wrapper;
using Kuleli.Shop.Domain.Entities;

namespace Kuleli.Shop.Application.Services.Implementation
{
    public class CategoryService : ICategoryServices
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Category> _repository;

        public CategoryService(IMapper mapper, IRepository<Category> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        //Automapper : Bir modeli baska bir modele cevirmek icin kullanılıyor.

        [PerformanceBehavior]
        public async Task<Result<List<CategoryDto>>> GetAllCategories()
        {
            var result = new Result<List<CategoryDto>>();

            //var categories = await _context.Categories.ToListAsync();

            ////_mapper.Map<T1,T2> T1 tipindeki kaynak objeyi T2 tipindeki hedef objeye cevirir.
            //var categoryDtos= _mapper.Map<List<Category>,List<CategoryDto>>(categories);
            var categoryEntities = await _repository.GetAllAsync();
            var categoryDtos = _mapper.Map<List<Category>, List<CategoryDto>>(categoryEntities);
            result.Data = categoryDtos;

            //var categoryDtos = await _context.Categories.ProjectTo<CategoryDto>
            //(_mapper.ConfigurationProvider).ToListAsync();

            return result;
        }


        [ValidationBehavior(typeof(GetCategoryByIdValidator))]
        public async Task<Result<CategoryDto>> GetCategoryById(GetCategoryByIdViewModel getCategoryByIdViewModel)
        {
            //var categoryEntity = await _context.Categories.FindAsync(id);
            //var categoryDto = new CategoryDto

            //{
            //    Id = id,
            //    Name = categoryEntity.Name,
            //};
            var result = new Result<CategoryDto>();



            var categoryExists = await _repository.AnyAsync(x => x.Id == getCategoryByIdViewModel.Id);
            if (!categoryExists)
            {
                throw new Exception($"{getCategoryByIdViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }
            //var categoryDto = await _context.Categories.ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
            //    .FirstOrDefaultAsync(x => x.Id == getCategoryByIdViewModel.Id);
            var categoryEntity = await _repository.GetById(getCategoryByIdViewModel.Id);
            var categoryDto = _mapper.Map<Category, CategoryDto>(categoryEntity);
            result.Data = categoryDto;
            return result;
        }


        [ValidationBehavior(typeof(CreateCategoryValidator))]
        public async Task<Result<int>> CreateCategory(CreateCategoryViewModel createCategoryViewModel)
        {

            // Yeni bir kategori entity nesnesi
            //var categoryEntity = new Category
            //{
            //    Name = createCategoryViewModel.CategoryName
            //};           

            var result = new Result<int>();

            var categoryEntity = _mapper.Map<CreateCategoryViewModel, Category>(createCategoryViewModel);

            //uretilen entity nesnesi kategori koleksiyonuna ekleniyor
            //await _context.Categories.AddAsync(categoryEntity);
            //await _context.SaveChangesAsync();
            //yansıtılan kategorinin idsi oluyor ve idyi getirmemizi sağlıyor...!!!
            //Db kayıt isleminden sonra herhangi bir sıkıntı yoksa bu kategori icin atanan entity geri doner...!!!
            await _repository.Add(categoryEntity);
            result.Data = categoryEntity.Id;
            return result;
        }


        [ValidationBehavior(typeof(DeleteCategoryValidator))]
        public async Task<Result<int>> DeleteCategory(DeleteCategoryViewModel deleteCategoryViewModel)
        {

            var result = new Result<int>();



            //sarta baglı kategori getirmek icin kullanılır fake id durumu!!!

            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            //var categoryExists = await _context.Categories.AnyAsync(x => x.Id == deleteCategoryViewModel.Id);
            var categoryExists = await _repository.AnyAsync(x => x.Id == deleteCategoryViewModel.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{deleteCategoryViewModel.Id} NUMARALI KATEGORI BULUNAMADI!");
            }

            // veritabaninda kayitli kategoriyi getirelim.
            //var existsCategory = await _context.Categories.FindAsync(deleteCategoryViewModel.Id);
            //var existsCategory = await _repository.GetById(deleteCategoryViewModel.Id);
            await _repository.Delete(deleteCategoryViewModel.Id);
            // silindi olarak isaretleyelim.
            //existsCategory.IsDeleted = true;
            ////guncellemeyi veritabanına yansitalim..!!
            //_context.Categories.Update(existsCategory);
            //await _context.SaveChangesAsync();


            result.Data = deleteCategoryViewModel.Id;

            return result;

        }


        [ValidationBehavior(typeof(UpdateCategoryValidator))]
        public async Task<Result<int>> UpdateCategory(UpdateCategoryVievModel updateCategoryVievModel)
        {
            var result = new Result<int>();


            //gonderilen id bilgisine karsilik gelen bir kategori var mi??
            //var categoryExists = await _context.Categories.AnyAsync(x => x.Id == updateCategoryVievModel.Id);
            var categoryExists = await _repository.AnyAsync(x => x.Id == updateCategoryVievModel.Id);
            if (!categoryExists)
            {
                throw new NotFoundException($"{updateCategoryVievModel} NUMARALI KATEGORI BULUNAMADI!");
            }


            var updatedCategory = _mapper.Map<UpdateCategoryVievModel, Category>(updateCategoryVievModel);

            //// veritabaninda kayitli kategoriyi getirelim.
            //var existsCategory = await _context.Categories.FindAsync(updateCategoryVievModel.Id);
            //// silindi olarak isaretleyelim.
            //existsCategory.Name = updateCategoryVievModel.CategoryName;

            //guncellemeyi veritabanına yansitalim..!!
            //_context.Categories.Update(updatedCategory);
            //await _context.SaveChangesAsync();
            _repository.Update(updatedCategory);
            result.Data = updatedCategory.Id;

            return result;

        }

    }
}
