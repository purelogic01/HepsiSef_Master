using HepsiSef.API.Code;
using HepsiSef.Core.Extensions;
using HepsiSef.Entity.App;
using HepsiSef.Entity.Definition;
using HepsiSef.Model.Base;
using HepsiSef.Model.Request.Recipe;
using HepsiSef.Model.Response.Recipe;
using HepsiSef.Repository.App.Interface;
using HepsiSef.Repository.Definition.Interface;
using HepsiSef.Repository.SystemUser.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.API.Controllers
{
    [ValidateModel]
    public class RecipeController : BaseController<RecipeController>
    {  
        private readonly IRecipeRepository recipeRepo;
        private readonly IRecipeIngredientRepository ingredientRepo;
        private readonly IStepRepository stepRepo;
        private readonly IRecipeImageRepository imageRepo;
        private readonly IRecipeRateRepository rateRepo;
        private readonly IBookmarkRepository bookMarkRepo;
        private readonly IRecipeCategoryRepository categoryRepo;
        private readonly IUserRepository userRepo;
        private readonly IHostingEnvironment environment;
        private readonly IHttpContextAccessor accessor;

        public RecipeController(
            IRecipeRepository recipeRepo,
            IRecipeIngredientRepository ingredientRepo,
            IStepRepository stepRepo,
            IRecipeImageRepository imageRepo,
            IRecipeRateRepository rateRepo,
            IBookmarkRepository bookMarkRepo,
            IRecipeCategoryRepository categoryRepo,
            IUserRepository userRepo,
            IHostingEnvironment environment,
            IHttpContextAccessor accessor
            )
        {
            this.recipeRepo = recipeRepo;
            this.ingredientRepo = ingredientRepo;
            this.stepRepo = stepRepo;
            this.imageRepo = imageRepo;
            this.rateRepo = rateRepo;
            this.bookMarkRepo = bookMarkRepo;
            this.categoryRepo = categoryRepo;
            this.userRepo = userRepo;
            this.environment = environment;
            this.accessor = accessor;
        }

        [HttpPost]
        public IActionResult Detail([FromBody]SearcBySlug request)
        {

            var response = new BaseResponse<RecipeFocusedResponse>();
            response.Data = new RecipeFocusedResponse();

            if (!recipeRepo.Any(x => x.Slug == request.Slug))
                return NotFound();

            response.Data = recipeRepo.GetBy(x => x.Slug == request.Slug).Select(x => new RecipeFocusedResponse
            {
                Id = x.Id,
                Title = x.Title,
                Calories = x.Calories,
                CookingTime = x.CookingTime,
                Details = x.Details,
                Images = (x.Images.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Images.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new ImageMMM
                {
                    Id = y.Id,
                    Image = y.Image
                }).ToList() : new List<ImageMMM>()),

                Ingredients = (x.Ingredients.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Ingredients.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new IngredientMMM
                {
                    Id = y.Id,
                    Title = y.Title
                }).ToList() : new List<IngredientMMM>()),

                Steps = (x.Steps.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Steps.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new StepMMMM
                {
                    Id = y.Id,
                    Title = y.Title
                }).ToList() : new List<StepMMMM>()),

                PrepareTime = x.PrepareTime,
                ServiceCount = x.ServiceCount,
                Slug = x.Slug,
                UserID = x.UserID,
                Username = x.User.Username,
                CreateDate = x.CreateDate,
                AvarageRate = x.Rates.Any(y => y.RecipeID == x.Id) ? x.Rates.Average(y => y.Rate) : 0
            }).ToList().FirstOrDefault();

            return Ok(response);
        }

        [HttpPost]
        public IActionResult All([FromBody]RecipeAllRequest request)
        {
            var response = new BaseResponse<RecipeAllResponse>();
            response.Data = new RecipeAllResponse();
            

            var query = recipeRepo.GetBy(x => true);

            if (request.CategoryID.HasValue)
                query = query.Where(x => x.RecipeCategories.Any(y => y.CategoryID == request.CategoryID.Value));

         
            if (request.CookingTime.HasValue)
                query = query.Where(x => x.CookingTime <= request.CookingTime);

            if (request.ServiceCount.HasValue)
                query = query.Where(x => x.ServiceCount == request.ServiceCount);

            response.Data.Count = query.Count();
            response.Data.Items = query.OrderByDescending(x => x.CreateDate).Skip(request.Skip).Take(10).Select(x => new RecipeMM {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Images = (x.Images.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Images.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new ImageMM
                {
                    Id = y.Id,
                    Image = y.Image
                }).ToList() : new List<ImageMM>()),
                Rates = (x.Rates.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Rates.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new RateMM {
                    Id = y.Id,
                    Rate = y.Rate
                }).ToList() : new List<RateMM>()),



                Slug = x.Slug,
                UserID = x.UserID,
                Username = x.User.Username,
                CreateDate = x.CreateDate,
                Rate = 0,
                AvarageRate = x.Rates.Any(y => y.RecipeID == x.Id) ? x.Rates.Average(y => y.Rate) : 0


            }).ToList();

            return Ok(response);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ClientUpload(List<IFormFile> files)
        {

            // var request = HttpContext.Request.Form.Files;
            try
            {
                List<string> uploadedFiles = new List<string>();

                //var result = new List<RecipeImage>();
                foreach (var file in HttpContext.Request.Form.Files)
                {
                    var uploadPath = Path.Combine(environment.WebRootPath, "uploads");
                    string FileName = Guid.NewGuid().ToString();
                    string Extension = Path.GetExtension(file.FileName).ToLower();

                    List<string> AllowedExtensions = new List<string>
                    {
                        ".jpg",
                        ".png",
                        ".jpeg"
                    };

                    if (AllowedExtensions.Any(x => x == Extension))
                    {
                        var filePath = Path.Combine(uploadPath, FileName + Extension);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            uploadedFiles.Add($"{accessor.HttpContext.Request.Scheme}://{accessor.HttpContext.Request.Host}/uploads/{FileName + Extension}");
                        }
                    }

                }
                return Ok(uploadedFiles);
            }
            catch
            {
                return BadRequest();
            }
        }
        
        [HttpPost]
        [Authorize]
        public ActionResult Create([FromBody]RecipeCreateRequest request)
        {

            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<Guid>();
            if (recipeRepo.Any(x => x.Title == request.Title))
            {
                response.SetMessage("Bu yemek tarifi kayıtlı");
                return Ok(response);

            }

            var item = new Recipe
            {
                Title = request.Title,
                Details = request.Details,
                UserID = CurrentUserID,
                Slug = request.Title.ToUrlSlug(),
                ServiceCount = request.ServiceCount,
                Calories = request.Calories,
                PrepareTime = request.PrepareTime,
                CookingTime = request.CookingTime,
                Ingredients = request.Ingredients.Select(y => new RecipeIngredient
                {
                    Title = y.Title
                }).ToList(),
                Steps = request.Steps.Select(y => new Entity.Definition.Step
                {
                    Title = y.Title
                }).ToList(),
                Images = request.Images.Select(y => new RecipeImage
                {
                    Image = y.image
                }).ToList(),
                RecipeCategories = request.Categories.Select(y => new RecipeCategory
                {
                    CategoryID = y.CategoryID
                }).ToList()

            };

            recipeRepo.Add(item);
            response.Data = item.Id;
            response.Message = "Kayıt başarıyla eklenmiştir.";

            return Ok(response);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Moderator")]
        public ActionResult Get([FromBody]IDRequest request)
        {

            var recipe = recipeRepo.GetById(request.Id);
            var response = new BaseResponse<bool>();

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete([FromBody]IDRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<bool>();
            var item = recipeRepo.GetById(request.Id);
            if (item == null)
            {
                return NotFound();
            }

            var ingredients = ingredientRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (ingredients.Any())
                ingredientRepo.DeleteRange(ingredients);

            var steps = stepRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (steps.Any())
                stepRepo.DeleteRange(steps);

            var images = imageRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (images.Any())
                imageRepo.DeleteRange(images);

            var recipeCategory = categoryRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (recipeCategory.Any())
                categoryRepo.DeleteRange(recipeCategory);

            var rates = rateRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (rates.Any())
                rateRepo.DeleteRange(rates);

            var bookmarks = bookMarkRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (bookmarks.Any())
                bookMarkRepo.DeleteRange(bookmarks);




            recipeRepo.Delete(item);
            response.Message = "Yemek tarifi başarıyla silinmiştir.";

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult AddRate([FromBody]RateRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<bool>();
            
            if ( rateRepo.Any(x => x.RecipeID == request.RecipeID  && x.UserID == CurrentUserID))
            {
                response.SetMessage("Daha önce oylama yapmışsınız");
                return Ok(response);
            }


            var item = new RecipeRate
            {
                RecipeID = request.RecipeID,
                Rate = request.Rate,
                Status = Status.NotAppproved

            };

            if (User.Identity.IsAuthenticated)
            {
                item.UserID = CurrentUserID;
            }

            rateRepo.Add(item);
            response.Message = "Değerlendirme başarıyla eklendi";
            decimal avarageRate = 0;
            List<RecipeRate> ratedRecipe = new List<RecipeRate>();
            ratedRecipe = rateRepo.GetBy(x => x.RecipeID == request.RecipeID).ToList();
            foreach (var aa in ratedRecipe)
            {

                avarageRate += aa.Rate;
            }

            avarageRate = avarageRate / ratedRecipe.Count();
            var ChangeAvarageRate = recipeRepo.FirstOrDefaultBy(x => x.Id == request.RecipeID);

            ChangeAvarageRate.AvarageRate = avarageRate;

            recipeRepo.Update(ChangeAvarageRate);
            
                

            return Ok(response);
        }

        [HttpPost]
        public IActionResult MostRatedRecipe()
        {
            var response = new BaseResponse<RecipeAllResponse>();
            response.Data = new RecipeAllResponse();

           

            response.Data.Items = recipeRepo.GetBy(x => true).OrderByDescending(x => x.AvarageRate).Take(2).Select(x => new RecipeMM
            {
                Id = x.Id,
                Title = x.Title,
                Details = x.Details,
                Images = (x.Images.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Images.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new ImageMM
                {
                    Id = y.Id,
                    Image = y.Image
                }).ToList() : new List<ImageMM>()),
                Rates = (x.Rates.Any(y => y.RecordStatus == RecordStatus.Active) ? x.Rates.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new RateMM
                {
                    Id = y.Id,
                    Rate = y.Rate
                }).ToList() : new List<RateMM>()),
                Slug = x.Slug,
                UserID = x.UserID,
                Username = x.User.Username,
                CreateDate = x.CreateDate,
                Rate = 0,
                AvarageRate = x.AvarageRate


            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        [Authorize]
        public IActionResult ToggleBookmark([FromBody]IDRequest request)
        {
            var response = new BaseResponse<bool>();

            var control = bookMarkRepo.FirstOrDefaultBy(x => x.UserID == CurrentUserID && x.RecipeID == request.Id  );

            if (control != null )
            {
                bookMarkRepo.Delete(control);
            }
            else
            {
                bookMarkRepo.Add(new Bookmark
                {
                    UserID = CurrentUserID,
                    RecipeID = request.Id
                });
                response.Data = true;
            }

            return Ok(response);

        }

        [HttpPost]
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult Update([FromBody]RecipeUpdateRequest request)
        {


            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<bool>();
            var item = recipeRepo.GetById(request.Id);

            if (item == null)
            {

                return NotFound();

            }



            var ingredients = ingredientRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (ingredients.Any())
                ingredientRepo.DeleteRange(ingredients);

            var steps = stepRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (steps.Any())
                stepRepo.DeleteRange(steps);

            var images = imageRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (images.Any())
                imageRepo.DeleteRange(images);

            var recipeCategory = categoryRepo.GetBy(x => x.RecipeID == item.Id).ToList();
            if (recipeCategory.Any())
                categoryRepo.DeleteRange(recipeCategory);


            item.Title = request.Title;
            item.Details = request.Details;
            item.CookingTime = request.CookingTime;
            item.Calories = request.Calories;
            item.PrepareTime = request.PrepareTime;
            item.ServiceCount = request.ServiceCount;



            item.Ingredients = request.Ingredients.Select(y => new RecipeIngredient
            {
                Title = y.Title
            }).ToList();

            item.Steps = request.Steps.Select(y => new Entity.Definition.Step
            {
                Title = y.Title
            }).ToList();


            item.Images = request.Images.Select(y => new RecipeImage
            {
                Image = y.Image
            }).ToList();


            item.RecipeCategories = request.Categories.Select(y => new RecipeCategory
            {
                CategoryID = y.CategoryID
            }).ToList();

            recipeRepo.Update(item);

            response.Message = "Kayıt başarıyla güncellenmiştir.";
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Search([FromBody]SearchRecipe request)
        {
            var response = new BaseResponse<RecipeAllResponse>();
            response.Data = new RecipeAllResponse();

            var query = recipeRepo.GetBy(x => true);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm) && request.SearchTerm.Length >= 3)
            {
                query = recipeRepo.GetBy(x => x.Title.Contains(request.SearchTerm) || x.Slug.Contains(request.SearchTerm));

                response.Data.Items = query.OrderByDescending(p => p.CreateDate).Take(10).Select(p => new RecipeMM
                {
                    Id = p.Id,
                    Title = p.Title,
                    Details = p.Details,
                    Images = (p.Images.Any(y => y.RecordStatus == RecordStatus.Active) ? p.Images.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new ImageMM
                    {
                        Id = y.Id,
                        Image = y.Image
                    }).ToList() : new List<ImageMM>()),
                    Rates = (p.Rates.Any(y => y.RecordStatus == RecordStatus.Active) ? p.Rates.Where(y => y.RecordStatus == RecordStatus.Active).Select(y => new RateMM
                    {
                        Id = y.Id,
                        Rate = y.Rate
                    }).ToList() : new List<RateMM>()),



                    Slug = p.Slug,
                    UserID = p.UserID,
                    Username = p.User.Username,
                    CreateDate = p.CreateDate,
                    Rate = 0,
                    AvarageRate = p.Rates.Any(y => y.RecipeID == p.Id) ? p.Rates.Average(y => y.Rate) : 0


                }).ToList();





                return Ok(response);
            }
            else
                return NotFound(); 

                
                    
        }

      }
}
