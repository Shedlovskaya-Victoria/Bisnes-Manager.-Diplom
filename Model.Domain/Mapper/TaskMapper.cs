using BisnesManager.Database.Models;
using BisnesManager.ETL.DTO;
using BisnesManager.ETL.request_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.Mapper
{
    public static class TaskMapper
    {
        public static BisnesTaskDTO ToTaskDTO(this BisnesTask task)
        {
            return new BisnesTaskDTO
            {
                Id = task.Id,
                AssignmentsContent = task.AssignmentsContent,
                Author = $"{task.IdUserNavigation.Name} {task.IdUserNavigation.Family} {task.IdUserNavigation.Patronymic}",
                StartDate = task.StartDate,
                Content = task.Content, 
                Status = task.IdStatusNavigation.Title,
                Indentation = task.Indentation,
                EndDate = task.EndDate, 
            };
        }
        public static BisnesTask ToTaskFromCreateDTO(this TaskDtoRequest dtoRequest)
        {
            return new BisnesTask
            {
            
                IdUser = dtoRequest.IdUser,
                Content = dtoRequest.Content,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                IdStatus = dtoRequest.IdStatus,
                Indentation = dtoRequest.Indentation,
                AssignmentsContent = dtoRequest.AssignmentsContent,
                EndDate = DateOnly.FromDateTime(dtoRequest.EndDate),
                StartDate = DateOnly.FromDateTime(dtoRequest.StartDate),  
            };
        }
    }
}
