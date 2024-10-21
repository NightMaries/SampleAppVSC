using System.Data.SqlTypes;
using Microsoft.Net.Http.Headers;
using SampleApp.API.Data;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace SampleApp.API.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly SampleAppContext _db;

    public RoleRepository(SampleAppContext db)
    {
        _db = db;
    }
    public Role CreateRole(Role role)
    {
        try
        {
            _db.Roles.Add(role);
            _db.SaveChanges();
            return role;
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

    public bool DeleteRole(int id)
    {
        try
        {
            _db.Roles.Remove(FindRoleById(id));
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
    /// <param name="role"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Role EditRole(Role role, int id)
    {
        try
        {
            _db.Entry(role).State = EntityState.Modified;
            _db.SaveChanges();
            return(role);
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

    public Role FindRoleById(int id)
    {
        try
        {
            return _db.Roles.Find(id);
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

    public IEnumerable<Role> GetRoles()
    {
        return _db.Roles.ToList();
    }
}
