using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
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
        public static RoleDTO ToRoleDTO(this UserRole role)
        {
            return new RoleDTO {
                Id = role.Id,
                Title = role.Title,
                IsEditWorkersRoles = role.IsEditWorkersRoles,
                IsEditWorkTimeTable = role.IsEditWorkTimeTable,
                Post = role.Post,
                IsUse = role.IsUse,
            };
        }
        public static UserRole ToRoleFromCreateDTO(this RoleDtoRequest dtoRequest)
        {
            return new UserRole
            {
                IsEditWorkersRoles = dtoRequest.IsEditWorkersRoles,
                IsEditWorkTimeTable = dtoRequest.IsEditWorkTimeTable,
                Post = dtoRequest.Post,
                Title = dtoRequest.Title,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                IsUse = dtoRequest.IsUse,
            };
        }
        public static RoleDtoRequest ToRoleCreateFromUpdateDTO(this UpdateRoleDto dtoRequest)
        {
            return new RoleDtoRequest
            {
                IsEditWorkersRoles = dtoRequest.IsEditWorkersRoles,
                IsEditWorkTimeTable = dtoRequest.IsEditWorkTimeTable,
                Post = dtoRequest.Post,
                Title = dtoRequest.Title,
                IsUse = dtoRequest.IsUse,
            };
        }
        public static UpdateRoleDto ToRoleUpdate(this UserRole dtoRequest)
        {
            return new UpdateRoleDto
            {
                Id = dtoRequest.Id,
                IsEditWorkersRoles = dtoRequest.IsEditWorkersRoles,
                IsEditWorkTimeTable = dtoRequest.IsEditWorkTimeTable,
                Post = dtoRequest.Post,
                Title = dtoRequest.Title,
                IsUse = dtoRequest.IsUse,
            };
        }
    }
}
