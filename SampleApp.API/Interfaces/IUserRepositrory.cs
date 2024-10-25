using SampleApp.API.Entities;

namespace SampleApp.API.Interfaces;

public interface IUserRepository
{
    User CreateUser(User user);
    IEnumerable<User> GetUsers();
    User FindUserById(int id);
    
    User FindUserByLogin(string userLogin);
    User EditUser (User user,int id);
    bool DeleteUser(int id);   

    bool DeleteAllUsers();   
}
