using HepsiSef.API.Code;
using HepsiSef.Model.Base;
using HepsiSef.Model.Response.Account;
using HepsiSef.Repository.SystemUser.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HepsiSef.API.Controllers
{
    [Authorize]
    public class AccountController : BaseController<AccountController>
    {
        private readonly IUserRepository userRepo;

        public AccountController(
            IUserRepository userRepo
            )
        {
            this.userRepo = userRepo;
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
    }
}
