using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using AdminProSolutions.API.Controllers.Base;
using AdminProSolutions.Domain.Dtos.Authentication;
using AdminProSolutions.Domain.Entities.Authentication;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Model;
using AdminProSolutions.API.Validations.Authentication;

namespace AdminProSolutions.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class RolesController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RolesController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
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
                var res = _unitOfWork.Groups.GetAll();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Read)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var res = _unitOfWork.Groups.GetById(id);
                var resDto = _mapper.Map<GroupsDto>(res);
                return Ok(resDto);

            }
            catch (Exception ex)
            {                
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Create)]
        [HttpPost]
        public IActionResult Create([FromBody] GroupsDto payload)
        {
            try
            {
                var validator = new RoleValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var permissions = payload.AccessTypes;

                var users = payload.UsersAlt;

                var entity = _mapper.Map<Groups>(payload);

                entity.CreatedUser = GetNameClaim();

                entity.CreatedDate = DateTime.Now;

                _unitOfWork.Groups.Add(entity);
                _unitOfWork.Groups.SyncRoles(GetNameClaim(), entity.GroupId, permissions);
                _unitOfWork.Groups.SyncUsers(GetNameClaim(), entity.GroupId, users);

                return Ok();
            }
            catch (Exception ex)
            {                
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Update)]
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GroupsDto payload)
        {
            try
            {
                var validator = new RoleValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                payload.GroupId = id;                
                
                var permissions = payload.AccessTypes;
                
                var users = payload.UsersAlt;
                
                payload.UpdatedUser = GetNameClaim();
                
                payload.UpdatedDate = DateTime.Now;
                
                var entity = _mapper.Map<Groups>(payload);
                
                _unitOfWork.Groups.Update(entity);
                _unitOfWork.Groups.SyncRoles(GetNameClaim(), payload.GroupId, permissions);
                _unitOfWork.Groups.SyncUsers(GetNameClaim(), payload.GroupId, users);

                return Accepted();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Delete)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Groups group = new()
                {
                    GroupId = id,
                    UpdatedUser = GetNameClaim()
                };

                _unitOfWork.Groups.Delete(group);

                return Accepted();
            }
            catch (Exception ex)
            {                
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Read)]
        [HttpGet("{id}/users")]
        public IActionResult GetUsers(int? id)
        {
            try
            {
                var res = _unitOfWork.Groups.GetUsers(id);
                return Accepted(res.Select(e => _mapper.Map<UserDto>(e.User)).ToList());
            }
            catch (Exception ex)
            {                
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Groups, Domain.Enums.PermissionAction.Read)]
        [HttpGet("{id}/permissions")]
        public IActionResult GetPermissions(int? id)
        {
            try
            {
                var res = _unitOfWork.Groups.GetPermissions(id);
                return Accepted(res);
            }
            catch (Exception ex)
            {                
                return DefaultError(ex);
            }
        }

        [HttpGet("checkName/{name}")]
        public IActionResult CheckName(string name)
        {
            try
            {
                var res = _unitOfWork.Groups.CheckName(name);

                if (res != null)
                   return Accepted(false);                

                return Accepted(true);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
