using HepsiSef.API.Code;
using HepsiSef.Entity.App;
using HepsiSef.Model.Base;
using HepsiSef.Model.Request.Comment;
using HepsiSef.Model.Response.Comment;
using HepsiSef.Repository.App.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static HepsiSef.Model.Response.Comment.ShowRecipeComment;

namespace HepsiSef.API.Controllers
{
    [ValidateModel]
    public class CommentController : BaseController<CommentController>
    {
        private readonly ICommentRepository commentRepo;
      

        public CommentController(
            ICommentRepository commentRepo

            )
        {
            this.commentRepo = commentRepo;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Add([FromBody]AddRequest request)
        {

            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<Guid>();

            var item = new Comment
            { 
                IPAddress = request.IPAddress,
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                UserID = request.UserID,
                RecipeID = request.RecipeID,
                Message = request.Message

            };

            commentRepo.Add(item);
            response.Message = "Mesajınız başarıyla eklenmiştir.";
            response.Data = item.Id;

            return Ok(response);

        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Get([FromBody]IDRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<ShowRecipeComment>();
            response.Data = new ShowRecipeComment();

            var query = commentRepo.GetBy(x => x.RecipeID == request.Id);

            response.Data.Count = query.Count();

            response.Data.Items = query.OrderByDescending(x => x.CreateDate).Skip(0).Take(10).Select(x => new CommentMM
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                CreateTime = x.CreateDate

            }).ToList();

            return Ok(response);
        }

    }
}
