using BisnesManager.ETL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BisnesManager.ETL.request_DTO
{
    public class AuthDtoRequest
    {
        public string Token {  get; set; }
        public UserDTO User { get; set; }
    }
}
