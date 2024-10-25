using System.Data.SqlTypes;
using SampleApp.API.Data;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

namespace SampleApp.API.Repositories;
public class UserRepository : IUserRepository
{
    private readonly SampleAppContext _db;

    public HMACSHA512 hmac = new HMACSHA512();
    public UserRepository(SampleAppContext db)
    {
        _db = db;
    }
    public User CreateUser(User user)
    {
        try
        {
            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Password"));
            user.PasswordSalt = hmac.Key;
            _db.Users.Add(user);
            _db.SaveChanges();
            return user;
        }
        catch (SqlTypeException ex)
        {
            throw new SqlTypeException($"Ошибка SQL: {ex.Message}");
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка: {ex.Message}");
        }
    
    }

 public bool DeleteUser(int id)
 {
    try
    {
        _db.Users.Remove(FindUserById(id));
        _db.SaveChanges();
        return true;
    }
    catch (SqlTypeException ex)
    {
        throw new SqlTypeException($"Ошибка SQL: {ex.Message}");
    }
    catch (Exception ex)
    {
        throw new Exception($"Ошибка: {ex.Message}");
    }
 }


 /// <summary>
 /// Редактирование пользователя
 /// </summary>
 /// <param name="user"></param>
 /// <param name="id"></param>
 /// <returns></returns>
 public User EditUser(User user, int id)
 {
    _db.Entry(user).State = EntityState.Modified;
    _db.SaveChanges();
    return user;
 }

 public User FindUserById(int id)
 {
    try
    {
        return _db.Users.Find(id);
    }
    catch (SqlTypeException ex)
    {
        throw new SqlTypeException($"Ошибка SQL: {ex.Message}");
    }
    catch (Exception ex)
    {
        throw new Exception($"Ошибка: {ex.Message}");
    }
  
 }

 public IEnumerable<User> GetUsers()
 {
     return _db.Users.ToList();
 }
}
