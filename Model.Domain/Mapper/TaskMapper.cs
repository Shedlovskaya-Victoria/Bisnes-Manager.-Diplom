using BisnesManager.DatabasePersistens.Model;
using BisnesManager.ETL.DTO;
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
                AssignmentsContent = task.AssignmentsContent,
                Author = $"{task.IdUserNavigation.Name} {task.IdUserNavigation.Family} {task.IdUserNavigation.Patronymic}",
                StartDate = task.StartDate,
                Content = task.Content, 
                Status = task.IdStatusNavigation.Title,
                Indentation = task.Indentation,
                EndDate = task.EndDate, 
            };
        }
    }
}
