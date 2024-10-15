using SampleApp.API.Entities;

namespace SampleApp.API.Interfaces;

public interface IRoleRepository
{
    Role CreateRole(Role role);
    Role EditRole(Role role,Guid id);
    bool DeleteRole(Guid Id);
    Role FindRoleById(Guid id);
    List<Role> GetRoles();
}
