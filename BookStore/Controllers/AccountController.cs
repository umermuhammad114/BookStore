using BookStore.Authentication;
using BookStore.Data;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class AccountController(UserManager<ApplicationUser> usermanager,
    IJwtProvider jwtProvider,
    IUserRepository userRepository) : ControllerBase
{
    private readonly UserManager<ApplicationUser> usermanager = usermanager;
    private readonly IJwtProvider jwtProvider = jwtProvider;
    private readonly IUserRepository userRepository = userRepository;

    [HttpPost]
    public async Task<IActionResult> Login(LoginModel loginModel)
    {
        var user = await this.usermanager.FindByNameAsync(loginModel.Username);
        if (user == null)
            return Unauthorized();

        var isUserValid = await this.usermanager.CheckPasswordAsync(user, loginModel.Password);
        if (!isUserValid)
            return Unauthorized();

        var permissions = await this.userRepository.GetUserPermissions(user.UserName!);

        return Ok(this.jwtProvider.Generate(user, permissions));
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterModel model)
    {
        var user = new ApplicationUser
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Email = model.Email,
            UserName = model.Username
        };

        var createdUser = await this.usermanager.CreateAsync(user, model.Password);
        if (createdUser.Succeeded)
        {
            return Ok(createdUser.Succeeded);
        }

        return Unauthorized();
    }
}
