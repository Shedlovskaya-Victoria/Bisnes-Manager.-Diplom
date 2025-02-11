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
            return new UserDTO()
            {
                Id = user.Id,
                FIO = $"{user.Name} {user.Family} {user.Patronymic}",
                Role = user.IdRoleNavigation.Title,
                PhotoImage = user.PhotoImage,
                EndWorkTime = DateTime.Parse(user.EndWorkTime.ToString()),
                StartWorkTime = DateTime.Parse(user.StartWorkTime.ToString()),
            };
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
