using AngularApp3.Server.Models;
using AngularApp3.Server.IDataService;
using AngularApp3.Server.DTO;
using Microsoft.AspNetCore.Mvc;

namespace AngularApp3.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly  IDataServicee _data ;
        public UserController(IDataServicee data)
        {
            _data = data;
        }
        [HttpGet("getAllUsers")]
        public IActionResult getAllUsers()
        {
            var allUsers = _data.getAllusers();
            return Ok(allUsers); // 200
        }



        [HttpGet("GetUserByID/{id}")]
        public IActionResult GetUserByID(int id)
        {
            if (id == null) return BadRequest();
            else
            {
                var user = _data.getSingleUser(id);
                return Ok(user);
            }
        }



        [HttpGet("GetUserByName/{name}")]
        public IActionResult GetUserByName(string name)
        {
            if (name == null) return BadRequest();
            else
            {
                var user = _data.getUserByname(name);
                return Ok(user);
            }
        }




        [HttpPost]
        public IActionResult AddNewUser([FromForm] AddUserDTO newUser ) {

            if (newUser.Name == null) return BadRequest(); // 400
            else
            {
                var Added = _data.AddnewUser(newUser);
                if(Added == false ) return BadRequest();
                else return Ok();
            }
        
        }



        [HttpDelete("delete/{id}")]
        public IActionResult DeleteUser(int id  )
        {
            if(id == null) return BadRequest();
            else
            {
                var user = _data.deleteUser(id);
                if (user == false) return BadRequest();
                //if (!user) return BadRequest();
                else  return Ok();
            }

        }


        [HttpPut("updateUser/{id}")]
        public IActionResult UpdateUser(int id , [FromBody] AddUserDTO newUser)
        {
            var user = _data.UpdateUser(id,  newUser);
            if (user == false) return BadRequest();
            else return Ok();
        }
    }
}
