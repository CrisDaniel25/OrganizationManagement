using AutoMapper;
using AdminProSolutions.API.Controllers.Base;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Interfaces.Base;
using Microsoft.AspNetCore.Mvc;
using AdminProSolutions.Infrastructure.Helper;
using AdminProSolutions.API.Validations.Authentication;
using AdminProSolutions.Domain.Model;
using Microsoft.Extensions.Options;
using AdminProSolutions.Domain.Enums;

namespace AdminProSolutions.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class UsersController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UsersController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value; 
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var record = _unitOfWork.Users.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var record = _unitOfWork.Users.GetUserByIdIncludindGroups(id);
                if (record == null) return NotFound();
                var recordDto = _mapper.Map<UserDto>(record);
                return Ok(recordDto);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UserDto payload)
        {
            try
            {
                var validator = new UserValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                payload.CreatedUser = GetNameClaim();

                payload.CreatedDate = DateTime.Now;

                var user = _unitOfWork.Users.AddNewUser(payload);

                var userDto = _mapper.Map<UserDto>(user);

                _unitOfWork.Users.SyncRoles(userDto);
               
                return CreatedAtAction(nameof(Get), new { id = payload.UserId }, payload);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDto payload)
        {
            try
            {

                payload.UserId = id;

                var validator = new UserValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);
                
                var entity = _mapper.Map<Users>(payload);

                entity.UpdatedUser = GetNameClaim();

                entity.UpdatedDate = DateTime.Now;

                _unitOfWork.Users.UpdateUser(entity, payload.Password);

                return AcceptedAtAction(nameof(Get), new { id = payload.UserId }, payload);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Users record = new() { UserId = id };

                _unitOfWork.Users.Delete(record);

                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Users, PermissionAction.Create)]
        [HttpPost("{userId}/roles/{roleId}")]
        public IActionResult AddRole(int userId, int roleId)
        {
            try
            {
                GroupsUsers userRole = new()
                {
                    UserId = userId,
                    GroupId = roleId
                };

                _unitOfWork.Users.AddRole(userRole);

                return Ok(userRole);

            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Users, PermissionAction.Delete)]
        [HttpDelete("{userId}/roles/{roleId}")]
        public IActionResult DeleteRole(int userId, int roleId)
        {
            try
            {
                _unitOfWork.Users.DeleteRole(userId, roleId);

                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpPatch("ChangePassword")]
        public IActionResult ChangePassword([FromBody] UserDto payload)
        {
            try
            {
                payload.UserId = GetNameClaim();

                var validator = new ChangePasswordValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                byte[] currentPassword = _unitOfWork.Users.GetByUserIdHashPassword(payload.UserId);

                AuthorizationManager.CreatePasswordHash(payload.NewPassword, out byte[] passwordHash);

                var payloadMapped = _mapper.Map<Users>(payload);

                /* check if password is correct */
                if (!AuthorizationManager.VerifyPasswordHash(payload.Password, currentPassword)) return Forbid();

                var res = _unitOfWork.Users.ChangePasswod(payloadMapped, passwordHash);          

                return Ok(res);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Users, PermissionAction.Read)]
        [HttpGet("ad/{username}")]
        public IActionResult GetADInfo(string username)
        {
            try
            {
                var user = _unitOfWork.ActiveDirectory.GetUserInfo(username);

                if (user == null)
                    return NotFound();
                
                return Ok(user);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("checkUserName/{username}")]
        public IActionResult CheckUserName(string username)
        {
            try
            {
                var user = _unitOfWork.Users.CheckUserName(username);

                if (user != null)                
                    return Ok(false);
                
                return Ok(true);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

    }
}
