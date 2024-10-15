using SampleApp.API.Entities;

namespace SampleApp.API.Interfaces;

public interface IUserRepository
{
    User CreateUser(User user);
    List<User> GetUsers();
    User FindUserById(Guid id);
    User EditUser (User user,Guid id);
    bool DeleteUser(Guid id);   

}
