using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Udemy.Core.Entities.Identity;

namespace Udemy.Core.Entities
{
    public class CourseTrainee
    {
        public Course Course { get; set; }
        public int CourseId { get; set; }
        public trainee Trainee { get; set; }
        public int TraineeId { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Today;
    }
}
