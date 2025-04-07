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
    public static class TaskMapper
    {
        public static BisnesTaskDTO ToTaskDTO(this BisnesTask task)
        {
            return new BisnesTaskDTO
            {
                Id = task.Id,
                UserId = task.IdUser,
                AssignmentsContent = task.AssignmentsContent,
                Author = $"{task.IdUserNavigation.Name} {task.IdUserNavigation.Family} {task.IdUserNavigation.Patronymic}",
                StartDate = DateTime.Parse(task.StartDate.ToString()),
                Content = task.Content, 
                IdStatus = task.IdStatus,
                Indentation = task.Indentation,
                EndDate = DateTime.Parse(task.EndDate.ToString()), 
            };
        }
        public static BisnesTask ToTaskFromCreateDTO(this TaskDtoRequest dtoRequest)
        {
            return new BisnesTask
            {
            
                IdUser = (short)dtoRequest.IdUser,
                Content = dtoRequest.Content,
                DateCreate = DateOnly.FromDateTime(DateTime.UtcNow),
                IdStatus = dtoRequest.IdStatus,
                Indentation = dtoRequest.Indentation,
                AssignmentsContent = dtoRequest.AssignmentsContent,
                EndDate = DateOnly.FromDateTime(dtoRequest.EndDate),
                StartDate = DateOnly.FromDateTime(dtoRequest.StartDate),  
            };
        }
        public static TaskDtoRequest ToCreateDto(this BisnesTaskDTO dtoRequest)
        {
            return new TaskDtoRequest
            {
                Content = dtoRequest.Content,
                IdUser = dtoRequest.UserId,
                IdStatus = (short)dtoRequest.IdStatus,
                Indentation = dtoRequest.Indentation,
                AssignmentsContent = dtoRequest.AssignmentsContent,
                EndDate = dtoRequest.EndDate,
                StartDate = dtoRequest.StartDate,  
            };
        }
        public static UpdateTaskDto ToUpdateDTO(this BisnesTaskDTO dtoRequest)
        {
            return new UpdateTaskDto
            {
                Content = dtoRequest.Content, 
                IdUser = dtoRequest.UserId,
                DateCreate = DateTime.UtcNow,
                IdStatus = (short)dtoRequest.IdStatus,
                Indentation = dtoRequest.Indentation,
                AssignmentsContent = dtoRequest.AssignmentsContent,
                EndDate = dtoRequest.EndDate,
                StartDate = dtoRequest.StartDate,  
            };
        }
    }
}
