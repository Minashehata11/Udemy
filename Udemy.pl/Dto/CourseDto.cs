namespace Udemy.pl.Dto
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CustomDate { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TrainerId { get; set; }
        public string TrainerName { get; set; }
        public string Post { get; set; }
    }
}
