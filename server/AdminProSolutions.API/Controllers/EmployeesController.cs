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
    public class EmployeesController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public EmployeesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Read)]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var record = _unitOfWork.Employees.GetAll();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Read)]
        [HttpGet("client/{clientId}")]
        public IActionResult GetEmployeesByClientId(int clientId)
        {
            try
            {
                var record = _unitOfWork.Employees.GetEmployeesByClientId(clientId);
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Read)]
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var record = _unitOfWork.Employees.GetById(id);
                if (record == null) return NotFound();
                return Ok(record);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Create)]
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeDto payload)
        {
            try
            {
                var validator = new EmployeeValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var entity = _mapper.Map<Employees>(payload);

                entity.CreatedUser = GetNameClaim();
                entity.CreatedDate = DateTime.Now;

                _unitOfWork.Employees.Add(entity);

                return CreatedAtAction(nameof(Get), new { id = entity.EmployeeId }, entity);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Update)]
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDto payload)
        {
            try
            {
                payload.EmployeeId = id;

                var validator = new EmployeeValidator();
                var validations = validator.Validate(payload);

                if (!validations.IsValid) return BadRequest(validations.Errors);

                var entity = _mapper.Map<Employees>(payload);

                entity.UpdatedUser = GetNameClaim();
                entity.UpdatedDate = DateTime.Now;

                _unitOfWork.Employees.Update(entity);

                return AcceptedAtAction(nameof(Get), new { id = entity.ClientId }, entity);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(PermissionItem.Employees, PermissionAction.Delete)]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Employees record = new() { EmployeeId = id };

                _unitOfWork.Employees.Delete(record);

                return NoContent();
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }
    }
}
