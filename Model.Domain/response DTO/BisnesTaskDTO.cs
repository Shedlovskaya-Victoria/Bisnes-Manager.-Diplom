using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.DTO
{
    public class BisnesTaskDTO
    {
        public int Id {  get; set; }
        
        public string? Author { get; set; }

        public string Content { get; set; } = null!;

        public int? Indentation { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string? AssignmentsContent { get; set; }

        public int? IdStatus { get; set; }

    }
}
