using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities.Identity
{
    public class trainee:BaseEntity
    {
        public bool IsActive { get; set; }
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
