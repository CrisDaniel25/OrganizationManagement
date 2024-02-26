using AutoMapper;
using AdminProSolutions.API.Controllers.Base;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.API.Validations.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Model;
using AdminProSolutions.Infrastructure.Helper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace AdminProSolutions.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class AuthenticationController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuthenticationController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginRequestDto payload)
        {
            try
            {
                var validator = new LoginValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                Users? user = _unitOfWork.Users.GetUserByUserNameIncludindGroups(payload.UserName);
                    
                // check if username exists
                if (user == null) return NotFound();

                if (user.GroupUsers.Count < 1) return Forbid();

                if (user.UserStatus == UserStatusTypeEnum.LOCKED) return StatusCode(StatusCodes.Status423Locked);

                if (user.TypeAutentication == TypeAuthentication.EX)
                {
                    // check if password is correct
                    var verified = AuthorizationManager.VerifyPasswordHash(payload.Password, user.HashPassword);
                    
                    if (!verified)
                    {
                        //UPDATE FAILED QTY OF USER
                        user.PasswordFailedQuantity++;
                        _unitOfWork.Users.Update(user);
                        if (user.PasswordFailedQuantity >= this._appSettings.MaxPasswordFailedQuantity)
                        {
                            if (user.UserStatus != UserStatusTypeEnum.LOCKED)
                            {
                                user.UserStatus = UserStatusTypeEnum.LOCKED;
                                user.PasswordFailedQuantity = 0; //RESET
                                _unitOfWork.Users.Update(user);
                            }
                            return StatusCode(StatusCodes.Status423Locked); //LOCKED CODE
                        }
                        else
                        {
                            return Forbid();
                        }
                    }
                }
                else
                {
                    if (user.TypeAutentication == TypeAuthentication.AD)
                    {
                        // check if password is correct
                        if (!_unitOfWork.ActiveDirectory.VerifyPassword(payload.UserName, payload.Password)) return Forbid();
                    }
                }

                var response = _unitOfWork.Authetication.Login(payload.UserName, payload.Password, user);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost("Register/User")]
        public IActionResult Register([FromBody] RegisterRequestDto payload)
        {
            try
            {
                var validator = new RegisterValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var newPayload = _mapper.Map<Users>(payload);

                var response = _unitOfWork.Authetication.Register(newPayload);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
