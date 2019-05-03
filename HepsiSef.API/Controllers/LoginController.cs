using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HepsiSef.Core.Security;
using HepsiSef.Model.Base;
using HepsiSef.Model.Request;
using HepsiSef.Model.Response;
using HepsiSef.Repository.SystemUser.Interface;
using HepsiSef.API.Code;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using HepsiSef.Entity.SystemUser;
using System.Web;
using HepsiSef.Model;
using HepsiSef.Model.Request.User;

namespace HepsiSef.API.Controllers
{
    [ValidateModel]
    public class LoginController : BaseController<LoginController>
    {
        private readonly IUserRepository userRepo;
        private readonly IForgatPasswordRepository forgatPasswordRepo;

        public LoginController(
            IUserRepository userRepo,
            IForgatPasswordRepository forgatPasswordRepo
            )
        {
            this.userRepo = userRepo;
            this.forgatPasswordRepo = forgatPasswordRepo;
        }

        [HttpPost]
        public ActionResult<BaseResponse<IDRequest>> GetUser( IDRequest request)
        {
            var response = new BaseResponse<UsernameResponse>();
            response.Data = new UsernameResponse();


            if (userRepo.Any(x => x.Id == request.Id))
            {
                return Ok(response);
            }else{
                response.SetMessage("Hatalı kullanıcı adı ya da şifre girdiniz.");
                return Ok(response);
            }
        }

        [HttpPost]
        public ActionResult<BaseResponse<SignInResponse>> SignIn([FromBody]SignInRequest request)
        {
            var response = new BaseResponse<SignInResponse>();
            response.Data = new SignInResponse();

            request.Password = new Cryptography().EncryptString(request.Password);
            var user = userRepo.FirstOrDefaultBy(x => x.Email == request.Email && x.Password == request.Password);

            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("userID",user.Id.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString()),
                    new Claim("firstName",user.FirstName),
                    new Claim("lastName",user.LastName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Data.Token = tokenHandler.WriteToken(token);
            }
            else
            {
                response.SetMessage("Hatalı kullanıcı adı ya da şifre girdiniz.");
            }

            return Ok(response);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult SignUp([FromBody]SignUpRequest request)
        {
            var response = new BaseResponse<SignInResponse>();
            response.Data = new SignInResponse();

            if (userRepo.Any(x => x.Email == request.Email))
            {
                response.SetMessage("Bu eposta adresi kayıtlı");
            }
            else if (userRepo.Any(x => x.Username == request.Username))
            {
                response.SetMessage("Bu kullanıcı adı kayıtlı");
            }
            else
            {
                var user = new User
                {
                    Username = request.Username,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Password = new Cryptography().EncryptString(request.Password)
                };
                userRepo.Add(user);


                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes("this is my custom Secret key for authnetication");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Username),
                    new Claim("userID",user.Id.ToString()),
                    new Claim("firstName",user.FirstName),
                    new Claim("lastName",user.LastName)
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                response.Data.Token = tokenHandler.WriteToken(token);
            }

            return Ok(response);
        }


        [HttpPost]
        public ActionResult ForgetPassword([FromBody]ForgetPasswordRequest request)
        {
            var control = userRepo.FirstOrDefaultBy(x => x.Username == request.Username && x.Email == request.Email);
            var response = new BaseResponse<bool>();

            if (control == null)
            {
                response.SetMessage("Sistemde kayıtlı böyle bir kullanıcı bulunamadı.");
                return Ok(response);
            }

            Random rnd = new Random();
            int passwordKey = rnd.Next(10000000, 99999999);
            string passwordKeyString = Convert.ToString(passwordKey);
            passwordKeyString = new Cryptography().EncryptString(passwordKeyString);

            var forgotPassword = new ForgatPassword();
            forgotPassword.UserID = control.Id;
            forgotPassword.Key = passwordKeyString;
            forgatPasswordRepo.Add(forgotPassword);


            var resetLink = "http://localhost:5001/Login/RePassword?Code=" + HttpUtility.UrlEncode(passwordKeyString);


            MailManager.Send(resetLink, control.Email);

            return Ok(response);
        }

        [HttpPost]
        public ActionResult RePassword([FromBody]RePassword request)
        {
            var response = new BaseResponse<Boolean>();
            var control = forgatPasswordRepo.FirstOrDefaultBy(x => x.Key == request.Code);


            if (control == null)
            {
                response.SetMessage("Geçersiz şifre sıfırlama kodu.");
                return Ok(response);
            }

            var user = userRepo.FirstOrDefaultBy(y => y.Id == control.UserID);


            if (user == null)
            {
                response.SetMessage("Kullanıcı kayıtı bulunamadıç");
                return NotFound(response);
            }



            user.Password = new Cryptography().EncryptString(request.Password);
            userRepo.Update(user);


            response.Message = "Şifreniz başarıyla değiştirilmiştir, yeni şifrenizi kullanarak giriş yapabilirsiniz.";

            return Ok(response);
        }





    }
}
