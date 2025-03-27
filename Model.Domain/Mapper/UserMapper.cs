using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
using BisnesManager.ETL.update_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class UserMapper
    {
        public static UserDTO ToUserDTO(this User user)
        {
            var dto = new UserDTO();

            
            dto.Id = user.Id;
            dto.FIO = $"{user.Name} {user.Family} {user.Patronymic}";
            dto.Role = user.IdRoleNavigation.Title;
            dto.IdRole = user.IdRole;
            dto.WorkTimeCount = user.WorkTimeCount;
            
            return dto;
        }
        public static UpdateUserDto ToUpdateDto(this User user)
        {
            return new UpdateUserDto
            {
                Id = user.Id,
                IdRole = user.IdRole,
                CheckPhrase = user.CheckPhrase,
                Password = user.Password,
                WorkTimeCount = user.WorkTimeCount,
                Email = user.Email,
                Family = user.Family,
                Login = user.Login,
                Name = user.Name,
                Patronymic = user.Patronymic,
                TitleRole = user.IdRoleNavigation.Title,
            };
        }
       
        public static User ToUserFromCreateDTO(this UserDtoRequest user)
        {
            return new User
            {
                Email = user.Email,
                CheckPhrase = user.CheckPhrase,
                WorkTimeCount = user.WorkTimeCount,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                Login = user.Login,
                Password = user.Password,
                Patronymic = user.Patronymic,
                Family = user.Family,
                IdRole = user.IdRole,
                Name = user.Name,
                
            };
        }
    }
}
