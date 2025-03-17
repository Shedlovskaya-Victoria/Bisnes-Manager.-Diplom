using BisnesManager.Database.Model;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
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

            if (user.EndWorkTime != null)
                dto.EndWorkTime = DateTime.Parse(user.EndWorkTime.ToString());

            dto.Id = user.Id;
            dto.FIO = $"{user.Name} {user.Family} {user.Patronymic}";
            dto.Role = user.IdRoleNavigation.Title;
            dto.PhotoImage = user.PhotoImage;
            dto.StartWorkTime = DateTime.Parse(user.StartWorkTime.ToString());
            
            return dto;
        }
        public static User ToUserFromCreateDTO(this UserDtoRequest user)
        {
            return new User
            {
                Email = user.Email,
                CheckPhrase = user.CheckPhrase,
                EndWorkTime = DateOnly.FromDateTime(user.EndWorkTime),
                StartWorkTime= DateOnly.FromDateTime(user.StartWorkTime),
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                Login = user.Login,
                Password = user.Password,
                Patronymic = user.Patronymic,
                Family = user.Family,
                IdRole = user.IdRole,
                Name = user.Name,
                PhotoImage = user.PhotoImage,
                
            };
        }
    }
}
