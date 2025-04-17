using AngularApp3.Server.Models;
using AngularApp3.Server.DTO;
using Microsoft.AspNetCore.Mvc;



namespace AngularApp3.Server.IDataService
{
    public interface IDataServicee
    {

        public List<User> getAllusers();

        public bool AddnewUser(AddUserDTO user);

        public User getSingleUser (int id);

        public User getUserByname( string name);

        public bool deleteUser( int id );

        public bool UpdateUser(int id, [FromBody] AddUserDTO newUser);


        //----------------------------------------------------------------------------





        //------------------------------------------------------------------------------






    }
}
