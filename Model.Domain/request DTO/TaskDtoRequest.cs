using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.request_DTO
{
    public class TaskDtoRequest
    {
        public short IdUser { get; set; }

        public string Content { get; set; } = null!;

        public int? Indentation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? AssignmentsContent { get; set; }

        public short IdStatus { get; set; }
    }
}
