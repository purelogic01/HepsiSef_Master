using HepsiSef.API.Code;
using HepsiSef.Core.Extensions;
using HepsiSef.Entity.App;
using HepsiSef.Model.Base;
using HepsiSef.Model.Request.Category;
using HepsiSef.Model.Response.Category;
using HepsiSef.Repository.App.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiSef.API.Controllers
{
    [ValidateModel]
    public class CategoryController : BaseController<CategoryController>
    {
        private readonly ICategoryRepository categoryRepo;
        //private readonly CategoryNonBaseEntityRepository categoryNonBaseEntityRepository;

        public CategoryController(
            ICategoryRepository categoryRepo
            //CategoryNonBaseEntityRepository categoryNonBaseEntityRepository
            )
        {
            this.categoryRepo = categoryRepo;
            //this.categoryNonBaseEntityRepository = categoryNonBaseEntityRepository;
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        private List<CategoryMM> WriteChilds(List<CategoryMM> items, Guid? ParentID)
        {
            List<CategoryMM> temp = new List<CategoryMM>();

            temp = items.Where(x => x.ParentID == ParentID).ToList();
            foreach (var item in temp)
            {
                if (items.Any(x => x.ParentID == item.value))
                {
                    item.children = WriteChilds(items, item.value);
                    if (!item.children.Any())
                        item.children = null;

                }
                else
                    item.children = null;

            }

            return temp;
        }

        [HttpPost]
        public IActionResult AllCategories()
        {
            var response = new BaseResponse<CategoryAllResponse2>();


            var temp = categoryRepo.GetBy(x => true).Select(x => new CategoryMM
            {
                value = x.Id,
                ParentID = x.ParentID,
                label = x.Title,
                children = new List<CategoryMM>()
            }).ToList();

            var mainCategories = temp.Where(x => !x.ParentID.HasValue).ToList();


            response.Data = new CategoryAllResponse2();
            response.Data.Items = WriteChilds(temp, null);
            

            return Ok(response);
        }


        [HttpPost]
        public IActionResult All([FromBody]CategoryAllRequest request)
        {
            var response = new BaseResponse<CategoryAllResponse>();

            var query = categoryRepo.GetBy(x => true);

            if (!string.IsNullOrWhiteSpace(request.SearchTerm) && request.SearchTerm.Length > 3)
            {
                query = categoryRepo.GetBy(x => x.Title.Contains(request.SearchTerm) || x.Slug.Contains(request.SearchTerm));
            }

            response.Data = new CategoryAllResponse();
            response.Data.Items = query.ToList();

            return Ok(response);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([FromBody]CategoryCreateRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<Guid>();
            if (categoryRepo.Any(x => x.Title == request.Title))
            {
                response.SetMessage("Bu kategori adı kayıtlı");
                return Ok(response);

            }
            var item = new Category
            {
                Description = request.Description,
                Title = request.Title,
                ParentID = request.ParentID,
                Slug = request.Title.ToUrlSlug()

            };
            categoryRepo.Add(item);
            response.Message = "Kayıt başarıyla eklenmiştir.";
            response.Data = item.Id;

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Get([FromBody]IDRequest request)
        {
            var categroy = categoryRepo.GetById(request.Id);
            var response = new BaseResponse<bool>();

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteFromCategories([FromBody]IDRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<bool>();
            var item = categoryRepo.GetById(request.Id);
            if (item == null)
            {
                return NotFound();
            }

            categoryRepo.Delete(item);
            response.Message = "Kategori başarıyla silinmiştir.";

            return Ok(response);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Update([FromBody]CategoryUptadeRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<bool>();
            var want = categoryRepo.FirstOrDefaultBy(x => x.Title == request.Title);

            if (want == null)
            {
                response.SetMessage("Bu kategori mevcut değildir");
                return Ok(response);
            }


            var item = categoryRepo.GetById(want.Id);

            if (item == null)
            {

                return NotFound();

            }

            item.Title = request.Title;
            item.Description = request.Description;
            categoryRepo.Update(item);
            response.Message = "güncelleme işlemi gerçekleşti";
            //response.Data = item.Id;

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Random()
        {
            var response = new BaseResponse<CategoryAllResponse>();

            response.Data = new CategoryAllResponse();

            List<Category> CategoryList = new List<Category>();

            CategoryList = categoryRepo.GetAll();

            var list = CategoryList.PickRandom(6);

            response.Data.Items = list.ToList();

            return Ok(response);
        }
    }
}
