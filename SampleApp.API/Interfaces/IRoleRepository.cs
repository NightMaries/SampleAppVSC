using SampleApp.API.Entities;

namespace SampleApp.API.Interfaces;

public interface IRoleRepository
{
    Role CreateRole(Role role);
    Role EditRole(Role role,int id);
    bool DeleteRole(int Id);
    Role FindRoleById(int id);
    IEnumerable<Role> GetRoles();
}
