using AdminProSolutions.API.Controllers.Base;
using AdminProSolutions.API.Validations.Organization;
using AdminProSolutions.Domain.Dtos.Organization;
using AdminProSolutions.Domain.Entities.Organization;
using AdminProSolutions.Domain.Enums;
using AdminProSolutions.Domain.Interfaces.Base;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AdminProSolutions.API.Controllers
{
    //Autorized default
    //Default route "api/[controller]" 
    public class ClientsController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ClientsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Helpers.Authorize(PermissionItem.Clients, PermissionAction.Read)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var record = _unitOfWork.Clients.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Clients, PermissionAction.Read)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var record = _unitOfWork.Clients.GetById(id);
                if (record == null) return NotFound();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Clients, PermissionAction.Create)]
        [HttpPost]
        public IActionResult Post([FromBody] ClientDto payload)
        {
            try
            {
                var validator = new ClientValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var entity = _mapper.Map<Clients>(payload);

                entity.CreatedUser = GetNameClaim();
                entity.CreatedDate = DateTime.Now;

                _unitOfWork.Clients.Add(entity);

                return CreatedAtAction(nameof(Get), new { id = entity.ClientId }, entity);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Clients, PermissionAction.Update)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ClientDto payload)
        {
            try
            {

                payload.ClientId = id;

                var validator = new ClientValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var entity = _mapper.Map<Clients>(payload);

                entity.UpdatedUser = GetNameClaim();
                entity.UpdatedDate = DateTime.Now;

                _unitOfWork.Clients.Update(entity);

                return AcceptedAtAction(nameof(Get), new { id = entity.ClientId }, entity);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Clients, PermissionAction.Delete)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Clients record = new() { ClientId = id };

                _unitOfWork.Clients.Delete(record);

                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
