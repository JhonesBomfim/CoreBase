using System;
using System.Collections.Generic;
using CoreBase.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoreBase.Controllers
{
    [ApiController]
    [Route("YOUR_URL")]
    public class ManagerController : ControllerBase
    {
        [HttpPost("Insert")]
        public IActionResult Insert(Manager newManager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Services services = new Services();
            services.Insert(newManager);

            return Ok(ModelState);
        }

        [HttpPost("ListUser")]
        public IActionResult ListUser()
        {
            try
            {
                Services services = new Services();
                List<Manager> User = services.ListUsers();
                return Ok(User);
            }
            catch (Exception)
            {
                return StatusCode(500, "Failed to acess");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(Manager loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Services services = new Services();

            if (!string.IsNullOrEmpty(loginRequest.Username) && !string.IsNullOrEmpty(loginRequest.Password))
            {
                bool isAuthenticated = services.ValidateUsers(loginRequest.Username, loginRequest.Password);

                if (isAuthenticated)
                {
                    return Ok(new { message = "Sucess" });
                }
            }

            return Unauthorized();
        }

        [HttpGet("EditProfile/{id}")]
        public IActionResult EditProfile(int id)
        {
            Services services = new Services();
            Manager? user = services.FindForId(id);

            if (user == null)
                return NotFound();

            return Ok(user); // Retorna o usuário encontrado como JSON
        }

        [HttpPost("EditProfile")]
        public IActionResult EditProfile([FromBody] Manager manager)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Services services = new Services();
            services.EditProfile(manager); // Método void

            return Ok(new { message = "Profile updated successfully" });
        }
    }
}
