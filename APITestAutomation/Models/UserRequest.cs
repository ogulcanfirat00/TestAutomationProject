using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITestAutomation.Models
{
    public class UserRequest
    {
        public string Name { get; set; }
        public string Job { get; set; }
    }

    public class UserResponse
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
