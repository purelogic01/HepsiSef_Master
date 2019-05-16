using HepsiSef.API.Code;
using HepsiSef.Entity.App;
using HepsiSef.Model;
using HepsiSef.Model.Base;
using HepsiSef.Model.Helpers;
using HepsiSef.Model.Request.Contact;
using HepsiSef.Model.Request.NewsLetter;
using HepsiSef.Model.Response;
using HepsiSef.Model.Response.Contact;
using HepsiSef.Repository.App.Interface;
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

    [ValidateModel]
    public class ContactController : BaseController<ContactController>
    {
        private readonly IContactRepository contactRepo;
        private readonly IUserRepository userRepo;
        private readonly INewsletterRepository newsletterRepo;

        public ContactController(
            IContactRepository contactRepo,
            IUserRepository userRepo,
            INewsletterRepository newsletterRepo
            )
        {
            this.contactRepo = contactRepo;
            this.userRepo = userRepo;
            this.newsletterRepo = newsletterRepo;
        }


        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Add([FromBody]ContactRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<Guid>();

            if (!await GoogleRecaptchaHelper.IsReCaptchaPassedAsync(request.CaptchaToken, "6Ldt7KEUAAAAAL_gnq4ORX4NrKDK3qegm1TSyBAg"))
            {
                response.Message = "Lütfen robot olmadığınızı doğrulayın.";
                return Ok(response);
            }

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

            var MailBody = "HepsiSef bize ulaşın" + "\n " + "isim:" + " " + item.FullName + "\n" + "email:" + " " + item.Email + "\n" + "telefon no:" + " " + item.PhoneNumber + "\n" + "mesaj:" + " " + item.Message;

            List<AdminMailMM> Admins = new List<AdminMailMM>();
            Admins = userRepo.GetBy(x => x.Role == Role.Admin).Select(x => new AdminMailMM
            {
                Email = x.Email

            }).ToList();

            foreach (var mail in Admins)
            {
                MailManager.Send(MailBody, mail.Email);
            }

            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult NewsLetter([FromBody]AddRequest request)
        {
            if (!ModelState.IsValid)
                return Ok(ModelState);

            var response = new BaseResponse<Guid>();

            var item = new Newsletter
            {
               Email = request.Email,
            };

            newsletterRepo.Add(item);
            response.Message = "Kayıt başarıyla eklenmiştir.";
            response.Data = item.Id;

            var MailBody = "HepsiSef bize ulaşın + E-Bülten" + "\n "  + " " + item.Email + "\n" ;

            List<AdminMailMM> Admins = new List<AdminMailMM>();
            Admins = userRepo.GetBy(x => x.Role == Role.Admin).Select(x => new AdminMailMM
            {
                Email = x.Email

            }).ToList();

            foreach (var mail in Admins)
            {
                MailManager.Send(MailBody, mail.Email);
            }

            return Ok(response);
        }
    }
}

