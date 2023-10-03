using AutoMapper;
using CustoMate.dtos;
using CustoMate.entity;
using CustoMate.services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CustoMate.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IServices<User> _services;
        private readonly IMapper _mapper;

        public UserController(IServices<User> services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CreateUser")]
        public async Task<ActionResult<ServicesRespons<UserResponsDto>>> CreateUserAsync(UserCreateDto userCreateDto)
        {

            var user = _mapper.Map<User>(userCreateDto);
            _services.CreateAsync(user);
            await _services.SaveChangesAsync();

            var respons = _mapper.Map<UserResponsDto>(user);

            var servicesRespons = new ServicesRespons<UserResponsDto>
            {
                Data = respons,
                IsSucess = true,
                Message = "Ok"
            };
            return CreatedAtRoute(nameof(GetUserByIdAsync), new { id = servicesRespons.Data.Id }, servicesRespons.Data);
        }

        [HttpGet("{id:int}",Name = "GetUserByIdAsync")]
        public async Task<ActionResult<ServicesRespons<UserResponsDto>>> GetUserByIdAsync(int id)
        {
            var user = await _services.GetItemByIdAsync(id);

            var respons = _mapper.Map<UserResponsDto>(user);

            var servicesRespons = new ServicesRespons<UserResponsDto>
            {
                Data = respons,
                IsSucess = true,
                Message = "OK"

            };
             return Ok(servicesRespons);
        }
    }
}
