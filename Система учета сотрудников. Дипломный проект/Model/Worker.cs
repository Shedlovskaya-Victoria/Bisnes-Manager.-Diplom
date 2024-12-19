using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.Client.Model
{
   public  class Worker
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Age { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public byte[] Photo { get; set; }
        public int IdRole { get; set; }
        public int IdDolzjnosts { get; set; }
        public string Dolzjnost { get; set; }
        public DateTime StartTimeWork { get; set; }
        public DateTime EndTimeWork { get; set; }
        [NotMapped]
        public string FIO { get; set; }
    }
}
