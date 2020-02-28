using CleanArch.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArch.Mvc.Repositories.Abstract
{
    public interface IRoleRepository
    {
        IEnumerable<Role> RoleList();
        Role GetRole(int RoleId);
        bool InsertRole(Role Role);
        Role DeleteRole(int RoleId);
        Role UpdateRole(int RoleId);
    }
}
