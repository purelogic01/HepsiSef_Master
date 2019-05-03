using HepsiSef.API.Code;
using HepsiSef.Entity.App;
using HepsiSef.Model.Base;
using HepsiSef.Model.Request.Contact;
using HepsiSef.Model.Response;
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
    public class ContactController : BaseController<ContactController>
    {
        private readonly IContactRepository contactRepo;

        public ContactController(
            IContactRepository contactRepo
            )
        {
            this.contactRepo = contactRepo;
        }


        [HttpPost]
        public IActionResult QuickContact([FromBody]ContactRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);


            var response = new BaseResponse<Guid>();

            var item = new Contact
            {
                FullName = request.Name,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                Message = request.Message

            };
            contactRepo.Add(item);
            response.Message = "Kayıt başarıyla eklenmiştir.";
            response.Data = item.Id;

            return Ok(response);
            
        }

        }
}

