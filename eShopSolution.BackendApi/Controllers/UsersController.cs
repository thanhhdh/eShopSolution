using eShopSolution.Application.System.Users;
using eShopSolution.ViewModels.Catalog.Products;
using eShopSolution.ViewModels.System.Users;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace eShopSolution.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService) 
        {
            _userService = userService;
        }
        [HttpPost("authenticate")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate([FromBody] LoginRequest request)
        {
            if(!ModelState.IsValid)  return BadRequest(ModelState); 
            var result = await _userService.Authenticate(request);
            if(string.IsNullOrEmpty(result.ResultObj))
            {
                return BadRequest(result);
            }
           
            return Ok(result);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _userService.Register(request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
           
            return Ok(result);
        }
        //https:/localhost/api/users/id
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UserUpdateRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }
            var result = await _userService.Update(id, request);
            if (!result.IsSuccessed)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        //https://localhost/api/users/paging?pageIndex=1&pageSize=10&keywork=
        [HttpGet("paging")]
        public async Task<IActionResult> GetUsersPaging([FromQuery]GetUserPagingRequest request)
        {

            var users = await _userService.GetUsersPaging(request);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var users = await _userService.GetById(id);
            return Ok(users);
        }
    }
}
