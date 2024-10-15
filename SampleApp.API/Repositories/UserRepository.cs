using SampleApp.API.Entities;
using SampleApp.API.Interfaces;

namespace SampleApp.API.Repositories;
public class UserRepository : IUserRepository
{
     public IList<User> Users { get; set; } = new List<User>();

 public User CreateUser(User user)
 {
    user.Id = Guid.NewGuid();
    Users.Add(user);
    return user;
 }

 public bool DeleteUser(Guid id)
 {
    var result = FindUserById(id);
    if (result == null)
        throw new Exception("Не удалось удалить пользователя");
    else
        Users.Remove(result);

     return true;
 }


 /// <summary>
 /// Редактирование пользователя
 /// </summary>
 /// <param name="user"></param>
 /// <param name="id"></param>
 /// <returns></returns>
 public User EditUser(User user, Guid id)
 {
     var result = FindUserById(id);
     //update
     result.Name = user.Name;
     return result;
 }

 public User FindUserById(Guid id)
 {
     var result = Users.Where(x => x.Id == id).FirstOrDefault();
     if (result == null)
        throw new Exception("$Нет такого пользователся с id = {id}");
     
     return result;
  
 }

 public List<User> GetUsers()
 {
     return (List<User>)Users;
 }
}
