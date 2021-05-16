namespace Exercise.Models
{
    public class Person

    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Schedule AvariableSchedule { get; set; }

        public Person()
        {
        }
    }
}