using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class RoleMapper
    {
        public static RoleDTO ToRoleDTO(this Role role)
        {
            return new RoleDTO {
                Title = role.Title,
                IsEditWorkersRoles = role.IsEditWorkersRoles,
                IsEditWorkTimeTable = role.IsEditWorkTimeTable,
                Post = role.Post,
            };
        }
    }
}
