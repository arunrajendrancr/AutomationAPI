using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationAPI.Models
{
    public class UpdateUserModel
    {
        public string? name { get; set; }
        public string? job { get; set; }
        public DateTime updatedAt { get; set; }
    }
}
