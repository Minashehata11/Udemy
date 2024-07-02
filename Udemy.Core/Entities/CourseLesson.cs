using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.Core.Entities
{
    public class CourseLesson:BaseEntity
    {
        public string  Title { get; set; }
        public int OrderNumer { get; set; }
        public Course Course { get; set; }
        public int CourseId { get; set; }
    }
}
