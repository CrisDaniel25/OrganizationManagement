using AutoMapper;
using AdminProSolutions.API.Controllers.Base;
using AdminProSolutions.Domain.Interfaces.Base;
using AdminProSolutions.Domain.Model;
using Microsoft.AspNetCore.Mvc;
using AdminProSolutions.Domain.Dtos.Miscellaneous;
using Microsoft.Extensions.Options;

namespace AdminProSolutions.API.Controllers
{
    public class AuditsController : BaseController
    {
        private readonly AppSettings _appSettings;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AuditsController(IUnitOfWork unitOfWork, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Tracking, Domain.Enums.PermissionAction.Read)]
        [HttpGet]
        public IActionResult GetAll([FromQuery(Name = "keyValues")] string keyValues, [FromQuery(Name = "tableName")] string tableName)
        {
            try
            {
                var filterData = new AuditFilterDto();

                if (!string.IsNullOrEmpty(keyValues)) filterData.KeyValues = keyValues;

                if (!string.IsNullOrEmpty(tableName)) filterData.TableName = tableName;

                var res = _unitOfWork.Audit.GetAllByFilter(filterData);

                var resDto = _mapper.Map<List<AuditDto>>(res);

                return Ok(resDto);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [Helpers.Authorize(Domain.Enums.PermissionItem.Tracking, Domain.Enums.PermissionAction.Read)]
        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            try
            {
                var res = _unitOfWork.Audit.GetByGuid(new Guid(id));

                if (res == null) return NotFound(); 

                var resDto = _mapper.Map<AuditDto>(res);

                return Ok(resDto);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

        [HttpGet("[action]")]
        public IActionResult GetTables()
        {
            List<DropDownListDto> ddlRes;
            try
            {
                ddlRes = (from a in _unitOfWork.Audit.GetAll()
                          select new DropDownListDto
                          {
                              Value = a.TableName,
                              Description = a.TableName
                          }).Distinct().ToList();

                if (ddlRes.Count == 0) return NotFound();
                                
                return Ok(ddlRes);
            }
            catch (Exception ex)
            {
                return DefaultError(ex);
            }
        }

    }
}
