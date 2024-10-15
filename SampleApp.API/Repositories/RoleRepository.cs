using Microsoft.Net.Http.Headers;
using SampleApp.API.Entities;
using SampleApp.API.Interfaces;

namespace SampleApp.API.Repositories;

public class RoleRepository : IRoleRepository
{
    public IList<Role> Roles { get; set; } = new List<Role>();
    public Role CreateRole(Role role)
    {
        role.Id = Guid.NewGuid();
        Roles.Add(role);
        return role;
    }

    public bool DeleteRole(Guid id)
    {
        var result = FindRoleById(id);
        if (result == null)
           throw new Exception("$Не удалось удалить роль");
        else
            Roles.Remove(result);
        return true;

    }

    /// <summary>
    /// Редактирование пользователя
    /// </summary>
    /// <param name="user"></param>
    /// <param name="id"></param>
    /// <returns></returns>
    public Role EditRole(Role role, Guid id)
    {
        var result = FindRoleById(id);
        result.Name = role.Name;
        return result;

    }

    public Role FindRoleById(Guid id)
    {
        var result = Roles.Where(x => x.Id == id).FirstOrDefault();
        if (result == null)
            throw new Exception("$Нет такой роли с id = {id}");
        return result;
    }

    public List<Role> GetRoles()
    {
        return(List<Role>)Roles;
    }
}
