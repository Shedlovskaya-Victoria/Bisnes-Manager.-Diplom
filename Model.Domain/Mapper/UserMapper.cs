using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
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
                EndWorkTime = user.EndWorkTime,
                StartWorkTime = user.StartWorkTime,
            };
        }
    }
}
