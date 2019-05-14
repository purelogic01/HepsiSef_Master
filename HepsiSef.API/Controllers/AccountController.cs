using HepsiSef.API.Code;
using HepsiSef.Model.Base;
using HepsiSef.Model.Response.Account;
using HepsiSef.Model.Response.Recipe;
using HepsiSef.Repository.App.Interface;
using HepsiSef.Repository.Definition.Interface;
using HepsiSef.Repository.SystemUser.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HepsiSef.Core.Enums.Enums;

namespace HepsiSef.API.Controllers
{
    [Authorize]
    public class AccountController : BaseController<AccountController>
    {
        private readonly IUserRepository userRepo;
        private readonly IBookmarkRepository bookMarkRepo;
        private readonly IRecipeRepository recipeRepo;

        public AccountController(
            IUserRepository userRepo,
            IBookmarkRepository bookMarkRepo, 
            IRecipeRepository recipeRepo

            )
        {
            this.userRepo = userRepo;
            this.bookMarkRepo = bookMarkRepo;
            this.recipeRepo = recipeRepo;

        }

        [HttpPost]
        public IActionResult Get()
        {
            var response = new BaseResponse<AccountGetResponse>();
            var user = userRepo.GetById(CurrentUserID);

            response.Data = new AccountGetResponse
            {
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = user.Role

            };

            return Ok(response);
        }
        [Authorize]
        [HttpPost]
        public IActionResult ToggleBookmark()
        {
            var response = new BaseResponse<RecipeAllResponse>();
            response.Data = new RecipeAllResponse();

            if (!bookMarkRepo.Any(x => x.UserID == CurrentUserID))
            {
                response.SetMessage("İşaretlenmiş yemek tarifiniz bulunmamaktadır");
                return Ok(response);

            }

            List<Guid> recipeIDs = new List<Guid>();

            
            recipeIDs = bookMarkRepo.GetBy(x => x.UserID == CurrentUserID).Select(x => x.RecipeID).ToList();
            //response.Data.Items = null;

            foreach (Guid recipeID in recipeIDs)
            {
                response.Data.Items = recipeRepo.GetBy(p=> p.Id == recipeID).OrderByDescending(p => p.CreateDate).Take(10).Select(p => new RecipeMM
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
            }


            return Ok(response);
        }

    }
}
